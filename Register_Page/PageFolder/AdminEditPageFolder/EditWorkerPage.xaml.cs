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
    /// Логика взаимодействия для EditWorkerPage.xaml
    /// </summary>
    public partial class EditWorkerPage : Page
    {
        Employee worker = new Employee();
        public EditWorkerPage(Employee worker)
        {
            InitializeComponent();

            DataContext = worker;

            this.worker.IdEmployee = worker.IdEmployee;

            AdressCb.ItemsSource = DBEntities.GetContext()
               .Adress.ToList();
            GenderCb.ItemsSource = DBEntities.GetContext()
              .Gender.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int index = AdressCb.SelectedIndex + 1;
                int index2 = GenderCb.SelectedIndex + 1;
                worker = DBEntities.GetContext().Employee
                    .FirstOrDefault(u => u.IdEmployee == worker.IdEmployee);
                worker.FirstNameEmployee = NameTB.Text;
                worker.LastNameEmployee = SurnameTb.Text;
                worker.MiddleNameEmployee = TherdNameTb.Text;
                worker.PhoneNumberEmployee = PhoneTb.Text;
                worker.NumberPassport = PasportTB.Text;
                worker.IdAdress = index;
                worker.IdGender = index2;
                worker.EmailEmployee = EmailTb.Text;
                
                DBEntities.GetContext().SaveChanges();
                MBClass.ShowMesagePopup("Успешно", Application.Current.MainWindow);
                (App.Current.Windows[0] as BaseWindow).MainFrame2.Content = null;
                (App.Current.Windows[0] as BaseWindow).MainFrame.Navigate(new WorkerPage());

            }
            catch (Exception ex)
            {
                MBClass.ShowErrorPopup(ex.Message, Application.Current.MainWindow);
            }
        }
    }
}
