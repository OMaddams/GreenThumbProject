using GreenThumbProject.Database;
using GreenThumbProject.Managers;
using GreenThumbProject.Models;
using GreenThumbProject.Windows;
using System.Windows;

namespace GreenThumbProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string userName = txtUserName.Text.Trim();
            string password = txtPassword.Password;

            using (AppDbContext context = new AppDbContext())
            {
                GreenThumbUOW uow = new(context);
                UserModel? model = await uow.UserRepository.GetByUsername(userName);
                if (model != null)
                {
                    if (model.UserPassword == password)
                    {
                        UserManager.loggedInUser = model;
                        PlantWindow plantWindow = new PlantWindow();
                        plantWindow.Show();
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Password was incorrect");
                    }
                }
                else
                {
                    MessageBox.Show("User doesn't exist");
                }

            }
        }
    }
}