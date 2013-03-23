using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Trivia.Test
{
    [TestFixture]
    class CategoryTests
    {
        const string CategoryName = "CategoryName";
        readonly List<string> _questions = new List<string> { "Q1", "Q2", "Q3", "Q4", "Q5", "Q6" };
        private Category _category;

        [SetUp]
        public void SetUp()
        {
            _category = new Category(CategoryName, _questions);
        }

        [Test]
        public void PullNextQuestionIteratesToNextQuestion()
        {
            var expectedQuestion = _questions[1];
            _category.MoveNextQuestion(); 
            var secondQuestion = _category.ReadQuestion();
            Assert.AreEqual(expectedQuestion, secondQuestion);
        }

        [Test]
        public void ReadQuestionReturnsFirstQuestion()
        {
            var expectedQuestion = _questions[0];
            var question = _category.ReadQuestion();
            Assert.AreEqual(expectedQuestion, question);
        }


    }
}
