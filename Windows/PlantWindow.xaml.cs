using GreenThumbProject.Database;
using GreenThumbProject.Managers;
using GreenThumbProject.Models;
using Microsoft.EntityFrameworkCore;
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
            AddPlantWindow addPlantWindow = new AddPlantWindow();
            addPlantWindow.Show();
            Close();
        }

        private void btnDetails_Click(object sender, RoutedEventArgs e)
        {
            PlantModel? selectedPlant = null;

            if (lstPlants.SelectedItem != null)
            {
                ListViewItem selectedItem = (ListViewItem)lstPlants.SelectedItem;
                selectedPlant = (PlantModel)selectedItem.Tag;
            }

            if (selectedPlant != null)
            {

                PlantDetailsWindow detailsWindow = new PlantDetailsWindow(selectedPlant);
                detailsWindow.ShowDialog();
            }

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


        //TODO :ADD BETTER SEARCH FUNCTIONALITY IF THERE IS TIME
        //USING  ON CHANGE TEXTFIELD :: CONTAINS 
        // DONE!
        /* private async void btnSearch_Click(object sender, RoutedEventArgs e)
         {
             string search = txtPlantSearch.Text;
             if (string.IsNullOrEmpty(search))
             {
                 FillListAsync();
                 return;
             }

             using (AppDbContext context = new())
             {
                 GreenThumbUOW uow = new(context);

                 PlantModel? searchedPlant = await uow.PlantRepository.GetByNameAsync(search);

                 if (searchedPlant != null)
                 {
                     lstPlants.Items.Clear();
                     ListViewItem lstItem = new();
                     lstItem.Tag = searchedPlant;
                     lstItem.Content = searchedPlant.PlantName;
                     lstPlants.Items.Add(lstItem);
                 }
                 else
                 {
                     MessageBox.Show("Plant not found");
                 }

             }

         }*/

        private void btnSignout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            UserManager.loggedInUser = null;
            mainWindow.Show();
            Close();
        }

        private void btnGarden_Click(object sender, RoutedEventArgs e)
        {
            MyGardenWindow myGardenWindow = new MyGardenWindow();
            myGardenWindow.Show();
            Close();
        }

        private async void txtPlantSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string search = txtPlantSearch.Text;
            if (string.IsNullOrEmpty(search) || search == "Search..")
            {
                FillListAsync();
                return;
            }

            using (AppDbContext context = new())
            {
                GreenThumbUOW uow = new(context);

                var searchedPlants = await context.Plants.Where(p => p.PlantName.Contains(search)).ToListAsync();

                if (searchedPlants != null)
                {
                    lstPlants.Items.Clear();
                    foreach (PlantModel searchedPlant in searchedPlants)
                    {

                        ListViewItem lstItem = new();
                        lstItem.Tag = searchedPlant;
                        lstItem.Content = searchedPlant.PlantName;
                        lstPlants.Items.Add(lstItem);
                    }

                }

            }
        }


        private void txtPlantSearch_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtPlantSearch.Text == "Search..")
            {
                txtPlantSearch.Text = string.Empty;
            }
        }

        private void txtPlantSearch_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtPlantSearch.Text == string.Empty)
            {
                txtPlantSearch.Text = "Search..";
            }
        }
    }
}