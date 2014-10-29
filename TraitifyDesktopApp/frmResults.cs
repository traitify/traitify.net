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
    public partial class frmResults : Form
    {
        private Traitify _traitify = new TraitifyClient().traitify;
        private Assessment _assessment;
        public Assessment assessment
        {
            set { _assessment = value; }
        }

        public frmResults()
        {
            InitializeComponent();
        }

        private void frmResults_Load(object sender, EventArgs e)
        {
            try
            {
                AssessmentPersonalityTypes types = _traitify.GetPersonalityTypes(_assessment.id);
                lblPersonalityBlend.Text = types.personality_blend.personality_type_1.name + "/" + types.personality_blend.personality_type_2.name;
                pbImage1.Load(types.personality_blend.personality_type_1.badge.image_small);
                pbImage2.Load(types.personality_blend.personality_type_2.badge.image_small);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            } 
        }
    }
}
