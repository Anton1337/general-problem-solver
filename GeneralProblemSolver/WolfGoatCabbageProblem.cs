using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralProblemSolver
{
    class WolfGoatCabbageProblem : Problem
    {
        public State InitialState { get; set; }
        public State GoalState { get; set; }

        /*
         GOAL           START
         0,             1,
         0,             1,
         0,             1,
         0              1
        */

        public WolfGoatCabbageProblem(State initialState, State goalState)
        {
            InitialState = initialState;
            GoalState = goalState;
        }

        public List<State> PossibleStatesAfterActions(State state)
        {
            List<State> resultingStates = new List<State>();

            int farmer = state.values[0];
            int wolf = state.values[1];
            int goat = state.values[2];
            int cabbage = state.values[3];

            // Action 1: Farmer moves alone from right to left (1 --> 0).
            if ( farmer == 1 && 
                !GoatAloneWithCabbage(0, wolf, goat, cabbage) &&
                !GoatAloneWithWolf(0, wolf, goat, cabbage) )
            {
                State newState = state.Copy();
                newState.values[0] = 0;
                resultingStates.Add(newState);
            }

            // Action 2: Farmer moves from left to right (0 --> 1).
            if (farmer == 0 &&
                !GoatAloneWithCabbage(1, wolf, goat, cabbage) &&
                !GoatAloneWithWolf(1, wolf, goat, cabbage))
            {
                State newState = state.Copy();
                newState.values[0] = 1;
                resultingStates.Add(newState);
            }

            // Action 3: Wolf (and farmer) moves from right to left (1 --> 0).
            if (farmer == wolf &&
                !GoatAloneWithCabbage(0, 0, goat, cabbage) &&
                !GoatAloneWithWolf(0, 0, goat, cabbage))
            {
                State newState = state.Copy();
                newState.values[0] = 0;
                newState.values[1] = 0;
                resultingStates.Add(newState);
            }

            // Action 4: Wolf (and farmer) moves from left to right (0 --> 1).
            if (farmer == wolf &&
                !GoatAloneWithCabbage(1, 1, goat, cabbage) &&
                !GoatAloneWithWolf(1, 1, goat, cabbage))
            {
                State newState = state.Copy();
                newState.values[0] = 1;
                newState.values[1] = 1;
                resultingStates.Add(newState);
            }

            // Action 5: Goat (and farmer) moves from right to left (1 --> 0).
            if (farmer == goat &&
                !GoatAloneWithCabbage(0, wolf, 0, cabbage) &&
                !GoatAloneWithWolf(0, wolf, 0, cabbage))
            {
                State newState = state.Copy();
                newState.values[0] = 0;
                newState.values[2] = 0;
                resultingStates.Add(newState);
            }

            // Action 6: Goat (and farmer) moves from left to right (0 --> 1).
            if (farmer == goat &&
                !GoatAloneWithCabbage(1, wolf, 1, cabbage) &&
                !GoatAloneWithWolf(1, wolf, 1, cabbage))
            {
                State newState = state.Copy();
                newState.values[0] = 1;
                newState.values[2] = 1;
                resultingStates.Add(newState);
            }

            // Action 7: Cabbage (and farmer) moves from right to left (1 --> 0).
            if (farmer == cabbage &&
                !GoatAloneWithCabbage(0, wolf, goat, 0) &&
                !GoatAloneWithWolf(0, wolf, goat, 0))
            {
                State newState = state.Copy();
                newState.values[0] = 0;
                newState.values[3] = 0;
                resultingStates.Add(newState);
            }

            // Action 8: Cabbage (and farmer) moves from left to right (0 --> 1).
            if (farmer == cabbage &&
                !GoatAloneWithCabbage(1, wolf, goat, 1) &&
                !GoatAloneWithWolf(1, wolf, goat, 1))
            {
                State newState = state.Copy();
                newState.values[0] = 1;
                newState.values[3] = 1;
                resultingStates.Add(newState);
            }

            return resultingStates;
        }

        // Conditional helpers.
        private bool GoatAloneWithCabbage(int farmer, int wolf, int goat, int cabbage)
        {
            if (farmer == 1 && wolf == 1 && goat == 0 && cabbage == 0)
                return true;
            else if (farmer == 0 && wolf == 0 && goat == 1 && cabbage == 1)
                return true;

            return false;
        }

        private bool GoatAloneWithWolf(int farmer, int wolf, int goat, int cabbage)
        {
            if (farmer == 1 && wolf == 0 && goat == 0 && cabbage == 1)
                return true;
            else if (farmer == 0 && wolf == 1 && goat == 1 && cabbage == 0)
                return true;

            return false;
        }

        public static void PrintStatePath(State n)
        {
            State s = n;
            List<string> output = new List<string>();
            while (s != null)
            {
                output.Add("Farmer: " + s.values[0] + ", Wolf: " + s.values[1] + ", Goat: " + s.values[2] + ", Cabbage: " + s.values[3]);
                s = s.parent;
            }

            output.Reverse();
            foreach (string str in output)
            {
                Console.WriteLine(str);
            }
        }
    }
}
