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
    public partial class frmAssessment : Form
    {
        private Traitify _traitify = new TraitifyClient().traitify;
        private int _currentSlide = 0;
        private bool _autoComplete = true;

        private List<Slide> _slides;
        public List<Slide> slides
        {
            set
            {
               _slides = value;
               LoadSlide();
            }
        }

        private Assessment _assessment;
        public Assessment assessment
        {
            set
            {
                _assessment = value;
            }
        }

        public frmAssessment()
        {
            InitializeComponent();
        }

        private void btnMe_Click(object sender, EventArgs e)
        {
            this.SendAnswer(true);
        }

        private void btnNotMe_Click(object sender, EventArgs e)
        {
            this.SendAnswer(false);
        }

        private void SendAnswer(bool answer)
        {
            _slides[_currentSlide].response = answer;
            _slides[_currentSlide].time_taken = 2;
            _currentSlide += 1;

            if(_currentSlide > 3 && _autoComplete == true)
            {
                // This is to provide an option when testing assessments
                if(MessageBox.Show("Do you want to auto-complete?", "Auto-Complete Assessment", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    foreach (Slide side in _slides)
                    {
                        side.response = true;
                        side.time_taken = 2;
                    }
                    _currentSlide = _slides.Count();
                }
                else
                {
                    _autoComplete = false;
                }
            }
            LoadSlide();
        }

        private void LoadSlide()
        {
            Cursor.Current = Cursors.WaitCursor;
            if (_slides != null)
            {
                if(_currentSlide < _slides.Count())
                {
                    label1.Text = _slides[_currentSlide].caption;
                    pbSlide.Load(_slides[_currentSlide].image_desktop);
                }
                else
                {
                    _traitify.SetSlideBulkUpdate(_assessment.id, _slides);

                    frmResults frm = new frmResults();
                    frm.assessment = _assessment;
                    frm.Show();
                    this.Close();
                }
            }
        }
    }
}
