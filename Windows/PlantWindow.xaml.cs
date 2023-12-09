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

        // OLD SEARCH CODE, USELESS
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

        //Removes the logged in user from the usermanager and opens the login window
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

        // Check if the text is the placeholder and if it is, show the entire list. Otherwise return and show a list with all the plants with the names that contains the search term.
        // This results a nice and responsive search bar, and also enables the user to search partial terms and get all results, ex 
        // Yellow tulip and blue tulip or w/e will both appear even if the user only searched for tulip or even just "t"
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



        // These 2 methods ensures that there is placeholder text in the searchbar that only appears when the field is empty so that the user keeps the search results even
        //When they deselect it. 
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