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

        public static AnimeClient Client { get; set; }

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
            else
                UpdateAll();
        }

        void newToolStrip_Click(object sender, EventArgs e)
        {
            Client.Ratings = new AnimeClient.AnimeRatings();
        }

        void openToolStrip_Click(object sender, EventArgs e)
        {
            try
            {
                if (openRatingsDialog.ShowDialog() != DialogResult.OK)
                    return;

                Client.LoadRatings(openRatingsDialog.FileName);
                currentPath = openRatingsDialog.FileName;
                UpdateAll();
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
                if (saveRatingsDialog.ShowDialog() != DialogResult.OK)
                    return;

                Client.SaveRatings(saveRatingsDialog.FileName);
                currentPath = saveRatingsDialog.FileName;
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
                malListView.Items.Clear();
                foreach (var anime in Client.MyAnimeList.Anime)
                {
                    malListView.Items.Add(anime.SeriesTitle).SubItems.Add(anime.MyScore.ToString());
                }
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void guideToolStrip_Click(object sender, EventArgs e)
        {

        }

        void myAnimeListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (importMalDialog.ShowDialog() != DialogResult.OK)
                return;

            Client.LoadList(importMalDialog.FileName);
            UpdateAll();
        }

        void UpdateAll()
        {
            if (Client.MyAnimeList?.Anime != null)
            {
                malListView.Items.Clear();
                foreach (var anime in Client.MyAnimeList.Anime)
                {
                    malListView.Items.Add(anime.SeriesTitle).SubItems.Add(anime.MyScore.ToString());
                }
            }

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
