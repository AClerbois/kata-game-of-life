using Aclerbois.GameOfLife.Business.Models;


namespace Aclerbois.GameOfLife.Business.Services
{
    public class NextGenerationService
    {
        public Generation Build(Generation generation)
        {
            var newGeneration = new Generation(generation.GenerationSize, generation.GenerationNumber + 1);
            for (int row = 0; row < generation.GenerationSize.Height; row++)
            {
                for (int column = 0; column < generation.GenerationSize.Width; column++)
                {
                    bool newValue;
                    var neightbourgCount = GetSumOfNeightbourgs(generation, row, column);
                    if (IsAlive(generation, row, column))
                        newValue = neightbourgCount == 2 || neightbourgCount == 3;
                    else
                        newValue = neightbourgCount == 3;

                    newGeneration.CurrentGeneration[row, column] = newValue;
                }
            }

            return newGeneration;
        }

        private bool IsAlive(Generation generation, int row, int column)
        {
            return generation.CurrentGeneration[row, column];
        }

        private int GetSumOfNeightbourgs(Generation generation, int indexRow, int indexColumn)
        {
            var count = 0;
            var startRowPosition = indexRow == 0
                ? indexRow
                : indexRow - 1;
            var endRowPosition = indexRow == generation.GenerationSize.Height - 1
                ? indexRow
                : indexRow + 1;

            var startColumnPosition = indexColumn == 0
              ? indexColumn
              : indexColumn - 1;
            var endColumnPosition = indexColumn == generation.GenerationSize.Width - 1
                ? indexColumn
                : indexColumn + 1;

            for (int row = startRowPosition; row <= endRowPosition; row++)
                for (int column = startColumnPosition; column <= endColumnPosition; column++)
                    if (!(row == indexRow && column == indexColumn))
                        count += IsAlive(generation, row, column) ? 1 : 0;


            return count;
        }
    }
}
