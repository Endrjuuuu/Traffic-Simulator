using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace TrafficSimulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Car car1;
        private readonly Car car2;
        private readonly DispatcherTimer disparcherTimer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();

            disparcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 300);
            disparcherTimer.Tick += DisparcherTimer_Tick;

            car1 = new Car("car1");
            car2 = new Car("car2");
        }

        private void DisparcherTimer_Tick(object sender, EventArgs e)
        {
            car1.GoAhead(car2);
            SetCarPicture(car1);
            car2.GoAhead(car1);
            SetCarPicture(car2);
            label_Car1Row.Content = car1.carPosition.row;
            label_Car1Column.Content = car1.carPosition.column;
            label_Car1PositionType.Content = car1.carPosition.positionType.ToString();

            label_Car2Row.Content = car2.carPosition.row;
            label_Car2Column.Content = car2.carPosition.column;
            label_Car2PositionType.Content = car2.carPosition.positionType.ToString();
        }

        public void SetCarPicture(Car car)
        {
            string targetString = "image" + car.carPosition.row.ToString() + car.carPosition.column.ToString();
            Image targetImage = FindChild<Image>(Application.Current.MainWindow, targetString);
            if (targetImage != null)
                targetImage.Source = new BitmapImage(new Uri(car.bitmapSource));

            if (car.carPosition.row != car.carPosition.oldRow || car.carPosition.column != car.carPosition.oldColumn)
            {
                targetString = "image" + car.carPosition.oldRow.ToString() + car.carPosition.oldColumn.ToString();
                targetImage = FindChild<Image>(Application.Current.MainWindow, targetString);
                if (targetImage != null)
                    targetImage.Source = null;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            disparcherTimer.Start();
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