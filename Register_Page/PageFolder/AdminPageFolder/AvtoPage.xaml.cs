using Register_Page.ClassFolder;
using Register_Page.DataFolder;
using Register_Page.PageFolder.AdminAddPageFolder;
using Register_Page.PageFolder.AdminEditPageFolder;
using Register_Page.WindowFolder;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Register_Page.PageFolder.AdminPageFolder
{
    /// <summary>
    /// Логика взаимодействия для AvtoPage.xaml
    /// </summary>
    public partial class AvtoPage : Page
    {

        public AvtoPage()
        {
            InitializeComponent();

            membersDataGrid.ItemsSource = DBEntities.GetContext().PriceList.
                    ToList().OrderBy(u => u.IdPriceList);
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

        private void EditInGridBTN_Click(object sender, RoutedEventArgs e)
        {
            if (membersDataGrid.SelectedItem == null)
            {
                MBClass.ShowErrorPopup("Выбиерите автомобиль", Application.Current.MainWindow);

            }
            else
            {
                Window currentWindow = GetCurrentWindow() as Window;
                if (currentWindow is MenagerBaseWindow)
                {
                    ((MenagerBaseWindow)currentWindow).MainFrame2.Navigate(new EditAuto(membersDataGrid.SelectedItem as PriceList));
                    ((MenagerBaseWindow)currentWindow).MainFrame.Content = null;
                }
                else
                {
                    (App.Current.Windows[0] as BaseWindow).MainFrame2.Navigate(new EditAuto(membersDataGrid.SelectedItem as PriceList));
                    (App.Current.Windows[0] as BaseWindow).MainFrame.Content = null;
                }
            }
        }

        private void DeleteInGridBTN_Click(object sender, RoutedEventArgs e)
        {
            PriceList auto = membersDataGrid.SelectedItem as PriceList;

            DBEntities.GetContext().PriceList
                        .Remove(membersDataGrid.SelectedItem as PriceList);
            DBEntities.GetContext().SaveChanges();

            MBClass.ShowMesagePopup("Успешно", Application.Current.MainWindow);

            membersDataGrid.ItemsSource = DBEntities.GetContext()
                .PriceList.ToList().OrderBy(u => u.IdPriceList);

        }

        private void CloseWindowBTN_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MinimizeWindowBTN_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddBTN_Click(object sender, RoutedEventArgs e)
        {
            (App.Current.Windows[0] as BaseWindow).MainFrame2.Navigate(new AddAutoPage());
            (App.Current.Windows[0] as BaseWindow).MainFrame.Content = null;
        }

        private void AddBTN2_Click(object sender, RoutedEventArgs e)
        {

            (App.Current.Windows[0] as MenagerBaseWindow).MainFrame2.Navigate(new AddAutoPage());
            (App.Current.Windows[0] as MenagerBaseWindow).MainFrame.Content = null;

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var item in App.Current.Windows)
            {
                if ((item as Window).Title == "MenagerWindow")
                {
                    AddBTN.Click -= AddBTN_Click;
                    AddBTN.Click += AddBTN2_Click;
                }

            }
        }

        private void textBoxFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            membersDataGrid.ItemsSource = DBEntities.GetContext()
                .PriceList.Where(u => u.NamePosition
                .StartsWith(textBoxFilter.Text))
                .ToList().OrderBy(u => u.NamePosition);
            if (membersDataGrid.Items.Count <= 0)
            {
                MBClass.ShowErrorPopup("Данные не найдены", Application.Current.MainWindow);
            }
        }
    }
}
