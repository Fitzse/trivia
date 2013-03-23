using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trivia.Test
{
    [TestFixture]
    public class BoardTests
    {
        private const int BOARD_SIZE = 12;
        private const string POP_CATEGORY = "Pop";
        private const string SCIENCE_CATEGORY = "Science";
        private const string SPORTS_CATEGORY = "Sports";
        private const string ROCK_CATEGORY = "Rock";
        private Board _board;
        private List<Category> _categories;

        [SetUp]
        public void SetUp()
        {
            _categories = new List<Category>
                {
                    CreateCategoryFromName(POP_CATEGORY),
                    CreateCategoryFromName(SCIENCE_CATEGORY),
                    CreateCategoryFromName(SPORTS_CATEGORY),
                    CreateCategoryFromName(ROCK_CATEGORY)
                };
            _board = new Board(BOARD_SIZE, _categories);
        }

        [Test]
        public void CalculateNewPositionAddsRollToPreviousPosition()
        {
            const int previous = 4;
            const int roll = 6;
            var newPosition = _board.CalculateNewPosition(previous, roll);

            Assert.AreEqual(10, newPosition);
        }

        [Test]
        public void CalculateNewPositionWrapsTo0IfAdditionOfPreviousAndRollEqualToBoardSize()
        {
            const int previous = 6;
            const int roll = 6;
            var newPosition = _board.CalculateNewPosition(previous, roll);

            Assert.AreEqual(0, newPosition);
        }

        [Test]
        public void CalculateNewPositionWrapsAroundIfAdditionOfPreviousAndRollGreaterThanBoardSize()
        {
            const int previous = 10;
            const int roll = 6;
            var newPosition = _board.CalculateNewPosition(previous, roll);

            Assert.AreEqual(4, newPosition);
        }

        [Test]
        public void GetCategoryForStartingPositionsReturnsCategoriesSuppliedInConstructorInOrder()
        {
            var first = _board.GetCategoryName(0);
            var second = _board.GetCategoryName(1);
            var third = _board.GetCategoryName(2);
            var fourth  = _board.GetCategoryName(3);

            Assert.AreEqual(POP_CATEGORY, first);
            Assert.AreEqual(SCIENCE_CATEGORY, second);
            Assert.AreEqual(SPORTS_CATEGORY, third);
            Assert.AreEqual(ROCK_CATEGORY, fourth);
        }

        [Test]
        public void GetCategoryForEveryNthPositionReturnsSameCategory() //N = length of categories list
        {
            var second = _board.GetCategoryName(2);
            var sixth = _board.GetCategoryName(6);
            var tenth = _board.GetCategoryName(10);

            Assert.AreEqual(SPORTS_CATEGORY, second);
            Assert.AreEqual(SPORTS_CATEGORY, sixth);
            Assert.AreEqual(SPORTS_CATEGORY, tenth);
        }

        [Test]
        public void GetNextQuestionReturnsNextQuestionForCategoryOfPosition()
        {
            var position = 5;
            var expectedQuestion = "Science Question 0";
            var question = _board.GetNextQuestion(position);
            Assert.AreEqual(expectedQuestion, question);
        }

        [Test]
        public void GetNextQuestionIteratesQuestionForCategory()
        {
            var position = 5;
            var expectedQuestion = "Science Question 1";
            _board.GetNextQuestion(position);
            var question = _board.GetNextQuestion(position);
            Assert.AreEqual(expectedQuestion, question);
        }

        private static Category CreateCategoryFromName(string name)
        {
            var questions = Enumerable.Range(0, 50).Select(n => name + " Question " + n).ToList();
            return new Category(name, questions);
        }
    }
}
