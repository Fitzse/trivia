using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trivia.Test
{
    [TestFixture]
    public class PlayerTests
    {
        private const string PLAYER_NAME = "george";
        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        public void CanConstructAPlayWithAName()
        {
            var player = new Player(PLAYER_NAME);
            Assert.AreEqual(PLAYER_NAME, player.Name);
        }

        [Test]
        public void PlayerStartsAtBoardPosition0()
        {
            var player = new Player(PLAYER_NAME);
            Assert.AreEqual(0, player.BoardPosition);
        }

        [Test]
        public void PlayerStartsNotInPenaltyBox()
        {
            var player = new Player(PLAYER_NAME);
            Assert.IsFalse(player.IsInPenaltyBox);
        }

        [Test]
        public void PlayerStartsWith0Coins()
        {
            var player = new Player(PLAYER_NAME);
            Assert.AreEqual(0, player.Coins);
        }
    }
}
