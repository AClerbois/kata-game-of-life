using Aclerbois.GameOfLife.Business.Services;
using Aclerbois.GameOfLife.Shared.Patterns;
using System.Threading;

namespace Aclerbois.GameOfLife.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Drawer drawer = new Drawer();
            int sleepTime = 500;
            IPattern pattern = new IColumnPattern();
            var nextGenerationService = new NextGenerationService();
            var generation = pattern.GetGeneration();
            do
            {
                drawer.DrawGeneration(generation);
                generation = nextGenerationService.Build(generation);
                Thread.Sleep(sleepTime);
            } while (true);
        }
    }
}
