using Register_Page.ClassFolder;
using Register_Page.DataFolder;
using Register_Page.WindowFolder;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Xml;

namespace Register_Page
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        XmlDocument load;
        XmlElement xmlElement;

        public Page1()
        {
            InitializeComponent();
            LoadCredentialsFromXml();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DoubleAnimation fadeInAnimation = new DoubleAnimation
            {
                From = 0.0,
                To = 1.0,
                Duration = TimeSpan.FromSeconds(0.5) // Продолжительность анимации в секундах
            };

            // Привязка анимации к свойству Opacity элемента (например, Grid или Window)
            MyGrid.BeginAnimation(Grid.OpacityProperty, fadeInAnimation);


        }

        private void LoadCredentialsFromXml()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(@"C:\Users\kommo\source\repos\Register_Page\Register_Page\ResourceFolder\LoadFile.xml");

                XmlNode root = doc.SelectSingleNode("Credentials");
                if (root != null)
                {
                    string username = root.SelectSingleNode("Username")?.InnerText;
                    string password = root.SelectSingleNode("Password")?.InnerText;

                    if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
                    {
                        LoginTb.Text = username;
                        PasswordTb.Password = password;
                    }
                }
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }


        private void SaveCredentialsToXml(string username, string password)
        {


            try
            {
                XmlDocument doc = new XmlDocument();

                if (!RememberChB.IsChecked == true)
                {
                    username = null;
                    password = null;
                }

                XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
                doc.AppendChild(xmlDeclaration);

                XmlElement root = doc.CreateElement("Credentials");
                doc.AppendChild(root);

                if (username != null)
                {
                    XmlElement usernameElement = doc.CreateElement("Username");
                    usernameElement.InnerText = username;
                    root.AppendChild(usernameElement);
                }

                if (password != null)
                {
                    XmlElement passwordElement = doc.CreateElement("Password");
                    passwordElement.InnerText = password;
                    root.AppendChild(passwordElement);
                }

                doc.Save(@"C:\Users\kommo\source\repos\Register_Page\Register_Page\ResourceFolder\LoadFile.xml");
            }
            catch (Exception ex)
            {
                MBClass.ShowErrorPopup(ex.Message, Application.Current.MainWindow);
            }
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var user = DBEntities.GetContext()
                    .User.FirstOrDefault(u => u.LoginUser == LoginTb.Text);

                if (user == null)
                {
                    MBClass.ShowErrorPopup("Не верный логин!", Application.Current.MainWindow);
                    LoginTb.Focus();
                    return;
                }
                if (user.PasswordUser != PasswordTb.Password)
                {
                    MBClass.ShowErrorPopup("Не верный пароль!", Application.Current.MainWindow);
                    PasswordTb.Focus();
                    return;
                }
                else
                {
                    switch (user.IdRole)
                    {
                        case 1:
                            new BaseWindow().Show();
                            string username = LoginTb.Text;
                            string password = PasswordTb.Password;

                            // Сохраняем данные в XML файл
                            SaveCredentialsToXml(username, password);

                            foreach (Window window in Application.Current.Windows)
                            {
                                if (window is Window && window.Title == "Autorisation")
                                {
                                    window.Close();
                                }
                            }
                            break;
                        case 2:
                            new MenagerBaseWindow().Show();
                            string username1 = LoginTb.Text;
                            string password1 = PasswordTb.Password;
                            SaveCredentialsToXml(username1, password1);

                            foreach (Window window in Application.Current.Windows)
                            {
                                if (window is Window && window.Title == "Autorisation")
                                {
                                    window.Close();
                                }
                            }
                            break;

                    }
                }
            }
            catch (Exception ex)
            {
                MBClass.ShowErrorPopup(ex.Message, Application.Current.MainWindow);
            }
        }


    }
}
