namespace Aclerbois.GameOfLife.Business.Models
{
    public struct GenerationSize
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
