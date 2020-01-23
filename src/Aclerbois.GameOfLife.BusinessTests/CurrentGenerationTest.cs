using Aclerbois.GameOfLife.Business.Models;
using Aclerbois.GameOfLife.Business.Services;
using Xunit;

namespace Aclerbois.GameOfLife.BusinessTests
{
    public class CurrentGenerationTest
    {
        [Fact]
        public void Build_WhenAGenerationIsBuilt_TheGenerationNumber_IsIncremented()
        {
            // Arrange
            var generationSize = new GenerationSize(100, 100);
            var generationNumber = 50;
            var expectedGenerationNumber = generationNumber + 1;
            var generation = new Generation(generationSize, generationNumber);
            var services = new NextGenerationService();

            // Act
            var newGeneration = services.Build(generation);

            //Assert
            Assert.Equal(expectedGenerationNumber, newGeneration.GenerationNumber);
        }

        [Fact]
        public void Build_WithPatternBlinkerPeriod2_HaveTheRightResult()
        {
            // Arrange
            var generationSize = new GenerationSize(5, 5);
            var generationNumber = 50;
            var expectedGenerationNumber = generationNumber + 1;
            var generation = new Generation(generationSize, generationNumber);
            generation.CurrentGeneration[2, 1] = true;
            generation.CurrentGeneration[2, 2] = true;
            generation.CurrentGeneration[2, 3] = true;
            var services = new NextGenerationService();

            // Act
            var newGeneration = services.Build(generation);

            //Assert
            Assert.Equal(expectedGenerationNumber, newGeneration.GenerationNumber);
            // First line
            Assert.False(newGeneration.CurrentGeneration[0, 0]);
            Assert.False(newGeneration.CurrentGeneration[0, 1]);
            Assert.False(newGeneration.CurrentGeneration[0, 2]);
            Assert.False(newGeneration.CurrentGeneration[0, 3]);
            Assert.False(newGeneration.CurrentGeneration[0, 4]);

            // Second Line
            Assert.False(newGeneration.CurrentGeneration[1, 0]);
            Assert.False(newGeneration.CurrentGeneration[1, 1]);
            Assert.True(newGeneration.CurrentGeneration[1, 2]);
            Assert.False(newGeneration.CurrentGeneration[1, 3]);
            Assert.False(newGeneration.CurrentGeneration[1, 4]);

            // Thrid Line
            Assert.False(newGeneration.CurrentGeneration[2, 0]);
            Assert.False(newGeneration.CurrentGeneration[2, 1]);
            Assert.True(newGeneration.CurrentGeneration[2, 2]);
            Assert.False(newGeneration.CurrentGeneration[2, 3]);
            Assert.False(newGeneration.CurrentGeneration[2, 4]);

            // Fourth Line
            Assert.False(newGeneration.CurrentGeneration[3, 0]);
            Assert.False(newGeneration.CurrentGeneration[3, 1]);
            Assert.True(newGeneration.CurrentGeneration[3, 2]);
            Assert.False(newGeneration.CurrentGeneration[3, 3]);
            Assert.False(newGeneration.CurrentGeneration[3, 4]);

            // Fifth Line
            Assert.False(newGeneration.CurrentGeneration[4, 0]);
            Assert.False(newGeneration.CurrentGeneration[4, 1]);
            Assert.False(newGeneration.CurrentGeneration[4, 2]);
            Assert.False(newGeneration.CurrentGeneration[4, 3]);
            Assert.False(newGeneration.CurrentGeneration[4, 4]);
        }

        [Fact]
        public void Build_WithPatternBeaconPeriod2_HaveTheRightResult()
        {
            // Arrange
            var generationSize = new GenerationSize(6, 6);
            var generationNumber = 50;
            var expectedGenerationNumber = generationNumber + 1;
            var generation = new Generation(generationSize, generationNumber);
            generation.CurrentGeneration[1, 1] = true;
            generation.CurrentGeneration[2, 1] = true;
            generation.CurrentGeneration[1, 2] = true;
            generation.CurrentGeneration[4, 3] = true;
            generation.CurrentGeneration[3, 4] = true;
            generation.CurrentGeneration[4, 4] = true;

            var services = new NextGenerationService();

            // Act
            var newGeneration = services.Build(generation);

            //Assert
            Assert.Equal(expectedGenerationNumber, newGeneration.GenerationNumber);

            Assert.False(newGeneration.CurrentGeneration[0, 0]);
            Assert.False(newGeneration.CurrentGeneration[1, 0]);
            Assert.False(newGeneration.CurrentGeneration[2, 0]);
            Assert.False(newGeneration.CurrentGeneration[3, 0]);
            Assert.False(newGeneration.CurrentGeneration[4, 0]);
            Assert.False(newGeneration.CurrentGeneration[5, 0]);

            Assert.False(newGeneration.CurrentGeneration[0, 1]);
            Assert.True(newGeneration.CurrentGeneration[1, 1]);
            Assert.True(newGeneration.CurrentGeneration[2, 1]);
            Assert.False(newGeneration.CurrentGeneration[3, 1]);
            Assert.False(newGeneration.CurrentGeneration[4, 1]);
            Assert.False(newGeneration.CurrentGeneration[5, 1]);

            Assert.False(newGeneration.CurrentGeneration[0, 2]);
            Assert.True(newGeneration.CurrentGeneration[1, 2]);
            Assert.True(newGeneration.CurrentGeneration[2, 2]);
            Assert.False(newGeneration.CurrentGeneration[3, 2]);
            Assert.False(newGeneration.CurrentGeneration[4, 2]);
            Assert.False(newGeneration.CurrentGeneration[5, 2]);

            Assert.False(newGeneration.CurrentGeneration[0, 3]);
            Assert.False(newGeneration.CurrentGeneration[1, 3]);
            Assert.False(newGeneration.CurrentGeneration[2, 3]);
            Assert.True(newGeneration.CurrentGeneration[3, 3]);
            Assert.True(newGeneration.CurrentGeneration[4, 3]);
            Assert.False(newGeneration.CurrentGeneration[5, 3]);

            Assert.False(newGeneration.CurrentGeneration[0, 4]);
            Assert.False(newGeneration.CurrentGeneration[1, 4]);
            Assert.False(newGeneration.CurrentGeneration[2, 4]);
            Assert.True(newGeneration.CurrentGeneration[3, 4]);
            Assert.True(newGeneration.CurrentGeneration[4, 4]);
            Assert.False(newGeneration.CurrentGeneration[5, 4]);

            Assert.False(newGeneration.CurrentGeneration[0, 5]);
            Assert.False(newGeneration.CurrentGeneration[1, 5]);
            Assert.False(newGeneration.CurrentGeneration[2, 5]);
            Assert.False(newGeneration.CurrentGeneration[3, 5]);
            Assert.False(newGeneration.CurrentGeneration[4, 5]);
            Assert.False(newGeneration.CurrentGeneration[5, 5]);
        }

        [Fact]
        public void Build_WithPatternBeaconPeriod2_HaveTheRightResultAfterTwoGeneration()
        {
            // Arrange
            var generationSize = new GenerationSize(6, 6);
            var generationNumber = 50;
            var expectedGeneration1Number = generationNumber + 1;
            var expectedGeneration2Number = expectedGeneration1Number + 1;
            var generation = new Generation(generationSize, generationNumber);
            generation.CurrentGeneration[1, 1] = true;
            generation.CurrentGeneration[2, 1] = true;
            generation.CurrentGeneration[1, 2] = true;
            generation.CurrentGeneration[4, 3] = true;
            generation.CurrentGeneration[3, 4] = true;
            generation.CurrentGeneration[4, 4] = true;

            var services = new NextGenerationService();

            // Act
            var newGeneration1 = services.Build(generation);
            var newGeneration2 = services.Build(newGeneration1);

            //Assert

            // Generation 1
            Assert.Equal(expectedGeneration1Number, newGeneration1.GenerationNumber);

            Assert.False(newGeneration1.CurrentGeneration[0, 0]);
            Assert.False(newGeneration1.CurrentGeneration[1, 0]);
            Assert.False(newGeneration1.CurrentGeneration[2, 0]);
            Assert.False(newGeneration1.CurrentGeneration[3, 0]);
            Assert.False(newGeneration1.CurrentGeneration[4, 0]);
            Assert.False(newGeneration1.CurrentGeneration[5, 0]);

            Assert.False(newGeneration1.CurrentGeneration[0, 1]);
            Assert.True(newGeneration1.CurrentGeneration[1, 1]);
            Assert.True(newGeneration1.CurrentGeneration[2, 1]);
            Assert.False(newGeneration1.CurrentGeneration[3, 1]);
            Assert.False(newGeneration1.CurrentGeneration[4, 1]);
            Assert.False(newGeneration1.CurrentGeneration[5, 1]);

            Assert.False(newGeneration1.CurrentGeneration[0, 2]);
            Assert.True(newGeneration1.CurrentGeneration[1, 2]);
            Assert.True(newGeneration1.CurrentGeneration[2, 2]);
            Assert.False(newGeneration1.CurrentGeneration[3, 2]);
            Assert.False(newGeneration1.CurrentGeneration[4, 2]);
            Assert.False(newGeneration1.CurrentGeneration[5, 2]);

            Assert.False(newGeneration1.CurrentGeneration[0, 3]);
            Assert.False(newGeneration1.CurrentGeneration[1, 3]);
            Assert.False(newGeneration1.CurrentGeneration[2, 3]);
            Assert.True(newGeneration1.CurrentGeneration[3, 3]);
            Assert.True(newGeneration1.CurrentGeneration[4, 3]);
            Assert.False(newGeneration1.CurrentGeneration[5, 3]);

            Assert.False(newGeneration1.CurrentGeneration[0, 4]);
            Assert.False(newGeneration1.CurrentGeneration[1, 4]);
            Assert.False(newGeneration1.CurrentGeneration[2, 4]);
            Assert.True(newGeneration1.CurrentGeneration[3, 4]);
            Assert.True(newGeneration1.CurrentGeneration[4, 4]);
            Assert.False(newGeneration1.CurrentGeneration[5, 4]);

            Assert.False(newGeneration1.CurrentGeneration[0, 5]);
            Assert.False(newGeneration1.CurrentGeneration[1, 5]);
            Assert.False(newGeneration1.CurrentGeneration[2, 5]);
            Assert.False(newGeneration1.CurrentGeneration[3, 5]);
            Assert.False(newGeneration1.CurrentGeneration[4, 5]);
            Assert.False(newGeneration1.CurrentGeneration[5, 5]);

            // Generation 2
            Assert.Equal(expectedGeneration2Number, newGeneration2.GenerationNumber);

            Assert.False(newGeneration2.CurrentGeneration[0, 0]);
            Assert.False(newGeneration2.CurrentGeneration[1, 0]);
            Assert.False(newGeneration2.CurrentGeneration[2, 0]);
            Assert.False(newGeneration2.CurrentGeneration[3, 0]);
            Assert.False(newGeneration2.CurrentGeneration[4, 0]);
            Assert.False(newGeneration2.CurrentGeneration[5, 0]);

            Assert.False(newGeneration2.CurrentGeneration[0, 1]);
            Assert.True(newGeneration2.CurrentGeneration[1, 1]);
            Assert.True(newGeneration2.CurrentGeneration[2, 1]);
            Assert.False(newGeneration2.CurrentGeneration[3, 1]);
            Assert.False(newGeneration2.CurrentGeneration[4, 1]);
            Assert.False(newGeneration2.CurrentGeneration[5, 1]);

            Assert.False(newGeneration2.CurrentGeneration[0, 2]);
            Assert.True(newGeneration2.CurrentGeneration[1, 2]);
            Assert.False(newGeneration2.CurrentGeneration[2, 2]);
            Assert.False(newGeneration2.CurrentGeneration[3, 2]);
            Assert.False(newGeneration2.CurrentGeneration[4, 2]);
            Assert.False(newGeneration2.CurrentGeneration[5, 2]);

            Assert.False(newGeneration2.CurrentGeneration[0, 3]);
            Assert.False(newGeneration2.CurrentGeneration[1, 3]);
            Assert.False(newGeneration2.CurrentGeneration[2, 3]);
            Assert.False(newGeneration2.CurrentGeneration[3, 3]);
            Assert.True(newGeneration2.CurrentGeneration[4, 3]);
            Assert.False(newGeneration2.CurrentGeneration[5, 3]);

            Assert.False(newGeneration2.CurrentGeneration[0, 4]);
            Assert.False(newGeneration2.CurrentGeneration[1, 4]);
            Assert.False(newGeneration2.CurrentGeneration[2, 4]);
            Assert.True(newGeneration2.CurrentGeneration[3, 4]);
            Assert.True(newGeneration2.CurrentGeneration[4, 4]);
            Assert.False(newGeneration2.CurrentGeneration[5, 4]);

            Assert.False(newGeneration2.CurrentGeneration[0, 5]);
            Assert.False(newGeneration2.CurrentGeneration[1, 5]);
            Assert.False(newGeneration2.CurrentGeneration[2, 5]);
            Assert.False(newGeneration2.CurrentGeneration[3, 5]);
            Assert.False(newGeneration2.CurrentGeneration[4, 5]);
            Assert.False(newGeneration2.CurrentGeneration[5, 5]);
        }
    }
}