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
    /// Логика взаимодействия для ClientPage.xaml
    /// </summary>
    public partial class ClientPage : Page
    {
        public ClientPage()
        {
            InitializeComponent();
            membersDataGrid.ItemsSource = DBEntities.GetContext().Customer.
                    ToList().OrderBy(u => u.IdCustomer);
        }

        public Window GetCurrentWindow()
        {
            foreach (var window in App.Current.Windows)
            {
                if (window is Window currentWindow)
                {
                    if (currentWindow.Title == "MenagerWindow")
                    {
                        return currentWindow;
                    }
                    else if (currentWindow.Title == "BaseWindow")
                    {
                        return currentWindow;
                    }
                }
            }

            return null;
        }

        private void AddBTN_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            (App.Current.Windows[0] as BaseWindow).MainFrame.Content = null;
            (App.Current.Windows[0] as BaseWindow).MainFrame2.Navigate(new AddClientPage());
        }

        private void EditInGrid_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Window currentWindow = GetCurrentWindow() as Window;
            if (currentWindow is MenagerBaseWindow)
            {
                ((MenagerBaseWindow)currentWindow).MainFrame2.Navigate(new EditClientPage(membersDataGrid.SelectedItem as Customer));
                ((MenagerBaseWindow)currentWindow).MainFrame.Content = null;
            }
            else
            {
                (App.Current.Windows[0] as BaseWindow).MainFrame2.Navigate(new EditClientPage(membersDataGrid.SelectedItem as Customer));
                (App.Current.Windows[0] as BaseWindow).MainFrame.Content = null;
            }

        }

        private void DeleteInGrid_Click(object sender, System.Windows.RoutedEventArgs e)
        {


            Customer auto = membersDataGrid.SelectedItem as Customer;



            DBEntities.GetContext().Customer
                        .Remove(membersDataGrid.SelectedItem as Customer);
            DBEntities.GetContext().SaveChanges();

            MBClass.ShowMesagePopup("Успешно", Application.Current.MainWindow);

            membersDataGrid.ItemsSource = DBEntities.GetContext()
                .Customer.ToList().OrderBy(u => u.IdCustomer);
        }

        private void CloseWindowBTN_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MinimizeWindowBTN_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddBTN2_Click(object sender, RoutedEventArgs e)
        {
            (App.Current.Windows[0] as MenagerBaseWindow).MainFrame2.Navigate(new AddClientPage());
            (App.Current.Windows[0] as MenagerBaseWindow).MainFrame.Content = null;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var item in App.Current.Windows)
            {
                if ((item as Window).Title == "MenagerWindow")
                {
                    AddBTN.Click -= AddBTN_Click;
                    AddBTN.Click += AddBTN2_Click;
                }

            }
        }

        private void textBoxFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            membersDataGrid.ItemsSource = DBEntities.GetContext()
               .Customer.Where(u => u.FirstNameCustomer
               .StartsWith(textBoxFilter.Text))
               .ToList().OrderBy(u => u.FirstNameCustomer);
            if (membersDataGrid.Items.Count <= 0)
            {
                MBClass.ShowErrorPopup("Данные не найдены", Application.Current.MainWindow);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void membersDataGrid_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            new FullInfoCLient(membersDataGrid.SelectedItem as Customer).Show();

        }

        private void modifyIt_Click(object sender, RoutedEventArgs e)
        {
            new FullInfoCLient(membersDataGrid.SelectedItem as Customer).Show();

        }
    }
}
