using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{


    public interface IDeck
    {
        public List<Card> GenerateDeck();
        public void PrintDeck(List<Card> Deck)
        {
            for (int i = 0; i < Deck.Count; i++)
                Console.WriteLine($"Card {i + 1}: {Deck.ElementAt(i).CardType} of {Deck.ElementAt(i).Suit} ");

        }

        public void RemoveRandomCardFromDeck(List<Card> Deck)
        {
            var r = new Random().Next(0,Deck.Count);
            Deck.RemoveAt(r);
        }

        public void RemoveCardFromDeck(List<Card> Deck,Card card)
        {
            try
            {
                Card rem = Deck.Single(r => r.CardType == card.CardType && r.Suit == card.Suit);
                Deck.Remove(rem);
            }
            catch
            {
                Console.WriteLine("No such card in this deck");
            }
            
        }

        public void ReturnCardToDeck(List<Card> Cards, List<Card> Deck)
        {
            int i;
            for (i = 0; i < Cards.Count; i++)
            {
                Deck.Add(Cards[i]);
            }
        }

        public Card PickCardFromDeck(List<Card> Deck)
        {
            var card = new Card();
            var r = new Random().Next(Deck.Count);
            card = Deck[r];
            return card;
        }
 
    }

    class Deck52 : IDeck
    {

        public List<Card> GenerateDeck()
        {
            var deckList = new List<Card>();
            foreach(var card in (CardsTypes[])Enum.GetValues(typeof(CardsTypes)))
            {
                for (var index = 0; index < ((Suits[]) Enum.GetValues(typeof(Suits))).Length; index++)
                {
                    Suits suit = ((Suits[]) Enum.GetValues(typeof(Suits)))[index];
                    var Card = new Card {CardType = (CardsTypes) card, Suit = suit};
                    deckList.Add(Card);
                }
            }
            return deckList;
        }

    }

    class Deck36 : IDeck
    {
        public List<Card> GenerateDeck()
        {
            var DeckList = new List<Card>();
            foreach (var card in (CardsTypes[])Enum.GetValues(typeof(CardsTypes)))
            {
                if(card >= (CardsTypes)6) 
                {
                    for (var index = 0; index < ((Suits[])Enum.GetValues(typeof(Suits))).Length; index++)
                    {
                        Suits suit = ((Suits[])Enum.GetValues(typeof(Suits)))[index];
                        var Card = new Card { CardType = (CardsTypes)card, Suit = suit };
                        DeckList.Add(Card);
                    }
                }
            }
            return DeckList;
        }
        
    }


    public class TestDeck : IDeck
    {
        public List<Card> GenerateDeck()
        {
            var Decklist = new List<Card>();
            for (int i = 6; i <= 10; i++)
            {
                var card = new Card { CardType = (CardsTypes)i, Suit = Suits.Clubs };
                Decklist.Add(card);
            }

            return Decklist;
        }
    }


}
