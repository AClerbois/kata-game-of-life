using Aclerbois.GameOfLife.Business.Models;

namespace Aclerbois.GameOfLife.Shared.Patterns
{
    public class IColumnPattern : IPattern
    {
        public string Name => "IColumn";

        public Generation GetGeneration()
        {
            var generationSize = new GenerationSize(11, 18);
            var generation = new Generation(generationSize);

            generation.CurrentGeneration[4, 5] = true;
            generation.CurrentGeneration[5, 5] = true;
            generation.CurrentGeneration[6, 4] = true;
            generation.CurrentGeneration[6, 6] = true;
            generation.CurrentGeneration[7, 5] = true;
            generation.CurrentGeneration[8, 5] = true;
            generation.CurrentGeneration[9, 5] = true;
            generation.CurrentGeneration[10, 5] = true;
            generation.CurrentGeneration[11, 4] = true;
            generation.CurrentGeneration[11, 6] = true;
            generation.CurrentGeneration[12, 5] = true;
            generation.CurrentGeneration[13, 5] = true;

            return generation;
        }
    }
}
