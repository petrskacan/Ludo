using System;
using System.Drawing;
using System.Windows.Forms;

namespace Člověče_nezlob_se
{
    public partial class Uvod : Form
    {
        public Uvod()
        {
            InitializeComponent();
        }
        //definování proměnných
        int counter = 0, counterDva = 255;
        SolidBrush barva = new SolidBrush(Color.FromArgb(0, Color.White));
        private void Form1_Load(object sender, EventArgs e)
        {
            //zmizení hranic formuláře
            this.FormBorderStyle = FormBorderStyle.None;
            //vyplnění pictureboxu obrázkem
            pbCervenaFigurka.SizeMode = PictureBoxSizeMode.StretchImage;
            pbZelenaFigurka.SizeMode = PictureBoxSizeMode.StretchImage;
            //nastavení obrázku
            pbCervenaFigurka.Image = Properties.Resources.Červená_figurka_úvod;           
            pbZelenaFigurka.Image = Properties.Resources.Zelená_figurka_úvod;
            //zapnutí časovače
            timer1.Start();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //vykreslení textu
            Graphics text = e.Graphics;
            text.DrawString("Člověče, nezlob se!", new Font("Arial", 48), barva, 230, 263);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //animace textu
            if(counter == 255)
            {
                //mizení textu
                counterDva -= 5;
                barva = new SolidBrush(Color.FromArgb(counterDva, Color.White));
                if (counterDva == 0)
                {
                    timer1.Stop();
                    Nastaveni nastaveni = new Nastaveni();
                    nastaveni.Show();
                    Hide();
                }
            }
            else
            {
                //zobrazení textu
                counter += 5;
                barva = new SolidBrush(Color.FromArgb(counter, Color.White));
            }  
            Refresh();
        }
    }
}
