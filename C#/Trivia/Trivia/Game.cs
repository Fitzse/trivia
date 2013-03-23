using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trivia;

namespace UglyTrivia
{
    public class Game
    {
        private const int BOARD_SIZE = 12;
        private List<Player> _players = new List<Player>();
        private const int WINNING_COINS = 6;
        private int currentPlayerIndex = 0;

        private Player CurrentPlayer
        {
            get { return _players[currentPlayerIndex]; }
        }

        private Board _board;

        private bool _isGettingOutOfPenaltyBox;

        public Game()
        {
            var categories = new List<string> {"Pop", "Science", "Sports", "Rock"}
                .Select(CreateCategoryFromName).ToList();

            _board = new Board(BOARD_SIZE, categories);
        }

        private static Category CreateCategoryFromName(string name)
        {
            var questions = Enumerable.Range(0, 50).Select(n => name + " Question " + n).ToList();
            return new Category(name, questions);
        }

        public bool isPlayable()
        {
            return (howManyPlayers() >= 2);
        }

        public bool add(String playerName)
        {
            _players.Add(new Player(playerName));

            Console.WriteLine(playerName + " was added");
            Console.WriteLine("They are player number " + _players.Count);
            return true;
        }

        public int howManyPlayers()
        {
            return _players.Count;
        }

        public void roll(int roll)
        {
            Console.WriteLine(CurrentPlayer.Name + " is the current player");
            Console.WriteLine("They have rolled a " + roll);

            if (CurrentPlayer.IsInPenaltyBox)
            {
                PenaltyBoxRoll(roll);
            }
            else
            {
                ExecutePlayerTurn(roll);
            }
        }

        private void PenaltyBoxRoll(int roll)
        {
            if (IsOdd(roll))
            {
                _isGettingOutOfPenaltyBox = true;
                Console.WriteLine(CurrentPlayer.Name + " is getting out of the penalty box");

                ExecutePlayerTurn(roll);
            }
            else
            {
                _isGettingOutOfPenaltyBox = false;
                Console.WriteLine(CurrentPlayer.Name + " is not getting out of the penalty box");
            }
        }

        private static bool IsOdd(int roll)
        {
            return roll%2 != 0;
        }

        private void ExecutePlayerTurn(int roll)
        {
            CurrentPlayer.BoardPosition = _board.CalculateNewPosition(CurrentPlayer.BoardPosition, roll);
            Console.WriteLine(CurrentPlayer.Name
                              + "'s new location is "
                              + CurrentPlayer.BoardPosition);
            Console.WriteLine("The category is " + GetCurrentCategory());
            AskQuestion();
        }

        private void AskQuestion()
        {
            var question = _board.GetNextQuestion(CurrentPlayer.BoardPosition);
            Console.WriteLine(question);
        }

        private String GetCurrentCategory()
        {
            return _board.GetCategoryName(CurrentPlayer.BoardPosition);
        }

        public bool wasCorrectlyAnswered()
        {
            var shouldGameContinue = true;

            if (CurrentPlayer.IsInPenaltyBox && _isGettingOutOfPenaltyBox)
            {
                Console.WriteLine("Answer was correct!!!!");
                CurrentPlayer.Coins++;
                PrintPlayerCoins();

                shouldGameContinue = ShouldGameContinue();
            }
            else if (!CurrentPlayer.IsInPenaltyBox)
            {
                Console.WriteLine("Answer was corrent!!!!");
                CurrentPlayer.Coins++;
                PrintPlayerCoins();

                shouldGameContinue = ShouldGameContinue();
            }

            IterateCurrentPlayer();
            return shouldGameContinue;
        }

        private void PrintPlayerCoins()
        {
            Console.WriteLine(CurrentPlayer.Name
                              + " now has "
                              + CurrentPlayer.Coins
                              + " Gold Coins.");
        }

        public bool wrongAnswer()
        {
            Console.WriteLine("Question was incorrectly answered");
            Console.WriteLine(CurrentPlayer.Name + " was sent to the penalty box");
            CurrentPlayer.IsInPenaltyBox = true;

            IterateCurrentPlayer();
            return true;
        }

        private void IterateCurrentPlayer()
        {
            currentPlayerIndex++;
            if (currentPlayerIndex == _players.Count)
            {
                currentPlayerIndex = 0;
            }
        }

        private bool ShouldGameContinue()
        {
            return CurrentPlayer.Coins != WINNING_COINS;
        }
    }
}
