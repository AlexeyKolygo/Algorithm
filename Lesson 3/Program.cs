using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using static System.Console;

namespace CardGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Test(5);
            Console.ReadLine();
        }

        static void Start()
        {
            var game = new BlackJack();
            var deck = new Deck36();
            var bj = game.NewInstance(deck);
            int i;
            for (i = 0; i < 10000; i++) game.Instance(bj);
            game.PrintResults(i);
            
        }

        static void Test(int i)
        {
            var test = new Tests();
            test.Test(Start, i);
        }


    }

     
}
