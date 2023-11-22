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
    /// Логика взаимодействия для EditClientPage.xaml
    /// </summary>
    public partial class EditClientPage : Page
    {
        Customer client = new Customer();
        public EditClientPage(Customer client)
        {
            InitializeComponent();
            DataContext = client;

            this.client.IdCustomer = client.IdCustomer;

            GenderCb.ItemsSource = DBEntities.GetContext()
        .Gender.ToList();
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
            try
            {
                int index2 = GenderCb.SelectedIndex + 1;
                client = DBEntities.GetContext().Customer
                    .FirstOrDefault(u => u.IdCustomer == client.IdCustomer);
                client.FirstNameCustomer = NameTb.Text;
                client.LastNameCustomer = SurNameTb.Text;
                client.MiddleNameCustomer = TherdNameTb.Text;
                client.PhoneNumberCustomer = PhoneTb.Text;
                client.EmailCustomer = EmailTb.Text;
                client.IdGender = index2;
                DBEntities.GetContext().SaveChanges();
                MBClass.ShowMesagePopup("Успешно", Application.Current.MainWindow);
                Window currentWindow = GetCurrentWindow() as Window;
                if (currentWindow is MenagerBaseWindow)
                {
                    ((MenagerBaseWindow)currentWindow).MainFrame.Navigate(new ClientPage());
                    ((MenagerBaseWindow)currentWindow).MainFrame2.Content = null;
                }
                else
                {
                    (App.Current.Windows[0] as BaseWindow).MainFrame.Navigate(new ClientPage());
                    (App.Current.Windows[0] as BaseWindow).MainFrame2.Content = null;
                }
            }
            catch (Exception ex)
            {
                MBClass.ShowErrorPopup(ex.Message, Application.Current.MainWindow);
            }
        }
    }
}
