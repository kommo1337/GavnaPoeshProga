using Register_Page.DataFolder;
using System.Windows;

namespace Register_Page.PageFolder.AdminEditPageFolder
{
    /// <summary>
    /// Логика взаимодействия для FullInfoCLient.xaml
    /// </summary>
    public partial class FullInfoCLient : Window
    {
        Customer worker = new Customer();
        public FullInfoCLient(Customer worker)
        {
            InitializeComponent();

            DataContext = worker;

            this.worker.IdCustomer = worker.IdCustomer;


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
