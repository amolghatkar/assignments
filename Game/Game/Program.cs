using System;

namespace Game
{
    internal class Program
    {

        /// <summary>
        /// When program will run, this is first place to come break point.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            string SPerson = "CORNERSTONE";
            int[] KPerson = { 3, 0, 1, 5, 2, 4, 9, 7, 8, 6, 10 };
            string finalOutPut = Logic(SPerson, KPerson);
            Console.WriteLine(finalOutPut);
            Console.ReadLine();

            //Out Put : CNRERO
        }

        /// <summary>
        /// SPerson : Its entired string "CORNERSTONE"
        /// KPerson : Its array of mentioned string "{ 3, 0, 1, 5, 2, 4, 9, 7, 8, 6, 10 }"
        /// Write a function: def solution(S, A) that given a string S and an array of
        /// integers A, both of length N, returns a string denoting the final message received by the Oth person
        /// </summary>
        /// <param name="SPerson"></param>
        /// <param name="KPerson"></param>
        /// <returns>It will return the string as output</returns>
        static string Logic(string SPerson, int[] KPerson)
        {
            // S stand for SPerson, A Stand for KPerson & K Stand for currentPerson of KPerson.
            //At the beginning the oth person sends a message, consisting of a single letter S[0]
            string finalResult = SPerson[0].ToString();

            int currentPerson = KPerson[0];
            //The game ends when the oth person receives the message. Find the final message.
            while (currentPerson != 0)
            {
                //When the K-th person receives the message,
                //they append their letter S[K] to the message and forward it to A[K].
                finalResult = finalResult + SPerson[currentPerson];
                currentPerson = KPerson[currentPerson];
            }

            return finalResult;
        }
    }
}
