using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trivia
{
    public class Board
    {
        private readonly int _size;
        private List<Category> _questionCategories;

        public Board(int size, List<Category> questionCategories)
        {
            _size = size;
            _questionCategories = questionCategories;
        }

        public int CalculateNewPosition(int previous, int roll)
        {
            var position = previous + roll;
            if (position >= _size)
            {
                position -= _size;
            }
            return position;
        }

        public string GetCategoryName(int position)
        {
            return GetCategory(position).Name;
        }

        public string GetNextQuestion(int position)
        {
            var category = GetCategory(position);
            var question = category.ReadQuestion();
            category.MoveNextQuestion();
            return question;

        }

        private Category GetCategory(int position)
        {
            return _questionCategories[position%_questionCategories.Count];
        }
    }
}
