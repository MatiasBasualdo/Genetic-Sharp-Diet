using System;
using System.Diagnostics.CodeAnalysis;
using GeneticSharp.Domain;
using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Fitnesses;
using GeneticSharp.Domain.Populations;
using GeneticSharp.Domain.Terminations;
using GeneticSharp.Infrastructure.Framework.Threading;

namespace GeneticSharp.Extensions.GeneticDiet
{
    /// <summary>
    /// A fitness function to auto config another genetic algorithm.
    /// </summary>
    public sealed class GeneticDietFitness : IFitness
    {
        #region Constructor               
        
        public GeneticDietFitness()
        {
            
        }

        #endregion
        
        #region Methods        
        /// <summary>
        /// Evaluates the specified chromosome.
        /// </summary>
        /// <param name="chromosome">The chromosome.</param>
        /// <returns>The chromosome fitness.</returns>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        public double Evaluate(IChromosome chromosome)
        {
            chromosome = chromosome as GeneticDietChromosome;
            double sum = 0;

            foreach (var item in chromosome.GetGenes())
            {
                EF.GenDB gendb = (EF.GenDB)item.Value;
                sum += gendb.ValueNutrient;
            }            

            return sum;
        }
        #endregion
    }
}
