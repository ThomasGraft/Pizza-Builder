using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSC420Project1
{
    public partial class Form2 : Form
    {
        public void SetPrice()
        {
            double total = 0;
            foreach (var item in Form1.pizzaList)
            {
                total += item.Price;
            }
            label3.Text = string.Format("{0:C}", total);
        }

        public void FillListBox()
        {

            foreach (var item in Form1.pizzaList)
            {
                listBox1.Items.Add(item);
            }
        }

        public Form2()
        {
            InitializeComponent();
            FillListBox();
            SetPrice();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Hide();
            var form3 = new Form3();
            form3.Closed += (s, args) => Close();
            form3.Show();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Close();
            
        }
    }
}
