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
    /// Логика взаимодействия для EditZakazPage.xaml
    /// </summary>
    public partial class EditZakazPage : Page
    {
        Order order = new Order();
        public EditZakazPage(Order order)
        {
            InitializeComponent();

            DataContext = order;
            ClientCb.ItemsSource = DBEntities.GetContext()
               .Customer.ToList();
            RabCb.ItemsSource = DBEntities.GetContext()
                .Employee.ToList();
            PriCb.ItemsSource = DBEntities.GetContext()
                .PriceList.ToList();
            

            this.order.IdOrder = order.IdOrder;
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
                int index = ClientCb.SelectedIndex + 1;
                int index2 = RabCb.SelectedIndex + 1;
                int index3 = PriCb.SelectedIndex + 1;
                
                order = DBEntities.GetContext().Order
                    .FirstOrDefault(u => u.IdOrder == order.IdOrder);
                order.DateOrder = (DateTime)BthPick.SelectedDate;
                order.IdCustomer = index;
                order.IdPriceList = index3;
                order.IdEmployee = index2;
                
                DBEntities.GetContext().SaveChanges();
                MBClass.ShowMesagePopup("Успешно", Application.Current.MainWindow);
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
