using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace TrafficSimulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Position positionCar1;
        Position positionCar2;
        Car car1;
        Car car2;
        public MainWindow()
        {
            InitializeComponent();

            DispatcherTimer disparcherTimer = new DispatcherTimer();
            disparcherTimer.Interval = new TimeSpan(0, 0, 1);
            disparcherTimer.Tick += DisparcherTimer_Tick;

            car1 = new Car();
            car2 = new Car();

            //disparcherTimer.Start();
        }

        private void DisparcherTimer_Tick(object sender, EventArgs e)
        {
            /*
            try
            {
                positionCar1.oldRow = positionCar1.row;
                positionCar1.oldColumn = positionCar1.column;
                positionCar1.row = (byte)tcAdsClient.ReadAny(hvarRowCar1, typeof(byte));
                positionCar1.column = (byte)tcAdsClient.ReadAny(hvarColumnCar1, typeof(byte));

                SetCarPicture(positionCar1);

                positionCar2.oldRow = positionCar2.row;
                positionCar2.oldColumn = positionCar2.column;
                positionCar2.row = (byte)tcAdsClient.ReadAny(hvarRowCar2, typeof(byte));
                positionCar2.column = (byte)tcAdsClient.ReadAny(hvarColumnCar2, typeof(byte));

                SetCarPicture2(positionCar2);
            }
            catch (Exception excep)
            {
                //timer1.Enabled = false;
                MessageBox.Show(excep.ToString());
            }
            */


        }


        public void SetCarPicture(Position position)
        {
            string targetString = "image" + position.row.ToString() + position.column.ToString();
            Image targetImage = FindChild<Image>(Application.Current.MainWindow, targetString);
            if (targetImage != null)
                targetImage.Source = new BitmapImage(new Uri(@"C:\Users\Andrzej\source\repos\TrafficSimulator\Images\car1.png"));

            if (position.row != position.oldRow || position.column != position.oldColumn)
            {
                targetString = "image" + position.oldRow.ToString() + position.oldColumn.ToString();
                targetImage = FindChild<Image>(Application.Current.MainWindow, targetString);
                targetImage.Source = null;
            }

        }

        /*
        public void SetCarPicture2(Position position)
        {
            string targetString = "pictureBox" + position.row.ToString() + position.column.ToString();
            PictureBox targetPictureBox = this.Controls.Find(targetString, true).FirstOrDefault() as PictureBox;
            targetPictureBox.Image = Properties.Resources.car2;

            if (position.row != position.oldRow || position.column != position.oldColumn)
            {
                targetString = "pictureBox" + position.oldRow.ToString() + position.oldColumn.ToString();
                targetPictureBox = this.Controls.Find(targetString, true).FirstOrDefault() as PictureBox;
                targetPictureBox.Image = nullBitmap;
            }
        }
        */

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //label_Car1Row.Content = car1.carPosition.row;
            //label_Car1Column.Content = car1.carPosition.column;
            //label_Car1PositionType.Content = car1.carPosition.positionType.ToString();
            //car1.GetCarPosition();

            //SetCarPicture(car1.carPosition);

            //label_oldRow.Content = car1.carPosition.oldRow;
            //label_oldColumn.Content = car1.carPosition.oldColumn;

            //car1.GoAhead(car2);
            car1.GoAhead();
            SetCarPicture(car1.carPosition);
            label_Car1Row.Content = car1.carPosition.row;
            label_Car1Column.Content = car1.carPosition.column;
            label_Car1PositionType.Content = car1.carPosition.positionType.ToString();

            label_oldRow.Content = car1.carPosition.oldRow;
            label_oldColumn.Content = car1.carPosition.oldColumn;
        }



        public static T FindChild<T>(DependencyObject parent, string childName) where T : DependencyObject
        {
            if (parent == null) return null;

            T foundChild = null;

            int childrenCount = VisualTreeHelper.GetChildrenCount(parent);

            for (int i = 0; i < childrenCount; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                T childType = child as T;
                if (childType == null)
                {
                    // recursively drill down the tree
                    foundChild = FindChild<T>(child, childName);

                    // If the child is found, break so we do not overwrite the found child
                    if (foundChild != null) break;
                }
                else if (!string.IsNullOrEmpty(childName))
                {
                    var frameworkElement = child as FrameworkElement;
                    // If the child's name is set for search
                    if (frameworkElement != null && frameworkElement.Name == childName)
                    {
                        foundChild = (T)child;
                        break;
                    }
                }
                else
                {
                    // child element found
                    foundChild = (T)child;
                    break;
                }
            }
            return foundChild;
        }
    }
}