using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    class Card
    {
        public string Value { get; }
        public string Suit { get; }
        public int Nvalue { get; }
        public Card(string value, string suit, int nvalue)
        {
            Value = value;
            Suit = suit;
            Nvalue = nvalue;
        }
        public string ShowCard()
        {
            return Value +" "+ Suit;
        }
    }
}
