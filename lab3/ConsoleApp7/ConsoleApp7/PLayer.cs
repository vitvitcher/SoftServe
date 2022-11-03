using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    class PLayer
    {
        private List<Card> CardsInHand = new List<Card>();
        public string Name { get; }
        public bool Won { set; get;  }
        public PLayer(string name)
        {
            Name = name;
            Won = false;
        }
        public void ToHand(Card card)
        {
            CardsInHand.Add(card);
        }
        public int GetHandSize()
        {
            return CardsInHand.Count;
        }
        public Card PlayCard(int i)
        {
            Card PlayCard = CardsInHand[i];
            CardsInHand.RemoveAt(i);
            return PlayCard;
        }
        public void ShowHand()
        {
            Console.WriteLine(string.Concat(Enumerable.Repeat("_____\t", GetHandSize())));
            foreach (var card in CardsInHand)
            {
                Console.Write($"|{card.Value}{card.Suit}".PadRight(4)+"|\t");
            }
            Console.WriteLine();
            Console.WriteLine(string.Concat(Enumerable.Repeat("|___|\t", GetHandSize())));
        }
        public int CheckSimilar(Card Acard, string Trump)
        {
            for (int i = 0; i < CardsInHand.Count; i++)
            {
                if (CardsInHand[i].Nvalue == Acard.Nvalue)
                {
                    if (CardsInHand[i].Suit != Trump)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }
        public int GetLowestCard(string Trump)
        {
            int Acard = -1;
            int Tcard = -1;
            for (int i=0; i<CardsInHand.Count;i++)
            {
                if (CardsInHand[i].Suit != Trump)
                {
                    if (Acard != -1)
                    {
                        if (CardsInHand[i].Nvalue < CardsInHand[Acard].Nvalue)
                        {
                            Acard = i;
                        }
                    }
                    else
                    {
                        Acard = i;
                    }
                }
                else
                {
                    if (Tcard != -1)
                    {
                        if (CardsInHand[i].Nvalue < CardsInHand[Tcard].Nvalue)
                        {
                            Tcard = i;
                        }
                    }
                    else
                    {
                        Tcard = i;
                    }
                }
            }
            if (Acard != -1)
            {
                return Acard;
            }
            else
            {
                return Tcard;
            }
        }
        public int CompareCards(Card Acard,string Trump)
        {
            int Bcard = -1;
            for (int i = 0; i < CardsInHand.Count; i++)
            {
                    if (CardsInHand[i].Suit == Acard.Suit)
                    {
                        if (CardsInHand[i].Nvalue > Acard.Nvalue)
                            if (Bcard != -1)
                            {
                                if (CardsInHand[i].Nvalue < CardsInHand[Bcard].Nvalue)
                                {
                                    Bcard = i;
                                }
                            }
                            else
                            {
                                Bcard = i;
                            }
                    }
            }
            if (Bcard == -1)
            {
                if (Acard.Suit != Trump)
                {
                    for (int i = 0; i < CardsInHand.Count; i++)
                    {
                        if (CardsInHand[i].Suit == Trump)
                        {
                            if (Bcard != -1)
                            {
                                if (CardsInHand[i].Nvalue < CardsInHand[Bcard].Nvalue)
                                {
                                    Bcard = i;
                                }
                            }
                            else
                            {
                                Bcard = i;
                            }
                        }
                    }
                }
            }
                return Bcard;
        }
    }
}
