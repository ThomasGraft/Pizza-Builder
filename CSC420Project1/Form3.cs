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
    
    public partial class Form3 : Form
    {
       
        public Form3()
        {
            InitializeComponent();
        }

       
        private void New_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Application.ExecutablePath); 
            this.Close(); 
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
