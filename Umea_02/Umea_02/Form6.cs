using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Umea_02
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Context context = new Context();

            context.Instruments.Add(new Instrument() {InstrumentId=Int32.Parse(textBox1.Text), InstrumentName=textBox2.Text, Manufacturer=textBox3.Text, Model = textBox4.Text });
            context.SaveChanges();
        }
    }
}
