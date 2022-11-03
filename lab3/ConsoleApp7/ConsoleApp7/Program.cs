using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    class Program
    {
        //static int AddNum(int num, int count)
        //{
        //    num++;
        //    if (num >= count)
        //        num = 0;
        //    return num;
        //}
        //static void StartGame(int playerCount, int CardsCount)
        //{
        //    Deck deck = new Deck(CardsCount);
        //    Stack<Card> CardsOnField = new Stack<Card>();
        //    Stack<Card> BeatenCards = new Stack<Card>();
        //    PLayer[] Players = new PLayer[playerCount];
        //    for (int i = 0; i < playerCount; i++)
        //    {
        //        Players[i] = new PLayer($"Player {i+1}");
        //    }
        //    int turnPlayer =0;
        //    int nextPlayer;
        //    int wonCount=0;
        //    int turn = 0;
        //    Console.WriteLine($"Козир: {deck.TrumpSuit}");
        //    while (true)
        //    {
        //        turn++;
        //        Console.WriteLine($"\nTurn {turn}");
        //        foreach (var player in Players)
        //        {
        //            if (player.Won)
        //            {
        //                continue;
        //            }
        //            while (!deck.IsEmpty())
        //            {
        //                if (player.GetHandSize() < 6)
        //                    player.ToHand(deck.DrawACard());
        //                else
        //                    break;
        //            }
        //            if (player.GetHandSize()==0)
        //            {
        //                player.Won = true;
        //                wonCount++;
        //            }
        //            else
        //            {
        //                Console.WriteLine($"{player.Name}'s hand is:");
        //                player.ShowHand();
        //            }
        //        }
        //        if (wonCount >= playerCount - 1)
        //        {
        //            Console.WriteLine("Players who won:");
        //            foreach(var player in Players)
        //            {
        //                if (player.Won)
        //                    Console.WriteLine(player.Name);
        //            }
        //            break;
        //        }
        //        while (Players[turnPlayer].Won)
        //        {
        //            AddNum(turnPlayer, playerCount);
        //        }
        //        nextPlayer = AddNum(turnPlayer, playerCount);
        //        while (Players[nextPlayer].Won)
        //        {
        //            AddNum(nextPlayer, playerCount);
        //        }
        //        while (CardsOnField.Count + BeatenCards.Count <= 12)
        //        {
        //            CardsOnField.Push(Players[turnPlayer].PlayCard(Players[turnPlayer].GetLowestCard(deck.TrumpSuit)));
        //            Console.Write("Played cards:");
        //            foreach (var card in CardsOnField)
        //            {
        //                Console.Write($" {card.Value} {card.Suit}\t");
        //            }
        //            Console.WriteLine();
        //            while(CardsOnField.Count!=0)
        //            {
        //                int Cardtoplay = Players[nextPlayer].CompareCards(CardsOnField.Peek(), deck.TrumpSuit);
        //                if (Cardtoplay != -1)
        //                {
        //                    BeatenCards.Push(CardsOnField.Pop());
        //                    BeatenCards.Push(Players[nextPlayer].PlayCard(Cardtoplay));
        //                    foreach (var card in BeatenCards)
        //                    {
        //                        Console.WriteLine($"{card.Value} {card.Suit}");
        //                    }
        //                }
        //                else
        //                {
        //                    Console.WriteLine("Take");
        //                    break;
        //                }
        //            }
        //            if (CardsOnField.Count > 0)
        //            {
        //                foreach (var card in CardsOnField)
        //                {
        //                    Players[nextPlayer].ToHand(card);
        //                }
        //                CardsOnField.Clear();
        //                foreach (var card in BeatenCards)
        //                {
        //                    Players[nextPlayer].ToHand(card);
        //                }
        //                BeatenCards.Clear();
        //                break;
        //            }
        //            turnPlayer = nextPlayer;
        //            BeatenCards.Clear();
        //            break;
        //        }

        //    }
        //    Console.WriteLine("\nWanna play another game?");
        //}
        static void Main(string[] args)
        {
           
            //deck.ShowDeck();
            //Console.WriteLine("trump card is:"+deck.TrumpSuit);
            Console.WriteLine();
            Console.WriteLine("Wanna play cards?");
            while (true)
            {
                Console.WriteLine("1. Start game\n" +
                                  "2.Exit game");
                switch (Console.ReadLine())
                {
                    case "1":
                        Game game = new Game();
                        Console.WriteLine("Write the number of players and the deck size:");
                        game.Start(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
                        break;
                    case "2":
                        return;
                }
            }
        }
    }
}
