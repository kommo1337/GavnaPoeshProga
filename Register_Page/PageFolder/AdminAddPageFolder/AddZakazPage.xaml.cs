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
    /// Логика взаимодействия для AddZakazPage.xaml
    /// </summary>
    public partial class AddZakazPage : Page
    {
        public AddZakazPage()
        {
            InitializeComponent();
            ClientCb.ItemsSource = DBEntities.GetContext()
                .Customer.ToList();
            EmCb.ItemsSource = DBEntities.GetContext()
                .Employee.ToList();
            PricesCb.ItemsSource = DBEntities.GetContext()
                .PriceList.ToList();
            
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


                DBEntities.GetContext().Order.Add(new Order()
                {
                    DateOrder = DateTime.Parse(BthPick.Text),
                    IdCustomer = Int32.Parse(ClientCb.SelectedValue.ToString()),
                    IdEmployee = Int32.Parse(EmCb.SelectedValue.ToString()),
                    IdPriceList = Int32.Parse(PricesCb.SelectedValue.ToString()),
                    

                });
                DBEntities.GetContext().SaveChanges();
                Window currentWindow = GetCurrentWindow() as Window;
                if (currentWindow is MenagerBaseWindow)
                {
                    ((MenagerBaseWindow)currentWindow).MainFrame.Navigate(new ZakazPage());
                    ((MenagerBaseWindow)currentWindow).MainFrame2.Content = null;
                }
                else
                {
                    (App.Current.Windows[0] as BaseWindow).MainFrame.Navigate(new ZakazPage());
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
