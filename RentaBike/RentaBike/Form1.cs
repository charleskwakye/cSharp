namespace RentaBike
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private BikeRental myBikeRental = new BikeRental();



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bike selected = (Bike)listBoxOfBikes.SelectedItem;
            myBikeRental.DeregisterRent(selected);
            showItemsInListBox();

        } 

        private void button1_Click(object sender, EventArgs e)
        {







        }

        private void rentabike(object sender, EventArgs e)
        {
            Bike myBike = new Bike(textBoxSerialNumberInput.Text, textBoxBikeDescriptionInput.Text);
            
            myBikeRental.RegisterRent(myBike);
            showItemsInListBox();


        }

        private void showItemsInListBox()
        {
            listBoxOfBikes.Items.Clear();
            foreach (Bike item in myBikeRental.RentedBikes)
            {
                listBoxOfBikes.Items.Add(item);
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBoxOfBikes_SelectedIndexChanged(object sender, EventArgs e)
        {
            //listBoxOfBikes.DataSource =  RentedBikes;
        }

    }
}