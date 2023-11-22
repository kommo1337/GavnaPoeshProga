using Register_Page.ClassFolder;
using Register_Page.DataFolder;
using Register_Page.WindowFolder;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Register_Page
{
    /// <summary>
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        public Page2()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DoubleAnimation fadeInAnimation = new DoubleAnimation
            {
                From = 0.0,
                To = 1.0,
                Duration = TimeSpan.FromSeconds(0.5) // Продолжительность анимации в секундах
            };

            // Привязка анимации к свойству Opacity элемента (например, Grid или Window)
            MyGrid.BeginAnimation(Grid.OpacityProperty, fadeInAnimation);
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DBEntities.GetContext().User.Add(new User()
                {

                    LoginUser = LoginTB.Text,
                    PasswordUser = PasswordTb.Password,
                    IdRole = 2
                });
                DBEntities.GetContext().SaveChanges();

                MBClass.ShowMesagePopup("Успешно", Application.Current.MainWindow);
                new MenagerBaseWindow().Show();

                foreach (Window window in Application.Current.Windows)
                {
                    if (window is Window && window.Title == "Autorisation")
                    {
                        window.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MBClass.ShowErrorPopup(ex.Message, Application.Current.MainWindow);
            }
        }

    }
}
