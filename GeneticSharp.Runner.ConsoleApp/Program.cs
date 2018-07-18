using System;
using System.Collections.Generic;
using System.IO;
using GeneticSharp.Domain;
using GeneticSharp.Domain.Populations;
using GeneticSharp.Infrastructure.Framework.Reflection;

namespace GeneticSharp.Runner.ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Run2();
        }

        private static void Run2()
        {
            var selection = new Domain.Selections.TournamentSelection();
                //.EliteSelection();
            var crossover = new Domain.Crossovers.OrderedCrossover();
            var mutation = new Domain.Mutations.InsertionMutation();
            var fitness = new Extensions.GeneticDiet.GeneticDietFitness();
            var chromosome = new Extensions.GeneticDiet.GeneticDietChromosome();

            var population = new GeneticSharp.Extensions.GeneticDiet.GeneticDietPopulation(150, 200, chromosome);

            var ga = new GeneticAlgorithm(population, fitness, selection, crossover, mutation);
            ga.Termination = new Domain.Terminations.GenerationNumberTermination(100);

            Console.WriteLine("GA running...");
            ga.Start();

            Console.WriteLine("Best solution found has {0} fitness.", ga.BestChromosome.Fitness);
            Console.WriteLine("Best solution found has {0} Gen1.", ((EF.GenDB)ga.BestChromosome.GetGene(0).Value).NameFood);
            Console.WriteLine("Best solution found has {0} Gen2.", ((EF.GenDB)ga.BestChromosome.GetGene(1).Value).NameFood);
            Console.WriteLine("Best solution found has {0} Gen3.", ((EF.GenDB)ga.BestChromosome.GetGene(2).Value).NameFood);
            Console.WriteLine("Best solution found has {0} Gen4.", ((EF.GenDB)ga.BestChromosome.GetGene(3).Value).NameFood);
            Console.WriteLine("Best solution found has {0} Gen5.", ((EF.GenDB)ga.BestChromosome.GetGene(4).Value).NameFood);
        }

        private static void DrawSampleName(string selectedSampleName)
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("GeneticSharp - ConsoleApp");
            Console.WriteLine();
            Console.WriteLine(selectedSampleName);
            Console.ResetColor();
        }
    }
}
