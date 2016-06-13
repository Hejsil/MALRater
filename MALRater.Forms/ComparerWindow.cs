using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MALRater.AnimeRater;

namespace MALRater.Forms
{
    public partial class ComparerWindow : Form
    {
        public AnimeRater Rater { get; set; }

        public ComparerWindow(AnimeRater rater)
        {
            Rater = rater;
            InitializeComponent();
            UpdateAll();
            IsEnabled(true);
        }

        private void dontrateButton_Click(object sender, EventArgs e)
        {
            MakeChoice(Choice.DontRate);
        }

        private void equalButton_Click(object sender, EventArgs e)
        {
            MakeChoice(Choice.AboutEqual);
        }

        private void currPicture_Click(object sender, EventArgs e)
        {
            MakeChoice(Choice.CurrentIsBetter);
        }

        private void compPicture_Click(object sender, EventArgs e)
        {
            MakeChoice(Choice.CurrentIsWorse);
        }

        void MakeChoice(Choice choice)
        {
            IsEnabled(false);
            Rater.Choose(choice);

            if (Rater.IsDone)
                Close();
            else
            {
                UpdateAll();
                IsEnabled(true);
            }
        }

        void UpdateAll()
        {
            compLabel.Text = Rater.ComparedTo.Title;
            currLabel.Text = Rater.CurrentlyRating.Title;
            compPicture.ImageLocation = Rater.ComparedTo.Image;
            currPicture.ImageLocation = Rater.CurrentlyRating.Image;
        }

        void IsEnabled(bool enabled)
        {
            currPicture.Enabled = enabled;
            compPicture.Enabled = enabled;
            dontrateButton.Enabled = enabled;
            equalButton.Enabled = enabled;
        }
    }
}
