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

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //Declaration on columns for DataGridView 
            dataGridView1.ColumnCount = 9;

            //Name of Columns
            dataGridView1.Columns[0].Name = "Number:";
            dataGridView1.Columns[1].Name = "Symbol";
            dataGridView1.Columns[2].Name = "Name";
            dataGridView1.Columns[3].Name = "Estimate";
            dataGridView1.Columns[4].Name = "PDF";
            dataGridView1.Columns[5].Name = "Coefficient";
            dataGridView1.Columns[6].Name = "Standard Uncertainty";
            dataGridView1.Columns[7].Name = "Sensitivity Coefficient";
            dataGridView1.Columns[8].Name = "Standard Uncertainty";

            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            comboBox3.Enabled = false;
            comboBox4.Enabled = false;
            comboBox5.Enabled = false;
            comboBox6.Enabled = false;
           
        }
        //This is an example to track
        private void iDNumberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            comboBox5.Items.Clear();

            Context context = new Context();

            var listUb = context.UncertaintyBudgets.ToList();

            foreach (var item in listUb)
            {

                comboBox5.Items.Add(item.UbId);
            }

            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            comboBox3.Enabled = false;
            comboBox4.Enabled = false;
            comboBox5.Enabled = true;
            comboBox6.Enabled = false;
        }

        private void instrumentNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
     
            Context context = new Context();

            var listInstruments = context.Instruments.ToList();

            foreach (var item in listInstruments)
            {
                comboBox2.Items.Add(item.InstrumentName);
            }

            comboBox1.Enabled = false;
            comboBox2.Enabled = true;
            comboBox3.Enabled = false;
            comboBox4.Enabled = false;
            comboBox5.Enabled = false;
            comboBox6.Enabled = false;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.Enabled = false;
            comboBox2.Enabled = true;
            comboBox3.Enabled = false;
            comboBox4.Enabled = false;
            comboBox5.Enabled = false;
            comboBox6.Enabled = true;

            Context context = new Context();

            var queryPage = context.UncertaintyBudgets.Where(q => q.Instrument.InstrumentName == comboBox2.Text).ToList();

            comboBox6.Items.Clear();
           
            int pageNumber = 0;
            
            foreach (var item in queryPage)
                {
                pageNumber++;
                 comboBox6.Items.Add(item.UbId + ") Page nr." + pageNumber) ;
                }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

            Context context = new Context();

            int ubNumber = Int32.Parse(comboBox5.Text.ToString());

            //Query with all information to display
            var queryUb = from ub in context.UncertaintyBudgets
                          join co in context.Contributions on ub.UbId equals co.UbId
                          join i in context.Instruments on ub.InstrumentId equals i.InstrumentId
                          join a in context.Author on ub.AuthorId equals a.AuthorId
                          join u in context.Users on ub.UserId equals u.UserId
                          join p in context.Pdf on co.PdfId equals p.PdfId
                          where (co.UbId.Equals(ubNumber))
                          select new
                          {
                              ubUbId = ub.UbId,
                              aAuthor = ub.Author.AuthorName,
                              uUser = u.UserName,
                              iInstrument = ub.Instrument.InstrumentName,
                              iInstrumentMfg = ub.Instrument.Manufacturer,
                              iInstrumentModel = ub.Instrument.Model,
                              cContributionId = co.ContributionId,
                              cContributionSym = co.Symbol,
                              cContributionName = co.Name,
                              cContributionEst = co.EstimatedValue,
                              cContributionPdf = p.PdfName,
                              cContributionCoeff = p.PdfCoefficient,
                              cContributionSu = co.StandardUncertainty,
                              cContributionCoef = co.SensitivityCoefficient,
                          };

            // Clear dataGridView
            dataGridView1.Rows.Clear();

            foreach (var item in queryUb)
            {  
                comboBox1.Text = item.aAuthor;
                comboBox5.Text = item.ubUbId.ToString();

                comboBox2.Text = item.iInstrument;
                comboBox3.Text = item.iInstrumentMfg;
                comboBox4.Text = item.iInstrumentModel;
                textBox1.Text = item.uUser;

                dataGridView1.Rows.Add(
                    item.cContributionId,
                    item.cContributionSym,
                    item.cContributionName,
                    item.cContributionEst,
                    item.cContributionPdf,
                    item.cContributionCoeff,
                    item.cContributionSu,
                    item.cContributionCoef
                    );
            }

            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            comboBox3.Enabled = false;
            comboBox4.Enabled = false;
            comboBox5.Enabled = true;
            comboBox6.Enabled = false;
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {


            Context context = new Context();
            //MessageBox.Show(comboBox6.Text.Remove(1));
            int ubSelected = Int32.Parse(comboBox6.Text.Remove(1));

                  var queryUbs = from ub in context.UncertaintyBudgets
                                join co in context.Contributions on ub.UbId equals co.UbId
                                join i in context.Instruments on ub.InstrumentId equals i.InstrumentId
                                join a in context.Author on ub.AuthorId equals a.AuthorId
                                join u in context.Users on ub.UserId equals u.UserId
                                join p in context.Pdf on co.PdfId equals p.PdfId
                                where (co.UncertaintyBudget.Instrument.InstrumentName.Equals(comboBox2.Text) && co.UncertaintyBudget.UbId.Equals(ubSelected))
                                select new
                                {
                                    ubUbId = ub.UbId,
                                    aAuthor = ub.Author.AuthorName,
                                    uUser = u.UserName,
                                    iInstrument = ub.Instrument.InstrumentName,
                                    iInstrumentMfg = ub.Instrument.Manufacturer,
                                    iInstrumentModel = ub.Instrument.Model,
                                    cContributionId = co.ContributionId,
                                    cContributionSym = co.Symbol,
                                    cContributionName = co.Name,
                                    cContributionEst = co.EstimatedValue,
                                    cContributionPdf = p.PdfName,
                                    cContributionCoeff = p.PdfCoefficient,
                                    cContributionSu = co.StandardUncertainty,
                                    cContributionCoef = co.SensitivityCoefficient,
                                };

            // Clear dataGridView
            dataGridView1.Rows.Clear();

            foreach (var item in queryUbs)
            {

                comboBox1.Text = item.aAuthor;
                comboBox5.Text = item.ubUbId.ToString();

                comboBox2.Text = item.iInstrument;
                comboBox3.Text = item.iInstrumentMfg;
                comboBox4.Text = item.iInstrumentModel;
                textBox1.Text = item.uUser;

                dataGridView1.Rows.Add(

                    item.cContributionId,
                    item.cContributionSym,
                    item.cContributionName,
                    item.cContributionEst,
                    item.cContributionPdf,
                    item.cContributionCoeff,
                    item.cContributionSu,
                    item.cContributionCoef
                    );
            }

            //comboBox1.Enabled = false;
            //comboBox2.Enabled = false;
            //comboBox3.Enabled = false;
            //comboBox4.Enabled = false;
            //comboBox5.Enabled = true;
            //comboBox6.Enabled = false;
        }

        private void listOfAllUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.ShowDialog();
        }

        private void instrumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        private void authorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.ShowDialog();
        }

        private void userToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.ShowDialog();
        }

        private void instrumentToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            form6.ShowDialog();
        }
    }      
}
