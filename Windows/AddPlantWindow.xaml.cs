using GreenThumbProject.Database;
using GreenThumbProject.Models;
using System.Windows;
using System.Windows.Controls;

namespace GreenThumbProject.Windows
{
    /// <summary>
    /// Interaction logic for AddPlantWindow.xaml
    /// </summary>
    public partial class AddPlantWindow : Window
    {
        public List<string> PlantInstructions = new List<string>();
        public AddPlantWindow()
        {
            InitializeComponent();
        }

        private void btnAddIns_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtInstruction.Text))
            {
                if (!PlantInstructions.Contains(txtInstruction.Text))
                {
                    PlantInstructions.Add(txtInstruction.Text);
                    FillList();
                    txtInstruction.Text = string.Empty;
                }
            }
        }
        private void btnRemoveIns_Click(object sender, RoutedEventArgs e)
        {
            if (lstInstructions.SelectedItem != null)
            {


                PlantInstructions.Remove((string)lstInstructions.SelectedItem);
                FillList();

            }
        }

        private void FillList()
        {
            lstInstructions.Items.Clear();
            foreach (var item in PlantInstructions)
            {
                ListViewItem lstitem = new ListViewItem();
                lstitem.Tag = item;
                lstitem.Content = item;
                lstInstructions.Items.Add(item);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure?", "Cancel confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                PlantWindow plantWindow = new PlantWindow();
                plantWindow.Show();

                Close();
            }

        }

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            using (AppDbContext context = new())
            {
                GreenThumbUOW uow = new(context);

                PlantModel plantModel = new PlantModel() { PlantName = txtName.Text };

                await context.Plants.AddAsync(plantModel);
                await uow.Complete();

                PlantModel? addedPlant = await uow.PlantRepository.GetByNameAsync(txtName.Text);

                if (addedPlant != null)
                {
                    foreach (string instruction in PlantInstructions)
                    {
                        InstructionModel instructionModel = new InstructionModel() { InstructionDescription = instruction, PlantId = addedPlant.PlantId };
                        await context.Instructions.AddAsync(instructionModel);
                        await uow.Complete();

                    }
                }


            }

            PlantWindow plantwindow = new PlantWindow();
            plantwindow.Show();
            Close();
        }
    }
}