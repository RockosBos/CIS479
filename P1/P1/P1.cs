/*-------------------------------------------------
    Developed By Nicholas Kessey
    Project Start: 01/27/2021
    Project Completion:
    Class: CIS 479
    Professor: Dr. Shengquan Wang
-------------------------------------------------*/
using System;
using System.Collections.Generic;

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

            For this Project the number 0 will represent the empty square
        */
        static void Main(string[] args)
        {
            int[] initialConfiguration = { 2, 8, 3, 6, 7, 4, 1, 5, 0 };
            //int[] testConfiguration = { 5, 2, 3, 8, 0, 4, 7, 6, 1 };

            State initialState = new State(initialConfiguration);

            Table table = new Table(initialState);

            

            List<State> solution = table.mainAlgorithm();
            for(int i = 0; i < solution.Count; i++)
            {
                printState(solution[i]);
            }

        }

        static void printState(State state)
        {
            int[] pos = state.getPositions();
            Console.WriteLine("{0} | {1} | {2}", pos[0], pos[1], pos[2]);
            Console.WriteLine("---------");
            Console.WriteLine("{0} | {1} | {2}", pos[3], pos[4], pos[5]);
            Console.WriteLine("---------");
            Console.WriteLine("{0} | {1} | {2}", pos[6], pos[7], pos[8]);
            Console.WriteLine("{0} | {1}", state.stateDepth, state.manhattanDistance);
            Console.WriteLine();
        }
    }
}
