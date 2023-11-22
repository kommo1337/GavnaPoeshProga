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
    /// Логика взаимодействия для WorkerAddPage.xaml
    /// </summary>
    public partial class WorkerAddPage : Page
    {
        public WorkerAddPage()
        {
            InitializeComponent();
            AdressCb.ItemsSource = DBEntities.GetContext()
                 .Adress.ToList();
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


        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {

                DBEntities.GetContext().Employee.Add(new Employee()
                {
                    FirstNameEmployee = NameTB.Text,
                    LastNameEmployee = SurnameTb.Text,
                    MiddleNameEmployee = TherdNameTb.Text,
                    IdAdress = Int32.Parse(AdressCb.SelectedValue.ToString()),
                    NumberPassport = PasportTB.Text,
                    PhoneNumberEmployee = PhoneTb.Text,
                    IdGender = Int32.Parse(GenderCb.SelectedValue.ToString()),
                    EmailEmployee = EmailTb.Text
                });
                DBEntities.GetContext().SaveChanges();

                Window currentWindow = GetCurrentWindow() as Window;
                if (currentWindow is MenagerBaseWindow)
                {
                    ((MenagerBaseWindow)currentWindow).MainFrame.Navigate(new WorkerPage());
                    ((MenagerBaseWindow)currentWindow).MainFrame2.Content = null;
                }
                else
                {
                    (App.Current.Windows[0] as BaseWindow).MainFrame.Navigate(new WorkerPage());
                    (App.Current.Windows[0] as BaseWindow).MainFrame2.Content = null;
                }


            }
            catch (Exception ex)
            {
                MBClass.ShowErrorPopup(ex.Message, Application.Current.MainWindow);
                throw;
            }
        }
    }
}
