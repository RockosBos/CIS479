using System;
using System.Collections.Generic;
using System.Text;

namespace P1
{
    class StateManager
    {

        public State[] generateNewStates(State state)
        {
            //State state = new State(oldState.getPositions());
            
            List<State> newStateList = new List<State>();
            int numValidStates = 0;

            int emptyPos = getEmptySquare(state.statePosition);

            if (emptyPos != 0 && emptyPos != 3 && emptyPos != 6)
            {
                newStateList.Add(shiftRight(state));
                numValidStates++;
                //Console.WriteLine("R");
            }
            if (emptyPos != 2 && emptyPos != 5 && emptyPos != 8)
            {
                newStateList.Add(shiftLeft(state));
                numValidStates++;
                //Console.WriteLine("L");
            }
            if (emptyPos != 6 && emptyPos != 7 && emptyPos != 8)
            {
                newStateList.Add(shiftUp(state));
                numValidStates++;
                //Console.WriteLine("U");
            }
            if (emptyPos != 0 && emptyPos != 1 && emptyPos != 2)
            {
                newStateList.Add(shiftDown(state));
                //Console.WriteLine("D");

            }

            return newStateList.ToArray();

        }
        public State shiftRight(State oldState)
        {
            State newState = new State(oldState);
            
            int emptyPos = getEmptySquare(newState.getPositions());

            
            newState.statePosition[emptyPos] = newState.statePosition[emptyPos - 1];
            newState.statePosition[emptyPos - 1] = 0;

            newState.calculateManhattanDistance();
            newState.expansionOrder = oldState.expansionOrder + 1;
            newState.stateDepth = oldState.stateDepth + 2;

            testOutput(newState);

            return newState;
        }
        public State shiftLeft(State oldState)
        {
            State newState = new State(oldState.getPositions());
            int emptyPos = getEmptySquare(newState.getPositions());

            newState.statePosition[emptyPos] = newState.statePosition[emptyPos + 1];
            newState.statePosition[emptyPos + 1] = 0;

            newState.calculateManhattanDistance();
            newState.expansionOrder = oldState.expansionOrder + 1;
            newState.stateDepth = oldState.stateDepth + 2;

            testOutput(newState);

            return newState;
        }
        public State shiftUp(State oldState)
        {
            State newState = new State(oldState.getPositions());
            int emptyPos = getEmptySquare(newState.getPositions());

            newState.statePosition[emptyPos] = newState.statePosition[emptyPos + 3];
            newState.statePosition[emptyPos + 3] = 0;

            newState.calculateManhattanDistance();
            newState.expansionOrder = oldState.expansionOrder + 1;
            newState.stateDepth = oldState.stateDepth + 1;

            testOutput(newState);

            return newState;
        }
        public State shiftDown(State oldState)
        {
            State newState = new State(oldState.getPositions());
            int emptyPos = getEmptySquare(newState.getPositions());

            newState.statePosition[emptyPos] = newState.statePosition[emptyPos - 3];
            newState.statePosition[emptyPos - 3] = 0;

            newState.calculateManhattanDistance();
            newState.expansionOrder = oldState.expansionOrder + 1;
            newState.stateDepth = oldState.stateDepth + 3;

            testOutput(newState);

            return newState;
        }

        public void testOutput(State newState)
        {
            int[] pos = newState.getPositions();

            Console.WriteLine("{0} | {1} | {2}", pos[0], pos[1], pos[2]);
            Console.WriteLine("---------");
            Console.WriteLine("{0} | {1} | {2}", pos[3], pos[4], pos[5]);
            Console.WriteLine("---------");
            Console.WriteLine("{0} | {1} | {2}", pos[6], pos[7], pos[8]);
            Console.WriteLine("{0} | {1}", newState.stateDepth, newState.manhattanDistance);
            Console.WriteLine();
        }


        public int getEmptySquare(int[] positions)
        {
            int emptyPos = 0;
            for(int i = 0; i < 9; i++)
            {
                if(positions[i] == 0)
                {
                    emptyPos = i;
                    break;
                }
            }
            return emptyPos;
        }
    }
}
