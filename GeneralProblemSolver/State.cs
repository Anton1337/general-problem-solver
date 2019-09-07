using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralProblemSolver
{
    class State : IEquatable<State>
    {
        public List<int> values = new List<int>(); // Representation of the state.

        public State parent; // Store parent state so we can backtrack when we find goal.
        public State(List<int> values)
        {
            this.values = values;
            parent = null;
        }

        public State(List<int> values, State parent)
        {
            this.values = values;
            this.parent = parent;
        }

        public State Copy()
        {
            List<int> copyValues = new List<int>();

            foreach(int value in values) copyValues.Add(value);

            return new State(copyValues, this);
        }

        public bool Equals(State other)
        {
            for(int i = 0; i < values.Count; i++)
            {
                if (values[i] != other.values[i]) return false;
            }
            return true;
        }
    }
}
