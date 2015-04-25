namespace ContentConsole.Test.Unit
{
    using NUnit.Framework;

    [TestFixture]
    class TextAnalyzerTests
    {
        [Test]
        public void GivenEmptyString_Returns0()
        {
            var input = string.Empty;

            var result = TextAnalyzer.CountBadWords(input);

            Assert.AreEqual(0, result);
        }

        [Test]
        public void GivenOneBadWord_Returns1()
        {
            const string input = "bad";

            var result = TextAnalyzer.CountBadWords(input);

            Assert.AreEqual(1, result);
        }

        [Test]
        public void GivenOneNotBadWord_Returns1()
        {
            const string input = "hello";

            var result = TextAnalyzer.CountBadWords(input);

            Assert.AreEqual(0, result);
        }

        [Test]
        public void Given3BadWordsAnd3NotBadWord_Returns3()
        {
            const string input = "bad bad bad good good good";

            var result = TextAnalyzer.CountBadWords(input);

            Assert.AreEqual(3, result);
        }
    }
}
