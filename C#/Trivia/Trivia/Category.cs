using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trivia
{
    public class Category
    {
        public Category(string categoryName, List<string> questions)
        {
            Name = categoryName;
            _questions = questions;
            _questions.RemoveAt(_questions.Count-1);
            _currentQuestionIndex = 0;
        }

        public string Name { get; set; }

        private readonly List<string> _questions;
        private int _currentQuestionIndex;

        public string ReadQuestion()
        {
            try
            {
                return _questions[_currentQuestionIndex];
            }
            catch (IndexOutOfRangeException)
            {
                throw new InvalidOperationException("The LinkedList is empty");
            }
        }

        public void MoveNextQuestion()
        {
            _currentQuestionIndex++;
        }
    }
}
