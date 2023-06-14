using overlap.lib.Figures;

namespace overlap.test
{
    public class OrientedCuboidsTests
    {
        [Test]
        [TestCase(2, 1, 3, 1, 4, 2, 2, 1, 3, 1, 4, 2, true, "The cuboids are equal")]
        [TestCase(2, 2, 2, 2, 1, 3, 10, 10, 10, 2, 2, 1, false, "The cuboids don't touch to each other")]
        [TestCase(1, 1, 2, 2, 2, 4, 3, 2, 3, 2, 2, 4, true, "The cuboids are tangent to each other")]
        [TestCase(2, 2, 2, 4, 3, 5, 2, 2, 2, 2, 3, 2, true, "Both cuboids have the same center but different edges")]
        [TestCase(2, 2, 2, 10, 10, 11, 2, 2, 2, 1, 1, 2, true, "One cuboid contains the other one and their centers are different")]
        [TestCase(1, 1, 2, 2, 2, 4, 2, 1, 1, 4, 2, 2, true, "The cuboids intersect to each other")]
        [TestCase(-1, 1, 1, 2, 2, 2, 1, 1, 1, 2, 2, 2, true, "Tangent cuboids and cube A's center has negative coordinates")]
        [TestCase(2, 2, 2, 1, 1, 1, -2, -2, -2, 1, 1, 1, false, "External cuboids and cuboid B's center has negative coordinates")]
        [TestCase(-2, -2, -2, 2, 2, 2, -3, -2, -2, 2, 2, 2, true, "Cuboids intersects to each other and both has negative coordinates")]
        [Parallelizable(ParallelScope.All)]
        public void PositiveAndNegativeIntersectionChecksForCuboidsDifferentValidScenarios(
            double cuboid_a_x, double cuboid_a_y, double cuboid_a_z, double cuboid_a_edge_x_length, double cuboid_a_edge_y_length, double cuboid_a_edge_z_length,
            double cuboid_b_x, double cuboid_b_y, double cuboid_b_z, double cuboid_b_edge_x_length, double cuboid_b_edge_y_length, double cuboid_b_edge_z_length,
            bool expectedResult, string description)
        {
            OrientedCuboid cuboidA = new(cuboid_a_x, cuboid_a_y, cuboid_a_z, cuboid_a_edge_x_length, cuboid_a_edge_y_length, cuboid_a_edge_z_length);
            OrientedCuboid cuboidB = new(cuboid_b_x, cuboid_b_y, cuboid_b_z, cuboid_b_edge_x_length, cuboid_b_edge_y_length, cuboid_b_edge_z_length);

            bool result = cuboidA.Intersects(cuboidB);
            Assert.That(result, Is.EqualTo(expectedResult), $"Unexpected result on test case '{description}'.");
        }

        [Test]
        [TestCase(2, 2, 2, 2, 2, 2, 2, 2, true, "The cubes are equal")]
        [TestCase(2, 2, 2, 2, 6, 11, 10, 2, false, "The cubes don't touch to each other")]
        [TestCase(2, 2, 2, 2, 2, 3, 4, 2, true, "The cubes are tangent to each other")]
        [TestCase(2, 2, 2, 2, 2, 2, 2, 3, true, "Both cubes have the same center but different edges")]
        [TestCase(2, 2, 2, 10, 3, 2, 2, 1, true, "One cube contains the other one and their centers are different")]
        [TestCase(2, 2, 2, 2, 3, 2, 2, 2, true, "The cubes intersect to each other")]
        [TestCase(-1, 1, 1, 2, 1, 1, 1, 2, true, "Tangent cubes and cube A's center has negative coordinates")]
        [TestCase(2, 2, 2, 2, -2, 2, 2, 2, false, "External cubes and cube B's center has negative coordinates")]
        [TestCase(-2, -2, -2, 2, -3, -2, -2, 2, true, "Cubes intersects to each other and both has negative coordinates")]
        [Parallelizable(ParallelScope.All)]
        public void IntersectionChecksForCubesDifferentValidScenarios(
            double cube_a_x, double cube_a_y, double cube_a_z, double cube_a_edge_length,
            double cube_b_x, double cube_b_y, double cube_b_z, double cube_b_edge_length, 
            bool expectedResult, string description)
        {
            OrientedCube cubeA = new(cube_a_x, cube_a_y, cube_a_z, cube_a_edge_length);
            OrientedCube cubeB = new(cube_b_x, cube_b_y, cube_b_z, cube_b_edge_length);

            bool result = cubeA.Intersects(cubeB);
            Assert.That(result, Is.EqualTo(expectedResult), $"Unexpected result on test case '{description}'.");
        }

        [Test]
        [TestCase(2, 2, 2, 1, 10, 10, 10, 2, 2, 1, false, "The cuboids don't touch to each other")]
        [TestCase(2, 2, 2, 2, 3, 2, 3, 2, 2, 4, true, "The cuboids are tangent to each other")]
        [TestCase(2, 2, 2, 4, 2, 2, 2, 2, 3, 2, true, "Both cuboids have the same center but different edges")]
        [Parallelizable(ParallelScope.All)]
        public void CombineCubesAndCuboidsDifferentValidScenarios(
            double cube_x, double cube_y, double cube_z, double cube_edge_length,
            double cuboid_x, double cuboid_y, double cuboid_z, double cuboid_edge_x_length, double cuboid_edge_y_length, double cuboid_edge_z_length,
            bool expectedResult, string description)
        {

            OrientedCube cube = new(cube_x, cube_y, cube_z, cube_edge_length);
            OrientedCuboid cuboid = new(cuboid_x, cuboid_y, cuboid_z, cuboid_edge_x_length, cuboid_edge_y_length, cuboid_edge_z_length);

            bool resultA = cube.Intersects(cuboid);
            bool resultB = cuboid.Intersects(cube);
            Assert.That(resultA, Is.EqualTo(expectedResult), $"Unexpected result on test case '{description}'.");
            Assert.That(resultA, Is.EqualTo(resultB), $"Commutative property not satisfied in test case {description}");
        }

        [Test]
        [TestCase(0, 0, 0, 0, 1, 2, "Edge x length is zero")]
        [TestCase(1, 1, 1, 1, -2, 2, "Edge y length is negative")]
        [TestCase(1, 1, 1, 1, 2, -2, "Edge z length is negative")]
        [Parallelizable(ParallelScope.All)]
        public void ThrowsExceptionWhenEdgesLengthsAreNotPositive(double cube_x, double cube_y, double cube_z,
            double edge_X_length, double edge_Y_length, double edge_Z_length, string description)
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () => new OrientedCuboid(cube_x, cube_y, cube_z, edge_X_length, edge_Y_length, edge_Z_length),
                $"Unexpected result on test case '{description}'.");
        }

        [Test]
        [TestCase(2, 2, 2, 2, 2, 3, 2, 2, 2, 3, 2, 2, true, "The cuboids overlap to each other")]
        [TestCase(2, 2, 2, 2, 1, 2, 6, 6, 6, 1, 1, 2, false, "The cuboids doesn't touch to each other")]
        [Parallelizable(ParallelScope.All)]
        public void SatisfiesConmutativeProperty(
            double cube_a_x, double cube_a_y, double cube_a_z, double cube_a_edge_x_length, double cube_a_edge_y_length, double cube_a_edge_z_length,
            double cube_b_x, double cube_b_y, double cube_b_z, double cube_b_edge_x_length, double cube_b_edge_y_length, double cube_b_edge_z_length,
            bool expectedResult, string description)
        {
            OrientedCuboid cubeA = new(cube_a_x, cube_a_y, cube_a_z, cube_a_edge_x_length, cube_a_edge_y_length, cube_a_edge_z_length);
            OrientedCuboid cubeB = new(cube_b_x, cube_b_y, cube_b_z, cube_b_edge_x_length, cube_b_edge_y_length, cube_b_edge_z_length);

            bool resultA = cubeA.Intersects(cubeB);
            bool resultB = cubeB.Intersects(cubeA);

            Assert.That(resultA, Is.EqualTo(expectedResult), $"Unexpected result on test case '{description}'.");
            Assert.That(resultA, Is.EqualTo(resultB), $"Commutative property not satisfied in test case {description}");
        }
    }
}