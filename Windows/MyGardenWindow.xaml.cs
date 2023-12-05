using GreenThumbProject.Database;
using GreenThumbProject.Managers;
using GreenThumbProject.Models;
using System.Windows;
using System.Windows.Controls;

namespace GreenThumbProject.Windows
{
    /// <summary>
    /// Interaction logic for MyGardenWindow.xaml
    /// </summary>
    public partial class MyGardenWindow : Window
    {
        public MyGardenWindow()
        {
            InitializeComponent();
            FillList();
        }

        private void FillList()
        {
            if (UserManager.loggedInUser == null)
            {
                return;
            }
            using (AppDbContext context = new())
            {

                GreenThumbUOW uow = new(context);
                GardenModel garden = context.Garden.Where(g => g.UserId == UserManager.loggedInUser.UserId).First();
                var UsersPlants = context.GardenPlant.Where(gp => gp.GardenId == garden.GardenId).Select(gp => gp.Plant).ToList();
                foreach (var item in UsersPlants)
                {
                    ListViewItem lstItem = new ListViewItem();
                    lstItem.Tag = item;
                    lstItem.Content = item.PlantName;
                    lstGarden.Items.Add(lstItem);
                }

            }
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            PlantWindow plantWindow = new PlantWindow();
            plantWindow.Show();
            Close();
        }
    }
}
