using Aclerbois.GameOfLife.Business.Models;

namespace Aclerbois.GameOfLife.Shared.Patterns
{
    public class ToadPattern : IPattern
    {
        public string Name => "Toad";

        public Generation GetGeneration()
        {
            var generationSize = new GenerationSize(6,6);
            var generation = new Generation(generationSize);
            generation.CurrentGeneration[2, 2] = true;
            generation.CurrentGeneration[3, 2] = true;
            generation.CurrentGeneration[4, 2] = true;
            generation.CurrentGeneration[1, 3] = true;
            generation.CurrentGeneration[2, 3] = true;
            generation.CurrentGeneration[3, 3] = true;

            return generation;
        }
    }   
}
