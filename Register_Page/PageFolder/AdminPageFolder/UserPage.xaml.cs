using Register_Page.ClassFolder;
using Register_Page.DataFolder;
using Register_Page.PageFolder.AdminAddPageFolder;
using Register_Page.PageFolder.AdminEditPageFolder;
using Register_Page.WindowFolder;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Register_Page.PageFolder.AdminPageFolder
{
    /// <summary>
    /// Логика взаимодействия для UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        public UserPage()
        {
            InitializeComponent();
            membersDataGrid.ItemsSource = DBEntities.GetContext().User.
                    ToList().OrderBy(u => u.IdUser);
        }

        private void AddBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {

            (App.Current.Windows[0] as BaseWindow).MainFrame.Content = null;
            (App.Current.Windows[0] as BaseWindow).MainFrame2.Navigate(new AddUserPage());
        }

        private void EditInGrid_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (membersDataGrid.SelectedItem != null)
            {


                (App.Current.Windows[0] as BaseWindow).MainFrame.Content = null;
                (App.Current.Windows[0] as BaseWindow).MainFrame2.Navigate(new EditUserPage(membersDataGrid.SelectedItem as User));
            }
            else
            {

            }
        }

        private void DeleteInGrid_Click(object sender, RoutedEventArgs e)
        {
            User auto = membersDataGrid.SelectedItem as User;

            DBEntities.GetContext().User
                        .Remove(membersDataGrid.SelectedItem as User);
            DBEntities.GetContext().SaveChanges();

            MBClass.ShowMesagePopup("Успешно", Application.Current.MainWindow);

            membersDataGrid.ItemsSource = DBEntities.GetContext()
                .Customer.ToList().OrderBy(u => u.IdCustomer);
        }

        private void CloseWindowBTN_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void MinimizeWindowBTN_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void membersDataGrid_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (PasswordDGD.Visibility == Visibility.Visible)
            {
                PasswordDGD.Visibility = Visibility.Collapsed;
            }
            else
            {
                PasswordDGD.Visibility = Visibility.Visible;
            }
        }

        private void textBoxFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            membersDataGrid.ItemsSource = DBEntities.GetContext()
               .User.Where(u => u.LoginUser
               .StartsWith(textBoxFilter.Text))
               .ToList().OrderBy(u => u.LoginUser);
            if (membersDataGrid.Items.Count <= 0)
            {
                MBClass.ShowErrorPopup("Данные не найдены", Application.Current.MainWindow);
            }
        }

        private void modifyIt_Click(object sender, RoutedEventArgs e)
        {
            new FulinfoUser(membersDataGrid.SelectedItem as User).Show();
        }
    }
}
