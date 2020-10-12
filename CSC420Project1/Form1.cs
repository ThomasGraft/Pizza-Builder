using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CSC420Project1
{
   
    public partial class Form1 : Form
    {
        public static List<Pizza> pizzaList = new List<Pizza>();

        public Form1()
        {
            InitializeComponent();
        }

        public void CreatePizza()
        {
            var size = GetCheckedRadio(panel1);
            var crust = GetCheckedRadio(panel2);
            var toppings = GetSelectedItem();
            var quantity = Convert.ToInt32(Math.Round(numericUpDown1.Value, 0));

            var p = new Pizza(size, crust, toppings, quantity);

            pizzaList.Add(p);
            listBox1.Items.Add(p);
            radioButton1.Checked = true;
            radioButton6.Checked = true;
            numericUpDown1.Value = 1;

            foreach (var item in panel3.Controls)
            {
                if (item is CheckBox)
                {
                    ((CheckBox)item).Checked = false;
                }
            }
        }

        public string GetCheckedRadio(Control container) => 
            container.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Text;

        public List<string> GetSelectedItem() => 
            (from Control c in panel3.Controls where c is CheckBox && ((CheckBox)c).Checked select c.Text).ToList();

        public void PizzaMaker(string name)
        {
            PizzaSaver p = new PizzaSaver();

            p.Name = name;
            p.Size = GetCheckedRadio(panel1);
            p.Crust = GetCheckedRadio(panel2);
            p.Quantity = Convert.ToInt32(Math.Round(numericUpDown1.Value, 0));
            p.Toppings = GetSelectedItem();
        }

        public void PizzaSelector(string value)
        {

            switch (value.ToUpper())
            {
                case "MEAT LOVERS":
                    checkBox1.Checked = true;
                    checkBox2.Checked = true;
                    checkBox3.Checked = true;
                    checkBox4.Checked = true;
                    break;

                case "SUPREME":
                    checkBox1.Checked = true;
                    checkBox2.Checked = true;
                    checkBox5.Checked = true;
                    checkBox6.Checked = true;
                    checkBox7.Checked = true;
                    checkBox8.Checked = true;
                    break;
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            CreatePizza();
        }
        
        private void Order_Click(object sender, EventArgs e)
        {
            Hide();
            var form2 = new Form2();
            form2.Closed += (s, args) => Close();
            form2.Show();
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                int i = listBox1.SelectedIndex;
                pizzaList.Remove(pizzaList[i]);
                listBox1.Items.RemoveAt(i);
            }
            
            else
            {
                MessageBox.Show("Please select an item to remove.");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var item in this.Controls)
            {
                if (item is CheckBox)
                {
                    ((CheckBox)item).Checked = false;
                }
            }

            var value = comboBox1.SelectedItem.ToString();

            PizzaSelector(value);
            
        }
    }
}
