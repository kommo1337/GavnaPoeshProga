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
    /// Логика взаимодействия для ZakazPage.xaml
    /// </summary>
    public partial class ZakazPage : Page
    {
        public ZakazPage()
        {
            InitializeComponent();
            membersDataGrid.ItemsSource = DBEntities.GetContext().Order.
                ToList().OrderBy(u => u.IdOrder);
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            (App.Current.Windows[0] as BaseWindow).MainFrame2.Navigate(new AddZakazPage());
            (App.Current.Windows[0] as BaseWindow).MainFrame.Content = null;
        }

        private void EditInGrid_Click(object sender, RoutedEventArgs e)
        {
            if (membersDataGrid.SelectedItem == null)
            {
                MBClass.ShowErrorPopup("Выбиерите заказ", Application.Current.MainWindow);

            }
            else
            {
                Window currentWindow = GetCurrentWindow() as Window;
                if (currentWindow is MenagerBaseWindow)
                {
                    ((MenagerBaseWindow)currentWindow).MainFrame2.Navigate(new EditZakazPage(membersDataGrid.SelectedItem as Order));
                    ((MenagerBaseWindow)currentWindow).MainFrame.Content = null;
                }
                else
                {
                    (App.Current.Windows[0] as BaseWindow).MainFrame2.Navigate(new EditZakazPage(membersDataGrid.SelectedItem as Order));
                    (App.Current.Windows[0] as BaseWindow).MainFrame.Content = null;
                }
            }
        }

        private void deleteInGrid_Click(object sender, RoutedEventArgs e)
        {
            Order auto = membersDataGrid.SelectedItem as Order;

            DBEntities.GetContext().Order
                        .Remove(membersDataGrid.SelectedItem as Order);
            DBEntities.GetContext().SaveChanges();

            MBClass.ShowMesagePopup("Успешно", Application.Current.MainWindow);

            membersDataGrid.ItemsSource = DBEntities.GetContext()
                .Order.ToList().OrderBy(u => u.IdOrder);
        }

        private void CloseWindowBTN_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MinimizeWindowBTN_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddBTN2_Click(object sender, RoutedEventArgs e)
        {
            (App.Current.Windows[0] as MenagerBaseWindow).MainFrame2.Navigate(new AddZakazPage());
            (App.Current.Windows[0] as MenagerBaseWindow).MainFrame.Content = null;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var item in App.Current.Windows)
            {
                if ((item as Window).Title == "MenagerWindow")
                {
                    AddBTN.Click -= Button_Click;
                    AddBTN.Click += AddBTN2_Click;
                }

            }
        }

        private void textBoxFilter_TextChanged(object sender, TextChangedEventArgs e)
        {

            membersDataGrid.ItemsSource = DBEntities.GetContext()
    .Order
    .Where(order => order.Customer.FirstNameCustomer.StartsWith(textBoxFilter.Text)) 
    .ToList()
    .OrderBy(order => order.Customer.FirstNameCustomer);


            if (membersDataGrid.Items.Count <= 0)
            {
                MBClass.ShowErrorPopup("Данные не найдены", Application.Current.MainWindow);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            membersDataGrid.ItemsSource = DBEntities.GetContext().Order.
                 ToList().OrderBy(u => u.IdOrder);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //membersDataGrid.ItemsSource = DBEntities.GetContext()
            //  .Order.Where(u => u.StatusId == 1)
            //  .ToList().OrderBy(u => u.StatusId);
            //if (membersDataGrid.Items.Count <= 0)
            //{
            //    MBClass.ShowErrorPopup("Данные не найдены", Application.Current.MainWindow);
            //}
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            //membersDataGrid.ItemsSource = DBEntities.GetContext()
            //  .Order.Where(u => u.StatusId == 2)
            //  .ToList().OrderBy(u => u.StatusId);
            //if (membersDataGrid.Items.Count <= 0)
            //{
            //    MBClass.ShowErrorPopup("Данные не найдены", Application.Current.MainWindow);
            //}
        }
    }
}
