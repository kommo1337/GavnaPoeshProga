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
    /// Логика взаимодействия для EditServicePage.xaml
    /// </summary>
    public partial class EditServicePage : Page
    {
        //Service service = new Service();
        public EditServicePage(/*Service service*/)
        {
            InitializeComponent();

            //DataContext = service;

            //service.ServiceId = service.ServiceId;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{

            //    service = DBEntities.GetContext().Service
            //        .FirstOrDefault(u => u.ServiceId == service.ServiceId);
            //    service.ServiceName = NameServiceTb.Text;
            //    service.ServicePrice = decimal.Parse(PriceTb.Text);


            //    DBEntities.GetContext().SaveChanges();
            //    MBClass.ShowMesagePopup("Успешно", Application.Current.MainWindow);
            //    (App.Current.Windows[0] as BaseWindow).MainFrame2.Content = null;
            //    (App.Current.Windows[0] as BaseWindow).MainFrame.Navigate(new AvtoPage());

            //}
            //catch (Exception ex)
            //{
            //    MBClass.ShowErrorPopup(ex.Message, Application.Current.MainWindow);
            //}
        }
    }
}
