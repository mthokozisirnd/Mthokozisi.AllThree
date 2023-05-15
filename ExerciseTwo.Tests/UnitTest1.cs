namespace ExerciseTwo.Tests
{
    public class StringCalculatorTests
    {
        [SetUp]
        public void InitFixture()
        {

        }

        [Test]
        public void ShouldReturnZeroForEmptyString()
        {
            Assert.That(
                StringCalculator.AddNumbers(String.Empty),
                Is.EqualTo(0)
            );
        }

        [TestCase(1, "1")]
        [TestCase(2, "2")]
        public void ShouldReturnNumberIfGivenOneNumber(int expected, string arg)
        {
            Assert.That(
                StringCalculator.AddNumbers(arg),
                Is.EqualTo(expected)
            );
        }

        [Test]
        [TestCase(3, "1,2")]
        [TestCase(11, "1,2,3,5")]
        public void ShouldReturnSumOfAllNumbers(int expected, string arg)
        {
            var result = StringCalculator.AddNumbers(arg);
            Assert.AreEqual(expected, result);
        }

        [Test]
        [TestCase(3, "1\n2")]
        [TestCase(11, "1,2\n3,5")]
        public void ShouldAllowNewLineAsASeparator(int expected, string arg)
        {
            var result = StringCalculator.AddNumbers(arg);
            Assert.AreEqual(expected, result);
        }

        [Test]
        [TestCase(3, "//;\n1;2")]
        [TestCase(11, "//.\n1.2\n3.5")]
        [TestCase(11, "//-\n1-2\n3-5")]
        public void ShouldSupportDifferentSeparators(int expected, string arg)
        {
            var result = StringCalculator.AddNumbers(arg);
            Assert.AreEqual(expected, result);
        }

        [Test]
        [TestCase(3, "//;\n-1;2")]
        [TestCase(3, "//;\n-1;-2")]
        public void ShouldThrowExceptionIfNegativeInArgs(int expected, string arg)
        {
            var result = StringCalculator.AddNumbers(arg);
            Assert.AreEqual(expected, result);
        }
    }
}