using GreenThumbProject.Database;
using GreenThumbProject.Managers;
using GreenThumbProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Windows;
using System.Windows.Controls;

namespace GreenThumbProject.Windows
{
    /// <summary>
    /// Interaction logic for PlantDetailsWindow.xaml
    /// </summary>
    public partial class PlantDetailsWindow : Window
    {
        public PlantModel PlantModel { get; set; }
        public PlantDetailsWindow(PlantModel plantModel)
        {
            InitializeComponent();
            PlantModel = plantModel;
            FillFields();

        }

        private void FillFields()
        {

            using (AppDbContext context = new())
            {
                var plant = context.Plants.Include(p => p.Instructions).First(p => p.PlantName == PlantModel.PlantName);
                txtName.Text = PlantModel.PlantName;
                txtDescription.Text = PlantModel.PlantDescription;
                var instructions = plant.Instructions.ToList();
                foreach (var instruction in instructions)
                {
                    ListViewItem item = new ListViewItem();
                    item.Tag = instruction;
                    item.Content = instruction.ToString();
                    lstInstructions.Items.Add(item);
                }
            }



        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private async void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            using (AppDbContext context = new())
            {
                GreenThumbUOW uow = new(context);
                if (UserManager.loggedInUser == null)
                {
                    return;
                }
                int userId = UserManager.loggedInUser.UserId;
                GardenModel? garden = await uow.GardenRepository.GetByUserId(userId);
                if (garden == null)
                {
                    return;
                }
                GardenPlantModel gardenPlantModel = new() { GardenId = garden.GardenId, PlantId = PlantModel.PlantId };
                await uow.GardenPlantRepository.AddAsync(gardenPlantModel);
                await uow.Complete();
            }
            Close();

        }
    }
}
