using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Crossovers;
using GeneticSharp.Domain.Mutations;
using GeneticSharp.Domain.Randomizations;
using GeneticSharp.Domain.Selections;
using GeneticSharp.Infrastructure.Framework.Reflection;

namespace GeneticSharp.Extensions.GeneticDiet
{
    /// <summary>
    /// Auto config another genetic algorithm.
    /// </summary>
    public sealed class GeneticDietChromosome : ChromosomeBase
    {
        private static List<EF.ChromosomeDB> list = new List<EF.ChromosomeDB>();

        #region Constructor           
        /// <summary>
        /// Initializes a new instance of the <see cref="GeneticDietChromosome"/> class.
        /// </summary>
        public GeneticDietChromosome() : base(5)
        {
            if (list.Count == 0)
            {
                list = new EF.FoodDB().InicializarProblacion();
            }
        }

        public GeneticDietChromosome(EF.ChromosomeDB chromosome) : base(5)
        {
            for (int i = 0; i < chromosome.Genes.Count; i++)
            {
                ReplaceGene(i, new Gene(chromosome.Genes[i]));
            }
        }

        #endregion

        #region Methods                
        /// <summary>
        /// Creates a new chromosome using the same structure of this.
        /// </summary>
        /// <returns>
        /// The new chromosome.
        /// </returns>
        public override IChromosome CreateNew()
        {
            return new GeneticDietChromosome();
        }

        //protected void CreateGenes()
        //{
        //    for (int i = 0; i < Length; i++)
        //    {
        //        switch (i)
        //        {
        //           case 1:
        //                ReplaceGene(1, gen1);
        //           break;
        //            case 2:
        //                ReplaceGene(2, gen2);
        //                break;
        //            case 3:
        //                ReplaceGene(3, gen3);
        //                break;
        //            case 4:
        //                ReplaceGene(4, gen4);
        //                break;
        //            case 5:
        //                ReplaceGene(5, gen5);
        //                break;
        //        }
        //    }
        //}

        /// <summary>
        /// Generates the gene.
        /// </summary>
        /// <param name="geneIndex">Index of the gene.</param>
        /// <returns>The new gene.</returns>
        /// <exception cref="System.InvalidOperationException">Invalid GeneticDietChromosome gene index.</exception>
        public override Gene GenerateGene(int geneIndex)
        {            
            Random random = new System.Random();
            int value = random.Next(0, 199);

            EF.ChromosomeDB chromo = list[value];            

            return new Gene(chromo.Genes[geneIndex]);
        }
        #endregion
    }
}
