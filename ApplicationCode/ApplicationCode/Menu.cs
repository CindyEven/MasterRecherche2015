using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApplicationCode
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btn_module1_Click(object sender, EventArgs e)
        {
            Module1 module1 = Application.OpenForms.OfType<Module1>().FirstOrDefault();
            if (module1 == null)
            {
                module1 = new Module1();
                module1.Show();
            }
            else module1.BringToFront();
        }

        private void btn_module2_Click(object sender, EventArgs e)
        {
            Module2 module2 = Application.OpenForms.OfType<Module2>().FirstOrDefault();
            if (module2 == null)
            {
                module2 = new Module2();
                module2.Show();
            }
            else module2.BringToFront();
        }

        private void btn_module3_Click(object sender, EventArgs e)
        {
            Module3 module3 = Application.OpenForms.OfType<Module3>().FirstOrDefault();
            if (module3 == null)
            {
                module3 = new Module3();
                module3.Show();
            }
            else module3.BringToFront();
        }
    }
}
