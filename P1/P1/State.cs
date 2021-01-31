using System;
using System.Collections.Generic;
using System.Text;

namespace P1
{
    class State
    {
        public int[] statePosition = new int[9];
        public int manhattanDistance { get; set; }
        public int stateDepth { get; set; }
        public int expansionOrder { get; set; }

        public List<State> path = new List<State>();

        //Costs for windy conditions
        private const int NORTHCOST = 1;
        private const int EASTCOST = 2;
        private const int SOUTHCOST = 3;
        private const int WESTCOST = 2;
        
        public State(int[] positions)
        {
            positions.CopyTo(this.statePosition, 0);
            manhattanDistance = calculateManhattanDistance();

        }

        public State(State oldState)
        {
            oldState.statePosition.CopyTo(this.statePosition, 0);
            this.manhattanDistance = oldState.manhattanDistance;
            this.stateDepth = oldState.stateDepth;
            this.expansionOrder = oldState.expansionOrder;
            this.path.Add(oldState);
            manhattanDistance = calculateManhattanDistance();
        }

        public int[] getPositions()
        {
            return statePosition;
        }

        public int calculateManhattanDistance()
        {
            /*
                The Manhattan distance is determined by the total 
                # of movements required to reach the goal state. 
                This will also factor in the windy conditions where
                North - 1 Cost
                East  - 2 Cost
                South - 3 Cost
                West  - 2 Cost

            */
            int manhattanSum = 0;
            int currentLocation;
            int currentNumber;

            for(int i = 0; i < 9; i++)
            {
                currentLocation = setCurrentLocation(i);
                currentNumber = this.statePosition[i];

                //Console.WriteLine("Loc: {0} | num: {1}", currentLocation, currentNumber);
                manhattanSum += getdistanceToGoalLoc(currentLocation, currentNumber);

            }
            //Console.WriteLine("Total Manhattan Distance is {0}", manhattanSum);
            return manhattanSum;
        }
        private int setCurrentLocation(int arrayNum)
        {
            int currentLoc;
            switch (arrayNum)
            {
                case 0:
                    currentLoc = 1;
                    break;
                case 1:
                    currentLoc = 2;
                    break;
                case 2:
                    currentLoc = 3;
                    break;
                case 3:
                    currentLoc = 8;
                    break;
                case 4:
                    currentLoc = 0;
                    break;
                case 5:
                    currentLoc = 4;
                    break;
                case 6:
                    currentLoc = 7;
                    break;
                case 7:
                    currentLoc = 6;
                    break;
                case 8:
                    currentLoc = 5;
                    break;
                default:
                    Console.WriteLine("What...How");
                    currentLoc = -1;
                    break;
            }
            return currentLoc;
        }

        private int getdistanceToGoalLoc(int loc, int num)
        {
            int total = 0;
            switch (loc)
            {
                case 1:
                    switch (num)
                    {
                       
                        case 1:
                            total = 0;
                            break;
                        case 2:
                            total = 1 * EASTCOST;
                            break;
                        case 3:
                            total = 2 * EASTCOST;
                            break;
                        case 4:
                            total = 2 * EASTCOST + 1 * SOUTHCOST;
                            break;
                        case 5:
                            total = 2 * EASTCOST + 2 * SOUTHCOST;
                            break;
                        case 6:
                            total = 1 * EASTCOST + 2 * SOUTHCOST;
                            break;
                        case 7:
                            total = 2 * SOUTHCOST;
                            break;
                        case 8:
                            total = 1 * SOUTHCOST;
                            break;
                    }
                    break;
                case 2:
                    switch (num)
                    {
                        
                        case 1:
                            total = 1 * WESTCOST;
                            break;
                        case 2:
                            total = 0;
                            break;
                        case 3:
                            total = 1 * EASTCOST;
                            break;
                        case 4:
                            total = 1 * EASTCOST + 1 * SOUTHCOST;
                            break;
                        case 5:
                            total = 1 * EASTCOST + 2 * SOUTHCOST;
                            break;
                        case 6:
                            total = 2 * SOUTHCOST;
                            break;
                        case 7:
                            total = 1 * WESTCOST + 2 * SOUTHCOST;
                            break;
                        case 8:
                            total = 1 * WESTCOST + 1 * SOUTHCOST;
                            break;
                    }
                    break;
                case 3:
                    switch (num)
                    {
                        
                        case 1:
                            total = 2 * WESTCOST;
                            break;
                        case 2:
                            total = 1 * WESTCOST;
                            break;
                        case 3:
                            total = 0;
                            break;
                        case 4:
                            total = 1 * SOUTHCOST;
                            break;
                        case 5:
                            total = 2 * SOUTHCOST;
                            break;
                        case 6:
                            total = 1 * WESTCOST + 2 * SOUTHCOST;
                            break;
                        case 7:
                            total = 2 * WESTCOST + 2 * SOUTHCOST;
                            break;
                        case 8:
                            total = 2 * WESTCOST + 1 * SOUTHCOST;
                            break;
                    }
                    break;
                case 4:
                    switch (num)
                    {
                       
                        case 1:
                            total = 2 * WESTCOST + 1 * NORTHCOST;
                            break;
                        case 2:
                            total = 1 * WESTCOST + 1 * NORTHCOST;
                            break;
                        case 3:
                            total = 1 * NORTHCOST;
                            break;
                        case 4:
                            total = 0;
                            break;
                        case 5:
                            total = 1 * SOUTHCOST;
                            break;
                        case 6:
                            total = 1 * WESTCOST + 1 * SOUTHCOST;
                            break;
                        case 7:
                            total = 2 * WESTCOST + 1 * SOUTHCOST;
                            break;
                        case 8:
                            total = 2 * WESTCOST;
                            break;
                    }
                    break;
                case 5:
                    switch (num)
                    {
                        
                        case 1:
                            total = 2 * WESTCOST + 2 * NORTHCOST;
                            break;
                        case 2:
                            total = 1 * WESTCOST + 2 * NORTHCOST;
                            break;
                        case 3:
                            total = 2 * NORTHCOST;
                            break;
                        case 4:
                            total = 1 * NORTHCOST;
                            break;
                        case 5:
                            total = 0;
                            break;
                        case 6:
                            total = 1 * WESTCOST;
                            break;
                        case 7:
                            total = 2 * WESTCOST;
                            break;
                        case 8:
                            total = 2 * WESTCOST + 1 * NORTHCOST;
                            break;
                    }
                    break;
                case 6:
                    switch (num)
                    {
                        
                        case 1:
                            total = 1 * WESTCOST + 2 * NORTHCOST;
                            break;
                        case 2:
                            total = 2 * NORTHCOST;
                            break;
                        case 3:
                            total = 1 * EASTCOST + 2 * NORTHCOST;
                            break;
                        case 4:
                            total = 1 * EASTCOST + 1 * NORTHCOST;
                            break;
                        case 5:
                            total = 1 * EASTCOST;
                            break;
                        case 6:
                            total = 0;
                            break;
                        case 7:
                            total = 1 * WESTCOST;
                            break;
                        case 8:
                            total = 1 * WESTCOST + 1 * NORTHCOST;
                            break;
                    }
                    break;
                case 7:
                    switch (num)
                    {
                        
                        case 1:
                            total = 2 * NORTHCOST;
                            break;
                        case 2:
                            total = 1 * EASTCOST + 2 * NORTHCOST;
                            break;
                        case 3:
                            total = 2 * EASTCOST + 2 * NORTHCOST;
                            break;
                        case 4:
                            total = 2 * EASTCOST + 1 * NORTHCOST;
                            break;
                        case 5:
                            total = 2 * EASTCOST;
                            break;
                        case 6:
                            total = 1 * EASTCOST;
                            break;
                        case 7:
                            total = 0;
                            break;
                        case 8:
                            total = 1 * NORTHCOST;
                            break;
                    }
                    break;
                case 8:
                    switch (num)
                    {
                        case 1:
                            total = 1 * NORTHCOST;
                            break;
                        case 2:
                            total = 1 * EASTCOST + 1 * NORTHCOST;
                            break;
                        case 3:
                            total = 2 * EASTCOST + 1 * NORTHCOST;
                            break;
                        case 4:
                            total = 2 * EASTCOST;
                            break;
                        case 5:
                            total = 2 * EASTCOST + 1 * SOUTHCOST;
                            break;
                        case 6:
                            total = 1 * EASTCOST + 1 * SOUTHCOST;
                            break;
                        case 7:
                            total = 1 * SOUTHCOST;
                            break;
                        case 8:
                            total = 0;
                            break;
                    }
                    break;
                case 0:
                    switch (num)
                    {
                        case 0:
                            total = 0;
                            break;
                        case 1:
                            total = 1 * WESTCOST + 1 * NORTHCOST;
                            break;
                        case 2:
                            total = 1 * NORTHCOST;
                            break;
                        case 3:
                            total = 2 * EASTCOST + 1 * NORTHCOST;
                            break;
                        case 4:
                            total = 1 * EASTCOST;
                            break;
                        case 5:
                            total = 1 * EASTCOST + 1 * SOUTHCOST;
                            break;
                        case 6:
                            total = 1 * SOUTHCOST;
                            break;
                        case 7:
                            total = 1 * WESTCOST + 1 * SOUTHCOST;
                            break;
                        case 8:
                            total = 1 * WESTCOST;
                            break;
                    }
                    break;
                
            }
            //Console.WriteLine("Total distance for {0} (Position {1}) to be corrected is {2}", num, loc, total);
            return total;
        }
    }
}
