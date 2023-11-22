using Register_Page.ClassFolder;
using Register_Page.DataFolder;
using System;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Register_Page.PageFolder.AdminEditPageFolder
{
    /// <summary>
    /// Логика взаимодействия для FullInfoWorker.xaml
    /// </summary>

 

    public partial class FullInfoWorker : Window
    {
        
        Employee worker = new Employee();
        public FullInfoWorker(Employee worker)
        {
            InitializeComponent();

            DataContext = worker;

           

            try
            {
                this.worker.IdEmployee = worker.IdEmployee;
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);

            }

            


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
