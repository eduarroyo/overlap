using overlap.lib.Figures;

namespace overlap.test
{
    public class OverlapAlignedCubesTests
    {
        [Test]
        [TestCase(2, 2, 2, 2, 2, 2, 2, 2, true, "The cubes are equals")]
        [TestCase(2, 2, 2, 2, 2, 2, 10, 2, false, "The cubes doesn't touch to each other, with aligned centers")]
        [TestCase(2, 2, 2, 2, 6, 11, 10, 2, false, "The cubes doesn't touch to each other, with non-aligned centers")]
        [TestCase(2, 2, 2, 2, 2, 2, 4, 2, true, "The cubes are tangent to each other")]
        [TestCase(2, 2, 2, 2, 2, 2, 2, 3, true, "Both cubes have the same center but different edges")]
        [TestCase(2, 2, 2, 10, 3, 2, 2, 1, true, "One cube contains the other one and their centers are different")]
        [TestCase(2, 2, 2, 2, 2, 2, 2, 2, true, "The cubes overlap to each other")]
        [TestCase(-1, 1, 1, 2, 1, 1, 1, 2, true, "Tangent cubes and cube A's center has negative coordinates")]
        [TestCase(2, 2, 2, 2, -2, 2, 2, 2, false, "External cubes and cube B's center has negative coordinates")]
        [TestCase(-2, -2, -2, 2, -3, -2, -2, 2, true, "Cubes intersects to each other and both has negative coordinates")]
        [Parallelizable(ParallelScope.All)]
        public void PositiveAndNegativeIntersectionChecksForDifferentValidScenarios(
            double cube_a_x, double cube_a_y, double cube_a_z, double cube_a_edge_length,
            double cube_b_x, double cube_b_y, double cube_b_z, double cube_b_edge_length, 
            bool expectedResult, string description)
        {
            AlignedCube cubeA = new(cube_a_x, cube_a_y, cube_a_z, cube_a_edge_length);
            AlignedCube cubeB = new(cube_b_x, cube_b_y, cube_b_z, cube_b_edge_length);

            bool result = cubeA.intersects(cubeB);
            Assert.That(expectedResult, Is.EqualTo(result), $"Unexpected result on test case '{description}'.");
        }

        [Test]
        [TestCase(0, 0, 0, 0, "Edge length is zero")]
        [TestCase(1, 1, 1, -2, "Edge length is negative")]
        [Parallelizable(ParallelScope.All)]
        public void ThrowsExceptionWhenEdgesLengthAreNotPositive(
            double cube_x, double cube_y, double cube_z, double cube_edge_length,
            string description)
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () => new AlignedCube(cube_x, cube_y, cube_z, cube_edge_length),
                $"Unexpected result on test case '{description}'.");
        }

        [Test]
        [TestCase(2, 2, 2, 2, 2, 2, 2, 2, true, "The cubes overlap to each other")]
        [TestCase(2, 2, 2, 2, 6, 11, 10, 2, false, "The cubes doesn't touch to each other, with non-aligned centers")]
        [Parallelizable(ParallelScope.All)]
        public void SatisfiesConmutativeProperty(
            double cube_a_x, double cube_a_y, double cube_a_z, double cube_a_edge_length,
            double cube_b_x, double cube_b_y, double cube_b_z, double cube_b_edge_length,
            bool expectedResult, string description)
        {
            AlignedCube cubeA = new(cube_a_x, cube_a_y, cube_a_z, cube_a_edge_length);
            AlignedCube cubeB = new(cube_b_x, cube_b_y, cube_b_z, cube_b_edge_length);

            bool resultA = cubeA.intersects(cubeB);
            bool resultB = cubeB.intersects(cubeA);

            Assert.That(expectedResult, Is.EqualTo(resultA), $"Unexpected result on test case '{description}'.");
            Assert.That(resultA, Is.EqualTo(resultB), $"Commutative property not satisfied in test case {description}");

        }
    }
}