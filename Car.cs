using System;

namespace TrafficSimulator
{
    public class Car
    {
        public Position carPosition = new Position();

        public Random random = new Random();
        public string bitmapSource;

        public Car(string carName)
        {
            carPosition.SetRandomPosition();
            bitmapSource = $@"C:\Users\Andrzej\source\repos\TrafficSimulator\Images\{carName}.png";
        }

        public void GoAhead(Car anotherCar)
        {
            carPosition.SetPositionType();
            carPosition.SetPossibleDirection();
            if (carPosition.positionType == PositionType.ColumnRoad || carPosition.positionType == PositionType.RowRoad)
            {
                carPosition.nextDirection = carPosition.oldDirection;
            }
            else
            {
                carPosition.GetRandomPossibleDirection();
                carPosition.oldDirection = carPosition.nextDirection;
            }
            carPosition.oldRow = carPosition.row;
            carPosition.oldColumn = carPosition.column;

            switch (carPosition.nextDirection)
            {
                case Direction.Up:
                    if ((anotherCar.carPosition.row != carPosition.row - 1) || (anotherCar.carPosition.column != carPosition.column))
                        carPosition.row--;
                    break;

                case Direction.Down:
                    if ((anotherCar.carPosition.row != carPosition.row + 1) || (anotherCar.carPosition.column != carPosition.column))
                        carPosition.row++;
                    break;

                case Direction.Left:
                    if ((anotherCar.carPosition.column != carPosition.column - 1) || (anotherCar.carPosition.row != carPosition.row))
                        carPosition.column--;
                    break;

                case Direction.Right:
                    if ((anotherCar.carPosition.column != carPosition.column + 1) || (anotherCar.carPosition.row != carPosition.row))
                        carPosition.column++;
                    break;
            }
            carPosition.SetPositionType();
        }

        public void GoAhead()
        {
            carPosition.SetPositionType();
            carPosition.SetPossibleDirection();
            if (carPosition.positionType == PositionType.ColumnRoad || carPosition.positionType == PositionType.RowRoad)
            {
                carPosition.nextDirection = carPosition.oldDirection;
            }
            else
            {
                carPosition.GetRandomPossibleDirection();
                carPosition.oldDirection = carPosition.nextDirection;
            }
            carPosition.oldRow = carPosition.row;
            carPosition.oldColumn = carPosition.column;

            switch (carPosition.nextDirection)
            {
                case Direction.Up:
                    carPosition.row--;
                    break;

                case Direction.Down:
                    carPosition.row++;
                    break;

                case Direction.Left:
                    carPosition.column--;
                    break;

                case Direction.Right:
                    carPosition.column++;
                    break;
            }
            carPosition.SetPositionType();
        }
    }
}