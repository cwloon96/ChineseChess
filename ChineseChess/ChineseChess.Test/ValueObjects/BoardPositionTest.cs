using ChineseChess.ValueObjects;
using NUnit.Framework;
using System;

namespace ChineseChess.Test.ValueObjects
{
    public class BoardPositionTest
    {
        [Test]
        public void ShouldSameRow()
        {
            var pos1 = new BoardPosition(1, 1);
            var pos2 = new BoardPosition(1, 2);

            Assert.True(pos1.IsSameRow(pos2));
        }

        [Test]
        public void ShouldNotSameRow()
        {
            var pos1 = new BoardPosition(1, 1);
            var pos2 = new BoardPosition(2, 2);

            Assert.False(pos1.IsSameRow(pos2));
        }

        [Test]
        public void ShouldGetRowDistance()
        {
            var pos1 = new BoardPosition(1, 1);
            var pos2 = new BoardPosition(5, 1);

            Assert.AreEqual(4, pos1.GetRowDistance(pos2));
        }

        [Test]
        public void ShouldThrowNotSameColException()
        {
            var pos1 = new BoardPosition(1, 1);
            var pos2 = new BoardPosition(5, 3);

            Assert.Throws<Exception>(() => pos1.GetRowDistance(pos2), "Not at same col");
        }

        [Test]
        public void ShouldSameCol()
        {
            var pos1 = new BoardPosition(3, 2);
            var pos2 = new BoardPosition(1, 2);

            Assert.True(pos1.IsSameCol(pos2));
        }

        [Test]
        public void ShouldNotSameCol()
        {
            var pos1 = new BoardPosition(1, 1);
            var pos2 = new BoardPosition(2, 2);

            Assert.False(pos1.IsSameCol(pos2));
        }

        [Test]
        public void ShouldGetColDistance()
        {
            var pos1 = new BoardPosition(1, 1);
            var pos2 = new BoardPosition(1, 5);

            Assert.AreEqual(4, pos1.GetColDistance(pos2));
        }

        [Test]
        public void ShouldThrowNotSameRowException()
        {
            var pos1 = new BoardPosition(1, 1);
            var pos2 = new BoardPosition(5, 3);

            Assert.Throws<Exception>(() => pos1.GetColDistance(pos2), "Not at same row");
        }

        [Test]
        public void ShouldBeDiagonal()
        {
            var pos1 = new BoardPosition(2, 2);

            var leftTop = new BoardPosition(1, 1);
            var rightTop = new BoardPosition(1, 3);
            var leftBottom = new BoardPosition(3, 1);
            var rightBottom = new BoardPosition(3, 3);

            Assert.True(pos1.IsDiagonal(leftTop));
            Assert.True(pos1.IsDiagonal(rightTop));
            Assert.True(pos1.IsDiagonal(leftBottom));
            Assert.True(pos1.IsDiagonal(rightBottom));
        }

        [Test]
        public void ShouldNotBeDiagonal()
        {
            var pos1 = new BoardPosition(1, 1);
            var pos2 = new BoardPosition(3, 2);

            Assert.False(pos1.IsDiagonal(pos2));
        }

        [Test]
        public void ShouldGetDiagonalDistance()
        {
            var pos1 = new BoardPosition(1, 1);
            var pos2 = new BoardPosition(3, 3);

            Assert.AreEqual(2, pos1.GetDiagonalDistance(pos2));
        }

        [Test]
        public void ShouldThrowNotDiagonalException()
        {
            var pos1 = new BoardPosition(1, 1);
            var pos2 = new BoardPosition(2, 1);

            Assert.Throws<Exception>(() => pos1.GetDiagonalDistance(pos2), "Not diaganol");
        }
    }
}