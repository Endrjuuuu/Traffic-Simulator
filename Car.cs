using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace TrafficSimulator
{
    class Car
    {
        public Position carPosition = new Position();

        public Random random = new Random();

        //public Direction nextDirection;
        //public Direction oldDirection;
        public Car()
        {
            carPosition.SetRandomPosition();
        }

        public PositionType GetCarPosition()
        {
            return carPosition.GetPositionType();

        }



        public void GoAhead(Car anotherCar)
        {
            if (carPosition.positionType == PositionType.ColumnRoad || carPosition.positionType == PositionType.RowRoad)
            {
                carPosition.nextDirection = carPosition.oldDirection;
            }
            else
            {
                carPosition.GetRandomPossibleDirection();
                carPosition.oldDirection = carPosition.nextDirection;   
                //nextDirection = carPosition.nextDirection;
            }

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

                //nextDirection = carPosition.nextDirection;
            }

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
