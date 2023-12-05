using GreenThumbProject.Database;
using GreenThumbProject.Models;
using System.Windows;

namespace GreenThumbProject.Windows
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private async void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            using (AppDbContext context = new())
            {
                GreenThumbUOW uow = new(context);

                var user = await uow.UserRepository.GetByUsername(txtUserName.Text);

                if (user != null)
                {
                    MessageBox.Show("User already exists");
                    return;
                }

                UserModel model = new UserModel() { UserName = txtUserName.Text, UserPassword = txtPassword.Password, Garden = new GardenModel { } };

                await context.Users.AddAsync(model);
                await uow.Complete();
            }
            MessageBox.Show("User created");
            MainWindow main = new MainWindow();
            main.Show();
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}
