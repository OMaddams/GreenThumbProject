using GreenThumbProject.Database;
using GreenThumbProject.Models;
using System.Windows;
using System.Windows.Controls;

namespace GreenThumbProject.Windows
{
    /// <summary>
    /// Interaction logic for PlantWindow.xaml
    /// </summary>
    public partial class PlantWindow : Window
    {
        public PlantWindow()
        {
            InitializeComponent();
            FillListAsync();
        }

        private async void FillListAsync()
        {
            lstPlants.Items.Clear();
            using (AppDbContext context = new())
            {
                GreenThumbUOW uow = new(context);
                var plants = await uow.PlantRepository.GetAllAsync();

                foreach (PlantModel plant in plants)
                {
                    ListViewItem item = new ListViewItem();
                    item.Tag = plant;
                    item.Content = plant.PlantName;
                    lstPlants.Items.Add(item);
                }

            }
        }

        private void btnAddPlant_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDetails_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            PlantModel? selectedPlant = null;

            if (lstPlants.SelectedItem != null)
            {
                ListViewItem selectedItem = (ListViewItem)lstPlants.SelectedItem;
                selectedPlant = (PlantModel)selectedItem.Tag;
            }

            if (selectedPlant != null)
            {
                using (AppDbContext context = new())
                {
                    GreenThumbUOW uow = new(context);
                    await uow.PlantRepository.Delete(selectedPlant);
                    await uow.Complete();
                }

            }
            FillListAsync();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
