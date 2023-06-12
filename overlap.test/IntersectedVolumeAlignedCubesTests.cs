using overlap.lib.Figures;

namespace overlap.test
{
    public class IntersectedVolumeAlignedCubesTests
    {
        [Test]
        [TestCase(2, 2, 2, 2, 2, 2, 2, 2, 8, "The cubes are equals")]
        [TestCase(2, 2, 2, 2, 2, 2, 10, 2, 0, "The cubes don't touch to each other")]
        [TestCase(2, 2, 2, 2, 2, 2, 4, 2, 0, "The cubes are tangent to each other")]
        [TestCase(2, 2, 2, 2, 2, 2, 2, 3, 8, "Both cubes have the same center but different edges")]
        [TestCase(2, 2, 2, 10, 3, 2, 2, 1, 1, "One cube contains the other one and their centers are different")]
        [TestCase(2, 2, 2, 2, 3, 2, 2, 2, 4, "The cubes intersect to each other")]
        [TestCase(-1, 1, 1, 2, 1, 1, 1, 2, 0, "Tangent cubes and cube A's center has negative coordinates")]
        [TestCase(2, 2, 2, 2, -2, 2, 2, 2, 0, "External cubes and cube B's center has negative coordinates")]
        [TestCase(-2, -2, -2, 2, -3, -2, -2, 2, 4, "Cubes intersects to each other and both has negative coordinates")]
        public void CalculateIntersectionVolumeForDifferentValidScenarios(
            double cube_a_x, double cube_a_y, double cube_a_z, double cube_a_edge_length,
            double cube_b_x, double cube_b_y, double cube_b_z, double cube_b_edge_length, 
            double expectedResult, string description)
        {
            AlignedCube cubeA = new(cube_a_x, cube_a_y, cube_a_z, cube_a_edge_length);
            AlignedCube cubeB = new(cube_b_x, cube_b_y, cube_b_z, cube_b_edge_length);

            double result = cubeA.IntersectedVolume(cubeB);
            Assert.That(result, Is.EqualTo(expectedResult), $"Unexpected result on test case '{description}'.");
        }

        //[Test]
        //[TestCase(2, 3, 4, 5, 1, 1, 1, 3, 64, "Test Case 1")]
        //[TestCase(0, 0, 0, 2, 4, 4, 4, 6, 0, "Test Case 2")]
        //[TestCase(-1, -1, -1, 4, 3, 3, 3, 5, 8, "Test Case 3")]
        //[TestCase(5, 5, 5, 7, 2, 2, 2, 4, 64, "Test Case 4")]
        //[TestCase(-2, -2, -2, 3, 1, 1, 1, 4, 1, "Test Case 5")]
        //[TestCase(3, 3, 3, 6, -1, -1, -1, 5, 64, "Test Case 6")]
        //[TestCase(0, 0, 0, 4, 2, 2, 2, 6, 27, "Test Case 7")]
        //[TestCase(2, 2, 2, 3, 1, 1, 1, 4, 1, "Test Case 8")]
        //[TestCase(-1, -1, -1, 5, 4, 4, 4, 7, 27, "Test Case 9")]
        //[TestCase(1, 1, 1, 4, 3, 3, 3, 6, 16, "Test Case 10")]
        //public void CalculateIntersectionVolumeForRandomScenarios(
        //    double cube_a_x, double cube_a_y, double cube_a_z, double cube_a_edge_length,
        //    double cube_b_x, double cube_b_y, double cube_b_z, double cube_b_edge_length, 
        //    double expectedResult, string description)
        //{
        //    AlignedCube cubeA = new(cube_a_x, cube_a_y, cube_a_z, cube_a_edge_length);
        //    AlignedCube cubeB = new(cube_b_x, cube_b_y, cube_b_z, cube_b_edge_length);

        //    double result = cubeA.IntersectedVolume(cubeB);
        //    Assert.That(result, Is.EqualTo(expectedResult), $"Unexpected result on test case '{description}'.");
        //}

        [Test]
        [TestCase(2, 2, 2, 2, 2, 2, 2, 2, 8, "The cubes are equals")]
        [TestCase(2, 2, 2, 2, 2, 2, 10, 2, 0, "The cubes don't touch to each other")]
        [TestCase(2, 2, 2, 2, 2, 2, 4, 2, 0, "The cubes are tangent to each other")]
        [TestCase(2, 2, 2, 2, 2, 2, 2, 3, 8, "Both cubes have the same center but different edges")]
        [TestCase(2, 2, 2, 10, 3, 2, 2, 1, 1, "One cube contains the other one and their centers are different")]
        [TestCase(2, 2, 2, 2, 3, 2, 2, 2, 4, "The cubes intersect to each other")]
        [TestCase(-1, 1, 1, 2, 1, 1, 1, 2, 0, "Tangent cubes and cube A's center has negative coordinates")]
        [TestCase(2, 2, 2, 2, -2, 2, 2, 2, 0, "External cubes and cube B's center has negative coordinates")]
        [TestCase(-2, -2, -2, 2, -3, -2, -2, 2, 4, "Cubes intersects to each other and both has negative coordinates")]
        public void SatisfiesConmutativeProperty(
            double cube_a_x, double cube_a_y, double cube_a_z, double cube_a_edge_length,
            double cube_b_x, double cube_b_y, double cube_b_z, double cube_b_edge_length,
            double expectedResult, string description)
        {

            AlignedCube cubeA = new(cube_a_x, cube_a_y, cube_a_z, cube_a_edge_length);
            AlignedCube cubeB = new(cube_b_x, cube_b_y, cube_b_z, cube_b_edge_length);

            double resultA = cubeA.IntersectedVolume(cubeB);
            double resultB = cubeB.IntersectedVolume(cubeA);
            Assert.That(resultA, Is.EqualTo(expectedResult), $"Unexpected result on test case '{description}'.");
            Assert.That(resultA, Is.EqualTo(resultB), $"Commutative property is not accomplished for test case: '{description}'");

        }
    }
}