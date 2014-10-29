using com.traitify.net.TraitifyLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TraitifyDesktopApp
{
   

    public partial class frmMain : Form
    {
        private Traitify _traitify;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                _traitify = new TraitifyClient().traitify;

                List<Deck> decks = _traitify.GetDecks();
                comboBox1.DataSource = decks;
                comboBox1.DisplayMember = "Name";
                comboBox1.ValueMember = "id";
            }
            catch (Exception ex)
            {
                btnGo.Enabled = false;
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            Assessment assessment = _traitify.CreateAssesment(comboBox1.SelectedValue.ToString());
            List<Slide> slides = _traitify.GetSlides(assessment.id);
            
            frmAssessment frm = new frmAssessment();
            frm.assessment = assessment;
            frm.slides = slides;
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
