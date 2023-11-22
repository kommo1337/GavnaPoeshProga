using Register_Page.ClassFolder;
using Register_Page.DataFolder;
using Register_Page.PageFolder.AdminPageFolder;
using Register_Page.WindowFolder;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Register_Page.PageFolder.AdminEditPageFolder
{
    /// <summary>
    /// Логика взаимодействия для EditUserPage.xaml
    /// </summary>
    public partial class EditUserPage : Page
    {
        User user = new User();

        public EditUserPage(User user)
        {
            InitializeComponent();

            DataContext = user;

            this.user.IdUser = user.IdUser;

            ClientCb.ItemsSource = DBEntities.GetContext()
                    .Role.ToList();

            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int index = ClientCb.SelectedIndex + 1;
                user = DBEntities.GetContext().User
                    .FirstOrDefault(u => u.IdUser == user.IdUser);
                user.LoginUser = LoginTB.Text;
                user.PasswordUser = PasswordTB.Text;
                user.IdRole = index;
                DBEntities.GetContext().SaveChanges();
                MBClass.ShowMesagePopup("Успешно", Application.Current.MainWindow);
                (App.Current.Windows[0] as BaseWindow).MainFrame2.Content = null;
                (App.Current.Windows[0] as BaseWindow).MainFrame.Navigate(new UserPage());
            }
            catch (Exception ex)
            {
                MBClass.ShowErrorPopup(ex.Message, Application.Current.MainWindow);
            }
        }
    }
}
