using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralProblemSolver
{
    interface Problem
    {
        State InitialState { get; set; }
        State GoalState { get; set; }


        List<State> PossibleStatesAfterActions(State state);

    }
}
