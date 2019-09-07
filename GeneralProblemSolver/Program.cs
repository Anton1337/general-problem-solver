using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralProblemSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            bool depthFirst = true;
            RunJugProblem(depthFirst);

            Console.ReadLine();
        }

        static void RunJugProblem(bool depthFirst)
        {
            State initialState = new State(new List<int>() { 0, 0 });
            State goalState = new State(new List<int>() { 2, 0 });

            JugsProblem jugsProblem = new JugsProblem(initialState, goalState);

            bool result = depthFirst  
                ? GeneralProblemSolver.SolveWithDepthFirst(jugsProblem)
                : GeneralProblemSolver.SolveWithDepthFirst(jugsProblem);

            Console.WriteLine(result ? "Success!" : "Fail!");
        }
    }
}
