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
        private List<string> _categories;

        [SetUp]
        public void SetUp()
        {
            _categories = new List<string> { POP_CATEGORY, SCIENCE_CATEGORY, SPORTS_CATEGORY, ROCK_CATEGORY };
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
            var first = _board.GetCategory(0);
            var second = _board.GetCategory(1);
            var third = _board.GetCategory(2);
            var fourth  = _board.GetCategory(3);

            Assert.AreEqual(POP_CATEGORY, first);
            Assert.AreEqual(SCIENCE_CATEGORY, second);
            Assert.AreEqual(SPORTS_CATEGORY, third);
            Assert.AreEqual(ROCK_CATEGORY, fourth);
        }

        [Test]
        public void GetCategoryForEveryNthPositionReturnsSameCategory() //N = length of categories list
        {
            var second = _board.GetCategory(2);
            var sixth = _board.GetCategory(6);
            var tenth = _board.GetCategory(10);

            Assert.AreEqual(SPORTS_CATEGORY, second);
            Assert.AreEqual(SPORTS_CATEGORY, sixth);
            Assert.AreEqual(SPORTS_CATEGORY, tenth);
        }

    }
}
