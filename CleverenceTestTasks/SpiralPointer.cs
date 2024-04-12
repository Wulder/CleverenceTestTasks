using System.Numerics;


namespace CleverenceTestTasks
{
    internal class SpiralPointer
    {
        private MatrixBound _matrixBound;
        private Direction _currentDirection;

        private Vector2 _currentMatrixPointer;

        public Vector2 CurrentMatrixPointer => _currentMatrixPointer;
        public SpiralPointer(int width, int heigth)
        {
            _matrixBound = new MatrixBound(1, width, 0, heigth);
            _currentMatrixPointer = new Vector2(0, -1);
            _currentDirection = Direction.Down;
        }

        public Vector2 MoveNext()
        {

            if (_currentDirection == Direction.Down)
            {
                if (_currentMatrixPointer.Y + 1 < _matrixBound.Bottom)
                {
                    _currentMatrixPointer.Y += 1;
                    return _currentMatrixPointer;
                }
                else
                {
                    _matrixBound.Bottom--;
                    _currentDirection = Direction.Right;
                }
            }
            if (_currentDirection == Direction.Right)
            {
                if (_currentMatrixPointer.X + 1 < _matrixBound.Right)
                {
                    _currentMatrixPointer.X += 1;
                    return _currentMatrixPointer;
                }
                else
                {
                    _matrixBound.Right--;
                    _currentDirection = Direction.Up;
                }
            }
            if (_currentDirection == Direction.Up)
            {
                if (_currentMatrixPointer.Y - 1 >= _matrixBound.Top)
                {
                    _currentMatrixPointer.Y -= 1;
                    return _currentMatrixPointer;
                }
                else
                {
                    _matrixBound.Top++;
                    _currentDirection = Direction.Left;
                }
            }
            if (_currentDirection == Direction.Left)
            {
                if (_currentMatrixPointer.X - 1 >= _matrixBound.Left)
                {
                    _currentMatrixPointer.X -= 1;
                    return _currentMatrixPointer;
                }
                else
                {
                    _currentDirection = Direction.Down;
                    _matrixBound.Left++;
                    return MoveNext();
                }
            }




            return _currentMatrixPointer;
        }
        private struct MatrixBound
        {
            public MatrixBound(int l, int r, int t, int b)
            {
                Left = l;
                Right = r;
                Top = t;
                Bottom = b;
            }
            public int Left, Right, Top, Bottom;
        }

        private enum Direction
        {
            Down, Up, Right, Left
        }
    }
}
