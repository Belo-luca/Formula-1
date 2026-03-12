using F1_2026;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace F1
{
    public partial class Classifica : Form
    {
        public Classifica()
        {
            InitializeComponent();
        }

        private void Classifica_Load(object sender, EventArgs e)
        {
            StagioneF1 stagione = Program.stagione;
            int Npiloti = stagione.Piloti.Count;

            TableLayoutPanel tabella = new TableLayoutPanel();
            tabella.ColumnCount = 7;
            tabella.RowCount = Npiloti + 1;
            tabella.Dock = DockStyle.Fill;
            tabella.AutoScroll = true;

            for (int i = 0; i < tabella.ColumnCount; i++)
            {
                tabella.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / 7f));
            }

            string[] headers = { "Pos", "Pilota", "Squadra", "Punti", "Vittorie", "Podio", "Giri Veloci" };
            for (int i = 0; i < headers.Length; i++)
            {
                Label headerLabel = new Label();
                headerLabel.Text = headers[i];
                headerLabel.Font = new Font("Arial", 10, FontStyle.Bold);
                headerLabel.Dock = DockStyle.Fill;
                headerLabel.TextAlign = ContentAlignment.MiddleCenter;
                headerLabel.BackColor = Color.LightGray;
                tabella.Controls.Add(headerLabel, i, 0);
            }

            // Ordinamento manuale dei piloti
            List<Pilota> pilotiOrdinati = new List<Pilota>();
            foreach (Pilota pilota in stagione.Piloti)
            {
                pilotiOrdinati.Add(pilota);
            }

            for (int i = 0; i < pilotiOrdinati.Count - 1; i++)
            {
                for (int j = i + 1; j < pilotiOrdinati.Count; j++)
                {
                    bool swap = false;
                    if (pilotiOrdinati[j].Punti > pilotiOrdinati[i].Punti)
                        swap = true;
                    else if (pilotiOrdinati[j].Punti == pilotiOrdinati[i].Punti && pilotiOrdinati[j].Vittorie > pilotiOrdinati[i].Vittorie)
                        swap = true;

                    if (swap)
                    {
                        Pilota temp = pilotiOrdinati[i];
                        pilotiOrdinati[i] = pilotiOrdinati[j];
                        pilotiOrdinati[j] = temp;
                    }
                }
            }

            for (int r = 0; r < pilotiOrdinati.Count; r++)
            {
                Pilota p = pilotiOrdinati[r];
                int rigaSorgente = r + 1;

                Label posLabel = new Label();
                posLabel.Text = (r + 1).ToString();
                posLabel.TextAlign = ContentAlignment.MiddleCenter;
                posLabel.Dock = DockStyle.Fill;
                tabella.Controls.Add(posLabel, 0, rigaSorgente);

                Label pilotaLabel = new Label();
                pilotaLabel.Text = p.Pilota;
                pilotaLabel.TextAlign = ContentAlignment.MiddleLeft;
                pilotaLabel.Dock = DockStyle.Fill;
                tabella.Controls.Add(pilotaLabel, 1, rigaSorgente);

                Label squadraLabel = new Label();
                squadraLabel.Text = p.Squadra;
                squadraLabel.TextAlign = ContentAlignment.MiddleLeft;
                squadraLabel.Dock = DockStyle.Fill;
                tabella.Controls.Add(squadraLabel, 2, rigaSorgente);

                Label puntiLabel = new Label();
                puntiLabel.Text = p.Punti.ToString();
                puntiLabel.TextAlign = ContentAlignment.MiddleCenter;
                puntiLabel.Dock = DockStyle.Fill;
                tabella.Controls.Add(puntiLabel, 3, rigaSorgente);

                Label vittorieLabel = new Label();
                vittorieLabel.Text = p.Vittorie.ToString();
                vittorieLabel.TextAlign = ContentAlignment.MiddleCenter;
                vittorieLabel.Dock = DockStyle.Fill;
                tabella.Controls.Add(vittorieLabel, 4, rigaSorgente);

                Label podioLabel = new Label();
                podioLabel.Text = p.Podio.ToString();
                podioLabel.TextAlign = ContentAlignment.MiddleCenter;
                podioLabel.Dock = DockStyle.Fill;
                tabella.Controls.Add(podioLabel, 5, rigaSorgente);

                Label giriVelociLabel = new Label();
                giriVelociLabel.Text = p.GiriVeloci.ToString();
                giriVelociLabel.TextAlign = ContentAlignment.MiddleCenter;
                giriVelociLabel.Dock = DockStyle.Fill;
                tabella.Controls.Add(giriVelociLabel, 6, rigaSorgente);
            }

            this.Controls.Add(tabella);
        }
    }
}
