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
            RunWolfGoatCabbageProblem(depthFirst);

            Console.ReadLine();
        }

        static void RunJugProblem(bool depthFirst)
        {

            State initialState = new State(new List<int>() { 0, 0 });
            State goalState = new State(new List<int>() { 2, 0 });

            JugsProblem jugsProblem = new JugsProblem(initialState, goalState);

            State finalState = depthFirst  
                ? GeneralProblemSolver.SolveWithDepthFirst(jugsProblem)
                : GeneralProblemSolver.SolveWithBreadthFirst(jugsProblem);

            // Some output formatting.
            if(finalState != null)
            {
                Console.WriteLine("------- JUG PROBLEM SUCCESS! -------");
                Console.WriteLine();
                JugsProblem.PrintStatePath(finalState);
                Console.WriteLine();
                Console.WriteLine("------------------------------------");
            } else
            {
                Console.WriteLine("JUG PROBLEM FAILED!");
            }
            Console.WriteLine();
        }


        private static void RunWolfGoatCabbageProblem(bool depthFirst)
        {
            State initialState = new State(new List<int>() { 1, 1, 1, 1 });
            State goalState = new State(new List<int>() { 0, 0, 0, 0 });

            WolfGoatCabbageProblem problem = new WolfGoatCabbageProblem(initialState, goalState);

            State finalState = depthFirst
                ? GeneralProblemSolver.SolveWithDepthFirst(problem)
                : GeneralProblemSolver.SolveWithBreadthFirst(problem);

            // Some output formatting.
            if (finalState != null)
            {
                Console.WriteLine("------- WOLFGOATCABBAGE PROBLEM SUCCESS! -------");
                Console.WriteLine();
                WolfGoatCabbageProblem.PrintStatePath(finalState);
                Console.WriteLine();
                Console.WriteLine("------------------------------------------------");
            }
            else
            {
                Console.WriteLine("WOLFGOATCABBAGE PROBLEM FAILED!");
            }
            Console.WriteLine();
        }
    }
}
