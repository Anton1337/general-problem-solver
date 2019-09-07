using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralProblemSolver
{
    class JugsProblem : Problem
    {
        public State InitialState { get; set; }
        public State GoalState { get; set; }

        public JugsProblem(State initialState, State goalState)
        {
            InitialState = initialState;
            GoalState = goalState;
        }

        public List<State> PossibleStatesAfterActions(State state)
        {
            List<State> resultingStates = new List<State>();

            // State.
            int firstJug = state.values[0];
            int secondJug = state.values[1];

            // Action 1: Fill first jug. (4G)
            if (firstJug < 4)
            {
                State newState = state.Copy();
                newState.values[0] = 4; // Jug filled.
                resultingStates.Add(newState);
            }

            // Action 2: Fill second jug. (3G)
            if (secondJug < 3)
            {
                State newState = state.Copy();
                newState.values[1] = 3; // Jug filled.
                resultingStates.Add(newState);
            }

            // Action 3: Empty first jug. (4G)
            if (firstJug > 0)
            {
                State newState = state.Copy();
                newState.values[0] = 0; // Jug filled.
                resultingStates.Add(newState);
            }

            // Action 4: Empty second jug. (3G)
            if (secondJug > 0)
            {
                State newState = state.Copy();
                newState.values[1] = 0; // Jug filled.
                resultingStates.Add(newState);
            }

            // Action 5: Fill first jug from second jug. ( 3G --> 4G).
            if ( (firstJug + secondJug >= 4) && (secondJug > 0) )
            {
                State newState = state.Copy();
                newState.values[0] = 4;
                newState.values[1] = secondJug - (4 - firstJug);
                resultingStates.Add(newState);
            }

            // Action 6: Fill second jug from first jug. ( 4G --> 3G).
            if ( (firstJug + secondJug >= 3) && (firstJug > 0) )
            {
                State newState = state.Copy();
                newState.values[0] = firstJug - (3 - secondJug);
                newState.values[1] = 3;
                resultingStates.Add(newState);
            }

            // Action 7: Empty second jug into first jug. ( 3G --> 4G).
            if ( (firstJug + secondJug <= 4) && (secondJug > 0) )
            {
                State newState = state.Copy();
                newState.values[0] = firstJug + secondJug;
                newState.values[1] = 0;
                resultingStates.Add(newState);
            }

            // Action 8: Empty first jug into second jug. ( 4G --> 3G).
            if ( (firstJug + secondJug <= 3) && (firstJug > 0) )
            {
                State newState = state.Copy();
                newState.values[0] = 0;
                newState.values[1] = firstJug + secondJug;
                resultingStates.Add(newState);
            }

            return resultingStates;
        }
    }
}
