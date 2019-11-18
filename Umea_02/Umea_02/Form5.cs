using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Umea_02
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Context context = new Context();

            context.Users.Add(new User() {UserId = Int32.Parse(textBox6.Text),
                                                        UserName =textBox1.Text,
                                                        Address = textBox2.Text,
                                                        Company = textBox3.Text,
                                                        Email = textBox4.Text,
                                                        Phone = textBox5.Text});
            context.SaveChanges();
        }
    }
}
