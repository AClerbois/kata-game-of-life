namespace Aclerbois.GameOfLife.Business.Models
{
    public class GenerationSize
    {
        public GenerationSize(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public int Width { get; }
        public int Height { get; }
    }
}
