using Aclerbois.GameOfLife.Business.Models;

namespace Aclerbois.GameOfLife.Shared.Patterns
{
    public class DoubleSquare : IPattern
    {
        public string Name => "DoubleSquare";

        public Generation GetGeneration()
        {
            var generationSize = new GenerationSize(6, 6);
            var generation = new Generation(generationSize);
            generation.CurrentGeneration[1, 1] = true;
            generation.CurrentGeneration[2, 1] = true;
            generation.CurrentGeneration[1, 2] = true;
            generation.CurrentGeneration[4, 3] = true;
            generation.CurrentGeneration[3, 4] = true;
            generation.CurrentGeneration[4, 4] = true;

            return generation;
        }
    }
}
