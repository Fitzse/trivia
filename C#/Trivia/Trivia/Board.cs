using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trivia
{
    public class Board
    {
        private readonly int _size;
        private List<string> _questionCategories;

        public Board(int size, List<string> questionCategories)
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

        public string GetCategory(int position)
        {
            return _questionCategories[position % _questionCategories.Count];
        }
    }
}
