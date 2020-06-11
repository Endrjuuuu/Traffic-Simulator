using System;
using System.Security.Policy;
using System.Windows.Input;

namespace TrafficSimulator
{
    public class Position
    {
        public int row;
        public int column;

        // TODO: oldRow i oldColumn nie sa nigdzie przypisywane
        public int oldRow;
        public int oldColumn;

        public PositionType positionType;
        public bool[] arrayPossibleDirection = new bool[4];
        public PositionType GetPositionType()
        {
            if (row == 0 && column == 0)
                return PositionType.CornerTopLeft;
            if (row == 5 && column == 0)
                return PositionType.MiddleLeft;
            if (row == 10 && column == 0)
                return PositionType.CornerDownLeft;
            if (row == 0 && column == 5)
                return PositionType.MiddleTop;
            if (row == 5 && column == 5)
                return PositionType.Center;
            if (row == 10 && column == 5)
                return PositionType.MiddleDown;
            if (row == 0 && column == 10)
                return PositionType.CornerTopRight;
            if (row == 5 && column == 10)
                return PositionType.MiddleRight;
            if (row == 10 && column == 10)
                return PositionType.CornerDownRight;
            if (row % 5 == 0)
                return PositionType.RowRoad;
            if (column % 5 == 0)
                return PositionType.ColumnRoad;
            else
                return PositionType.Center;
        }

        public PositionType GetPositionType(int row, int column)
        {
            if (row == 0 && column == 0)
                return PositionType.CornerTopLeft;
            if (row == 5 && column == 0)
                return PositionType.MiddleLeft;
            if (row == 10 && column == 0)
                return PositionType.CornerDownLeft;
            if (row == 0 && column == 5)
                return PositionType.MiddleTop;
            if (row == 5 && column == 5)
                return PositionType.Center;
            if (row == 10 && column == 5)
                return PositionType.MiddleDown;
            if (row == 0 && column == 10)
                return PositionType.CornerTopRight;
            if (row == 5 && column == 10)
                return PositionType.MiddleRight;
            if (row == 10 && column == 10)
                return PositionType.CornerDownRight;
            if (row % 5 == 0)
                return PositionType.RowRoad;
            if (column % 5 == 0)
                return PositionType.ColumnRoad;
            else
                return PositionType.Center;
        }

        public void SetPositionType()
        {
            if (row == 0 && column == 0)
                positionType = PositionType.CornerTopLeft;
            else if (row == 5 && column == 0)
                positionType = PositionType.MiddleLeft;
            else if (row == 10 && column == 0)
                positionType = PositionType.CornerDownLeft;
            else if (row == 0 && column == 5)
                positionType = PositionType.MiddleTop;
            else if (row == 5 && column == 5)
                positionType = PositionType.Center;
            else if (row == 10 && column == 5)
                positionType = PositionType.MiddleDown;
            else if (row == 0 && column == 10)
                positionType = PositionType.CornerTopRight;
            else if (row == 5 && column == 10)
                positionType = PositionType.MiddleRight;
            else if (row == 10 && column == 10)
                positionType = PositionType.CornerDownRight;
            else if (row % 5 == 0)
                positionType = PositionType.RowRoad;
            else if (column % 5 == 0)
                positionType = PositionType.ColumnRoad;

        }

        public Direction nextDirection;
        public Direction oldDirection;


        public void GetRandomPossibleDirection()
        {
            Random random = new Random();
            int randomNumber = random.Next(arrayPossibleDirection.Length);

            while (!arrayPossibleDirection[randomNumber])
                randomNumber = random.Next(arrayPossibleDirection.Length);

            nextDirection = (Direction)randomNumber;
        }
        public void SetPossibleDirection()
        {
            switch (positionType)
            {
                case PositionType.CornerTopLeft:
                    arrayPossibleDirection[0] = false;
                    arrayPossibleDirection[1] = true;
                    arrayPossibleDirection[2] = false;
                    arrayPossibleDirection[3] = true;
                    break;
                case PositionType.MiddleLeft:
                    arrayPossibleDirection[0] = true;
                    arrayPossibleDirection[1] = true;
                    arrayPossibleDirection[2] = false;
                    arrayPossibleDirection[3] = true;
                    break;
                case PositionType.CornerDownLeft:
                    arrayPossibleDirection[0] = true;
                    arrayPossibleDirection[1] = false;
                    arrayPossibleDirection[2] = false;
                    arrayPossibleDirection[3] = true;
                    break;
                case PositionType.MiddleTop:
                    arrayPossibleDirection[0] = false;
                    arrayPossibleDirection[1] = true;
                    arrayPossibleDirection[2] = true;
                    arrayPossibleDirection[3] = true;
                    break;
                case PositionType.Center:
                    arrayPossibleDirection[0] = true;
                    arrayPossibleDirection[1] = true;
                    arrayPossibleDirection[2] = true;
                    arrayPossibleDirection[3] = true;
                    break;
                case PositionType.MiddleDown:
                    arrayPossibleDirection[0] = true;
                    arrayPossibleDirection[1] = false;
                    arrayPossibleDirection[2] = true;
                    arrayPossibleDirection[3] = true;
                    break;
                case PositionType.CornerTopRight:
                    arrayPossibleDirection[0] = false;
                    arrayPossibleDirection[1] = true;
                    arrayPossibleDirection[2] = true;
                    arrayPossibleDirection[3] = false;
                    break;
                case PositionType.MiddleRight:
                    arrayPossibleDirection[0] = true;
                    arrayPossibleDirection[1] = true;
                    arrayPossibleDirection[2] = true;
                    arrayPossibleDirection[3] = false;
                    break;
                case PositionType.CornerDownRight:
                    arrayPossibleDirection[0] = true;
                    arrayPossibleDirection[1] = false;
                    arrayPossibleDirection[2] = true;
                    arrayPossibleDirection[3] = false;
                    break;
                case PositionType.RowRoad:
                    arrayPossibleDirection[0] = false;
                    arrayPossibleDirection[1] = false;
                    arrayPossibleDirection[2] = true;
                    arrayPossibleDirection[3] = true;
                    break;
                case PositionType.ColumnRoad:
                    arrayPossibleDirection[0] = true;
                    arrayPossibleDirection[1] = true;
                    arrayPossibleDirection[2] = false;
                    arrayPossibleDirection[3] = false;
                    break;
                default:
                    break;
            }
        }

        public void SetRandomPosition()
        {
            Random random = new Random();
            int[] pos = new int[] { 0, 5, 10 };
            row = pos[random.Next(pos.Length)];
            column = pos[random.Next(pos.Length)];

            oldRow = row;
            oldColumn = column;
        }
    }
}