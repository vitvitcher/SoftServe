using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    class Deck
    {
        //readonly string[] CardValues = { "Двiйка", "Трiйка", "Четвiрка", "П'ятiрка", "Шестiрка", "Сiмка", "Вiсiмка", "Дев'ятка", "Десятка", "Валет", "Дама", "Король", "Туз" };
        //readonly string[] CardSuits = { "Чирви", "Бубни", "Хрести", "Пiки" };
        readonly string[] CardValues = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        readonly string[] CardSuits = { "♥", "♦", "♣", "♠" };
        private List<Card> CardsInDeck = new List<Card>();
        public string TrumpSuit;
        int DeckSize;
        public Deck (int size)
        {
            //normalizes the deck size
            DeckSize= size - size % 4;
            if (DeckSize > 52)
            {
                DeckSize = 52;
            }
            MakeADeck();
            
        }
        public bool IsEmpty()
        {
            return CardsInDeck.Count==0;
        }
        public Card DrawACard()
        {
            Card Card = CardsInDeck[0];
            CardsInDeck.RemoveAt(0);
            return Card;
        }
        public void MakeADeck()
        {
            for (int i = 0; i < DeckSize / 4; i++)
            {
                //for each suit
                for (int j = 0; j < 4; j++)
                {
                    //add a card to the deck of the value from the top
                    CardsInDeck.Add(new Card(CardValues[12 - i], CardSuits[j],12-i));
                }
            }
            //shuffle the deck
            Random rnd = new Random();
            CardsInDeck = CardsInDeck.OrderBy(x => rnd.Next()).ToList();
            //get the trump suit from the last card in the deck
            TrumpSuit = CardsInDeck.Last().Suit;
        }
        public void ShowDeck()
        {
            for (int i = 0; i < CardsInDeck.Count; i++)
            {
                Console.WriteLine(CardsInDeck[i].Value + " " + CardsInDeck[i].Suit);
            }
            //foreach (var card in CardsInDeck)
            //{
            //    Console.WriteLine(card.Value + " "+ card.Suit);
            //}
        }
        public Card GetCard()
        {
            Card Card = CardsInDeck[0];
            CardsInDeck.RemoveAt(0);
            return Card;
        }
    }
}
