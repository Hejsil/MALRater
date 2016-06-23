using MALRater.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MALRater.Forms
{
    public partial class MainWindow : Form
    {
        string currentPath;
        bool unsavedChanges;

        public static AnimeClient Client { get; set; }
            = new AnimeClient();

        public MainWindow()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            
            var login = new LoginWindow();

            if (login.ShowDialog() != DialogResult.OK)
                Close();
        }

        void newToolStrip_Click(object sender, EventArgs e)
        {
            Client.Ratings = new AnimeClient.AnimeRatings();
            unsavedChanges = true;
        }

        void openToolStrip_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() != DialogResult.OK)
                    return;

                Client.LoadRatings(openFileDialog1.FileName);
                currentPath = openFileDialog1.FileName;
                UpdateAll();
                unsavedChanges = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
        }

        void saveToolStrip_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(currentPath))
                    saveAsToolStrip_Click(sender, e);
                else
                {
                    Client.SaveRatings(currentPath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
        }

        void saveAsToolStrip_Click(object sender, EventArgs e)
        {
            try
            {
                if (saveFileDialog1.ShowDialog() != DialogResult.OK)
                    return;

                Client.SaveRatings(saveFileDialog1.FileName);
                currentPath = saveFileDialog1.FileName;
                unsavedChanges = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
        }

        void importMALToolStrip_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() != DialogResult.OK)
                    return;

                Client.LoadList(openFileDialog1.FileName);

                if (Client.MALList == null)
                    return;

                exportMALToolStrip.Enabled = true;
                recalcScoreToolStrip.Enabled = true;
                rateUnratedToolStrip.Enabled = true;

                malListView.Items.Clear();
                foreach (var anime in Client.MALList.Anime)
                {
                    malListView.Items.Add(anime.SeriesTitle)
                        .SubItems.Add(anime.MyScore.ToString());
                }

                UpdateUnrated();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
        }

        void exportMALToolStrip_Click(object sender, EventArgs e)
        {
            try
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    Client.SaveList(saveFileDialog1.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void recalcScoreToolStrip_Click(object sender, EventArgs e)
        {
            try
            {
                Client.GiveScores();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void rateUnratedToolStrip_Click(object sender, EventArgs e)
        {
            try
            {
                var rater = Client.GetRater();

                if (!rater.IsDone)
                {
                    var compareWindow = new ComparerWindow(rater);
                    compareWindow.ShowDialog();
                }

                Client.GiveScores();
                UpdateAll();
                unsavedChanges = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void guideToolStrip_Click(object sender, EventArgs e)
        {

        }

        void UpdateAll()
        {
            ratedListBox.Items.Clear();
            foreach (var anime in Client.Ratings.Rated)
            {
                ratedListBox.Items.Add(anime.Title);
            }

            dontrateListBox.Items.Clear();
            foreach (var anime in Client.Ratings.DontRate)
            {
                dontrateListBox.Items.Add(anime.Title);
            }

            UpdateUnrated();
        }

        void UpdateUnrated()
        {
            unratedListBox.Items.Clear();
            foreach (var anime in Client.UnRated)
            {
                unratedListBox.Items.Add(anime.SeriesTitle);
            }

            rateUnratedToolStrip.Enabled = Client.UnRated.Any();
        }
    }
}
