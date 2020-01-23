using System;

namespace Aclerbois.GameOfLife.Business.Models
{
    public class Generation
    {
        public Generation(GenerationSize generationSize, int generationNumber)
        {
            this.GenerationSize = generationSize;
            this.GenerationNumber = generationNumber;
            this.CurrentGeneration = new bool[generationSize.Width, generationSize.Height];
        }

        public bool[,] CurrentGeneration { get; }
        public GenerationSize GenerationSize { get; }
        public int GenerationNumber { get; }
    }
}
