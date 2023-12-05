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
            if (txtUserName.Text.Trim().Count() <= 3)
            {
                MessageBox.Show("Username is too short");
                return;
            }
            if (txtPassword.Password.Trim().Count() < 5)
            {
                MessageBox.Show("Password is too short");
                txtPassword.Password = null;
                return;
            }

            using (AppDbContext context = new())
            {
                GreenThumbUOW uow = new(context);

                var user = await uow.UserRepository.GetByUsername(txtUserName.Text);

                if (user != null)
                {
                    MessageBox.Show("User already exists");
                    return;
                }

                UserModel model = new UserModel() { UserName = txtUserName.Text, UserPassword = txtPassword.Password, UserEmail = txtEmail.Text, Garden = new GardenModel { } };

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
