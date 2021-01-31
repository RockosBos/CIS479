using System;
using System.Collections.Generic;
using System.Text;

namespace P1
{
    class Table
    {
        private State initialState;
        private State goalState;
        private List<State> exploredStates = new List<State>();
        private List<State> frontier = new List<State>();
        private List<State> solutionStateList;
        private StateManager stateManager;

        public Table(State state, State goalState)
        {
            this.initialState = state;
            this.goalState = goalState;
            this.stateManager = new StateManager();
            this.frontier.Add(state);
        }
        public List<State> mainAlgorithm()
        {
            bool solutionFound = false;
            while (!solutionFound)
            {
                exploreFrontier();
            }
            return solutionStateList;
        }

        public void exploreFrontier()
        {

            
            
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
