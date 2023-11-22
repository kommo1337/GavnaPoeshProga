using Register_Page.PageFolder.AdminPageFolder;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Register_Page.WindowFolder
{
    /// <summary>
    /// Логика взаимодействия для BaseWindow.xaml
    /// </summary>
    public partial class BaseWindow : Window
    {
        public static bool IsClicked = false;
        public static Button BTN = new Button();


        public BaseWindow()
        {
            InitializeComponent();

            foreach (var item in BorderButtonSP.Children)
            {
                if (item is Button)
                {
                    (item as Button).Click += BaseWindow_Click;

                }
            }
            MainFrame.Navigate(new ZakazPage());

        }

        private void BaseWindow_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as Button) != BTN)
            {
                string hexColor = "#FFFFD500";
                SolidColorBrush Trans = new SolidColorBrush(Colors.Transparent);

                // Создание кисти
                SolidColorBrush brush = (SolidColorBrush)(new BrushConverter().ConvertFrom(hexColor));
                (sender as Button).Background = brush;
                IsClicked = true;

                BTN = sender as Button;
                foreach (var item in BorderButtonSP.Children)
                {
                    if (item is Button)
                    {
                        if (item != BTN)
                        {
                            (item as Button).Background = Trans;

                        }

                    }

                }
            }



        }




        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AvtoPage());
            (App.Current.Windows[0] as BaseWindow).MainFrame2.Content = null;

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ClientPage());
            (App.Current.Windows[0] as BaseWindow).MainFrame2.Content = null;

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ZakazPage());
            (App.Current.Windows[0] as BaseWindow).MainFrame2.Content = null;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

            MainFrame.Navigate(new UserPage());
            (App.Current.Windows[0] as BaseWindow).MainFrame2.Content = null;

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new WorkerPage());
            (App.Current.Windows[0] as BaseWindow).MainFrame2.Content = null;

        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
