using GAF;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorytmGenetyczny
{
    public static class GAMethods
    {
        static double range = 200;
        static IFunction function = new MyFunction();


        public static double GeneticFitness(Chromosome chromosome)
        {
            double geneticAssessment = -1;
            if (chromosome != null)
            {
                (double x, double y) coordinates = GetCoordinates(chromosome);

                //Calculate genetic assessment using binary calculations
                geneticAssessment = 1 - function.GetResult(coordinates.x, coordinates.y);
            }
            else
            {
                //Chromosome is null
                throw new ArgumentNullException("chromosom", "Chromosome is null.");
            }
            return geneticAssessment;
        }

        public static void endOfGeneration(object sender, GaEventArgs gaArgs)
        {
            //Get the best solution
            var chromosome = gaArgs.Population.GetTop(1)[0];

            (double x, double y) coordinates = GetCoordinates(chromosome);

            //Show X and Y in console and fitness for best chromosome from current generation
            Console.WriteLine($"x:{coordinates.x} y:{coordinates.y} Fitness: {gaArgs.Population.MaximumFitness} Generation: {gaArgs.Generation}\n");
        }

        public static (double x, double y) GetCoordinates(Chromosome chromosome)
        {
            //Get x and y from chromosome
            var xChromosome = Convert.ToInt32(chromosome.ToBinaryString(0, chromosome.Count / 2), 2);
            var yChromosome = Convert.ToInt32(chromosome.ToBinaryString(chromosome.Count / 2, chromosome.Count / 2), 2);

            //Set chromosome range from -100 to 100
            range = range / (System.Math.Pow(2, chromosome.Count / 2) - 1);
            double x = (xChromosome * range) - 100;
            double y = (yChromosome * range) - 100;
            return (x, y);
        }
        public static bool RunAlgorithm(Population population, int currentGeneration, long currentAssessment)
        {
            return currentGeneration > 250;
        }
    }
}
