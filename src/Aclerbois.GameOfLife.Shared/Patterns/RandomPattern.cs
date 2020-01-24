using Aclerbois.GameOfLife.Business.Models;

namespace Aclerbois.GameOfLife.Shared.Patterns
{
    public class RandomPattern : IPattern
    {
        public string Name => "Random";

        public Generation GetGeneration()
        {
            var generationSize = new GenerationSize(50, 30);
            var generation = new Generation(generationSize);

            generation.CurrentGeneration[2, 4] = true;
            generation.CurrentGeneration[2, 5] = true;
            generation.CurrentGeneration[2, 6] = true;
            generation.CurrentGeneration[7, 5] = true;
            generation.CurrentGeneration[7, 6] = true;
            generation.CurrentGeneration[7, 10] = true;
            generation.CurrentGeneration[7, 11] = true;
            generation.CurrentGeneration[7, 12] = true;
            generation.CurrentGeneration[9, 4] = true;
            generation.CurrentGeneration[9, 5] = true;
            generation.CurrentGeneration[9, 6] = true;
            generation.CurrentGeneration[9, 10] = true;
            generation.CurrentGeneration[12, 9] = true;
            generation.CurrentGeneration[12, 14] = true;
            generation.CurrentGeneration[14, 4] = true;
            generation.CurrentGeneration[14, 5] = true;
            generation.CurrentGeneration[14, 6] = true;
            generation.CurrentGeneration[14, 10] = true;
            generation.CurrentGeneration[14, 11] = true;
            generation.CurrentGeneration[14, 12] = true;
            generation.CurrentGeneration[24, 10] = true;
            generation.CurrentGeneration[24, 1] = true;
            generation.CurrentGeneration[24, 21] = true;
            generation.CurrentGeneration[24, 14] = true;
            generation.CurrentGeneration[24, 12] = true;

            return generation;
        }
    }
}
