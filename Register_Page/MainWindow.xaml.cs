using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace Register_Page
{
    public partial class MainWindow : Window
    {
        private bool isReverse = false;

        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new Page1());
            Loaded += Window_Loaded;
        }

        private void Border_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left) this.DragMove();
        }




        private void button_Click(object sender, RoutedEventArgs e)
        {

            if (!isReverse)
            {
                Storyboard myStoryboard = (Storyboard)this.Resources["MainAnimation"];
                myStoryboard.Completed += MyStoryboard_Completed;
                myStoryboard.Begin();
                Page currentPage = MainFrame.Content as Page;

                if (currentPage != null)
                {
                    // Создаем анимацию затухания
                    DoubleAnimation fadeOutAnimation = new DoubleAnimation
                    {
                        From = 1.0,
                        To = 0.0,
                        Duration = TimeSpan.FromSeconds(0.5)
                    };

                    // Обработчик завершения анимации
                    fadeOutAnimation.Completed += (s, _) =>
                    {
                        // Переход на новую страницу после завершения анимации
                        MainFrame.Navigate(new Page2());
                    };

                    // Начинаем анимацию на текущей странице в Frame
                    currentPage.BeginAnimation(UIElement.OpacityProperty, fadeOutAnimation);
                }
            }
            else
            {
                Storyboard reverseStoryboard = (Storyboard)this.Resources["ReverseAnimation"];
                reverseStoryboard.Completed += ReverseStoryboard_Completed; ;
                reverseStoryboard.Begin();
                Page currentPage = MainFrame.Content as Page;

                if (currentPage != null)
                {
                    // Создаем анимацию затухания
                    DoubleAnimation fadeOutAnimation = new DoubleAnimation
                    {
                        From = 1.0,
                        To = 0.0,
                        Duration = TimeSpan.FromSeconds(0.5)
                    };

                    // Обработчик завершения анимации
                    fadeOutAnimation.Completed += (s, _) =>
                    {
                        // Переход на новую страницу после завершения анимации
                        MainFrame.Navigate(new Page1());
                    };

                    // Начинаем анимацию на текущей странице в Frame
                    currentPage.BeginAnimation(UIElement.OpacityProperty, fadeOutAnimation);
                }
            }

            isReverse = !isReverse;

            // Получаем текущую страницу в Frame



        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Найдем анимацию по ключу
            //Storyboard animation = FindResource("Rect") as Storyboard;
            //if (animation != null)
            //{
            //    // Устанавливаем обработчик события Completed для анимации
            //    animation.Completed += Animation_Completed;
            //    animation.RepeatBehavior = RepeatBehavior.Forever;
            //    animation.Begin();
            //}

            Storyboard animation2 = FindResource("Gradient") as Storyboard;
            if (animation2 != null)
            {
                // Устанавливаем обработчик события Completed для анимации
                animation2.Completed += Animation_Completed2;
                animation2.RepeatBehavior = RepeatBehavior.Forever;
                animation2.Begin();
            }
        }

        private void Animation_Completed(object sender, EventArgs e)
        {
            // Перезапускаем анимацию при завершении
            Storyboard animation = sender as Storyboard;
            if (animation != null)
            {
                animation.Begin();
            }
        }
        private void Animation_Completed2(object sender, EventArgs e)
        {
            // Перезапускаем анимацию при завершении
            Storyboard animation2 = sender as Storyboard;
            if (animation2 != null)
            {
                animation2.Begin();
            }
        }



        private void ReverseStoryboard_Completed(object sender, EventArgs e)
        {
            //MainFrame.Navigate(new Page2());
        }

        private void MyStoryboard_Completed(object sender, EventArgs e)
        {
            //MainFrame.Navigate(new Page1());
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            App.Current.Shutdown();
        }
    }
}