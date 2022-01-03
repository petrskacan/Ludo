using System;
using System.Windows.Forms;
using System.Media;
using System.Drawing;

namespace Člověče_nezlob_se
{
    public partial class Nastaveni : Form
    {
        public Nastaveni()
        {
            InitializeComponent();
        }
        SoundPlayer hudbaVPozadi = new SoundPlayer();
        private void tbHracJedna_Click(object sender, EventArgs e)
        {
            //vymazání obsahu po kliknutí na textbox
            tbHracJedna.Text = "";
        }

        private void tbHracDva_Click(object sender, EventArgs e)
        {
            //vymazání obsahu po kliknutí na textbox
            tbHracDva.Text = "";
        }

        private void tbHracTri_Click(object sender, EventArgs e)
        {
            //vymazání obsahu po kliknutí na textbox
            tbHracTri.Text = "";
        }

        private void tbHracCtyri_Click(object sender, EventArgs e)
        {
            //vymazání obsahu po kliknutí na textbox
            tbHracCtyri.Text = "";
        }


        private void Form2_Load(object sender, EventArgs e)
        {
            //pouštění hudby v pozadí
            hudbaVPozadi.Stream = Properties.Resources.ElevatorMusic;
            hudbaVPozadi.PlayLooping();
            //zavření prvního formuláře
            Uvod uvod = new Uvod();
            uvod.Close();
        }

        private void btStart_Click(object sender, EventArgs e)
        {
            //kontrola zda-li jsou textboxy prázdné, přepsat je na původní 
            if(tbHracJedna.Text == "")
            {
                tbHracJedna.Text = "Hráč 1";
            }
            if(tbHracDva.Text == "")
            {
                tbHracDva.Text = "Hráč 2";
            }
            if(tbHracTri.Text == "")
            {

                tbHracTri.Text = "Hráč 3";
            }
            if(tbHracCtyri.Text == "")
            {
                tbHracCtyri.Text = "Hráč 4";
            }
            //zapsání obsahů textboxů do pole
            string[] jmena = new string[4] { tbHracJedna.Text, tbHracDva.Text, tbHracTri.Text, tbHracCtyri.Text };
            //vypnutí hudby
            hudbaVPozadi.Stop();
            //zobrazení hry
            Hra oknoHry = new Hra(jmena);
            oknoHry.Show();
            Hide();
        }

        private void panel1_MouseHover(object sender, EventArgs e)
        {
            //změna barvy panelu při najetí myší
            panel1.BackColor = Color.Red;
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            //změna barvy panelu při odjetí s myší
            panel1.BackColor = Color.White;
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            //vypnutí aplikace
            Application.Exit();
        }

        private void label1_MouseHover(object sender, EventArgs e)
        {
            //změna barvy panelu při najetí myší
            panel1.BackColor = Color.Red;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //vypnutí aplikace
            Application.Exit();
        }
    }
}
