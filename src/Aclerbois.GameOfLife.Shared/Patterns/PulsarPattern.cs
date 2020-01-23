using Aclerbois.GameOfLife.Business.Models;

namespace Aclerbois.GameOfLife.Shared.Patterns
{
    public class PulsarPattern : IPattern
    {
        public string Name => "Pulsar";

        public Generation GetGeneration()
        {
            var generationSize = new GenerationSize(17, 17);
            var generation = new Generation(generationSize);

            generation.CurrentGeneration[2, 4] = true;
            generation.CurrentGeneration[2, 5] = true;
            generation.CurrentGeneration[2, 6] = true;
            generation.CurrentGeneration[2, 10] = true;
            generation.CurrentGeneration[2, 11] = true;
            generation.CurrentGeneration[2, 12] = true;
            generation.CurrentGeneration[4, 2] = true;
            generation.CurrentGeneration[4, 7] = true;
            generation.CurrentGeneration[4, 9] = true;
            generation.CurrentGeneration[4, 14] = true;
            generation.CurrentGeneration[5, 2] = true;
            generation.CurrentGeneration[5, 7] = true;
            generation.CurrentGeneration[5, 9] = true;
            generation.CurrentGeneration[5, 14] = true;
            generation.CurrentGeneration[6, 2] = true;
            generation.CurrentGeneration[6, 7] = true;
            generation.CurrentGeneration[6, 9] = true;
            generation.CurrentGeneration[6, 14] = true;
            generation.CurrentGeneration[7, 4] = true;
            generation.CurrentGeneration[7, 5] = true;
            generation.CurrentGeneration[7, 6] = true;
            generation.CurrentGeneration[7, 10] = true;
            generation.CurrentGeneration[7, 11] = true;
            generation.CurrentGeneration[7, 12] = true;
            generation.CurrentGeneration[9, 4] = true;
            generation.CurrentGeneration[9, 5] = true;
            generation.CurrentGeneration[9, 6] = true;
            generation.CurrentGeneration[9, 10] = true;
            generation.CurrentGeneration[9, 11] = true;
            generation.CurrentGeneration[9, 12] = true;
            generation.CurrentGeneration[10, 2] = true;
            generation.CurrentGeneration[10, 7] = true;
            generation.CurrentGeneration[10, 9] = true;
            generation.CurrentGeneration[10, 14] = true;
            generation.CurrentGeneration[11, 2] = true;
            generation.CurrentGeneration[11, 7] = true;
            generation.CurrentGeneration[11, 9] = true;
            generation.CurrentGeneration[11, 14] = true;
            generation.CurrentGeneration[12, 2] = true;
            generation.CurrentGeneration[12, 7] = true;
            generation.CurrentGeneration[12, 9] = true;
            generation.CurrentGeneration[12, 14] = true;
            generation.CurrentGeneration[14, 4] = true;
            generation.CurrentGeneration[14, 5] = true;
            generation.CurrentGeneration[14, 6] = true;
            generation.CurrentGeneration[14, 10] = true;
            generation.CurrentGeneration[14, 11] = true;
            generation.CurrentGeneration[14, 12] = true;

            return generation;
        }
    }
}
