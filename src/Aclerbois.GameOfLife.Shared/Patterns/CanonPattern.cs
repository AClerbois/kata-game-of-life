using Aclerbois.GameOfLife.Business.Models;


namespace Aclerbois.GameOfLife.Shared.Patterns
{
    public class CanonPattern : IPattern
    {
        public string Name => "Canon";


        public Generation GetGeneration()
        {
            var generationSize = new GenerationSize(40, 40);

            var generation = new Generation(generationSize);

            generation.CurrentGeneration[5, 26] = true;
            generation.CurrentGeneration[6, 24] = true;
            generation.CurrentGeneration[6, 26] = true;
            generation.CurrentGeneration[7, 14] = true;
            generation.CurrentGeneration[7, 15] = true;
            generation.CurrentGeneration[7, 22] = true;
            generation.CurrentGeneration[7, 23] = true;
            generation.CurrentGeneration[7, 36] = true;
            generation.CurrentGeneration[7, 37] = true;
            generation.CurrentGeneration[8, 13] = true;
            generation.CurrentGeneration[8, 17] = true;
            generation.CurrentGeneration[8, 22] = true;
            generation.CurrentGeneration[8, 23] = true;
            generation.CurrentGeneration[8, 36] = true;
            generation.CurrentGeneration[8, 37] = true;
            generation.CurrentGeneration[9, 2] = true;
            generation.CurrentGeneration[9, 3] = true;
            generation.CurrentGeneration[9, 12] = true;
            generation.CurrentGeneration[9, 18] = true;
            generation.CurrentGeneration[9, 22] = true;
            generation.CurrentGeneration[9, 23] = true;
            generation.CurrentGeneration[10, 2] = true;
            generation.CurrentGeneration[10, 3] = true;
            generation.CurrentGeneration[10, 12] = true;
            generation.CurrentGeneration[10, 16] = true;
            generation.CurrentGeneration[10, 18] = true;
            generation.CurrentGeneration[10, 19] = true;
            generation.CurrentGeneration[10, 24] = true;
            generation.CurrentGeneration[10, 26] = true;
            generation.CurrentGeneration[11, 12] = true;
            generation.CurrentGeneration[11, 18] = true;
            generation.CurrentGeneration[11, 26] = true;
            generation.CurrentGeneration[12, 13] = true;
            generation.CurrentGeneration[12, 17] = true;
            generation.CurrentGeneration[13, 14] = true;
            generation.CurrentGeneration[13, 15] = true;

            return generation;

        }
    }
}
