using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace NikitaAleksander
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string userLogin { get; } = "SPAWN";
        public string userPass { get; } = "12345";

        public MainWindow()
        {
            InitializeComponent();
           tbKapcha.Visibility = Visibility.Hidden;
            Vvod.Visibility = Visibility.Hidden;
            Knopka.Visibility = Visibility.Hidden;
            Kapcha.Visibility = Visibility.Hidden;
            kartinka.Visibility = Visibility.Hidden;
            Captcha();
            string path = @"C:\Users\USER\Desktop\Login and Password\note.txt";
            

            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                string login = sr.ReadLine();
                string pass = sr.ReadLine();

                if (pass != null && login != null)
                {
                    txtLogin.Text = login;
                    Password.Text = pass;
                }
            }

        }

        public void swBlocknot()
        {
            string path = @"C:\Users\USER\Desktop\Login and Password\note.txt";

            using (StreamWriter sw = new StreamWriter(path, true))
            {
                if (Save.IsChecked == true)
                {
                    sw.WriteLine();
                    sw.WriteLine(txtLogin.Text);
                    sw.WriteLine(Password.Text);
                    
                }
            }
        }



        private void Knopka_Click(object sender, RoutedEventArgs e)
        {
            Captcha();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        

        private void Password_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Password.Text == "Пароль")
            {
                Password.Clear();
            }
        }
        public void Captcha()
        {
            string arraySymbols = "a b c d e f g h i j k l m n o p q r" +
                                  "s t u v w x w z A B C D E F G H I J" +
                                  "K L M N O P Q R S T U V W Z X W 0 1" +
                                  " 2 3 4 5 6 7 8 9";

            String[] symbols = arraySymbols.Split(' ');
            Random random = new Random();

            Kapcha.Text = string.Empty;

            for (int i = 0; i < 6; i++)
            {
                Kapcha.Text += symbols[random.Next(0, 35)];
            }

        }

        private void Vvod_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Vvod.Text == "Введите капчу")
            {
                Vvod.Clear();
            }
        }

        

        private void Password_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Password.Text == "")
            {
                Password.Text = "Пароль";
            }
        }

        private void Vvod_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Vvod.Text == "")
            {
                Vvod.Text = "Введите капчу";
            }
        }

        private void Vxod_Click(object sender, RoutedEventArgs e)
        {
            swBlocknot();

            if ((txtLogin.Text == userLogin) && (Password.Text == userPass))
            {
                

                var txtlogin = Convert.ToString(txtLogin.Text);
                
                Window1 wnd1 = new Window1(txtLogin.ToString());
                this.Hide();
                wnd1.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Введен неправильный логин или пароль");
                tbKapcha.Visibility = Visibility.Visible;
                Vvod.Visibility = Visibility.Visible;
                Knopka.Visibility = Visibility.Visible;
                Kapcha.Visibility = Visibility.Visible;
                kartinka.Visibility = Visibility.Visible;
                if ((txtLogin.Text == userLogin) && (Password.Text == userPass) && (Vvod.Text == Kapcha.Text))
                {
                    var login = Convert.ToString(txtLogin.Text);

                    this.Hide();
                    Window1 next = new Window1(login.ToString());
                    next.ShowDialog();
                    this.Show();
                }
            }
            
            


        }

        private void txtLogin_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtLogin.Text == "Логин")
            {
                txtLogin.Clear();
            }
        }

        private void txtLogin_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtLogin.Text == "")
            {
                txtLogin.Text = "Логин";
            }
        }
    }
}
