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
    /// Логика взаимодействия для WorkerPage.xaml
    /// </summary>
    public partial class WorkerPage : Page
    {
        public WorkerPage()
        {
            InitializeComponent();
            membersDataGrid.ItemsSource = DBEntities.GetContext().Employee.
                    ToList().OrderBy(u => u.IdEmployee);
        }

        private void EditInGrid_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            (App.Current.Windows[0] as BaseWindow).MainFrame.Content = null;
            (App.Current.Windows[0] as BaseWindow).MainFrame2.Navigate(new EditWorkerPage(membersDataGrid.SelectedItem as Employee));

        }

        private void DeleteInGrid_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Employee auto = membersDataGrid.SelectedItem as Employee;

            DBEntities.GetContext().Employee
                        .Remove(membersDataGrid.SelectedItem as Employee);
            DBEntities.GetContext().SaveChanges();

            MBClass.ShowMesagePopup("Успешно", Application.Current.MainWindow);

            membersDataGrid.ItemsSource = DBEntities.GetContext()
                .Employee.ToList().OrderBy(u => u.IdEmployee);
        }

        private void AddBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            (App.Current.Windows[0] as BaseWindow).MainFrame.Content = null;
            (App.Current.Windows[0] as BaseWindow).MainFrame2.Navigate(new WorkerAddPage());

        }

        private void CloseWindowBTN_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MinimizeWindowBTN_Click(object sender, RoutedEventArgs e)
        {

        }

        private void textBoxFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            membersDataGrid.ItemsSource = DBEntities.GetContext()
               .Employee.Where(u => u.FirstNameEmployee
               .StartsWith(textBoxFilter.Text))
               .ToList().OrderBy(u => u.FirstNameEmployee);
            if (membersDataGrid.Items.Count <= 0)
            {
                MBClass.ShowErrorPopup("Данные не найдены", Application.Current.MainWindow);
            }
        }

        private void membersDataGrid_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            new FullInfoWorker(membersDataGrid.SelectedItem as Employee).Show();
        }

        private void modifyIt_Click(object sender, RoutedEventArgs e)
        {
            new FullInfoWorker(membersDataGrid.SelectedItem as Employee).Show();
        }
    }
}
