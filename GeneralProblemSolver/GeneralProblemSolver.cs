using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralProblemSolver
{
    class GeneralProblemSolver
    {
       public static bool SolveWithBreadthFirst(Problem problem)
        {
            Queue<State> open = new Queue<State>();
            open.Enqueue(problem.InitialState);

            List<State> closed = new List<State>();

            while(open.Count > 0)
            {
                // Select next node and move it from OPEN to CLOSED
                State n = open.Dequeue();
                closed.Add(n);

                // If we have reached the goalstate we finish with success.
                if (n.Equals(problem.GoalState))
                {
                    PrintSuccessPath(n);
                    return true;
                }

                // Expand N using its rules and add to OPEN
                List<State> _new = problem.PossibleStatesAfterActions(n);
                foreach(State state in _new)
                {
                    if (!closed.Contains(state) && !open.Contains(state))
                        open.Enqueue(state);
                }

            }
            return false;
        }

        public static bool SolveWithDepthFirst(Problem problem)
        {
            Stack<State> open = new Stack<State>();
            open.Push(problem.InitialState);

            List<State> closed = new List<State>();

            while (open.Count > 0)
            {
                // Select next node and move it from OPEN to CLOSED
                State n = open.Pop();
                closed.Add(n);

                // If we have reached the goalstate we finish with success.
                if (n.Equals(problem.GoalState))
                {
                    PrintSuccessPath(n);
                    return true;
                }

                // Expand N using its rules and add to OPEN
                List<State> _new = problem.PossibleStatesAfterActions(n);
                foreach (State state in _new)
                {
                    if (!closed.Contains(state) && !open.Contains(state))
                        open.Push(state);
                }

            }
            return false;
        }

        private static void PrintSuccessPath(State n)
        {
            State s = n;
            List<string> output = new List<string>();
            while (s != null)
            {
                output.Add("First Jug: " + s.values[0] + ", Second Jug: " + s.values[1]);
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
