using Register_Page.DataFolder;
using System.Windows;

namespace Register_Page.PageFolder.AdminEditPageFolder
{
    /// <summary>
    /// Логика взаимодействия для FulinfoUser.xaml
    /// </summary>
    public partial class FulinfoUser : Window
    {
        User worker = new User();
        public FulinfoUser(User worker)
        {
            InitializeComponent();

            DataContext = worker;

            this.worker.IdUser = worker.IdUser;


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}
