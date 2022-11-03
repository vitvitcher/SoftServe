using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{

    class Game
    {

        public void Start(int playerCount, int CardsCount)
        {
            Deck deck = new Deck(CardsCount);
            Stack<Card> CardsOnField = new Stack<Card>();
            Stack<Card> BeatenCards = new Stack<Card>();
            PLayer[] Players = new PLayer[playerCount];
            for (int i = 0; i < playerCount; i++)
            {
                Players[i] = new PLayer($"Player {i + 1}");
            }
            int turnPlayer = 0;
            int nextPlayer;
            int wonCount = 0;
            int turn = 0;
            Console.WriteLine($"Козир: {deck.TrumpSuit}");
            while (true)
            {
                turn++;
                Console.WriteLine($"\nTurn {turn}");
                foreach (var player in Players)
                {
                    if (player.Won)
                    {
                        continue;
                    }
                    while (!deck.IsEmpty())
                    {
                        if (player.GetHandSize() < 6)
                            player.ToHand(deck.DrawACard());
                        else
                            break;
                    }
                    if (player.GetHandSize() == 0)
                    {
                        player.Won = true;
                        wonCount++;
                    }
                    else
                    {
                        Console.WriteLine($"{player.Name}'s hand is:");
                        player.ShowHand();
                    }
                }
                if (wonCount >= playerCount - 1)
                {
                    Console.WriteLine("Players who won:");
                    foreach (var player in Players)
                    {
                        if (player.Won)
                            Console.WriteLine(player.Name);
                    }
                    break;
                }
                while (Players[turnPlayer].Won)
                {
                    turnPlayer =AddNum(turnPlayer, playerCount);
                }
                nextPlayer = AddNum(turnPlayer, playerCount);
                while (Players[nextPlayer].Won)
                {
                    nextPlayer = AddNum(nextPlayer, playerCount);
                }
                Card CardToPlay = Players[turnPlayer].PlayCard(Players[turnPlayer].GetLowestCard(deck.TrumpSuit));
                CardsOnField.Push(CardToPlay);
                while (true)
                {
                    int similar = Players[turnPlayer].CheckSimilar(CardToPlay, deck.TrumpSuit);
                    if (similar != -1)
                    {
                        CardsOnField.Push(Players[turnPlayer].PlayCard(similar));
                    }
                    else
                    {
                        break;
                    }
                }
                while (CardsOnField.Count + BeatenCards.Count < 12)
                {
                    
                    Console.Write($"Player {turnPlayer+1} played cards:");
                    foreach (var card in CardsOnField)
                    {
                        Console.Write($" {card.Value} {card.Suit}\t");
                    }
                    Console.WriteLine();
                    while (CardsOnField.Count != 0)
                    {
                        int BeatCard = Players[nextPlayer].CompareCards(CardsOnField.Peek(), deck.TrumpSuit);
                        if (BeatCard != -1)
                        {
                            BeatenCards.Push(CardsOnField.Pop());
                            BeatenCards.Push(Players[nextPlayer].PlayCard(BeatCard));
                        }
                        else
                        {
                            Console.WriteLine($"Player {nextPlayer+1} take");
                            break;
                        }
                    }
                    foreach (var card in BeatenCards)
                    {
                        Console.WriteLine($"{card.Value} {card.Suit}");
                    }
                    if (CardsOnField.Count > 0)
                    {
                        foreach (var card in CardsOnField)
                        {
                            Players[nextPlayer].ToHand(card);
                        }
                        CardsOnField.Clear();
                        foreach (var card in BeatenCards)
                        {
                            Players[nextPlayer].ToHand(card);
                        }
                        BeatenCards.Clear();
                        break;
                    }
                    int i = 0;
                    while (i < BeatenCards.Count)
                    {
                        if (CardsOnField.Count + BeatenCards.Count < 11)
                        {
                            int addCard = Players[turnPlayer].CheckSimilar(BeatenCards.ElementAt(i), deck.TrumpSuit);
                            if (addCard != -1)
                            {
                                CardsOnField.Push(Players[turnPlayer].PlayCard(addCard));
                                continue;
                            }
                        }
                        i++;
                    }
                    if (CardsOnField.Count == 0)
                    {
                        turnPlayer = nextPlayer;
                        BeatenCards.Clear();
                        break;
                    }
                }

            }
            Console.WriteLine("\nWanna play another game?");
        }
        static int AddNum(int num, int count)
        {
            num++;
            if (num >= count)
                num = 0;
            return num;
        }
    }
    
}
