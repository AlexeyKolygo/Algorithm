using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static CardGame.CardsTypes;

namespace CardGame
{
    public class Games
    {
        public IDeck Deckmethods;

    }

    public class BlackJack : Games
    {
        public int Count { get; set; }
        public int Score { get; set; }
        private int Win { get; set; }
        private int Lose { get; set; }



        public List<Card> NewInstance(IDeck deck)
        {
            Deckmethods = deck;
            var currentDeck = Deckmethods.GenerateDeck();
            
            return currentDeck;
        }

        public void PrintResults(int counter)
        {
            Console.WriteLine($"There was {counter} tries. WIN:{Win}, FAIL:{Lose}");
        }

        private void PrintInstanceResults(int counter, Stopwatch time,string turnScore)
        {
            Console.WriteLine($"Your final score = {counter}, {turnScore}, elapsed time: {time.ElapsedMilliseconds} ms");
        }

        private void PrintTurnResult(CardsTypes card,int result)
        {
            Console.Write($"{card}, {result}, ");
        }
        public void Instance(List<Card> currentDeck)
        {
            int i;
            Count = 3;
            var used = new List<Card>();
            var test = new Stopwatch();
            test.Start();
            
            do
            {
              i= Turn(currentDeck, used);
              Count--;
            }
            
            while (Count!= 0);
            test.Stop();
            string turnScore = CheckScore(i);
            //PrintInstanceResults(i, test, turnScore);
            Deckmethods.ReturnCardToDeck(used, currentDeck);
            used.Clear();
            Score = 0;
        }

        private string CheckScore(int i)
        {
            string result;
            if (i == 21)
            {
                result = "WIN";
                Win = Win + 1;
            }
            else
            {
                result = "LOST";
                Lose = Lose + 1;
            }
            return result;
        }

        public int Turn(List<Card> currentDeck, List<Card> used)
        {
            var card = Deckmethods.PickCardFromDeck(currentDeck);
            var cardCardType = card.CardType;
            int result = CalculateResult(cardCardType);
            //PrintTurnResult(card.CardType, result);
            used.Add(card);
            Deckmethods.RemoveCardFromDeck(currentDeck, card);
            Score += result;
            return Score;
        }


        private static int CalculateResult(CardsTypes type)
        {
            int result = 0;
            switch (type)
            {
                case Six:
                    result = 6; break;
                case Seven:
                    result = 7; break;
                case Eight:
                    result = 8; break;
                case Nine:
                    result = 9; break;
                case Ten:
                    result = 10; break;
                case Jack:
                    result = 2; break;
                case Queen:
                    result = 3; break;
                case King:
                    result = 4; break;
                case Ace:
                    result = 11; break;

            }

            return result;
        }

    }
}
