using System;
using GAF; //Genetic Alghoritm Framework
using GAF.Operators;

namespace AlgorytmGenetyczny
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const double crossoverPossibility = 0.65;
            const double mutationPossibility = 0.08;
            const int elitePercent = 5;   

            var population = new Population(100, 44, false, false); //Population - imported from GAF

            //Genetic operations:
            var elite = new Elite(elitePercent);
            var crossover = new Crossover(crossoverPossibility, true) { CrossoverType = CrossoverType.SinglePoint };
            var mutation = new BinaryMutate(mutationPossibility, true);

            //Genetic Algorithm creation
            var ga = new GeneticAlgorithm(population, GAMethods.GeneticFitness);
            ga.OnGenerationComplete += GAMethods.endOfGeneration;
            ga.Operators.Add(elite);
            ga.Operators.Add(crossover);
            ga.Operators.Add(mutation);

            ga.Run(GAMethods.RunAlgorithm);
        }
    }
}
