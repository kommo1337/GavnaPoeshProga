using Register_Page.ClassFolder;
using Register_Page.DataFolder;
using Register_Page.PageFolder.AdminPageFolder;
using Register_Page.WindowFolder;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Register_Page.PageFolder.AdminAddPageFolder
{
    /// <summary>
    /// Логика взаимодействия для AddClientPage.xaml
    /// </summary>
    public partial class AddClientPage : Page
    {
        public AddClientPage()
        {
            InitializeComponent();

            //GenderCb.ItemsSource = DBEntities.GetContext()
            //        .Gender.ToList();
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
                string dateString = BTHDatePick.SelectedDate.ToString();


                DBEntities.GetContext().Customer.Add(new Customer()
                {
                    FirstNameCustomer = NameTb.Text,
                    LastNameCustomer = SurNameTb.Text,
                    MiddleNameCustomer = TherdNameTb.Text,
                    Birthday = DateTime.Parse(BTHDatePick.Text),
                    EmailCustomer = EmailTb.Text,
                    PhoneNumberCustomer = PhoneTb.Text,
                    IdGender = Int32.Parse(GenderCb.SelectedValue.ToString())
                     

                });
                DBEntities.GetContext().SaveChanges();

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
