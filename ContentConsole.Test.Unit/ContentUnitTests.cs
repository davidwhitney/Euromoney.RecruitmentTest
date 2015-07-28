namespace ContentConsole.Test.Unit
{
    using System;
    using System.Collections.Generic;
    using ContentConsole.Core;
    using NUnit.Framework;

    /// <summary>
    /// A class containing all the
    /// unit tests to be run.
    /// </summary>
    [TestFixture]
    public class ContentUnitTests
    {
        private SharedMethod shared;

        public ContentUnitTests()
        {
            shared = new SharedMethod();
        }

        #region Story 1

        /// <summary>
        /// Simple test as a user
        /// using the default sentence.
        /// </summary>
        [Test]
        public void BasicUserTest()
        {
            // Arrange            
            int predictedCount = 2;
            string sentence = "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";

            // Act
            int actualCount = shared.CountBannedWords(sentence);

            // Assert
            Assert.AreEqual(predictedCount, actualCount);
        }

        /// <summary>
        /// Test where all words in
        /// the sentence are banned.
        /// </summary>
        [Test]
        public void AllBannedWordsUserTest()
        {
            // Arrange
            int predictedCount = 4;
            string sentence = "Swine, bad, nasty, horrible.";

            // Act
            int actualCount = shared.CountBannedWords(sentence);

            // Assert
            Assert.AreEqual(predictedCount, actualCount);
        }

        /// <summary>
        /// Test where there are
        /// no banned words.
        /// </summary>
        [Test]
        public void NoBannedWordsUserTest()
        {
            // Arrange
            int predictedCount = 0;
            string sentence = "There are no banned words in this sentence.";

            // Act
            int actualCount = shared.CountBannedWords(sentence);

            // Assert
            Assert.AreEqual(predictedCount, actualCount);
        }

        /// <summary>
        /// Test passing an empty string
        /// through as a sentence.
        /// </summary>
        [Test]
        public void EmptyStringUserTest()
        {
            // Arrange
            int predictedCount = 0;
            string sentence = string.Empty;

            // Act
            int actualCount = shared.CountBannedWords(sentence);

            // Assert
            Assert.AreEqual(predictedCount, actualCount);
        }

        #endregion Story 1

        #region Story 2

        /// <summary>
        /// Simple test as an admin
        /// where the list of banned
        /// words will be retrieved.
        /// </summary>
        [Test]
        public void BasicAdminListTest()
        {
            // Arrange
            List<string> predictedOutput = new List<string> { "swine", "bad", "nasty", "horrible" };

            // Act
            List<string> actualOutput = shared.PrintBannedList();

            // Assert
            Assert.AreEqual(predictedOutput, actualOutput);
        }

        /// <summary>
        /// Simple test as an admin
        /// where the list of banned
        /// words will be retrieved
        /// but the predicted output
        /// will be different.
        /// </summary>
        [Test]
        public void NotEqualAdminListTest()
        {
            // Arrange
            List<string> predictedOutput = new List<string> { "these", "are", "not", "the", "right", "words" };

            // Act
            List<string> actualOutput = shared.PrintBannedList();

            // Assert
            Assert.AreNotEqual(predictedOutput, actualOutput);
        }

        /// <summary>
        /// Adding one value to the list
        /// </summary>
        [Test]
        public void BasicAdminAddToListTest()
        {
            // Arrange
            List<string> wordToAdd = new List<string> { "negative" };
            List<string> predictedOutput = new List<string> { "swine", "bad", "nasty", "horrible", "negative" };

            // Act
            List<string> actualOutput = shared.AddWordsToBannedList(wordToAdd);

            // Assert
            Assert.AreEqual(predictedOutput, actualOutput);

            // Reset list so it doesn't affect the other tests
            shared.ResetBannedList();
        }

        /// <summary>
        /// Adding multiple values to the list
        /// </summary>
        [Test]
        public void AdminAddMultipleToListTest()
        {
            // Arrange
            List<string> wordsToAdd = new List<string> { "negative", "disgust", "banned" };
            List<string> predictedOutput = new List<string> { "swine", "bad", "nasty", "horrible", "negative", "disgust", "banned" };

            // Act
            List<string> actualOutput = shared.AddWordsToBannedList(wordsToAdd);

            // Assert
            Assert.AreEqual(predictedOutput, actualOutput);

            // Reset list so it doesn't affect the other tests
            shared.ResetBannedList();
        }

        /// <summary>
        /// Adding null value to the list
        /// </summary>
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AdminAddNullToListTest()
        {
            // Arrange
            List<string> wordToAdd = new List<string> { null };            

            // Act
            List<string> actualOutput = shared.AddWordsToBannedList(wordToAdd);

            // Assert
            // Nothing to assert as it should throw an exception

            // Reset list so it doesn't affect the other tests
            shared.ResetBannedList();
        }

        /// <summary>
        /// Removing one value from the list
        /// </summary>
        [Test]
        public void BasicAdminRemoveFromListTest()
        {
            // Arrange
            List<string> wordToRemove = new List<string> { "bad" };
            List<string> predictedOutput = new List<string> { "swine", "nasty", "horrible" };

            // Act
            List<string> actualOutput = shared.RemoveWordsFromBannedList(wordToRemove);

            // Assert
            Assert.AreEqual(predictedOutput, actualOutput);

            // Reset list so it doesn't affect the other tests
            shared.ResetBannedList();
        }

        /// <summary>
        /// Removing multiple values from the list
        /// </summary>
        [Test]
        public void AdminRemoveMultipleFromListTest()
        {
            // Arrange
            List<string> wordsToRemove = new List<string> { "swine", "bad" };
            List<string> predictedOutput = new List<string> { "nasty", "horrible" };

            // Act
            List<string> actualOutput = shared.RemoveWordsFromBannedList(wordsToRemove);

            // Assert
            Assert.AreEqual(predictedOutput, actualOutput);

            // Reset list so it doesn't affect the other tests
            shared.ResetBannedList();
        }

        /// <summary>
        /// Removing all the values from the list
        /// </summary>
        [Test]
        public void AdminRemoveAllFromListTest()
        {
            // Arrange
            List<string> wordsToRemove = new List<string> { "swine", "bad", "nasty", "horrible" };
            List<string> predictedOutput = new List<string> { "List of banned words is empty." };

            // Act
            List<string> actualOutput = shared.RemoveWordsFromBannedList(wordsToRemove);

            // Assert
            Assert.AreEqual(predictedOutput, actualOutput);

            // Reset list so it doesn't affect the other tests
            shared.ResetBannedList();
        }

        /// <summary>
        /// Removing null value from the list
        /// </summary>
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AdminRemoveNullFromListTest()
        {
            // Arrange
            List<string> wordToRemove = new List<string> { null };

            // Act
            List<string> actualOutput = shared.RemoveWordsFromBannedList(wordToRemove);

            // Assert
            // Nothing to assert as it should throw an exception

            // Reset list so it doesn't affect the other tests
            shared.ResetBannedList();
        }

        /// <summary>
        /// Removing value from the list
        /// that isn't present.
        /// </summary>
        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AdminRemoveWrongValueFromListTest()
        {
            // Arrange
            List<string> wordToRemove = new List<string> { "asdf" };

            // Act
            List<string> actualOutput = shared.RemoveWordsFromBannedList(wordToRemove);

            // Assert
            // Nothing to assert as it should throw an exception

            // Reset list so it doesn't affect the other tests
            shared.ResetBannedList();
        }

        /// <summary>
        /// Clearing the list of banned words
        /// </summary>
        [Test]
        public void AdminClearListTest()
        {
            // Arrange
            string predictedOutput = "List of banned words successfully cleared.";

            // Act
            string actualOutput = shared.ClearBannedList();

            // Assert
            Assert.AreEqual(predictedOutput, actualOutput);

            // Reset list so it doesn't affect the other tests
            shared.ResetBannedList();
        }

        #endregion Story 2

        #region Story 3

        /// <summary>
        /// Simple test as a reader
        /// using the default sentence.
        /// </summary>
        [Test]
        public void BasicReaderTest()
        {
            // Arrange
            string sentence = "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";
            string predictedOutput = "the weather in manchester in winter is b#d. it rains all the time - it must be h######e for people visiting.";

            // Act
            string actualOutput = shared.MaskBannedWords(sentence);

            // Assert
            Assert.AreEqual(predictedOutput, actualOutput);
        }

        /// <summary>
        /// Simple test as a reader
        /// using all banned words.
        /// </summary>
        [Test]
        public void AllBannedWordsReaderTest()
        {
            // Arrange
            string sentence = "Swine, bad, nasty, horrible.";
            string predictedOutput = "s###e, b#d, n###y, h######e.";

            // Act
            string actualOutput = shared.MaskBannedWords(sentence);

            // Assert
            Assert.AreEqual(predictedOutput, actualOutput);
        }

        /// <summary>
        /// Simple test as a reader
        /// using no banned words.
        /// </summary>
        [Test]
        public void NoBannedWordsReaderTest()
        {
            // Arrange
            string sentence = "There are no banned words in this sentence.";
            string predictedOutput = "there are no banned words in this sentence.";

            // Act
            string actualOutput = shared.MaskBannedWords(sentence);

            // Assert
            Assert.AreEqual(predictedOutput, actualOutput);
        }

        #endregion Story 3

        // Not sure if this was needed
        // as the requirements for Story
        // 1 & 4 seem to be identical.
        // (From my understanding anyways.)
        #region Story 4
        #endregion Story 4
    }
}
