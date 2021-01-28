/*-------------------------------------------------
    Developed By Nicholas Kessey
    Project Start: 01/27/2021
    Project Completion:
    Class: CIS 479
    Professor: Dr. Shengquan Wang
-------------------------------------------------*/
using System;

namespace P1
{
    class P1
    {
        /*
            This project solves the Windy 8-Puzzle Problem by returning actions that will result in the puzzles completion

            -------------                 ------------- 
            | 2 | 8 | 3 |                 | 1 | 2 | 3 |
            -------------                 -------------
            | 6 | 7 | 4 |     ------->    | 8 | - | 4 |     
            -------------                 -------------
            | 1 | 5 | - |                 | 7 | 6 | 5 |
            -------------                 -------------
        */
        static void Main(string[] args)
        {
            int[] initialConfiguration = { 2, 8, 3, 6, 7, 4, 1, 5, 0 };
            State initialState = new State(initialConfiguration);

            printState(initialState.getPositions());
        }

        static void printState(int[] state)
        {
            Console.WriteLine("{0} | {1} | {2}", state[0], state[1], state[2]);
            Console.WriteLine("---------");
            Console.WriteLine("{0} | {1} | {2}", state[3], state[4], state[5]);
            Console.WriteLine("---------");
            Console.WriteLine("{0} | {1} | {2}", state[6], state[7], state[8]);
            Console.WriteLine();
        }
    }
}
