using Register_Page.ClassFolder;
using Register_Page.DataFolder;
using Register_Page.PageFolder.AdminPageFolder;
using Register_Page.WindowFolder;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Register_Page.PageFolder.AdminAddPageFolder
{
    /// <summary>
    /// Логика взаимодействия для AddServicePage.xaml
    /// </summary>
    public partial class AddServicePage : Page
    {
        public AddServicePage()
        {
            InitializeComponent();
        }

        //public Window GetCurrentWindow()
        //{
        //    foreach (var window in App.Current.Windows)
        //    {
        //        if (window is Window currentWindow)
        //        {
        //            if (currentWindow.Title == "MenagerWindow")
        //            {
        //                return currentWindow;
        //            }
        //            else if (currentWindow.Title == "BaseWindow")
        //            {
        //                return currentWindow;
        //            }
        //        }
        //    }

        //    return null;
        //}


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    DBEntities.GetContext().Service.Add(new Service()
            //    {
            //        ServiceName = NameServiceTb.Text,
            //        ServicePrice = Int32.Parse(PriceTb.Text),

            //    });
            //    DBEntities.GetContext().SaveChanges();
            //    (App.Current.Windows[0] as BaseWindow).MainFrame2.Content = null;
            //    (App.Current.Windows[0] as BaseWindow).MainFrame.Navigate(new ClientPage());
            //}
            //catch (Exception ex)
            //{
            //    MBClass.ShowErrorPopup(ex.Message, Application.Current.MainWindow);
            //    throw;
            //}
        }
    }
}
