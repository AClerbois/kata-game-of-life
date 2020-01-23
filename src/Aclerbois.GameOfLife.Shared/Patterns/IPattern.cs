using Aclerbois.GameOfLife.Business.Models;

namespace Aclerbois.GameOfLife.Shared.Patterns
{
    public interface IPattern
    {
        string Name { get; }
        Generation GetGeneration();
    }
}
