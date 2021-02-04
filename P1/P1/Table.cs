using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace P1
{
    class Table
    {
        private State initialState;
        private State goalState;
        private List<exploredRow> exploredTable = new List<exploredRow>(new exploredRow[100]);
        private List<State> frontier = new List<State>();
        private List<State> solutionStateList;
        private StateManager stateManager;

        public class exploredRow
        {
            

            public List<State> stateList = new List<State>();

      
        }

        public Table(State state)
        {
            this.initialState = state;
            this.stateManager = new StateManager();
            for(int i = 0; i < exploredTable.Count; i++)
            {
                exploredTable[i] = new exploredRow();
            }

        }
        public List<State> mainAlgorithm()
        {
            bool solutionFound = false;
            State[] newStates = { };
            insertIntoFrontier(initialState);
            
            
            while (!solutionFound)
            {
                
                if(frontier[0].manhattanDistance == 0)
                {
                    frontier[0].path.Add(frontier[0]);
                    solutionStateList = frontier[0].path;
                    solutionFound = true;
                    break;
                }
                newStates = stateManager.generateNewStates(frontier[0]);
                
                insertIntoExploredSet(frontier[0]);
                newStates = removeExploredFromFrontier(newStates);
                //printExploredSet();

                frontier.RemoveAt(0);
                for (int i = 0; i < frontier.Count - 1; i++)
                {
                    frontier[i] = frontier[i + 1];
                }


                for (int i = 0; i < newStates.Length; i++)
                {
                    
                    insertIntoFrontier(newStates[i]);
                   
                }
                //printFrontier();

            }

            return solutionStateList;
        }


        public void insertIntoFrontier(State newState)
        {
            if (frontier.Count > 0 && newState.manhattanDistance < frontier[frontier.Count - 1].manhattanDistance)
            {

                for (int i = 0; i < frontier.Count; i++)
                {
                    if (frontier[i].manhattanDistance > newState.manhattanDistance)
                    {
                        frontier.Insert(i, newState);
                        break;
                    }
                }
               
            }
            
            else
            {
                frontier.Add(newState);
            }
        }

        public void printFrontier()
        {
            for(int i = 0; i < frontier.Count; i++)
            {
                Console.WriteLine("{0} | {1} | {2}", frontier[i].statePosition[0], frontier[i].statePosition[1], frontier[i].statePosition[2]);
                Console.WriteLine("---------");
                Console.WriteLine("{0} | {1} | {2}", frontier[i].statePosition[3], frontier[i].statePosition[4], frontier[i].statePosition[5]);
                Console.WriteLine("---------");
                Console.WriteLine("{0} | {1} | {2}", frontier[i].statePosition[6], frontier[i].statePosition[7], frontier[i].statePosition[8]);
                Console.WriteLine("{0} | {1}", frontier[i].stateDepth, frontier[i].manhattanDistance);
                Console.WriteLine();
            }
        }
        public void insertIntoExploredSet(State state)
        {
            exploredTable[state.manhattanDistance].stateList.Add(state);

        }   
        public void printExploredSet()
        {

            for(int i = 0; i < exploredTable.Count; i++)
            {
                for(int j = 0; j < exploredTable[i].stateList.Count; j++)
                {
                    int[] statePos = exploredTable[i].stateList[j].getPositions();
                    Console.Write("Row " + i + ": num " + j + ":");
                    Console.WriteLine(" {0} | {1} | {2} | {3} | {4} | {5} | {6} | {7} | {8}", statePos[0], statePos[1], statePos[2], statePos[3], statePos[4], statePos[5], statePos[6], statePos[7], statePos[8]);
                    Console.WriteLine();

                }
                Console.WriteLine();
                
            }
            
        }

        public State[] removeExploredFromFrontier(State[] inputStates)
        {
            List<State> outputStates = new List<State>();
            
            bool matched = false;

            for(int i = 0; i < inputStates.Length; i++)
            {
                for(int j = 0; j < exploredTable[inputStates[i].manhattanDistance].stateList.Count; j++)
                {
                    if(inputStates[i].statePosition.SequenceEqual(exploredTable[inputStates[i].manhattanDistance].stateList[j].statePosition))
                    {
                        matched = true;
                        break;
                    }
                }
                if (!matched)
                {
                    outputStates.Add(inputStates[i]);
                    matched = false;
                }
                matched = false;
            }
            
            return outputStates.ToArray();
        }
        public bool checkState(State state)
        {
            if(state == this.goalState)
            {
                return true;
            }
            return false;
        }
    }
}
