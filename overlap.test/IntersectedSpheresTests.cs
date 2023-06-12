using overlap.lib.Figures;

namespace overlap.test
{
    public class IntersectedSpheresTests
    {
        [Test]
        [TestCase(2, 2, 2, 2, 2, 2, 2, 2, true, "The spheres are equal")]
        [TestCase(2, 2, 2, 2, 2, 2, 10, 2, false, "The spheres don't touch to each other")]
        [TestCase(2, 2, 2, 2, 2, 2, 4, 2, true, "The spheres are tangent to each other")]
        [TestCase(2, 2, 2, 2, 2, 2, 2, 3, true, "Both spheres have the same center but different radius")]
        [TestCase(2, 2, 2, 10, 3, 2, 2, 1, true, "One sphere contains the other one and their centers are different")]
        [TestCase(2, 2, 2, 2, 3, 2, 2, 2, true, "The spheres intersect to each other")]
        [TestCase(-1, 1, 1, 2, 1, 1, 1, 2, true, "Tangent spheres and sphere A's center has negative coordinates")]
        [TestCase(2, 2, 2, 2, -2, 2, 2, 1, false, "External spheres and sphere B's center has negative coordinates")]
        [TestCase(-2, -2, -2, 2, -3, -2, -2, 2, true, "Spheres intersects to each other and both has negative coordinates")]
        [Parallelizable(ParallelScope.All)]
        public void PositiveAndNegativeIntersectionChecksForDifferentValidScenarios(
            double center_a_x, double center_a_y, double center_a_z, double radius_a,
            double center_b_x, double center_b_y, double center_b_z, double radius_b, 
            bool expectedResult, string description)
        {
            Sphere sphereA = new(center_a_x, center_a_y, center_a_z, radius_a);
            Sphere sphereB = new(center_b_x, center_b_y, center_b_z, radius_b);

            bool result = sphereA.Intersects(sphereB);
            Assert.That(result, Is.EqualTo(expectedResult), $"Unexpected result on test case '{description}'.");
        }

        [Test]
        [TestCase(0, 0, 0, 0, "Radius is zero")]
        [TestCase(1, 1, 1, -2, "Radius is negative")]
        [Parallelizable(ParallelScope.All)]
        public void ThrowsExceptionWhenEdgesLengthAreNotPositive(
            double center_x, double center_y, double center_z, double radius,
            string description)
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () => new Sphere(center_x, center_y, center_z, radius),
                $"Unexpected result on test case '{description}'.");
        }
         
        [Test]
        [TestCase(2, 2, 2, 2, 2, 2, 2, 2, true, "The spheres overlap to each other")]
        [TestCase(2, 2, 2, 2, 6, 11, 10, 2, false, "The spheres doesn't touch to each other")]
        [Parallelizable(ParallelScope.All)]
        public void SatisfiesConmutativeProperty(
            double center_a_x, double center_a_y, double center_a_z, double radius_a,
            double center_b_x, double center_b_y, double center_b_z, double radius_b,
            bool expectedResult, string description)
        {
            Sphere sphereA = new(center_a_x, center_a_y, center_a_z, radius_a);
            Sphere sphereB = new(center_b_x, center_b_y, center_b_z, radius_b);

            bool resultA = sphereA.Intersects(sphereB);
            bool resultB = sphereB.Intersects(sphereA);

            Assert.That(resultA, Is.EqualTo(expectedResult), $"Unexpected result on test case '{description}'.");
            Assert.That(resultA, Is.EqualTo(resultB), $"Commutative property not satisfied in test case {description}");

        }
    }
}