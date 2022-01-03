using System;
using System.Drawing;
using System.Windows.Forms;
using System.Media;

namespace Člověče_nezlob_se
{
    public partial class Hra : Form
    {
        public Hra(string[] jmeno)
        {
            InitializeComponent();
            //přebrání jmen z předcházejícího formu a nastavení jich jako text do labelů
            lbHracJedna.Text = jmeno[0];
            lbHracDva.Text = jmeno[1];
            lbHracTri.Text = jmeno[2];
            lbHracCtyri.Text = jmeno[3];         
        }
        
        private void Hra_Load(object sender, EventArgs e)
        {
            //nekonečné opakování hudby
            SoundPlayer hudbaVPozadi = new SoundPlayer();
            hudbaVPozadi.Stream = Properties.Resources.Pizzicato;
            hudbaVPozadi.PlayLooping();
            //nstavení barvu popředí a pozadí u labelu s pořadníkem tahů
            lbTah.BackColor = Color.Red;
            lbTah.ForeColor = Color.Red;
        }
        //
        private void pKonec_Click(object sender, EventArgs e)
        {
            //zavírání aplikace
            Application.Exit();
        }

        private void pKonec_MouseHover(object sender, EventArgs e)
        {
            //změna barvy panelu
            pKonec.BackColor = Color.Red;
        }

        private void pKonec_MouseLeave(object sender, EventArgs e)
        {
            //změna barvy panelu
            pKonec.BackColor = Color.White;
        }

        private void lbX_Click(object sender, EventArgs e)
        {
            //zavírání aplikace
            Application.Exit();
        }

        private void lbX_MouseHover(object sender, EventArgs e)
        {
            //změna barvy panelu
            pKonec.BackColor = Color.Red;
        }
        public void Vyhazovani(int figurka)
        {
            //metoda, která mění souřadnice figurek, které byli překryty jinou
            switch(figurka)
            {
                case 0:
                    pbFigurkaCervenaJedna.Location = new Point(81, 838);
                    break;
                case 1:
                    pbFigurkaCervenaDva.Location = new Point(81, 893);
                    break;
                case 2:
                    pbFigurkaCervenaTri.Location = new Point(25, 893);
                    break;
                case 3:
                    pbFigurkaCervenaCtyri.Location = new Point(25, 838);
                    break;
                case 4:
                    pbFigurkaZlutaJedna.Location = new Point(81, 82);
                    break;
                case 5:
                    pbFigurkaZlutaDva.Location = new Point(81, 138);
                    break;
                case 6:
                    pbFigurkaZlutaTri.Location = new Point(25, 138);
                    break;
                case 7:
                    pbFigurkaZlutaCtyri.Location = new Point(25, 82);
                    break;
                case 8:
                    pbFigurkaZelenaJedna.Location = new Point(951, 82);
                    break;
                case 9:
                    pbFigurkaZelenaDva.Location = new Point(951, 138);
                    break;
                case 10:
                    pbFigurkaZelenaTri.Location = new Point(895, 138);
                    break;
                case 11:
                    pbFigurkaZelenaCtyri.Location = new Point(895, 82);
                    break;
                case 12:
                    pbFigurkaModraJedna.Location = new Point(951, 838);
                    break;
                case 13:
                    pbFigurkaModraDva.Location = new Point(951, 893);
                    break;
                case 14:
                    pbFigurkaModraTri.Location = new Point(895, 893);
                    break;
                case 15:
                    pbFigurkaModraCtyri.Location = new Point(895, 838);
                    break;
            }
        }
        //definování proměnných
        Nastaveni zpetDoMenu = new Nastaveni();
        Random hodKostkou = new Random();
        int hozeneCislo, minuleCislo = 0;
        string tah = "CE", minulyTah;
        int[] pozice = new int[16] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        int[] souradniceX = new int[16];
        int[] souradniceY = new int[16];
        private void Hra_Paint(object sender, PaintEventArgs e)
        {
            //vykreslení pozadí(spojnic mezi políčky, celkové pozadí a obdélníku ve spodní části)
            Graphics pozadi = e.Graphics;
            pozadi.FillRectangle(Brushes.Gold, 0, 36, 555, 482);
            pozadi.FillRectangle(Brushes.LawnGreen, 500, 36, 505, 482);
            pozadi.FillRectangle(Brushes.Tomato, 0, 500, 555, 500);
            pozadi.FillRectangle(Brushes.CornflowerBlue, 500, 500, 505, 500);
            Pen tuzka = new Pen(Color.Black, 3);
            pozadi.DrawLine(tuzka, 149, 150, 305, 150);
            pozadi.DrawLine(tuzka, 305, 150, 305, 206);
            pozadi.DrawLine(tuzka, 305, 206, 695, 206);
            pozadi.DrawLine(tuzka, 695, 206, 695, 150);
            pozadi.DrawLine(tuzka, 695, 150, 851, 150);
            pozadi.DrawLine(tuzka, 851, 150, 851, 306);
            pozadi.DrawLine(tuzka, 851, 306, 795, 306);
            pozadi.DrawLine(tuzka, 795, 306, 795, 694);
            pozadi.DrawLine(tuzka, 795, 694, 851, 694);
            pozadi.DrawLine(tuzka, 851, 694, 851, 850);
            pozadi.DrawLine(tuzka, 851, 850, 695, 850);
            pozadi.DrawLine(tuzka, 695, 850, 695, 796);
            pozadi.DrawLine(tuzka, 695, 796, 305, 796);
            pozadi.DrawLine(tuzka, 305, 796, 305, 850);
            pozadi.DrawLine(tuzka, 305, 850, 149, 850);
            pozadi.DrawLine(tuzka, 149, 850, 149, 694);
            pozadi.DrawLine(tuzka, 149, 694, 205, 694);
            pozadi.DrawLine(tuzka, 205, 694, 205, 306);
            pozadi.DrawLine(tuzka, 205, 306, 149, 306);
            pozadi.DrawLine(tuzka, 149, 306, 149, 150);
            pozadi.FillRectangle(Brushes.Black, 0, 964, 1050, 36);
        }

        private void pbFigurkaCervenaJedna_Click(object sender, EventArgs e)
        {
            //umístění při hodu šestky k nasazení
            if (pozice[0] == 0 && hozeneCislo == 6)
            {
                //změna na 0, aby se později nepřičítal
                hozeneCislo = 0;
                pozice[0] = 1;
            }
            if (pozice[0] != 0)
            {
                pozice[0] += hozeneCislo;
                //opatření proti "kolizi" dvou stejných figurek
                if (pozice[0] == pozice[1] || pozice[0] == pozice[2] || pozice[0] == pozice[3])
                {
                    if (pozice[0] == 1)
                    {
                        pozice[0] = 0;
                    }
                    pozice[0] -= hozeneCislo;
                    
                }
            umisteni:
                //umístění figurky
                switch (pozice[0])
                {
                    case 1:       //C1Z31Z21M11 je název pb políčka, které je 1. pro červenou 31. pro žlutou 21. pro zelenou a 11. pro modrou 
                        pbFigurkaCervenaJedna.Location = new Point(C1Z31Z21M11.Location.X + 12, C1Z31Z21M11.Location.Y + 12);
                        break;
                    case 2:
                        pbFigurkaCervenaJedna.Location = new Point(C2Z32Z22M12.Location.X + 12, C2Z32Z22M12.Location.Y + 12);
                        break;
                    case 3:
                        pbFigurkaCervenaJedna.Location = new Point(C3Z33Z23M13.Location.X + 12, C3Z33Z23M13.Location.Y + 12);
                        break;
                    case 4:
                        pbFigurkaCervenaJedna.Location = new Point(C4Z34Z24M14.Location.X + 12, C4Z34Z24M14.Location.Y + 12);
                        break;
                    case 5:
                        pbFigurkaCervenaJedna.Location = new Point(C5Z35Z25M15.Location.X + 12, C5Z35Z25M15.Location.Y + 12);
                        break;
                    case 6:
                        pbFigurkaCervenaJedna.Location = new Point(C6Z36Z26M16.Location.X + 12, C6Z36Z26M16.Location.Y + 12);
                        break;
                    case 7:
                        pbFigurkaCervenaJedna.Location = new Point(C7Z27M17.Location.X + 12, C7Z27M17.Location.Y + 12);
                        break;
                    case 8:
                        pbFigurkaCervenaJedna.Location = new Point(C8Z28M18.Location.X + 12, C8Z28M18.Location.Y + 12);
                        break;
                    case 9:
                        pbFigurkaCervenaJedna.Location = new Point(C9Z29M19.Location.X + 12, C9Z29M19.Location.Y + 12);
                        break;
                    case 10:
                        pbFigurkaCervenaJedna.Location = new Point(C10Z30M20.Location.X + 12, C10Z30M20.Location.Y + 12);
                        break;
                    case 11:
                        pbFigurkaCervenaJedna.Location = new Point(C11Z1Z31M21.Location.X + 12, C11Z1Z31M21.Location.Y + 12);
                        break;
                    case 12:
                        pbFigurkaCervenaJedna.Location = new Point(C12Z2Z32M22.Location.X + 12, C12Z2Z32M22.Location.Y + 12);
                        break;
                    case 13:
                        pbFigurkaCervenaJedna.Location = new Point(C13Z3Z33M23.Location.X + 12, C13Z3Z33M23.Location.Y + 12);
                        break;
                    case 14:
                        pbFigurkaCervenaJedna.Location = new Point(C14Z4Z34M24.Location.X + 12, C14Z4Z34M24.Location.Y + 12);
                        break;
                    case 15:
                        pbFigurkaCervenaJedna.Location = new Point(C15Z5Z35M25.Location.X + 12, C15Z5Z35M25.Location.Y + 12);
                        break;
                    case 16:
                        pbFigurkaCervenaJedna.Location = new Point(C16Z6Z36M26.Location.X + 12, C16Z6Z36M26.Location.Y + 12);
                        break;
                    case 17:
                        pbFigurkaCervenaJedna.Location = new Point(C17Z7M27.Location.X + 12, C17Z7M27.Location.Y + 12);
                        break;
                    case 18:
                        pbFigurkaCervenaJedna.Location = new Point(C18Z8M28.Location.X + 12, C18Z8M28.Location.Y + 12);
                        break;
                    case 19:
                        pbFigurkaCervenaJedna.Location = new Point(C19Z9M29.Location.X + 12, C19Z9M29.Location.Y + 12);
                        break;
                    case 20:
                        pbFigurkaCervenaJedna.Location = new Point(C20Z10M30.Location.X + 12, C20Z10M30.Location.Y + 12);
                        break;
                    case 21:
                        pbFigurkaCervenaJedna.Location = new Point(C21Z11Z1M31.Location.X + 12, C21Z11Z1M31.Location.Y + 12);
                        break;
                    case 22:
                        pbFigurkaCervenaJedna.Location = new Point(C22Z12Z2M32.Location.X + 12, C22Z12Z2M32.Location.Y + 12);
                        break;
                    case 23:
                        pbFigurkaCervenaJedna.Location = new Point(C23Z13Z3M33.Location.X + 12, C23Z13Z3M33.Location.Y + 12);
                        break;
                    case 24:
                        pbFigurkaCervenaJedna.Location = new Point(C24Z14Z4M34.Location.X + 12, C24Z14Z4M34.Location.Y + 12);
                        break;
                    case 25:
                        pbFigurkaCervenaJedna.Location = new Point(C25Z15Z5M35.Location.X + 12, C25Z15Z5M35.Location.Y + 12);
                        break;
                    case 26:
                        pbFigurkaCervenaJedna.Location = new Point(C26Z16Z6M36.Location.X + 12, C26Z16Z6M36.Location.Y + 12);
                        break;
                    case 27:
                        pbFigurkaCervenaJedna.Location = new Point(C27Z17Z7.Location.X + 12, C27Z17Z7.Location.Y + 12);
                        break;
                    case 28:
                        pbFigurkaCervenaJedna.Location = new Point(C28Z18Z8.Location.X + 12, C28Z18Z8.Location.Y + 12);
                        break;
                    case 29:
                        pbFigurkaCervenaJedna.Location = new Point(C29Z19Z9.Location.X + 12, C29Z19Z9.Location.Y + 12);
                        break;
                    case 30:
                        pbFigurkaCervenaJedna.Location = new Point(C30Z20Z10.Location.X + 12, C30Z20Z10.Location.Y + 12);
                        break;
                    case 31:
                        pbFigurkaCervenaJedna.Location = new Point(C31Z21Z11M1.Location.X + 12, C31Z21Z11M1.Location.Y + 12);
                        break;
                    case 32:
                        pbFigurkaCervenaJedna.Location = new Point(C32Z22Z12M2.Location.X + 12, C32Z22Z12M2.Location.Y + 12);
                        break;
                    case 33:
                        pbFigurkaCervenaJedna.Location = new Point(C33Z23Z13M3.Location.X + 12, C33Z23Z13M3.Location.Y + 12);
                        break;
                    case 34:
                        pbFigurkaCervenaJedna.Location = new Point(C34Z24Z14M4.Location.X + 12, C34Z24Z14M4.Location.Y + 12);
                        break;
                    case 35:
                        pbFigurkaCervenaJedna.Location = new Point(C35Z25Z15M5.Location.X + 12, C35Z25Z15M5.Location.Y + 12);
                        break;
                    case 36:
                        pbFigurkaCervenaJedna.Location = new Point(C36Z26Z16M6.Location.X + 12, C36Z26Z16M6.Location.Y + 12);
                        break;
                    case 37:
                        pbFigurkaCervenaJedna.Location = new Point(C37.Location.X + 12, C37.Location.Y + 12);
                        break;
                    case 38:
                        pbFigurkaCervenaJedna.Location = new Point(C38.Location.X + 12, C38.Location.Y + 12);
                        break;
                    case 39:
                        pbFigurkaCervenaJedna.Location = new Point(C39.Location.X + 12, C39.Location.Y + 12);
                        break;
                    case 40:
                        pbFigurkaCervenaJedna.Location = new Point(C40.Location.X + 12, C40.Location.Y + 12);
                        break;
                    default:
                        pozice[0] -= hozeneCislo;
                        goto umisteni;
                }
            }
            //obnovení kostky
            pbKostka.Enabled = true;
            //změna tahu
            tah = "ZL";
            //zablokování všech figurek této barvy
            pbFigurkaCervenaJedna.Enabled = false;
            pbFigurkaCervenaDva.Enabled = false;
            pbFigurkaCervenaTri.Enabled = false;
            pbFigurkaCervenaCtyri.Enabled = false;
            //zapsání aktuálních souřadnic na vyhazování
            souradniceX[0] = pbFigurkaCervenaJedna.Location.X;
            souradniceY[0] = pbFigurkaCervenaJedna.Location.Y;
            //vyhazování
            for (int i = 4; i <= 15; i++)
            {
                if (souradniceX[0] == souradniceX[i] && souradniceY[0] == souradniceY[i])
                {
                    pozice[i] = 0;
                    Vyhazovani(i);
                    break;
                }
            }
            //kontrola jestliže jsou všechny 4 figurky v "domečku", hra končí a vyhrává ta barva
            for(int i = 0; i <= 3; i++)
            {
                for(int j = 0; j <= 3; j++)
                {
                    for(int k = 0; k <= 3; k++)
                    {
                        for(int l = 0; l <= 3; l++)
                        {
                            if(pozice[i] == 37 && pozice[j] == 38 && pozice[k] == 39 && pozice[l] == 40)
                            {
                                MessageBox.Show("Vyhrává" + lbHracJedna);
                                zpetDoMenu.Show();
                                Hide();
                            }
                        }
                    }
                }
            }

        }
        //u zbylých patnácti figurek se algoritmus opakuje jen s jinými hodnotami
        private void pbFigurkaCervenaDva_Click(object sender, EventArgs e)
        {
            if (pozice[1] == 0 && hozeneCislo == 6)
            {
                hozeneCislo = 0;
                pozice[1] = 1;
            }
            if (pozice[1] != 0)
            {
                pozice[1] += hozeneCislo;
                if(pozice [1] == pozice[0] || pozice[1] == pozice[2] || pozice[1] == pozice[3])
                {
                    if (pozice[1] == 1)
                    {
                        pozice[1] = 0;
                    }
                    pozice[1] -= hozeneCislo;
                }
            umisteni:
                switch (pozice[1])
                {
                    case 1:
                        pbFigurkaCervenaDva.Location = new Point(C1Z31Z21M11.Location.X + 12, C1Z31Z21M11.Location.Y + 12);
                        break;
                    case 2:
                        pbFigurkaCervenaDva.Location = new Point(C2Z32Z22M12.Location.X + 12, C2Z32Z22M12.Location.Y + 12);
                        break;
                    case 3:
                        pbFigurkaCervenaDva.Location = new Point(C3Z33Z23M13.Location.X + 12, C3Z33Z23M13.Location.Y + 12);
                        break;
                    case 4:
                        pbFigurkaCervenaDva.Location = new Point(C4Z34Z24M14.Location.X + 12, C4Z34Z24M14.Location.Y + 12);
                        break;
                    case 5:
                        pbFigurkaCervenaDva.Location = new Point(C5Z35Z25M15.Location.X + 12, C5Z35Z25M15.Location.Y + 12);
                        break;
                    case 6:
                        pbFigurkaCervenaDva.Location = new Point(C6Z36Z26M16.Location.X + 12, C6Z36Z26M16.Location.Y + 12);
                        break;
                    case 7:
                        pbFigurkaCervenaDva.Location = new Point(C7Z27M17.Location.X + 12, C7Z27M17.Location.Y + 12);
                        break;
                    case 8:
                        pbFigurkaCervenaDva.Location = new Point(C8Z28M18.Location.X + 12, C8Z28M18.Location.Y + 12);
                        break;
                    case 9:
                        pbFigurkaCervenaDva.Location = new Point(C9Z29M19.Location.X + 12, C9Z29M19.Location.Y + 12);
                        break;
                    case 10:
                        pbFigurkaCervenaDva.Location = new Point(C10Z30M20.Location.X + 12, C10Z30M20.Location.Y + 12);
                        break;
                    case 11:
                        pbFigurkaCervenaDva.Location = new Point(C11Z1Z31M21.Location.X + 12, C11Z1Z31M21.Location.Y + 12);
                        break;
                    case 12:
                        pbFigurkaCervenaDva.Location = new Point(C12Z2Z32M22.Location.X + 12, C12Z2Z32M22.Location.Y + 12);
                        break;
                    case 13:
                        pbFigurkaCervenaDva.Location = new Point(C13Z3Z33M23.Location.X + 12, C13Z3Z33M23.Location.Y + 12);
                        break;
                    case 14:
                        pbFigurkaCervenaDva.Location = new Point(C14Z4Z34M24.Location.X + 12, C14Z4Z34M24.Location.Y + 12);
                        break;
                    case 15:
                        pbFigurkaCervenaDva.Location = new Point(C15Z5Z35M25.Location.X + 12, C15Z5Z35M25.Location.Y + 12);
                        break;
                    case 16:
                        pbFigurkaCervenaDva.Location = new Point(C16Z6Z36M26.Location.X + 12, C16Z6Z36M26.Location.Y + 12);
                        break;
                    case 17:
                        pbFigurkaCervenaDva.Location = new Point(C17Z7M27.Location.X + 12, C17Z7M27.Location.Y + 12);
                        break;
                    case 18:
                        pbFigurkaCervenaDva.Location = new Point(C18Z8M28.Location.X + 12, C18Z8M28.Location.Y + 12);
                        break;
                    case 19:
                        pbFigurkaCervenaDva.Location = new Point(C19Z9M29.Location.X + 12, C19Z9M29.Location.Y + 12);
                        break;
                    case 20:
                        pbFigurkaCervenaDva.Location = new Point(C20Z10M30.Location.X + 12, C20Z10M30.Location.Y + 12);
                        break;
                    case 21:
                        pbFigurkaCervenaDva.Location = new Point(C21Z11Z1M31.Location.X + 12, C21Z11Z1M31.Location.Y + 12);
                        break;
                    case 22:
                        pbFigurkaCervenaDva.Location = new Point(C22Z12Z2M32.Location.X + 12, C22Z12Z2M32.Location.Y + 12);
                        break;
                    case 23:
                        pbFigurkaCervenaDva.Location = new Point(C23Z13Z3M33.Location.X + 12, C23Z13Z3M33.Location.Y + 12);
                        break;
                    case 24:
                        pbFigurkaCervenaDva.Location = new Point(C24Z14Z4M34.Location.X + 12, C24Z14Z4M34.Location.Y + 12);
                        break;
                    case 25:
                        pbFigurkaCervenaDva.Location = new Point(C25Z15Z5M35.Location.X + 12, C25Z15Z5M35.Location.Y + 12);
                        break;
                    case 26:
                        pbFigurkaCervenaDva.Location = new Point(C26Z16Z6M36.Location.X + 12, C26Z16Z6M36.Location.Y + 12);
                        break;
                    case 27:
                        pbFigurkaCervenaDva.Location = new Point(C27Z17Z7.Location.X + 12, C27Z17Z7.Location.Y + 12);
                        break;
                    case 28:
                        pbFigurkaCervenaDva.Location = new Point(C28Z18Z8.Location.X + 12, C28Z18Z8.Location.Y + 12);
                        break;
                    case 29:
                        pbFigurkaCervenaDva.Location = new Point(C29Z19Z9.Location.X + 12, C29Z19Z9.Location.Y + 12);
                        break;
                    case 30:
                        pbFigurkaCervenaDva.Location = new Point(C30Z20Z10.Location.X + 12, C30Z20Z10.Location.Y + 12);
                        break;
                    case 31:
                        pbFigurkaCervenaDva.Location = new Point(C31Z21Z11M1.Location.X + 12, C31Z21Z11M1.Location.Y + 12);
                        break;
                    case 32:
                        pbFigurkaCervenaDva.Location = new Point(C32Z22Z12M2.Location.X + 12, C32Z22Z12M2.Location.Y + 12);
                        break;
                    case 33:
                        pbFigurkaCervenaDva.Location = new Point(C33Z23Z13M3.Location.X + 12, C33Z23Z13M3.Location.Y + 12);
                        break;
                    case 34:
                        pbFigurkaCervenaDva.Location = new Point(C34Z24Z14M4.Location.X + 12, C34Z24Z14M4.Location.Y + 12);
                        break;
                    case 35:
                        pbFigurkaCervenaDva.Location = new Point(C35Z25Z15M5.Location.X + 12, C35Z25Z15M5.Location.Y + 12);
                        break;
                    case 36:
                        pbFigurkaCervenaDva.Location = new Point(C36Z26Z16M6.Location.X + 12, C36Z26Z16M6.Location.Y + 12);
                        break;
                    case 37:
                        pbFigurkaCervenaDva.Location = new Point(C37.Location.X + 12, C37.Location.Y + 12);
                        break;
                    case 38:
                        pbFigurkaCervenaDva.Location = new Point(C38.Location.X + 12, C38.Location.Y + 12);
                        break;
                    case 39:
                        pbFigurkaCervenaDva.Location = new Point(C39.Location.X + 12, C39.Location.Y + 12);
                        break;
                    case 40:
                        pbFigurkaCervenaDva.Location = new Point(C40.Location.X + 12, C40.Location.Y + 12);
                        break;
                    default:
                        pozice[1] -= hozeneCislo;
                        goto umisteni;
                }
            }
            pbKostka.Enabled = true;
             tah = "ZL";
            pbFigurkaCervenaJedna.Enabled = false;
            pbFigurkaCervenaDva.Enabled = false;
            pbFigurkaCervenaTri.Enabled = false;
            pbFigurkaCervenaCtyri.Enabled = false;
            souradniceX[1] = pbFigurkaCervenaDva.Location.X;
            souradniceY[1] = pbFigurkaCervenaDva.Location.Y;
            for (int i = 4; i <= 15; i++)
            {
                if (souradniceX[1] == souradniceX[i] && souradniceY[1] == souradniceY[i])
                {
                    pozice[i] = 0;
                    Vyhazovani(i);
                    break;
                }
            }
            for (int i = 0; i <= 3; i++)
            {
                for (int j = 0; j <= 3; j++)
                {
                    for (int k = 0; k <= 3; k++)
                    {
                        for (int l = 0; l <= 3; l++)
                        {
                            if (pozice[i] == 37 && pozice[j] == 38 && pozice[k] == 39 && pozice[l] == 40)
                            {
                              MessageBox.Show("Vyhrává" + lbHracJedna);
                                zpetDoMenu.Show();
                                Hide();
                            }
                        }
                    }
                }
            }
        }

        private void pbFigurkaCervenaTri_Click(object sender, EventArgs e)
        {
            if (pozice[2] == 0 && hozeneCislo == 6)
            {
                hozeneCislo = 0;
                pozice[2] = 1;
            }
            if (pozice[2] != 0)
            {
                pozice[2] += hozeneCislo;
                if (pozice[2] == pozice[0] || pozice[2] == pozice[1] || pozice[2] == pozice[3])
                {
                    if (pozice[2] == 1)
                    {
                        pozice[2] = 0;
                    }
                    pozice[2] -= hozeneCislo;
                }
            umisteni:
                switch (pozice[2])
                {
                    case 1:
                        pbFigurkaCervenaTri.Location = new Point(C1Z31Z21M11.Location.X + 12, C1Z31Z21M11.Location.Y + 12);
                        break;
                    case 2:
                        pbFigurkaCervenaTri.Location = new Point(C2Z32Z22M12.Location.X + 12, C2Z32Z22M12.Location.Y + 12);
                        break;
                    case 3:
                        pbFigurkaCervenaTri.Location = new Point(C3Z33Z23M13.Location.X + 12, C3Z33Z23M13.Location.Y + 12);
                        break;
                    case 4:
                        pbFigurkaCervenaTri.Location = new Point(C4Z34Z24M14.Location.X + 12, C4Z34Z24M14.Location.Y + 12);
                        break;
                    case 5:
                        pbFigurkaCervenaTri.Location = new Point(C5Z35Z25M15.Location.X + 12, C5Z35Z25M15.Location.Y + 12);
                        break;
                    case 6:
                        pbFigurkaCervenaTri.Location = new Point(C6Z36Z26M16.Location.X + 12, C6Z36Z26M16.Location.Y + 12);
                        break;
                    case 7:
                        pbFigurkaCervenaTri.Location = new Point(C7Z27M17.Location.X + 12, C7Z27M17.Location.Y + 12);
                        break;
                    case 8:
                        pbFigurkaCervenaTri.Location = new Point(C8Z28M18.Location.X + 12, C8Z28M18.Location.Y + 12);
                        break;
                    case 9:
                        pbFigurkaCervenaTri.Location = new Point(C9Z29M19.Location.X + 12, C9Z29M19.Location.Y + 12);
                        break;
                    case 10:
                        pbFigurkaCervenaTri.Location = new Point(C10Z30M20.Location.X + 12, C10Z30M20.Location.Y + 12);
                        break;
                    case 11:
                        pbFigurkaCervenaTri.Location = new Point(C11Z1Z31M21.Location.X + 12, C11Z1Z31M21.Location.Y + 12);
                        break;
                    case 12:
                        pbFigurkaCervenaTri.Location = new Point(C12Z2Z32M22.Location.X + 12, C12Z2Z32M22.Location.Y + 12);
                        break;
                    case 13:
                        pbFigurkaCervenaTri.Location = new Point(C13Z3Z33M23.Location.X + 12, C13Z3Z33M23.Location.Y + 12);
                        break;
                    case 14:
                        pbFigurkaCervenaTri.Location = new Point(C14Z4Z34M24.Location.X + 12, C14Z4Z34M24.Location.Y + 12);
                        break;
                    case 15:
                        pbFigurkaCervenaTri.Location = new Point(C15Z5Z35M25.Location.X + 12, C15Z5Z35M25.Location.Y + 12);
                        break;
                    case 16:
                        pbFigurkaCervenaTri.Location = new Point(C16Z6Z36M26.Location.X + 12, C16Z6Z36M26.Location.Y + 12);
                        break;
                    case 17:
                        pbFigurkaCervenaTri.Location = new Point(C17Z7M27.Location.X + 12, C17Z7M27.Location.Y + 12);
                        break;
                    case 18:
                        pbFigurkaCervenaTri.Location = new Point(C18Z8M28.Location.X + 12, C18Z8M28.Location.Y + 12);
                        break;
                    case 19:
                        pbFigurkaCervenaTri.Location = new Point(C19Z9M29.Location.X + 12, C19Z9M29.Location.Y + 12);
                        break;
                    case 20:
                        pbFigurkaCervenaTri.Location = new Point(C20Z10M30.Location.X + 12, C20Z10M30.Location.Y + 12);
                        break;
                    case 21:
                        pbFigurkaCervenaTri.Location = new Point(C21Z11Z1M31.Location.X + 12, C21Z11Z1M31.Location.Y + 12);
                        break;
                    case 22:
                        pbFigurkaCervenaTri.Location = new Point(C22Z12Z2M32.Location.X + 12, C22Z12Z2M32.Location.Y + 12);
                        break;
                    case 23:
                        pbFigurkaCervenaTri.Location = new Point(C23Z13Z3M33.Location.X + 12, C23Z13Z3M33.Location.Y + 12);
                        break;
                    case 24:
                        pbFigurkaCervenaTri.Location = new Point(C24Z14Z4M34.Location.X + 12, C24Z14Z4M34.Location.Y + 12);
                        break;
                    case 25:
                        pbFigurkaCervenaTri.Location = new Point(C25Z15Z5M35.Location.X + 12, C25Z15Z5M35.Location.Y + 12);
                        break;
                    case 26:
                        pbFigurkaCervenaTri.Location = new Point(C26Z16Z6M36.Location.X + 12, C26Z16Z6M36.Location.Y + 12);
                        break;
                    case 27:
                        pbFigurkaCervenaTri.Location = new Point(C27Z17Z7.Location.X + 12, C27Z17Z7.Location.Y + 12);
                        break;
                    case 28:
                        pbFigurkaCervenaTri.Location = new Point(C28Z18Z8.Location.X + 12, C28Z18Z8.Location.Y + 12);
                        break;
                    case 29:
                        pbFigurkaCervenaTri.Location = new Point(C29Z19Z9.Location.X + 12, C29Z19Z9.Location.Y + 12);
                        break;
                    case 30:
                        pbFigurkaCervenaTri.Location = new Point(C30Z20Z10.Location.X + 12, C30Z20Z10.Location.Y + 12);
                        break;
                    case 31:
                        pbFigurkaCervenaTri.Location = new Point(C31Z21Z11M1.Location.X + 12, C31Z21Z11M1.Location.Y + 12);
                        break;
                    case 32:
                        pbFigurkaCervenaTri.Location = new Point(C32Z22Z12M2.Location.X + 12, C32Z22Z12M2.Location.Y + 12);
                        break;
                    case 33:
                        pbFigurkaCervenaTri.Location = new Point(C33Z23Z13M3.Location.X + 12, C33Z23Z13M3.Location.Y + 12);
                        break;
                    case 34:
                        pbFigurkaCervenaTri.Location = new Point(C34Z24Z14M4.Location.X + 12, C34Z24Z14M4.Location.Y + 12);
                        break;
                    case 35:
                        pbFigurkaCervenaTri.Location = new Point(C35Z25Z15M5.Location.X + 12, C35Z25Z15M5.Location.Y + 12);
                        break;
                    case 36:
                        pbFigurkaCervenaTri.Location = new Point(C36Z26Z16M6.Location.X + 12, C36Z26Z16M6.Location.Y + 12);
                        break;
                    case 37:
                        pbFigurkaCervenaTri.Location = new Point(C37.Location.X + 12, C37.Location.Y + 12);
                        break;
                    case 38:
                        pbFigurkaCervenaTri.Location = new Point(C38.Location.X + 12, C38.Location.Y + 12);
                        break;
                    case 39:
                        pbFigurkaCervenaTri.Location = new Point(C39.Location.X + 12, C39.Location.Y + 12);
                        break;
                    case 40:
                        pbFigurkaCervenaTri.Location = new Point(C40.Location.X + 12, C40.Location.Y + 12);
                        break;
                    default:
                        pozice[2] -= hozeneCislo;
                        goto umisteni;
                }
            }
            pbKostka.Enabled = true;
             tah = "ZL";
            pbFigurkaCervenaJedna.Enabled = false;
            pbFigurkaCervenaDva.Enabled = false;
            pbFigurkaCervenaTri.Enabled = false;
            pbFigurkaCervenaCtyri.Enabled = false;
            souradniceX[2] = pbFigurkaCervenaTri.Location.X;
            souradniceY[2] = pbFigurkaCervenaTri.Location.Y;
            for (int i = 4; i <= 15; i++)
            {
                if (souradniceX[2] == souradniceX[i] && souradniceY[2] == souradniceY[i])
                {
                    pozice[i] = 0;
                    Vyhazovani(i);
                    break;
                }
            }
            for (int i = 0; i <= 3; i++)
            {
                for (int j = 0; j <= 3; j++)
                {
                    for (int k = 0; k <= 3; k++)
                    {
                        for (int l = 0; l <= 3; l++)
                        {
                            if (pozice[i] == 37 && pozice[j] == 38 && pozice[k] == 39 && pozice[l] == 40)
                            {
                                MessageBox.Show("Vyhrává" + lbHracJedna);
                                zpetDoMenu.Show();
                                Hide();
                            }
                        }
                    }
                }
            }
        }

        private void pbFigurkaCervenaCtyri_Click(object sender, EventArgs e)
        {
            if (pozice[3] == 0 && hozeneCislo == 6)
            {
                hozeneCislo = 0;
                pozice[3] = 1;
            }
            if (pozice[3] != 0)
            {
                pozice[3] += hozeneCislo;
                if (pozice[3] == pozice[1] || pozice[3] == pozice[2] || pozice[3] == pozice[0])
                {
                    if (pozice[3] == 1)
                    {
                        pozice[3] = 0;
                    }
                    pozice[3] -= hozeneCislo;
                }
            umisteni:
                if (pozice[3] == pozice[0] || pozice[3] == pozice[2] || pozice[3] == pozice[1])
                {
                    pozice[3] -= hozeneCislo;
                }
                switch (pozice[3])
                {
                    case 1:
                        pbFigurkaCervenaCtyri.Location = new Point(C1Z31Z21M11.Location.X + 12, C1Z31Z21M11.Location.Y + 12);
                        break;
                    case 2:
                        pbFigurkaCervenaCtyri.Location = new Point(C2Z32Z22M12.Location.X + 12, C2Z32Z22M12.Location.Y + 12);
                        break;
                    case 3:
                        pbFigurkaCervenaCtyri.Location = new Point(C3Z33Z23M13.Location.X + 12, C3Z33Z23M13.Location.Y + 12);
                        break;
                    case 4:
                        pbFigurkaCervenaCtyri.Location = new Point(C4Z34Z24M14.Location.X + 12, C4Z34Z24M14.Location.Y + 12);
                        break;
                    case 5:
                        pbFigurkaCervenaCtyri.Location = new Point(C5Z35Z25M15.Location.X + 12, C5Z35Z25M15.Location.Y + 12);
                        break;
                    case 6:
                        pbFigurkaCervenaCtyri.Location = new Point(C6Z36Z26M16.Location.X + 12, C6Z36Z26M16.Location.Y + 12);
                        break;
                    case 7:
                        pbFigurkaCervenaCtyri.Location = new Point(C7Z27M17.Location.X + 12, C7Z27M17.Location.Y + 12);
                        break;
                    case 8:
                        pbFigurkaCervenaCtyri.Location = new Point(C8Z28M18.Location.X + 12, C8Z28M18.Location.Y + 12);
                        break;
                    case 9:
                        pbFigurkaCervenaCtyri.Location = new Point(C9Z29M19.Location.X + 12, C9Z29M19.Location.Y + 12);
                        break;
                    case 10:
                        pbFigurkaCervenaCtyri.Location = new Point(C10Z30M20.Location.X + 12, C10Z30M20.Location.Y + 12);
                        break;
                    case 11:
                        pbFigurkaCervenaCtyri.Location = new Point(C11Z1Z31M21.Location.X + 12, C11Z1Z31M21.Location.Y + 12);
                        break;
                    case 12:
                        pbFigurkaCervenaCtyri.Location = new Point(C12Z2Z32M22.Location.X + 12, C12Z2Z32M22.Location.Y + 12);
                        break;
                    case 13:
                        pbFigurkaCervenaCtyri.Location = new Point(C13Z3Z33M23.Location.X + 12, C13Z3Z33M23.Location.Y + 12);
                        break;
                    case 14:
                        pbFigurkaCervenaCtyri.Location = new Point(C14Z4Z34M24.Location.X + 12, C14Z4Z34M24.Location.Y + 12);
                        break;
                    case 15:
                        pbFigurkaCervenaCtyri.Location = new Point(C15Z5Z35M25.Location.X + 12, C15Z5Z35M25.Location.Y + 12);
                        break;
                    case 16:
                        pbFigurkaCervenaCtyri.Location = new Point(C16Z6Z36M26.Location.X + 12, C16Z6Z36M26.Location.Y + 12);
                        break;
                    case 17:
                        pbFigurkaCervenaCtyri.Location = new Point(C17Z7M27.Location.X + 12, C17Z7M27.Location.Y + 12);
                        break;
                    case 18:
                        pbFigurkaCervenaCtyri.Location = new Point(C18Z8M28.Location.X + 12, C18Z8M28.Location.Y + 12);
                        break;
                    case 19:
                        pbFigurkaCervenaCtyri.Location = new Point(C19Z9M29.Location.X + 12, C19Z9M29.Location.Y + 12);
                        break;
                    case 20:
                        pbFigurkaCervenaCtyri.Location = new Point(C20Z10M30.Location.X + 12, C20Z10M30.Location.Y + 12);
                        break;
                    case 21:
                        pbFigurkaCervenaCtyri.Location = new Point(C21Z11Z1M31.Location.X + 12, C21Z11Z1M31.Location.Y + 12);
                        break;
                    case 22:
                        pbFigurkaCervenaCtyri.Location = new Point(C22Z12Z2M32.Location.X + 12, C22Z12Z2M32.Location.Y + 12);
                        break;
                    case 23:
                        pbFigurkaCervenaCtyri.Location = new Point(C23Z13Z3M33.Location.X + 12, C23Z13Z3M33.Location.Y + 12);
                        break;
                    case 24:
                        pbFigurkaCervenaCtyri.Location = new Point(C24Z14Z4M34.Location.X + 12, C24Z14Z4M34.Location.Y + 12);
                        break;
                    case 25:
                        pbFigurkaCervenaCtyri.Location = new Point(C25Z15Z5M35.Location.X + 12, C25Z15Z5M35.Location.Y + 12);
                        break;
                    case 26:
                        pbFigurkaCervenaCtyri.Location = new Point(C26Z16Z6M36.Location.X + 12, C26Z16Z6M36.Location.Y + 12);
                        break;
                    case 27:
                        pbFigurkaCervenaCtyri.Location = new Point(C27Z17Z7.Location.X + 12, C27Z17Z7.Location.Y + 12);
                        break;
                    case 28:
                        pbFigurkaCervenaCtyri.Location = new Point(C28Z18Z8.Location.X + 12, C28Z18Z8.Location.Y + 12);
                        break;
                    case 29:
                        pbFigurkaCervenaCtyri.Location = new Point(C29Z19Z9.Location.X + 12, C29Z19Z9.Location.Y + 12);
                        break;
                    case 30:
                        pbFigurkaCervenaCtyri.Location = new Point(C30Z20Z10.Location.X + 12, C30Z20Z10.Location.Y + 12);
                        break;
                    case 31:
                        pbFigurkaCervenaCtyri.Location = new Point(C31Z21Z11M1.Location.X + 12, C31Z21Z11M1.Location.Y + 12);
                        break;
                    case 32:
                        pbFigurkaCervenaCtyri.Location = new Point(C32Z22Z12M2.Location.X + 12, C32Z22Z12M2.Location.Y + 12);
                        break;
                    case 33:
                        pbFigurkaCervenaCtyri.Location = new Point(C33Z23Z13M3.Location.X + 12, C33Z23Z13M3.Location.Y + 12);
                        break;
                    case 34:
                        pbFigurkaCervenaCtyri.Location = new Point(C34Z24Z14M4.Location.X + 12, C34Z24Z14M4.Location.Y + 12);
                        break;
                    case 35:
                        pbFigurkaCervenaCtyri.Location = new Point(C35Z25Z15M5.Location.X + 12, C35Z25Z15M5.Location.Y + 12);
                        break;
                    case 36:
                        pbFigurkaCervenaCtyri.Location = new Point(C36Z26Z16M6.Location.X + 12, C36Z26Z16M6.Location.Y + 12);
                        break;
                    case 37:
                        pbFigurkaCervenaCtyri.Location = new Point(C37.Location.X + 12, C37.Location.Y + 12);
                        break;
                    case 38:
                        pbFigurkaCervenaCtyri.Location = new Point(C38.Location.X + 12, C38.Location.Y + 12);
                        break;
                    case 39:
                        pbFigurkaCervenaCtyri.Location = new Point(C39.Location.X + 12, C39.Location.Y + 12);
                        break;
                    case 40:
                        pbFigurkaCervenaCtyri.Location = new Point(C40.Location.X + 12, C40.Location.Y + 12);
                        break;
                    default:
                        pozice[3] -= hozeneCislo;
                        goto umisteni;
                }
            }
            pbKostka.Enabled = true;
             tah = "ZL";
            pbFigurkaCervenaJedna.Enabled = false;
            pbFigurkaCervenaDva.Enabled = false;
            pbFigurkaCervenaTri.Enabled = false;
            pbFigurkaCervenaCtyri.Enabled = false;
            souradniceX[3] = pbFigurkaCervenaCtyri.Location.X;
            souradniceY[3] = pbFigurkaCervenaCtyri.Location.Y;
            for (int i = 4; i <= 15; i++)
            {
                if (souradniceX[3] == souradniceX[i] && souradniceY[3] == souradniceY[i])
                {
                    pozice[i] = 0;
                    Vyhazovani(i);
                    break;
                }
            }
            for (int i = 0; i <= 3; i++)
            {
                for (int j = 0; j <= 3; j++)
                {
                    for (int k = 0; k <= 3; k++)
                    {
                        for (int l = 0; l <= 3; l++)
                        {
                            if (pozice[i] == 37 && pozice[j] == 38 && pozice[k] == 39 && pozice[l] == 40)
                            {
                                MessageBox.Show("Vyhrává" + lbHracJedna);
                                zpetDoMenu.Show();
                                Hide();
                            }
                        }
                    }
                }
            }
        }

        private void pbFigurkaZlutaJedna_Click(object sender, EventArgs e)
        {
            if (pozice[4] == 0 && hozeneCislo == 6)
            {
                hozeneCislo = 0;
                pozice[4] = 1;
            }
            if (pozice[4] != 0)
            {
                pozice[4] += hozeneCislo;
                if (pozice[4] == pozice[5] || pozice[4] == pozice[6] || pozice[4] == pozice[7])
                {
                    if (pozice[4] == 1)
                    {
                        pozice[4] = 0;
                    }
                    pozice[4] -= hozeneCislo;
                }
            umisteni:
                switch (pozice[4])
                {               
                    case 1:
                        pbFigurkaZlutaJedna.Location = new Point(C11Z1Z31M21.Location.X + 12, C11Z1Z31M21.Location.Y + 12);
                        break;
                    case 2:
                        pbFigurkaZlutaJedna.Location = new Point(C12Z2Z32M22.Location.X + 12, C12Z2Z32M22.Location.Y + 12);
                        break;
                    case 3:
                        pbFigurkaZlutaJedna.Location = new Point(C13Z3Z33M23.Location.X + 12, C13Z3Z33M23.Location.Y + 12);
                        break;
                    case 4:
                        pbFigurkaZlutaJedna.Location = new Point(C14Z4Z34M24.Location.X + 12, C14Z4Z34M24.Location.Y + 12);
                        break;
                    case 5:
                        pbFigurkaZlutaJedna.Location = new Point(C15Z5Z35M25.Location.X + 12, C15Z5Z35M25.Location.Y + 12);
                        break;
                    case 6:
                        pbFigurkaZlutaJedna.Location = new Point(C16Z6Z36M26.Location.X + 12, C16Z6Z36M26.Location.Y + 12);
                        break;
                    case 7:
                        pbFigurkaZlutaJedna.Location = new Point(C17Z7M27.Location.X + 12, C17Z7M27.Location.Y + 12);
                        break;
                    case 8:
                        pbFigurkaZlutaJedna.Location = new Point(C18Z8M28.Location.X + 12, C18Z8M28.Location.Y + 12);
                        break;
                    case 9:
                        pbFigurkaZlutaJedna.Location = new Point(C19Z9M29.Location.X + 12, C19Z9M29.Location.Y + 12);
                        break;
                    case 10:
                        pbFigurkaZlutaJedna.Location = new Point(C20Z10M30.Location.X + 12, C20Z10M30.Location.Y + 12);
                        break;
                    case 11:
                        pbFigurkaZlutaJedna.Location = new Point(C21Z11Z1M31.Location.X + 12, C21Z11Z1M31.Location.Y + 12);
                        break;
                    case 12:
                        pbFigurkaZlutaJedna.Location = new Point(C22Z12Z2M32.Location.X + 12, C22Z12Z2M32.Location.Y + 12);
                        break;
                    case 13:
                        pbFigurkaZlutaJedna.Location = new Point(C23Z13Z3M33.Location.X + 12, C23Z13Z3M33.Location.Y + 12);
                        break;
                    case 14:
                        pbFigurkaZlutaJedna.Location = new Point(C24Z14Z4M34.Location.X + 12, C24Z14Z4M34.Location.Y + 12);
                        break;
                    case 15:
                        pbFigurkaZlutaJedna.Location = new Point(C25Z15Z5M35.Location.X + 12, C25Z15Z5M35.Location.Y + 12);
                        break;
                    case 16:
                        pbFigurkaZlutaJedna.Location = new Point(C26Z16Z6M36.Location.X + 12, C26Z16Z6M36.Location.Y + 12);
                        break;
                    case 17:
                        pbFigurkaZlutaJedna.Location = new Point(C27Z17Z7.Location.X + 12, C27Z17Z7.Location.Y + 12);
                        break;
                    case 18:
                        pbFigurkaZlutaJedna.Location = new Point(C28Z18Z8.Location.X + 12, C28Z18Z8.Location.Y + 12);
                        break;
                    case 19:
                        pbFigurkaZlutaJedna.Location = new Point(C29Z19Z9.Location.X + 12, C29Z19Z9.Location.Y + 12);
                        break;
                    case 20:
                        pbFigurkaZlutaJedna.Location = new Point(C30Z20Z10.Location.X + 12, C30Z20Z10.Location.Y + 12);
                        break;
                    case 21:
                        pbFigurkaZlutaJedna.Location = new Point(C31Z21Z11M1.Location.X + 12, C31Z21Z11M1.Location.Y + 12);
                        break;
                    case 22:
                        pbFigurkaZlutaJedna.Location = new Point(C32Z22Z12M2.Location.X + 12, C32Z22Z12M2.Location.Y + 12);
                        break;
                    case 23:
                        pbFigurkaZlutaJedna.Location = new Point(C33Z23Z13M3.Location.X + 12, C33Z23Z13M3.Location.Y + 12);
                        break;
                    case 24:
                        pbFigurkaZlutaJedna.Location = new Point(C34Z24Z14M4.Location.X + 12, C34Z24Z14M4.Location.Y + 12);
                        break;
                    case 25:
                        pbFigurkaZlutaJedna.Location = new Point(C35Z25Z15M5.Location.X + 12, C35Z25Z15M5.Location.Y + 12);
                        break;
                    case 26:
                        pbFigurkaZlutaJedna.Location = new Point(C36Z26Z16M6.Location.X + 12, C36Z26Z16M6.Location.Y + 12);
                        break;
                    case 31:
                        pbFigurkaZlutaJedna.Location = new Point(C1Z31Z21M11.Location.X + 12, C1Z31Z21M11.Location.Y + 12);
                        break;
                    case 32:
                        pbFigurkaZlutaJedna.Location = new Point(C2Z32Z22M12.Location.X + 12, C2Z32Z22M12.Location.Y + 12);
                        break;
                    case 33:
                        pbFigurkaZlutaJedna.Location = new Point(C3Z33Z23M13.Location.X + 12, C3Z33Z23M13.Location.Y + 12);
                        break;
                    case 34:
                        pbFigurkaZlutaJedna.Location = new Point(C4Z34Z24M14.Location.X + 12, C4Z34Z24M14.Location.Y + 12);
                        break;
                    case 35:
                        pbFigurkaZlutaJedna.Location = new Point(C5Z35Z25M15.Location.X + 12, C5Z35Z25M15.Location.Y + 12);
                        break;
                    case 36:
                        pbFigurkaZlutaJedna.Location = new Point(C6Z36Z26M16.Location.X + 12, C6Z36Z26M16.Location.Y + 12);
                        break;
                    case 27:
                        pbFigurkaZlutaJedna.Location = new Point(Z27Z17M7.Location.X + 12, Z27Z17M7.Location.Y + 12);
                        break;
                    case 28:
                        pbFigurkaZlutaJedna.Location = new Point(Z28Z18M8.Location.X + 12, Z28Z18M8.Location.Y + 12);
                        break;
                    case 29:
                        pbFigurkaZlutaJedna.Location = new Point(Z29Z19M9.Location.X + 12, Z29Z19M9.Location.Y + 12);
                        break;
                    case 30:
                        pbFigurkaZlutaJedna.Location = new Point(Z30Z20M10.Location.X + 12, Z30Z20M10.Location.Y + 12);
                        break;
                    case 37:
                        pbFigurkaZlutaJedna.Location = new Point(ZL37.Location.X + 12, ZL37.Location.Y + 12);
                        break;
                    case 38:
                        pbFigurkaZlutaJedna.Location = new Point(ZL38.Location.X + 12, ZL38.Location.Y + 12);
                        break;
                    case 39:
                        pbFigurkaZlutaJedna.Location = new Point(ZL39.Location.X + 12, ZL39.Location.Y + 12);
                        break;
                    case 40:
                        pbFigurkaZlutaJedna.Location = new Point(ZL40.Location.X + 12, ZL40.Location.Y + 12);
                        break;
                    default:
                        pozice[4] -= hozeneCislo;
                        goto umisteni;
                }
            }
            pbKostka.Enabled = true;
             tah = "ZE";
            pbFigurkaZlutaJedna.Enabled = false;
            pbFigurkaZlutaDva.Enabled = false;
            pbFigurkaZlutaTri.Enabled = false;
            pbFigurkaZlutaCtyri.Enabled = false;
            souradniceX[4] = pbFigurkaZlutaJedna.Location.X;
            souradniceY[4] = pbFigurkaZlutaJedna.Location.Y;
            for (int i = 0; i <= 3; i++)
            {
                if (souradniceX[4] == souradniceX[i] && souradniceY[4] == souradniceY[i])
                {
                    pozice[i] = 0;
                    Vyhazovani(i);
                    break;
                }
            }
            for (int i = 8; i <= 15; i++)
            {
                if (souradniceX[4] == souradniceX[i] && souradniceY[4] == souradniceY[i])
                {
                    pozice[i] = 0;
                    Vyhazovani(i);
                    break;
                }
            }
            for (int i = 4; i <= 7; i++)
            {
                for (int j = 4; j <= 7; j++)
                {
                    for (int k = 4; k <= 7; k++)
                    {
                        for (int l = 4; l <= 7; l++)
                        {
                            if (pozice[i] == 37 && pozice[j] == 38 && pozice[k] == 39 && pozice[l] == 40)
                            {
                                MessageBox.Show("Vyhrává" + lbHracDva);
                                zpetDoMenu.Show();
                                Hide();
                            }
                        }
                    }
                }
            }
        }

        private void pbFigurkaZlutaDva_Click(object sender, EventArgs e)
        {
            if (pozice[5] == 0 && hozeneCislo == 6)
            {
                hozeneCislo = 0;
                pozice[5] = 1;
            }
            if (pozice[5] != 0)
            {
                pozice[5] += hozeneCislo;
                if (pozice[5] == pozice[4] || pozice[5] == pozice[6] || pozice[5] == pozice[7])
                {
                    if (pozice[5] == 1)
                    {
                        pozice[5] = 0;
                    }
                    pozice[5] -= hozeneCislo;
                }
            umisteni:
                switch (pozice[5])
                {
                    case 1:
                        pbFigurkaZlutaDva.Location = new Point(C11Z1Z31M21.Location.X + 12, C11Z1Z31M21.Location.Y + 12);
                        break;
                    case 2:
                        pbFigurkaZlutaDva.Location = new Point(C12Z2Z32M22.Location.X + 12, C12Z2Z32M22.Location.Y + 12);
                        break;
                    case 3:
                        pbFigurkaZlutaDva.Location = new Point(C13Z3Z33M23.Location.X + 12, C13Z3Z33M23.Location.Y + 12);
                        break;
                    case 4:
                        pbFigurkaZlutaDva.Location = new Point(C14Z4Z34M24.Location.X + 12, C14Z4Z34M24.Location.Y + 12);
                        break;
                    case 5:
                        pbFigurkaZlutaDva.Location = new Point(C15Z5Z35M25.Location.X + 12, C15Z5Z35M25.Location.Y + 12);
                        break;
                    case 6:
                        pbFigurkaZlutaDva.Location = new Point(C16Z6Z36M26.Location.X + 12, C16Z6Z36M26.Location.Y + 12);
                        break;
                    case 7:
                        pbFigurkaZlutaDva.Location = new Point(C17Z7M27.Location.X + 12, C17Z7M27.Location.Y + 12);
                        break;
                    case 8:
                        pbFigurkaZlutaDva.Location = new Point(C18Z8M28.Location.X + 12, C18Z8M28.Location.Y + 12);
                        break;
                    case 9:
                        pbFigurkaZlutaDva.Location = new Point(C19Z9M29.Location.X + 12, C19Z9M29.Location.Y + 12);
                        break;
                    case 10:
                        pbFigurkaZlutaDva.Location = new Point(C20Z10M30.Location.X + 12, C20Z10M30.Location.Y + 12);
                        break;
                    case 11:
                        pbFigurkaZlutaDva.Location = new Point(C21Z11Z1M31.Location.X + 12, C21Z11Z1M31.Location.Y + 12);
                        break;
                    case 12:
                        pbFigurkaZlutaDva.Location = new Point(C22Z12Z2M32.Location.X + 12, C22Z12Z2M32.Location.Y + 12);
                        break;
                    case 13:
                        pbFigurkaZlutaDva.Location = new Point(C23Z13Z3M33.Location.X + 12, C23Z13Z3M33.Location.Y + 12);
                        break;
                    case 14:
                        pbFigurkaZlutaDva.Location = new Point(C24Z14Z4M34.Location.X + 12, C24Z14Z4M34.Location.Y + 12);
                        break;
                    case 15:
                        pbFigurkaZlutaDva.Location = new Point(C25Z15Z5M35.Location.X + 12, C25Z15Z5M35.Location.Y + 12);
                        break;
                    case 16:
                        pbFigurkaZlutaDva.Location = new Point(C26Z16Z6M36.Location.X + 12, C26Z16Z6M36.Location.Y + 12);
                        break;
                    case 17:
                        pbFigurkaZlutaDva.Location = new Point(C27Z17Z7.Location.X + 12, C27Z17Z7.Location.Y + 12);
                        break;
                    case 18:
                        pbFigurkaZlutaDva.Location = new Point(C28Z18Z8.Location.X + 12, C28Z18Z8.Location.Y + 12);
                        break;
                    case 19:
                        pbFigurkaZlutaDva.Location = new Point(C29Z19Z9.Location.X + 12, C29Z19Z9.Location.Y + 12);
                        break;
                    case 20:
                        pbFigurkaZlutaDva.Location = new Point(C30Z20Z10.Location.X + 12, C30Z20Z10.Location.Y + 12);
                        break;
                    case 21:
                        pbFigurkaZlutaDva.Location = new Point(C31Z21Z11M1.Location.X + 12, C31Z21Z11M1.Location.Y + 12);
                        break;
                    case 22:
                        pbFigurkaZlutaDva.Location = new Point(C32Z22Z12M2.Location.X + 12, C32Z22Z12M2.Location.Y + 12);
                        break;
                    case 23:
                        pbFigurkaZlutaDva.Location = new Point(C33Z23Z13M3.Location.X + 12, C33Z23Z13M3.Location.Y + 12);
                        break;
                    case 24:
                        pbFigurkaZlutaDva.Location = new Point(C34Z24Z14M4.Location.X + 12, C34Z24Z14M4.Location.Y + 12);
                        break;
                    case 25:
                        pbFigurkaZlutaDva.Location = new Point(C35Z25Z15M5.Location.X + 12, C35Z25Z15M5.Location.Y + 12);
                        break;
                    case 26:
                        pbFigurkaZlutaDva.Location = new Point(C36Z26Z16M6.Location.X + 12, C36Z26Z16M6.Location.Y + 12);
                        break;
                    case 31:
                        pbFigurkaZlutaDva.Location = new Point(C1Z31Z21M11.Location.X + 12, C1Z31Z21M11.Location.Y + 12);
                        break;
                    case 32:
                        pbFigurkaZlutaDva.Location = new Point(C2Z32Z22M12.Location.X + 12, C2Z32Z22M12.Location.Y + 12);
                        break;
                    case 33:
                        pbFigurkaZlutaDva.Location = new Point(C3Z33Z23M13.Location.X + 12, C3Z33Z23M13.Location.Y + 12);
                        break;
                    case 34:
                        pbFigurkaZlutaDva.Location = new Point(C4Z34Z24M14.Location.X + 12, C4Z34Z24M14.Location.Y + 12);
                        break;
                    case 35:
                        pbFigurkaZlutaDva.Location = new Point(C5Z35Z25M15.Location.X + 12, C5Z35Z25M15.Location.Y + 12);
                        break;
                    case 36:
                        pbFigurkaZlutaDva.Location = new Point(C6Z36Z26M16.Location.X + 12, C6Z36Z26M16.Location.Y + 12);
                        break;
                    case 27:
                        pbFigurkaZlutaDva.Location = new Point(Z27Z17M7.Location.X + 12, Z27Z17M7.Location.Y + 12);
                        break;
                    case 28:
                        pbFigurkaZlutaDva.Location = new Point(Z28Z18M8.Location.X + 12, Z28Z18M8.Location.Y + 12);
                        break;
                    case 29:
                        pbFigurkaZlutaDva.Location = new Point(Z29Z19M9.Location.X + 12, Z29Z19M9.Location.Y + 12);
                        break;
                    case 30:
                        pbFigurkaZlutaDva.Location = new Point(Z30Z20M10.Location.X + 12, Z30Z20M10.Location.Y + 12);
                        break;
                    case 37:
                        pbFigurkaZlutaDva.Location = new Point(ZL37.Location.X + 12, ZL37.Location.Y + 12);
                        break;
                    case 38:
                        pbFigurkaZlutaDva.Location = new Point(ZL38.Location.X + 12, ZL38.Location.Y + 12);
                        break;
                    case 39:
                        pbFigurkaZlutaDva.Location = new Point(ZL39.Location.X + 12, ZL39.Location.Y + 12);
                        break;
                    case 40:
                        pbFigurkaZlutaDva.Location = new Point(ZL40.Location.X + 12, ZL40.Location.Y + 12);
                        break;
                    default:
                        pozice[5] -= hozeneCislo;
                        goto umisteni;
                }
            }
            pbKostka.Enabled = true;
             tah = "ZE";
            pbFigurkaZlutaJedna.Enabled = false;
            pbFigurkaZlutaDva.Enabled = false;
            pbFigurkaZlutaTri.Enabled = false;
            pbFigurkaZlutaCtyri.Enabled = false;
            souradniceX[5] = pbFigurkaZlutaDva.Location.X;
            souradniceY[5] = pbFigurkaZlutaDva.Location.Y;
            for (int i = 0; i <= 3; i++)
            {
                if (souradniceX[5] == souradniceX[i] && souradniceY[5] == souradniceY[i])
                {
                    pozice[i] = 0;
                    Vyhazovani(i);
                    break;
                }
            }
            for (int i = 8; i <= 15; i++)
            {
                if (souradniceX[5] == souradniceX[i] && souradniceY[5] == souradniceY[i])
                {
                    pozice[i] = 0;
                    Vyhazovani(i);
                    break;
                }
            }
            for (int i = 4; i <= 7; i++)
            {
                for (int j = 4; j <= 7; j++)
                {
                    for (int k = 4; k <= 7; k++)
                    {
                        for (int l = 4; l <= 7; l++)
                        {
                            if (pozice[i] == 37 && pozice[j] == 38 && pozice[k] == 39 && pozice[l] == 40)
                            {
                                MessageBox.Show("Vyhrává" + lbHracDva);
                                zpetDoMenu.Show();
                                Hide();
                            }
                        }
                    }
                }
            }
        }

        private void pbFigurkaZlutaTri_Click(object sender, EventArgs e)
        {
            if (pozice[6] == 0 && hozeneCislo == 6)
            {
                hozeneCislo = 0;
                pozice[6] = 1;
            }
            if (pozice[6] != 0)
            {
                pozice[6] += hozeneCislo;
                if (pozice[6] == pozice[5] || pozice[6] == pozice[4] || pozice[6] == pozice[7])
                {
                    if (pozice[6] == 1)
                    {
                        pozice[6] = 0;
                    }
                    pozice[6] -= hozeneCislo;
                }
            umisteni:
                switch (pozice[6])
                {
                    case 1:
                        pbFigurkaZlutaTri.Location = new Point(C11Z1Z31M21.Location.X + 12, C11Z1Z31M21.Location.Y + 12);
                        break;
                    case 2:
                        pbFigurkaZlutaTri.Location = new Point(C12Z2Z32M22.Location.X + 12, C12Z2Z32M22.Location.Y + 12);
                        break;
                    case 3:
                        pbFigurkaZlutaTri.Location = new Point(C13Z3Z33M23.Location.X + 12, C13Z3Z33M23.Location.Y + 12);
                        break;
                    case 4:
                        pbFigurkaZlutaTri.Location = new Point(C14Z4Z34M24.Location.X + 12, C14Z4Z34M24.Location.Y + 12);
                        break;
                    case 5:
                        pbFigurkaZlutaTri.Location = new Point(C15Z5Z35M25.Location.X + 12, C15Z5Z35M25.Location.Y + 12);
                        break;
                    case 6:
                        pbFigurkaZlutaTri.Location = new Point(C16Z6Z36M26.Location.X + 12, C16Z6Z36M26.Location.Y + 12);
                        break;
                    case 7:
                        pbFigurkaZlutaTri.Location = new Point(C17Z7M27.Location.X + 12, C17Z7M27.Location.Y + 12);
                        break;
                    case 8:
                        pbFigurkaZlutaTri.Location = new Point(C18Z8M28.Location.X + 12, C18Z8M28.Location.Y + 12);
                        break;
                    case 9:
                        pbFigurkaZlutaTri.Location = new Point(C19Z9M29.Location.X + 12, C19Z9M29.Location.Y + 12);
                        break;
                    case 10:
                        pbFigurkaZlutaTri.Location = new Point(C20Z10M30.Location.X + 12, C20Z10M30.Location.Y + 12);
                        break;
                    case 11:
                        pbFigurkaZlutaTri.Location = new Point(C21Z11Z1M31.Location.X + 12, C21Z11Z1M31.Location.Y + 12);
                        break;
                    case 12:
                        pbFigurkaZlutaTri.Location = new Point(C22Z12Z2M32.Location.X + 12, C22Z12Z2M32.Location.Y + 12);
                        break;
                    case 13:
                        pbFigurkaZlutaTri.Location = new Point(C23Z13Z3M33.Location.X + 12, C23Z13Z3M33.Location.Y + 12);
                        break;
                    case 14:
                        pbFigurkaZlutaTri.Location = new Point(C24Z14Z4M34.Location.X + 12, C24Z14Z4M34.Location.Y + 12);
                        break;
                    case 15:
                        pbFigurkaZlutaTri.Location = new Point(C25Z15Z5M35.Location.X + 12, C25Z15Z5M35.Location.Y + 12);
                        break;
                    case 16:
                        pbFigurkaZlutaTri.Location = new Point(C26Z16Z6M36.Location.X + 12, C26Z16Z6M36.Location.Y + 12);
                        break;
                    case 17:
                        pbFigurkaZlutaTri.Location = new Point(C27Z17Z7.Location.X + 12, C27Z17Z7.Location.Y + 12);
                        break;
                    case 18:
                        pbFigurkaZlutaTri.Location = new Point(C28Z18Z8.Location.X + 12, C28Z18Z8.Location.Y + 12);
                        break;
                    case 19:
                        pbFigurkaZlutaTri.Location = new Point(C29Z19Z9.Location.X + 12, C29Z19Z9.Location.Y + 12);
                        break;
                    case 20:
                        pbFigurkaZlutaTri.Location = new Point(C30Z20Z10.Location.X + 12, C30Z20Z10.Location.Y + 12);
                        break;
                    case 21:
                        pbFigurkaZlutaTri.Location = new Point(C31Z21Z11M1.Location.X + 12, C31Z21Z11M1.Location.Y + 12);
                        break;
                    case 22:
                        pbFigurkaZlutaTri.Location = new Point(C32Z22Z12M2.Location.X + 12, C32Z22Z12M2.Location.Y + 12);
                        break;
                    case 23:
                        pbFigurkaZlutaTri.Location = new Point(C33Z23Z13M3.Location.X + 12, C33Z23Z13M3.Location.Y + 12);
                        break;
                    case 24:
                        pbFigurkaZlutaTri.Location = new Point(C34Z24Z14M4.Location.X + 12, C34Z24Z14M4.Location.Y + 12);
                        break;
                    case 25:
                        pbFigurkaZlutaTri.Location = new Point(C35Z25Z15M5.Location.X + 12, C35Z25Z15M5.Location.Y + 12);
                        break;
                    case 26:
                        pbFigurkaZlutaTri.Location = new Point(C36Z26Z16M6.Location.X + 12, C36Z26Z16M6.Location.Y + 12);
                        break;
                    case 31:
                        pbFigurkaZlutaTri.Location = new Point(C1Z31Z21M11.Location.X + 12, C1Z31Z21M11.Location.Y + 12);
                        break;
                    case 32:
                        pbFigurkaZlutaTri.Location = new Point(C2Z32Z22M12.Location.X + 12, C2Z32Z22M12.Location.Y + 12);
                        break;
                    case 33:
                        pbFigurkaZlutaTri.Location = new Point(C3Z33Z23M13.Location.X + 12, C3Z33Z23M13.Location.Y + 12);
                        break;
                    case 34:
                        pbFigurkaZlutaTri.Location = new Point(C4Z34Z24M14.Location.X + 12, C4Z34Z24M14.Location.Y + 12);
                        break;
                    case 35:
                        pbFigurkaZlutaTri.Location = new Point(C5Z35Z25M15.Location.X + 12, C5Z35Z25M15.Location.Y + 12);
                        break;
                    case 36:
                        pbFigurkaZlutaTri.Location = new Point(C6Z36Z26M16.Location.X + 12, C6Z36Z26M16.Location.Y + 12);
                        break;
                    case 27:
                        pbFigurkaZlutaTri.Location = new Point(Z27Z17M7.Location.X + 12, Z27Z17M7.Location.Y + 12);
                        break;
                    case 28:
                        pbFigurkaZlutaTri.Location = new Point(Z28Z18M8.Location.X + 12, Z28Z18M8.Location.Y + 12);
                        break;
                    case 29:
                        pbFigurkaZlutaTri.Location = new Point(Z29Z19M9.Location.X + 12, Z29Z19M9.Location.Y + 12);
                        break;
                    case 30:
                        pbFigurkaZlutaTri.Location = new Point(Z30Z20M10.Location.X + 12, Z30Z20M10.Location.Y + 12);
                        break;
                    case 37:
                        pbFigurkaZlutaTri.Location = new Point(ZL37.Location.X + 12, ZL37.Location.Y + 12);
                        break;
                    case 38:
                        pbFigurkaZlutaTri.Location = new Point(ZL38.Location.X + 12, ZL38.Location.Y + 12);
                        break;
                    case 39:
                        pbFigurkaZlutaTri.Location = new Point(ZL39.Location.X + 12, ZL39.Location.Y + 12);
                        break;
                    case 40:
                        pbFigurkaZlutaTri.Location = new Point(ZL40.Location.X + 12, ZL40.Location.Y + 12);
                        break;
                    default:
                        pozice[6] -= hozeneCislo;
                        goto umisteni;
                }
            }
            pbKostka.Enabled = true;
             tah = "ZE";
            pbFigurkaZlutaJedna.Enabled = false;
            pbFigurkaZlutaDva.Enabled = false;
            pbFigurkaZlutaTri.Enabled = false;
            pbFigurkaZlutaCtyri.Enabled = false;
            souradniceX[6] = pbFigurkaZlutaTri.Location.X;
            souradniceY[6] = pbFigurkaZlutaTri.Location.Y;
            for (int i = 0; i <= 3; i++)
            {
                if (souradniceX[6] == souradniceX[i] && souradniceY[6] == souradniceY[i])
                {
                    pozice[i] = 0;
                    Vyhazovani(i);
                    break;
                }
            }
            for (int i = 8; i <= 15; i++)
            {
                if (souradniceX[6] == souradniceX[i] && souradniceY[6] == souradniceY[i])
                {
                    pozice[i] = 0;
                    Vyhazovani(i);
                    break;
                }
            }
            for (int i = 4; i <= 7; i++)
            {
                for (int j = 4; j <= 7; j++)
                {
                    for (int k = 4; k <= 7; k++)
                    {
                        for (int l = 4; l <= 7; l++)
                        {
                            if (pozice[i] == 37 && pozice[j] == 38 && pozice[k] == 39 && pozice[l] == 40)
                            {
                                MessageBox.Show("Vyhrává" + lbHracDva);
                                zpetDoMenu.Show();
                                Hide();
                            }
                        }
                    }
                }
            }
        }

        private void pbFigurkaZlutaCtyri_Click(object sender, EventArgs e)
        {
            if (pozice[7] == 0 && hozeneCislo == 6)
            {
                hozeneCislo = 0;
                pozice[7] = 1;
            }
            if (pozice[7] != 0)
            {
                pozice[7] += hozeneCislo;
                if (pozice[7] == pozice[5] || pozice[7] == pozice[6] || pozice[7] == pozice[4])
                {
                    if (pozice[7] == 1)
                    {
                        pozice[7] = 0;
                    }
                    pozice[7] -= hozeneCislo;
                }
            umisteni:
                switch (pozice[7])
                {
                    case 1:
                        pbFigurkaZlutaCtyri.Location = new Point(C11Z1Z31M21.Location.X + 12, C11Z1Z31M21.Location.Y + 12);
                        break;
                    case 2:
                        pbFigurkaZlutaCtyri.Location = new Point(C12Z2Z32M22.Location.X + 12, C12Z2Z32M22.Location.Y + 12);
                        break;
                    case 3:
                        pbFigurkaZlutaCtyri.Location = new Point(C13Z3Z33M23.Location.X + 12, C13Z3Z33M23.Location.Y + 12);
                        break;
                    case 4:
                        pbFigurkaZlutaCtyri.Location = new Point(C14Z4Z34M24.Location.X + 12, C14Z4Z34M24.Location.Y + 12);
                        break;
                    case 5:
                        pbFigurkaZlutaCtyri.Location = new Point(C15Z5Z35M25.Location.X + 12, C15Z5Z35M25.Location.Y + 12);
                        break;
                    case 6:
                        pbFigurkaZlutaCtyri.Location = new Point(C16Z6Z36M26.Location.X + 12, C16Z6Z36M26.Location.Y + 12);
                        break;
                    case 7:
                        pbFigurkaZlutaCtyri.Location = new Point(C17Z7M27.Location.X + 12, C17Z7M27.Location.Y + 12);
                        break;
                    case 8:
                        pbFigurkaZlutaCtyri.Location = new Point(C18Z8M28.Location.X + 12, C18Z8M28.Location.Y + 12);
                        break;
                    case 9:
                        pbFigurkaZlutaCtyri.Location = new Point(C19Z9M29.Location.X + 12, C19Z9M29.Location.Y + 12);
                        break;
                    case 10:
                        pbFigurkaZlutaCtyri.Location = new Point(C20Z10M30.Location.X + 12, C20Z10M30.Location.Y + 12);
                        break;
                    case 11:
                        pbFigurkaZlutaCtyri.Location = new Point(C21Z11Z1M31.Location.X + 12, C21Z11Z1M31.Location.Y + 12);
                        break;
                    case 12:
                        pbFigurkaZlutaCtyri.Location = new Point(C22Z12Z2M32.Location.X + 12, C22Z12Z2M32.Location.Y + 12);
                        break;
                    case 13:
                        pbFigurkaZlutaCtyri.Location = new Point(C23Z13Z3M33.Location.X + 12, C23Z13Z3M33.Location.Y + 12);
                        break;
                    case 14:
                        pbFigurkaZlutaCtyri.Location = new Point(C24Z14Z4M34.Location.X + 12, C24Z14Z4M34.Location.Y + 12);
                        break;
                    case 15:
                        pbFigurkaZlutaCtyri.Location = new Point(C25Z15Z5M35.Location.X + 12, C25Z15Z5M35.Location.Y + 12);
                        break;
                    case 16:
                        pbFigurkaZlutaCtyri.Location = new Point(C26Z16Z6M36.Location.X + 12, C26Z16Z6M36.Location.Y + 12);
                        break;
                    case 17:
                        pbFigurkaZlutaCtyri.Location = new Point(C27Z17Z7.Location.X + 12, C27Z17Z7.Location.Y + 12);
                        break;
                    case 18:
                        pbFigurkaZlutaCtyri.Location = new Point(C28Z18Z8.Location.X + 12, C28Z18Z8.Location.Y + 12);
                        break;
                    case 19:
                        pbFigurkaZlutaCtyri.Location = new Point(C29Z19Z9.Location.X + 12, C29Z19Z9.Location.Y + 12);
                        break;
                    case 20:
                        pbFigurkaZlutaCtyri.Location = new Point(C30Z20Z10.Location.X + 12, C30Z20Z10.Location.Y + 12);
                        break;
                    case 21:
                        pbFigurkaZlutaCtyri.Location = new Point(C31Z21Z11M1.Location.X + 12, C31Z21Z11M1.Location.Y + 12);
                        break;
                    case 22:
                        pbFigurkaZlutaCtyri.Location = new Point(C32Z22Z12M2.Location.X + 12, C32Z22Z12M2.Location.Y + 12);
                        break;
                    case 23:
                        pbFigurkaZlutaCtyri.Location = new Point(C33Z23Z13M3.Location.X + 12, C33Z23Z13M3.Location.Y + 12);
                        break;
                    case 24:
                        pbFigurkaZlutaCtyri.Location = new Point(C34Z24Z14M4.Location.X + 12, C34Z24Z14M4.Location.Y + 12);
                        break;
                    case 25:
                        pbFigurkaZlutaCtyri.Location = new Point(C35Z25Z15M5.Location.X + 12, C35Z25Z15M5.Location.Y + 12);
                        break;
                    case 26:
                        pbFigurkaZlutaCtyri.Location = new Point(C36Z26Z16M6.Location.X + 12, C36Z26Z16M6.Location.Y + 12);
                        break;
                    case 31:
                        pbFigurkaZlutaCtyri.Location = new Point(C1Z31Z21M11.Location.X + 12, C1Z31Z21M11.Location.Y + 12);
                        break;
                    case 32:
                        pbFigurkaZlutaCtyri.Location = new Point(C2Z32Z22M12.Location.X + 12, C2Z32Z22M12.Location.Y + 12);
                        break;
                    case 33:
                        pbFigurkaZlutaCtyri.Location = new Point(C3Z33Z23M13.Location.X + 12, C3Z33Z23M13.Location.Y + 12);
                        break;
                    case 34:
                        pbFigurkaZlutaCtyri.Location = new Point(C4Z34Z24M14.Location.X + 12, C4Z34Z24M14.Location.Y + 12);
                        break;
                    case 35:
                        pbFigurkaZlutaCtyri.Location = new Point(C5Z35Z25M15.Location.X + 12, C5Z35Z25M15.Location.Y + 12);
                        break;
                    case 36:
                        pbFigurkaZlutaCtyri.Location = new Point(C6Z36Z26M16.Location.X + 12, C6Z36Z26M16.Location.Y + 12);
                        break;
                    case 27:
                        pbFigurkaZlutaCtyri.Location = new Point(Z27Z17M7.Location.X + 12, Z27Z17M7.Location.Y + 12);
                        break;
                    case 28:
                        pbFigurkaZlutaCtyri.Location = new Point(Z28Z18M8.Location.X + 12, Z28Z18M8.Location.Y + 12);
                        break;
                    case 29:
                        pbFigurkaZlutaCtyri.Location = new Point(Z29Z19M9.Location.X + 12, Z29Z19M9.Location.Y + 12);
                        break;
                    case 30:
                        pbFigurkaZlutaCtyri.Location = new Point(Z30Z20M10.Location.X + 12, Z30Z20M10.Location.Y + 12);
                        break;
                    case 37:
                        pbFigurkaZlutaCtyri.Location = new Point(ZL37.Location.X + 12, ZL37.Location.Y + 12);
                        break;
                    case 38:
                        pbFigurkaZlutaCtyri.Location = new Point(ZL38.Location.X + 12, ZL38.Location.Y + 12);
                        break;
                    case 39:
                        pbFigurkaZlutaCtyri.Location = new Point(ZL39.Location.X + 12, ZL39.Location.Y + 12);
                        break;
                    case 40:
                        pbFigurkaZlutaCtyri.Location = new Point(ZL40.Location.X + 12, ZL40.Location.Y + 12);
                        break;
                    default:
                        pozice[7] -= hozeneCislo;
                        goto umisteni;
                }
            }
            pbKostka.Enabled = true;
             tah = "ZE";
            pbFigurkaZlutaJedna.Enabled = false;
            pbFigurkaZlutaDva.Enabled = false;
            pbFigurkaZlutaTri.Enabled = false;
            pbFigurkaZlutaCtyri.Enabled = false;
            souradniceX[7] = pbFigurkaZlutaCtyri.Location.X;
            souradniceY[7] = pbFigurkaZlutaCtyri.Location.Y;
            for (int i = 0; i <= 3; i++)
            {
                if (souradniceX[7] == souradniceX[i] && souradniceY[7] == souradniceY[i])
                {
                    pozice[i] = 0;
                    Vyhazovani(i);
                    break;
                }
            }
            for (int i = 8; i <= 15; i++)
            {
                if (souradniceX[7] == souradniceX[i] && souradniceY[7] == souradniceY[i])
                {
                    pozice[i] = 0;
                    Vyhazovani(i);
                    break;
                }
            }
            for (int i = 4; i <= 7; i++)
            {
                for (int j = 4; j <= 7; j++)
                {
                    for (int k = 4; k <= 7; k++)
                    {
                        for (int l = 4; l <= 7; l++)
                        {
                            if (pozice[i] == 37 && pozice[j] == 38 && pozice[k] == 39 && pozice[l] == 40)
                            {
                                MessageBox.Show("Vyhrává" + lbHracDva);
                                zpetDoMenu.Show();
                                Hide();
                            }
                        }
                    }
                }
            }
        }

        private void pbFigurkaZelenaJedna_Click(object sender, EventArgs e)
        {
            if (pozice[8] == 0 && hozeneCislo == 6)
            {
                hozeneCislo = 0;
                pozice[8] = 1;
            }
            if (pozice[8] != 0)
            {
                pozice[8] += hozeneCislo;
                if (pozice[8] == pozice[9] || pozice[8] == pozice[10] || pozice[8] == pozice[11])
                {
                    if (pozice[8] == 1)
                    {
                        pozice[8] = 0;
                    }
                    pozice[8] -= hozeneCislo;
                }
            umisteni:
                switch (pozice[8])
                {
                    case 1:
                        pbFigurkaZelenaJedna.Location = new Point(C21Z11Z1M31.Location.X + 12, C21Z11Z1M31.Location.Y + 12);
                        break;
                    case 2:
                        pbFigurkaZelenaJedna.Location = new Point(C22Z12Z2M32.Location.X + 12, C22Z12Z2M32.Location.Y + 12);
                        break;
                    case 3:
                        pbFigurkaZelenaJedna.Location = new Point(C23Z13Z3M33.Location.X + 12, C23Z13Z3M33.Location.Y + 12);
                        break;
                    case 4:
                        pbFigurkaZelenaJedna.Location = new Point(C24Z14Z4M34.Location.X + 12, C24Z14Z4M34.Location.Y + 12);
                        break;
                    case 5:
                        pbFigurkaZelenaJedna.Location = new Point(C25Z15Z5M35.Location.X + 12, C25Z15Z5M35.Location.Y + 12);
                        break;
                    case 6:
                        pbFigurkaZelenaJedna.Location = new Point(C26Z16Z6M36.Location.X + 12, C26Z16Z6M36.Location.Y + 12);
                        break;
                    case 7:
                        pbFigurkaZelenaJedna.Location = new Point(C27Z17Z7.Location.X + 12, C27Z17Z7.Location.Y + 12);
                        break;
                    case 8:
                        pbFigurkaZelenaJedna.Location = new Point(C28Z18Z8.Location.X + 12, C28Z18Z8.Location.Y + 12);
                        break;
                    case 9:
                        pbFigurkaZelenaJedna.Location = new Point(C29Z19Z9.Location.X + 12, C29Z19Z9.Location.Y + 12);
                        break;
                    case 10:
                        pbFigurkaZelenaJedna.Location = new Point(C30Z20Z10.Location.X + 12, C30Z20Z10.Location.Y + 12);
                        break;
                    case 11:
                        pbFigurkaZelenaJedna.Location = new Point(C31Z21Z11M1.Location.X + 12, C31Z21Z11M1.Location.Y + 12);
                        break;
                    case 12:
                        pbFigurkaZelenaJedna.Location = new Point(C32Z22Z12M2.Location.X + 12, C32Z22Z12M2.Location.Y + 12);
                        break;
                    case 13:
                        pbFigurkaZelenaJedna.Location = new Point(C33Z23Z13M3.Location.X + 12, C33Z23Z13M3.Location.Y + 12);
                        break;
                    case 14:
                        pbFigurkaZelenaJedna.Location = new Point(C34Z24Z14M4.Location.X + 12, C34Z24Z14M4.Location.Y + 12);
                        break;
                    case 15:
                        pbFigurkaZelenaJedna.Location = new Point(C35Z25Z15M5.Location.X + 12, C35Z25Z15M5.Location.Y + 12);
                        break;
                    case 16:
                        pbFigurkaZelenaJedna.Location = new Point(C36Z26Z16M6.Location.X + 12, C36Z26Z16M6.Location.Y + 12);
                        break;
                    case 17:
                        pbFigurkaZelenaJedna.Location = new Point(Z27Z17M7.Location.X + 12, Z27Z17M7.Location.Y + 12);
                        break;
                    case 18:
                        pbFigurkaZelenaJedna.Location = new Point(Z28Z18M8.Location.X + 12, Z28Z18M8.Location.Y + 12);
                        break;
                    case 19:
                        pbFigurkaZelenaJedna.Location = new Point(Z29Z19M9.Location.X + 12, Z29Z19M9.Location.Y + 12);
                        break;
                    case 20:
                        pbFigurkaZelenaJedna.Location = new Point(Z30Z20M10.Location.X + 12, Z30Z20M10.Location.Y + 12);
                        break;
                    case 21:
                        pbFigurkaZelenaJedna.Location = new Point(C1Z31Z21M11.Location.X + 12, C1Z31Z21M11.Location.Y + 12);
                        break;
                    case 22:
                        pbFigurkaZelenaJedna.Location = new Point(C2Z32Z22M12.Location.X + 12, C2Z32Z22M12.Location.Y + 12);
                        break;
                    case 23:
                        pbFigurkaZelenaJedna.Location = new Point(C3Z33Z23M13.Location.X + 12, C3Z33Z23M13.Location.Y + 12);
                        break;
                    case 24:
                        pbFigurkaZelenaJedna.Location = new Point(C4Z34Z24M14.Location.X + 12, C4Z34Z24M14.Location.Y + 12);
                        break;
                    case 25:
                        pbFigurkaZelenaJedna.Location = new Point(C5Z35Z25M15.Location.X + 12, C5Z35Z25M15.Location.Y + 12);
                        break;
                    case 26:
                        pbFigurkaZelenaJedna.Location = new Point(C6Z36Z26M16.Location.X + 12, C6Z36Z26M16.Location.Y + 12);
                        break;
                    case 27:
                        pbFigurkaZelenaJedna.Location = new Point(C7Z27M17.Location.X + 12, C7Z27M17.Location.Y + 12);
                        break;
                    case 28:
                        pbFigurkaZelenaJedna.Location = new Point(C8Z28M18.Location.X + 12, C8Z28M18.Location.Y + 12);
                        break;
                    case 29:
                        pbFigurkaZelenaJedna.Location = new Point(C9Z29M19.Location.X + 12, C9Z29M19.Location.Y + 12);
                        break;
                    case 30:
                        pbFigurkaZelenaJedna.Location = new Point(C10Z30M20.Location.X + 12, C10Z30M20.Location.Y + 12);
                        break;
                    case 31:
                        pbFigurkaZelenaJedna.Location = new Point(C11Z1Z31M21.Location.X + 12, C11Z1Z31M21.Location.Y + 12);
                        break;
                    case 32:
                        pbFigurkaZelenaJedna.Location = new Point(C12Z2Z32M22.Location.X + 12, C12Z2Z32M22.Location.Y + 12);
                        break;
                    case 33:
                        pbFigurkaZelenaJedna.Location = new Point(C13Z3Z33M23.Location.X + 12, C13Z3Z33M23.Location.Y + 12);
                        break;
                    case 34:
                        pbFigurkaZelenaJedna.Location = new Point(C14Z4Z34M24.Location.X + 12, C14Z4Z34M24.Location.Y + 12);
                        break;
                    case 35:
                        pbFigurkaZelenaJedna.Location = new Point(C15Z5Z35M25.Location.X + 12, C15Z5Z35M25.Location.Y + 12);
                        break;
                    case 36:
                        pbFigurkaZelenaJedna.Location = new Point(C16Z6Z36M26.Location.X + 12, C16Z6Z36M26.Location.Y + 12);
                        break;
                    case 37:
                        pbFigurkaZelenaJedna.Location = new Point(ZE37.Location.X + 12, ZE37.Location.Y + 12);
                        break;
                    case 38:
                        pbFigurkaZelenaJedna.Location = new Point(ZE38.Location.X + 12, ZE38.Location.Y + 12);
                        break;
                    case 39:
                        pbFigurkaZelenaJedna.Location = new Point(ZE39.Location.X + 12, ZE39.Location.Y + 12);
                        break;
                    case 40:
                        pbFigurkaZelenaJedna.Location = new Point(ZE40.Location.X + 12, ZE40.Location.Y + 12);
                        break;
                    default:
                        pozice[8] -= hozeneCislo;
                        goto umisteni;
                }
            }
            pbKostka.Enabled = true;
            tah = "MO";
            pbFigurkaZelenaJedna.Enabled = false;
            pbFigurkaZelenaDva.Enabled = false;
            pbFigurkaZelenaTri.Enabled = false;
            pbFigurkaZelenaCtyri.Enabled = false;
            souradniceX[8] = pbFigurkaZelenaJedna.Location.X;
            souradniceY[8] = pbFigurkaZelenaJedna.Location.Y;
            for (int i = 0; i <= 7; i++)
            {
                if (souradniceX[8] == souradniceX[i] && souradniceY[8] == souradniceY[i])
                {
                    pozice[i] = 0;
                    Vyhazovani(i);
                    break;
                }
            }
            for (int i = 12; i <= 15; i++)
            {
                if (souradniceX[8] == souradniceX[i] && souradniceY[8] == souradniceY[i])
                {
                    pozice[i] = 0;
                    Vyhazovani(i);
                    break;
                }
            }
            for (int i = 8; i <= 11; i++)
            {
                for (int j = 8; j <= 11; j++)
                {
                    for (int k = 8; k <= 11; k++)
                    {
                        for (int l = 8; l <= 11; l++)
                        {
                            if (pozice[i] == 37 && pozice[j] == 38 && pozice[k] == 39 && pozice[l] == 40)
                            {
                                MessageBox.Show("Vyhrává" + lbHracTri);
                                zpetDoMenu.Show();
                                Hide();
                            }
                        }
                    }
                }
            }
        }

        private void pbFigurkaZelenaDva_Click(object sender, EventArgs e)
        {
            if (pozice[9] == 0 && hozeneCislo == 6)
            {
                hozeneCislo = 0;
                pozice[9] = 1;
            }
            if (pozice[9] != 0)
            {
                pozice[9] += hozeneCislo;
                if (pozice[9] == pozice[8] || pozice[9] == pozice[10] || pozice[9] == pozice[11])
                {
                    if (pozice[9] == 1)
                    {
                        pozice[9] = 0;
                    }
                    pozice[9] -= hozeneCislo;
                }
            umisteni:
                switch (pozice[9])
                {
                    case 1:
                        pbFigurkaZelenaDva.Location = new Point(C21Z11Z1M31.Location.X + 12, C21Z11Z1M31.Location.Y + 12);
                        break;
                    case 2:
                        pbFigurkaZelenaDva.Location = new Point(C22Z12Z2M32.Location.X + 12, C22Z12Z2M32.Location.Y + 12);
                        break;
                    case 3:
                        pbFigurkaZelenaDva.Location = new Point(C23Z13Z3M33.Location.X + 12, C23Z13Z3M33.Location.Y + 12);
                        break;
                    case 4:
                        pbFigurkaZelenaDva.Location = new Point(C24Z14Z4M34.Location.X + 12, C24Z14Z4M34.Location.Y + 12);
                        break;
                    case 5:
                        pbFigurkaZelenaDva.Location = new Point(C25Z15Z5M35.Location.X + 12, C25Z15Z5M35.Location.Y + 12);
                        break;
                    case 6:
                        pbFigurkaZelenaDva.Location = new Point(C26Z16Z6M36.Location.X + 12, C26Z16Z6M36.Location.Y + 12);
                        break;
                    case 7:
                        pbFigurkaZelenaDva.Location = new Point(C27Z17Z7.Location.X + 12, C27Z17Z7.Location.Y + 12);
                        break;
                    case 8:
                        pbFigurkaZelenaDva.Location = new Point(C28Z18Z8.Location.X + 12, C28Z18Z8.Location.Y + 12);
                        break;
                    case 9:
                        pbFigurkaZelenaDva.Location = new Point(C29Z19Z9.Location.X + 12, C29Z19Z9.Location.Y + 12);
                        break;
                    case 10:
                        pbFigurkaZelenaDva.Location = new Point(C30Z20Z10.Location.X + 12, C30Z20Z10.Location.Y + 12);
                        break;
                    case 11:
                        pbFigurkaZelenaDva.Location = new Point(C31Z21Z11M1.Location.X + 12, C31Z21Z11M1.Location.Y + 12);
                        break;
                    case 12:
                        pbFigurkaZelenaDva.Location = new Point(C32Z22Z12M2.Location.X + 12, C32Z22Z12M2.Location.Y + 12);
                        break;
                    case 13:
                        pbFigurkaZelenaDva.Location = new Point(C33Z23Z13M3.Location.X + 12, C33Z23Z13M3.Location.Y + 12);
                        break;
                    case 14:
                        pbFigurkaZelenaDva.Location = new Point(C34Z24Z14M4.Location.X + 12, C34Z24Z14M4.Location.Y + 12);
                        break;
                    case 15:
                        pbFigurkaZelenaDva.Location = new Point(C35Z25Z15M5.Location.X + 12, C35Z25Z15M5.Location.Y + 12);
                        break;
                    case 16:
                        pbFigurkaZelenaDva.Location = new Point(C36Z26Z16M6.Location.X + 12, C36Z26Z16M6.Location.Y + 12);
                        break;
                    case 17:
                        pbFigurkaZelenaDva.Location = new Point(Z27Z17M7.Location.X + 12, Z27Z17M7.Location.Y + 12);
                        break;
                    case 18:
                        pbFigurkaZelenaDva.Location = new Point(Z28Z18M8.Location.X + 12, Z28Z18M8.Location.Y + 12);
                        break;
                    case 19:
                        pbFigurkaZelenaDva.Location = new Point(Z29Z19M9.Location.X + 12, Z29Z19M9.Location.Y + 12);
                        break;
                    case 20:
                        pbFigurkaZelenaDva.Location = new Point(Z30Z20M10.Location.X + 12, Z30Z20M10.Location.Y + 12);
                        break;
                    case 21:
                        pbFigurkaZelenaDva.Location = new Point(C1Z31Z21M11.Location.X + 12, C1Z31Z21M11.Location.Y + 12);
                        break;
                    case 22:
                        pbFigurkaZelenaDva.Location = new Point(C2Z32Z22M12.Location.X + 12, C2Z32Z22M12.Location.Y + 12);
                        break;
                    case 23:
                        pbFigurkaZelenaDva.Location = new Point(C3Z33Z23M13.Location.X + 12, C3Z33Z23M13.Location.Y + 12);
                        break;
                    case 24:
                        pbFigurkaZelenaDva.Location = new Point(C4Z34Z24M14.Location.X + 12, C4Z34Z24M14.Location.Y + 12);
                        break;
                    case 25:
                        pbFigurkaZelenaDva.Location = new Point(C5Z35Z25M15.Location.X + 12, C5Z35Z25M15.Location.Y + 12);
                        break;
                    case 26:
                        pbFigurkaZelenaDva.Location = new Point(C6Z36Z26M16.Location.X + 12, C6Z36Z26M16.Location.Y + 12);
                        break;
                    case 27:
                        pbFigurkaZelenaDva.Location = new Point(C7Z27M17.Location.X + 12, C7Z27M17.Location.Y + 12);
                        break;
                    case 28:
                        pbFigurkaZelenaDva.Location = new Point(C8Z28M18.Location.X + 12, C8Z28M18.Location.Y + 12);
                        break;
                    case 29:
                        pbFigurkaZelenaDva.Location = new Point(C9Z29M19.Location.X + 12, C9Z29M19.Location.Y + 12);
                        break;
                    case 30:
                        pbFigurkaZelenaDva.Location = new Point(C10Z30M20.Location.X + 12, C10Z30M20.Location.Y + 12);
                        break;
                    case 31:
                        pbFigurkaZelenaDva.Location = new Point(C11Z1Z31M21.Location.X + 12, C11Z1Z31M21.Location.Y + 12);
                        break;
                    case 32:
                        pbFigurkaZelenaDva.Location = new Point(C12Z2Z32M22.Location.X + 12, C12Z2Z32M22.Location.Y + 12);
                        break;
                    case 33:
                        pbFigurkaZelenaDva.Location = new Point(C13Z3Z33M23.Location.X + 12, C13Z3Z33M23.Location.Y + 12);
                        break;
                    case 34:
                        pbFigurkaZelenaDva.Location = new Point(C14Z4Z34M24.Location.X + 12, C14Z4Z34M24.Location.Y + 12);
                        break;
                    case 35:
                        pbFigurkaZelenaDva.Location = new Point(C15Z5Z35M25.Location.X + 12, C15Z5Z35M25.Location.Y + 12);
                        break;
                    case 36:
                        pbFigurkaZelenaDva.Location = new Point(C16Z6Z36M26.Location.X + 12, C16Z6Z36M26.Location.Y + 12);
                        break;
                    case 37:
                        pbFigurkaZelenaDva.Location = new Point(ZE37.Location.X + 12, ZE37.Location.Y + 12);
                        break;
                    case 38:
                        pbFigurkaZelenaDva.Location = new Point(ZE38.Location.X + 12, ZE38.Location.Y + 12);
                        break;
                    case 39:
                        pbFigurkaZelenaDva.Location = new Point(ZE39.Location.X + 12, ZE39.Location.Y + 12);
                        break;
                    case 40:
                        pbFigurkaZelenaDva.Location = new Point(ZE40.Location.X + 12, ZE40.Location.Y + 12);
                        break;
                    default:
                        pozice[9] -= hozeneCislo;
                        goto umisteni;
                }
            }
            pbKostka.Enabled = true;
            tah = "MO";
            pbFigurkaZelenaJedna.Enabled = false;
            pbFigurkaZelenaDva.Enabled = false;
            pbFigurkaZelenaTri.Enabled = false;
            pbFigurkaZelenaCtyri.Enabled = false;
            souradniceX[9] = pbFigurkaZelenaDva.Location.X;
            souradniceY[9] = pbFigurkaZelenaDva.Location.Y;
            for (int i = 0; i <= 7; i++)
            {
                if (souradniceX[9] == souradniceX[i] && souradniceY[9] == souradniceY[i])
                {
                    pozice[i] = 0;
                    Vyhazovani(i);
                    break;
                }
            }
            for (int i = 12; i <= 15; i++)
            {
                if (souradniceX[9] == souradniceX[i] && souradniceY[9] == souradniceY[i])
                {
                    pozice[i] = 0;
                    Vyhazovani(i);
                    break;
                }
            }
            for (int i = 8; i <= 11; i++)
            {
                for (int j = 8; j <= 11; j++)
                {
                    for (int k = 8; k <= 11; k++)
                    {
                        for (int l = 8; l <= 11; l++)
                        {
                            if (pozice[i] == 37 && pozice[j] == 38 && pozice[k] == 39 && pozice[l] == 40)
                            {
                                MessageBox.Show("Vyhrává" + lbHracTri);
                                zpetDoMenu.Show();
                                Hide();
                            }
                        }
                    }
                }
            }
        }

        private void pbFigurkaZelenaTri_Click(object sender, EventArgs e)
        {
            if (pozice[10] == 0 && hozeneCislo == 6)
            {
                hozeneCislo = 0;
                pozice[10] = 1;
            }
            if (pozice[10] != 0)
            {
                pozice[10] += hozeneCislo;
                if (pozice[10] == pozice[9] || pozice[10] == pozice[8] || pozice[10] == pozice[11])
                {
                    if (pozice[10] == 1)
                    {
                        pozice[10] = 0;
                    }
                    pozice[10] -= hozeneCislo;
                }
            umisteni:
                switch (pozice[10])
                {
                    case 1:
                        pbFigurkaZelenaTri.Location = new Point(C21Z11Z1M31.Location.X + 12, C21Z11Z1M31.Location.Y + 12);
                        break;
                    case 2:
                        pbFigurkaZelenaTri.Location = new Point(C22Z12Z2M32.Location.X + 12, C22Z12Z2M32.Location.Y + 12);
                        break;
                    case 3:
                        pbFigurkaZelenaTri.Location = new Point(C23Z13Z3M33.Location.X + 12, C23Z13Z3M33.Location.Y + 12);
                        break;
                    case 4:
                        pbFigurkaZelenaTri.Location = new Point(C24Z14Z4M34.Location.X + 12, C24Z14Z4M34.Location.Y + 12);
                        break;
                    case 5:
                        pbFigurkaZelenaTri.Location = new Point(C25Z15Z5M35.Location.X + 12, C25Z15Z5M35.Location.Y + 12);
                        break;
                    case 6:
                        pbFigurkaZelenaTri.Location = new Point(C26Z16Z6M36.Location.X + 12, C26Z16Z6M36.Location.Y + 12);
                        break;
                    case 7:
                        pbFigurkaZelenaTri.Location = new Point(C27Z17Z7.Location.X + 12, C27Z17Z7.Location.Y + 12);
                        break;
                    case 8:
                        pbFigurkaZelenaTri.Location = new Point(C28Z18Z8.Location.X + 12, C28Z18Z8.Location.Y + 12);
                        break;
                    case 9:
                        pbFigurkaZelenaTri.Location = new Point(C29Z19Z9.Location.X + 12, C29Z19Z9.Location.Y + 12);
                        break;
                    case 10:
                        pbFigurkaZelenaTri.Location = new Point(C30Z20Z10.Location.X + 12, C30Z20Z10.Location.Y + 12);
                        break;
                    case 11:
                        pbFigurkaZelenaTri.Location = new Point(C31Z21Z11M1.Location.X + 12, C31Z21Z11M1.Location.Y + 12);
                        break;
                    case 12:
                        pbFigurkaZelenaTri.Location = new Point(C32Z22Z12M2.Location.X + 12, C32Z22Z12M2.Location.Y + 12);
                        break;
                    case 13:
                        pbFigurkaZelenaTri.Location = new Point(C33Z23Z13M3.Location.X + 12, C33Z23Z13M3.Location.Y + 12);
                        break;
                    case 14:
                        pbFigurkaZelenaTri.Location = new Point(C34Z24Z14M4.Location.X + 12, C34Z24Z14M4.Location.Y + 12);
                        break;
                    case 15:
                        pbFigurkaZelenaTri.Location = new Point(C35Z25Z15M5.Location.X + 12, C35Z25Z15M5.Location.Y + 12);
                        break;
                    case 16:
                        pbFigurkaZelenaTri.Location = new Point(C36Z26Z16M6.Location.X + 12, C36Z26Z16M6.Location.Y + 12);
                        break;
                    case 17:
                        pbFigurkaZelenaTri.Location = new Point(Z27Z17M7.Location.X + 12, Z27Z17M7.Location.Y + 12);
                        break;
                    case 18:
                        pbFigurkaZelenaTri.Location = new Point(Z28Z18M8.Location.X + 12, Z28Z18M8.Location.Y + 12);
                        break;
                    case 19:
                        pbFigurkaZelenaTri.Location = new Point(Z29Z19M9.Location.X + 12, Z29Z19M9.Location.Y + 12);
                        break;
                    case 20:
                        pbFigurkaZelenaTri.Location = new Point(Z30Z20M10.Location.X + 12, Z30Z20M10.Location.Y + 12);
                        break;
                    case 21:
                        pbFigurkaZelenaTri.Location = new Point(C1Z31Z21M11.Location.X + 12, C1Z31Z21M11.Location.Y + 12);
                        break;
                    case 22:
                        pbFigurkaZelenaTri.Location = new Point(C2Z32Z22M12.Location.X + 12, C2Z32Z22M12.Location.Y + 12);
                        break;
                    case 23:
                        pbFigurkaZelenaTri.Location = new Point(C3Z33Z23M13.Location.X + 12, C3Z33Z23M13.Location.Y + 12);
                        break;
                    case 24:
                        pbFigurkaZelenaTri.Location = new Point(C4Z34Z24M14.Location.X + 12, C4Z34Z24M14.Location.Y + 12);
                        break;
                    case 25:
                        pbFigurkaZelenaTri.Location = new Point(C5Z35Z25M15.Location.X + 12, C5Z35Z25M15.Location.Y + 12);
                        break;
                    case 26:
                        pbFigurkaZelenaTri.Location = new Point(C6Z36Z26M16.Location.X + 12, C6Z36Z26M16.Location.Y + 12);
                        break;
                    case 27:
                        pbFigurkaZelenaTri.Location = new Point(C7Z27M17.Location.X + 12, C7Z27M17.Location.Y + 12);
                        break;
                    case 28:
                        pbFigurkaZelenaTri.Location = new Point(C8Z28M18.Location.X + 12, C8Z28M18.Location.Y + 12);
                        break;
                    case 29:
                        pbFigurkaZelenaTri.Location = new Point(C9Z29M19.Location.X + 12, C9Z29M19.Location.Y + 12);
                        break;
                    case 30:
                        pbFigurkaZelenaTri.Location = new Point(C10Z30M20.Location.X + 12, C10Z30M20.Location.Y + 12);
                        break;
                    case 31:
                        pbFigurkaZelenaTri.Location = new Point(C11Z1Z31M21.Location.X + 12, C11Z1Z31M21.Location.Y + 12);
                        break;
                    case 32:
                        pbFigurkaZelenaTri.Location = new Point(C12Z2Z32M22.Location.X + 12, C12Z2Z32M22.Location.Y + 12);
                        break;
                    case 33:
                        pbFigurkaZelenaTri.Location = new Point(C13Z3Z33M23.Location.X + 12, C13Z3Z33M23.Location.Y + 12);
                        break;
                    case 34:
                        pbFigurkaZelenaTri.Location = new Point(C14Z4Z34M24.Location.X + 12, C14Z4Z34M24.Location.Y + 12);
                        break;
                    case 35:
                        pbFigurkaZelenaTri.Location = new Point(C15Z5Z35M25.Location.X + 12, C15Z5Z35M25.Location.Y + 12);
                        break;
                    case 36:
                        pbFigurkaZelenaTri.Location = new Point(C16Z6Z36M26.Location.X + 12, C16Z6Z36M26.Location.Y + 12);
                        break;
                    case 37:
                        pbFigurkaZelenaTri.Location = new Point(ZE37.Location.X + 12, ZE37.Location.Y + 12);
                        break;
                    case 38:
                        pbFigurkaZelenaTri.Location = new Point(ZE38.Location.X + 12, ZE38.Location.Y + 12);
                        break;
                    case 39:
                        pbFigurkaZelenaTri.Location = new Point(ZE39.Location.X + 12, ZE39.Location.Y + 12);
                        break;
                    case 40:
                        pbFigurkaZelenaTri.Location = new Point(ZE40.Location.X + 12, ZE40.Location.Y + 12);
                        break;
                    default:
                        pozice[10] -= hozeneCislo;
                        goto umisteni;
                }
            }
            pbKostka.Enabled = true;
            tah = "MO";
            pbFigurkaZelenaJedna.Enabled = false;
            pbFigurkaZelenaDva.Enabled = false;
            pbFigurkaZelenaTri.Enabled = false;
            pbFigurkaZelenaCtyri.Enabled = false;
            souradniceX[10] = pbFigurkaZelenaTri.Location.X;
            souradniceY[10] = pbFigurkaZelenaTri.Location.Y;
            for (int i = 0; i <= 7; i++)
            {
                if (souradniceX[10] == souradniceX[i] && souradniceY[10] == souradniceY[i])
                {
                    pozice[i] = 0;
                    Vyhazovani(i);
                    break;
                }
            }
            for (int i = 12; i <= 15; i++)
            {
                if (souradniceX[10] == souradniceX[i] && souradniceY[10] == souradniceY[i])
                {
                    pozice[i] = 0;
                    Vyhazovani(i);
                    break;
                }
            }
            for (int i = 8; i <= 11; i++)
            {
                for (int j = 8; j <= 11; j++)
                {
                    for (int k = 8; k <= 11; k++)
                    {
                        for (int l = 8; l <= 11; l++)
                        {
                            if (pozice[i] == 37 && pozice[j] == 38 && pozice[k] == 39 && pozice[l] == 40)
                            {
                                MessageBox.Show("Vyhrává" + lbHracTri);
                                zpetDoMenu.Show();
                                Hide();
                            }
                        }
                    }
                }
            }
        }

        private void pbFigurkaZelenaCtyri_Click(object sender, EventArgs e)
        {
            if (pozice[11] == 0 && hozeneCislo == 6)
            {
                hozeneCislo = 0;
                pozice[11] = 1;
            }
            if (pozice[11] != 0)
            {
                pozice[11] += hozeneCislo;
                if (pozice[11] == pozice[9] || pozice[11] == pozice[10] || pozice[11] == pozice[8])
                {
                    if (pozice[11] == 1)
                    {
                        pozice[11] = 0;
                    }
                    pozice[11] -= hozeneCislo;
                }
            umisteni:
                switch (pozice[11])
                {
                    case 1:
                        pbFigurkaZelenaCtyri.Location = new Point(C21Z11Z1M31.Location.X + 12, C21Z11Z1M31.Location.Y + 12);
                        break;
                    case 2:
                        pbFigurkaZelenaCtyri.Location = new Point(C22Z12Z2M32.Location.X + 12, C22Z12Z2M32.Location.Y + 12);
                        break;
                    case 3:
                        pbFigurkaZelenaCtyri.Location = new Point(C23Z13Z3M33.Location.X + 12, C23Z13Z3M33.Location.Y + 12);
                        break;
                    case 4:
                        pbFigurkaZelenaCtyri.Location = new Point(C24Z14Z4M34.Location.X + 12, C24Z14Z4M34.Location.Y + 12);
                        break;
                    case 5:
                        pbFigurkaZelenaCtyri.Location = new Point(C25Z15Z5M35.Location.X + 12, C25Z15Z5M35.Location.Y + 12);
                        break;
                    case 6:
                        pbFigurkaZelenaCtyri.Location = new Point(C26Z16Z6M36.Location.X + 12, C26Z16Z6M36.Location.Y + 12);
                        break;
                    case 7:
                        pbFigurkaZelenaCtyri.Location = new Point(C27Z17Z7.Location.X + 12, C27Z17Z7.Location.Y + 12);
                        break;
                    case 8:
                        pbFigurkaZelenaCtyri.Location = new Point(C28Z18Z8.Location.X + 12, C28Z18Z8.Location.Y + 12);
                        break;
                    case 9:
                        pbFigurkaZelenaCtyri.Location = new Point(C29Z19Z9.Location.X + 12, C29Z19Z9.Location.Y + 12);
                        break;
                    case 10:
                        pbFigurkaZelenaCtyri.Location = new Point(C30Z20Z10.Location.X + 12, C30Z20Z10.Location.Y + 12);
                        break;
                    case 11:
                        pbFigurkaZelenaCtyri.Location = new Point(C31Z21Z11M1.Location.X + 12, C31Z21Z11M1.Location.Y + 12);
                        break;
                    case 12:
                        pbFigurkaZelenaCtyri.Location = new Point(C32Z22Z12M2.Location.X + 12, C32Z22Z12M2.Location.Y + 12);
                        break;
                    case 13:
                        pbFigurkaZelenaCtyri.Location = new Point(C33Z23Z13M3.Location.X + 12, C33Z23Z13M3.Location.Y + 12);
                        break;
                    case 14:
                        pbFigurkaZelenaCtyri.Location = new Point(C34Z24Z14M4.Location.X + 12, C34Z24Z14M4.Location.Y + 12);
                        break;
                    case 15:
                        pbFigurkaZelenaCtyri.Location = new Point(C35Z25Z15M5.Location.X + 12, C35Z25Z15M5.Location.Y + 12);
                        break;
                    case 16:
                        pbFigurkaZelenaCtyri.Location = new Point(C36Z26Z16M6.Location.X + 12, C36Z26Z16M6.Location.Y + 12);
                        break;
                    case 17:
                        pbFigurkaZelenaCtyri.Location = new Point(Z27Z17M7.Location.X + 12, Z27Z17M7.Location.Y + 12);
                        break;
                    case 18:
                        pbFigurkaZelenaCtyri.Location = new Point(Z28Z18M8.Location.X + 12, Z28Z18M8.Location.Y + 12);
                        break;
                    case 19:
                        pbFigurkaZelenaCtyri.Location = new Point(Z29Z19M9.Location.X + 12, Z29Z19M9.Location.Y + 12);
                        break;
                    case 20:
                        pbFigurkaZelenaCtyri.Location = new Point(Z30Z20M10.Location.X + 12, Z30Z20M10.Location.Y + 12);
                        break;
                    case 21:
                        pbFigurkaZelenaCtyri.Location = new Point(C1Z31Z21M11.Location.X + 12, C1Z31Z21M11.Location.Y + 12);
                        break;
                    case 22:
                        pbFigurkaZelenaCtyri.Location = new Point(C2Z32Z22M12.Location.X + 12, C2Z32Z22M12.Location.Y + 12);
                        break;
                    case 23:
                        pbFigurkaZelenaCtyri.Location = new Point(C3Z33Z23M13.Location.X + 12, C3Z33Z23M13.Location.Y + 12);
                        break;
                    case 24:
                        pbFigurkaZelenaCtyri.Location = new Point(C4Z34Z24M14.Location.X + 12, C4Z34Z24M14.Location.Y + 12);
                        break;
                    case 25:
                        pbFigurkaZelenaCtyri.Location = new Point(C5Z35Z25M15.Location.X + 12, C5Z35Z25M15.Location.Y + 12);
                        break;
                    case 26:
                        pbFigurkaZelenaCtyri.Location = new Point(C6Z36Z26M16.Location.X + 12, C6Z36Z26M16.Location.Y + 12);
                        break;
                    case 27:
                        pbFigurkaZelenaCtyri.Location = new Point(C7Z27M17.Location.X + 12, C7Z27M17.Location.Y + 12);
                        break;
                    case 28:
                        pbFigurkaZelenaCtyri.Location = new Point(C8Z28M18.Location.X + 12, C8Z28M18.Location.Y + 12);
                        break;
                    case 29:
                        pbFigurkaZelenaCtyri.Location = new Point(C9Z29M19.Location.X + 12, C9Z29M19.Location.Y + 12);
                        break;
                    case 30:
                        pbFigurkaZelenaCtyri.Location = new Point(C10Z30M20.Location.X + 12, C10Z30M20.Location.Y + 12);
                        break;
                    case 31:
                        pbFigurkaZelenaCtyri.Location = new Point(C11Z1Z31M21.Location.X + 12, C11Z1Z31M21.Location.Y + 12);
                        break;
                    case 32:
                        pbFigurkaZelenaCtyri.Location = new Point(C12Z2Z32M22.Location.X + 12, C12Z2Z32M22.Location.Y + 12);
                        break;
                    case 33:
                        pbFigurkaZelenaCtyri.Location = new Point(C13Z3Z33M23.Location.X + 12, C13Z3Z33M23.Location.Y + 12);
                        break;
                    case 34:
                        pbFigurkaZelenaCtyri.Location = new Point(C14Z4Z34M24.Location.X + 12, C14Z4Z34M24.Location.Y + 12);
                        break;
                    case 35:
                        pbFigurkaZelenaCtyri.Location = new Point(C15Z5Z35M25.Location.X + 12, C15Z5Z35M25.Location.Y + 12);
                        break;
                    case 36:
                        pbFigurkaZelenaCtyri.Location = new Point(C16Z6Z36M26.Location.X + 12, C16Z6Z36M26.Location.Y + 12);
                        break;
                    case 37:
                        pbFigurkaZelenaCtyri.Location = new Point(ZE37.Location.X + 12, ZE37.Location.Y + 12);
                        break;
                    case 38:
                        pbFigurkaZelenaCtyri.Location = new Point(ZE38.Location.X + 12, ZE38.Location.Y + 12);
                        break;
                    case 39:
                        pbFigurkaZelenaCtyri.Location = new Point(ZE39.Location.X + 12, ZE39.Location.Y + 12);
                        break;
                    case 40:
                        pbFigurkaZelenaCtyri.Location = new Point(ZE40.Location.X + 12, ZE40.Location.Y + 12);
                        break;
                    default:
                        pozice[11] -= hozeneCislo;
                        goto umisteni;
                }
            }
            pbKostka.Enabled = true;
            tah = "MO";
            pbFigurkaZelenaJedna.Enabled = false;
            pbFigurkaZelenaDva.Enabled = false;
            pbFigurkaZelenaTri.Enabled = false;
            pbFigurkaZelenaCtyri.Enabled = false;
            souradniceX[11] = pbFigurkaZelenaCtyri.Location.X;
            souradniceY[11] = pbFigurkaZelenaCtyri.Location.Y;
            for (int i = 0; i <= 7; i++)
            {
                if (souradniceX[11] == souradniceX[i] && souradniceY[11] == souradniceY[i])
                {
                    pozice[i] = 0;
                    Vyhazovani(i);
                    break;
                }
            }
            for(int i = 12; i <= 15; i++)
            {
                if (souradniceX[11] == souradniceX[i] && souradniceY[11] == souradniceY[i])
                {
                    pozice[i] = 0;
                    Vyhazovani(i);
                    break;
                }
            }
            for (int i = 8; i <= 11; i++)
            {
                for (int j = 8; j <= 11; j++)
                {
                    for (int k = 8; k <= 11; k++)
                    {
                        for (int l = 8; l <= 11; l++)
                        {
                            if (pozice[i] == 37 && pozice[j] == 38 && pozice[k] == 39 && pozice[l] == 40)
                            {
                                MessageBox.Show("Vyhrává" + lbHracTri);
                                zpetDoMenu.Show();
                                Hide();
                            }
                        }
                    }
                }
            }
        }

        private void pbFigurkaModraJedna_Click(object sender, EventArgs e)
        {
            if (pozice[12] == 0 && hozeneCislo == 6)
            {
                hozeneCislo = 0;
                pozice[12] = 1;
            }
            if (pozice[12] != 0)
            {
                pozice[12] += hozeneCislo;
                if (pozice[12] == pozice[13] || pozice[12] == pozice[14] || pozice[12] == pozice[15])
                {
                    if (pozice[12] == 1)
                    {
                        pozice[12] = 0;
                    }
                    pozice[12] -= hozeneCislo;
                }
            umisteni:
                switch (pozice[12])
                {
                    case 1:
                        pbFigurkaModraJedna.Location = new Point(C31Z21Z11M1.Location.X + 12, C31Z21Z11M1.Location.Y + 12);
                        break;
                    case 2:
                        pbFigurkaModraJedna.Location = new Point(C32Z22Z12M2.Location.X + 12, C32Z22Z12M2.Location.Y + 12);
                        break;
                    case 3:
                        pbFigurkaModraJedna.Location = new Point(C33Z23Z13M3.Location.X + 12, C33Z23Z13M3.Location.Y + 12);
                        break;
                    case 4:
                        pbFigurkaModraJedna.Location = new Point(C34Z24Z14M4.Location.X + 12, C34Z24Z14M4.Location.Y + 12);
                        break;
                    case 5:
                        pbFigurkaModraJedna.Location = new Point(C35Z25Z15M5.Location.X + 12, C35Z25Z15M5.Location.Y + 12);
                        break;
                    case 6:
                        pbFigurkaModraJedna.Location = new Point(C36Z26Z16M6.Location.X + 12, C36Z26Z16M6.Location.Y + 12);
                        break;
                    case 7:
                        pbFigurkaModraJedna.Location = new Point(Z27Z17M7.Location.X + 12, Z27Z17M7.Location.Y + 12);
                        break;
                    case 8:
                        pbFigurkaModraJedna.Location = new Point(Z28Z18M8.Location.X + 12, Z28Z18M8.Location.Y + 12);
                        break;
                    case 9:
                        pbFigurkaModraJedna.Location = new Point(Z29Z19M9.Location.X + 12, Z29Z19M9.Location.Y + 12);
                        break;
                    case 10:
                        pbFigurkaModraJedna.Location = new Point(Z30Z20M10.Location.X + 12, Z30Z20M10.Location.Y + 12);
                        break;
                    case 11:
                        pbFigurkaModraJedna.Location = new Point(C1Z31Z21M11.Location.X + 12, C1Z31Z21M11.Location.Y + 12);
                        break;
                    case 12:
                        pbFigurkaModraJedna.Location = new Point(C2Z32Z22M12.Location.X + 12, C2Z32Z22M12.Location.Y + 12);
                        break;
                    case 13:
                        pbFigurkaModraJedna.Location = new Point(C3Z33Z23M13.Location.X + 12, C3Z33Z23M13.Location.Y + 12);
                        break;
                    case 14:
                        pbFigurkaModraJedna.Location = new Point(C4Z34Z24M14.Location.X + 12, C4Z34Z24M14.Location.Y + 12);
                        break;
                    case 15:
                        pbFigurkaModraJedna.Location = new Point(C5Z35Z25M15.Location.X + 12, C5Z35Z25M15.Location.Y + 12);
                        break;
                    case 16:
                        pbFigurkaModraJedna.Location = new Point(C6Z36Z26M16.Location.X + 12, C6Z36Z26M16.Location.Y + 12);
                        break;
                    case 17:
                        pbFigurkaModraJedna.Location = new Point(C7Z27M17.Location.X + 12, C7Z27M17.Location.Y + 12);
                        break;
                    case 18:
                        pbFigurkaModraJedna.Location = new Point(C8Z28M18.Location.X + 12, C8Z28M18.Location.Y + 12);
                        break;
                    case 19:
                        pbFigurkaModraJedna.Location = new Point(C9Z29M19.Location.X + 12, C9Z29M19.Location.Y + 12);
                        break;
                    case 20:
                        pbFigurkaModraJedna.Location = new Point(C10Z30M20.Location.X + 12, C10Z30M20.Location.Y + 12);
                        break;
                    case 21:
                        pbFigurkaModraJedna.Location = new Point(C11Z1Z31M21.Location.X + 12, C11Z1Z31M21.Location.Y + 12);
                        break;
                    case 22:
                        pbFigurkaModraJedna.Location = new Point(C12Z2Z32M22.Location.X + 12, C12Z2Z32M22.Location.Y + 12);
                        break;
                    case 23:
                        pbFigurkaModraJedna.Location = new Point(C13Z3Z33M23.Location.X + 12, C13Z3Z33M23.Location.Y + 12);
                        break;
                    case 24:
                        pbFigurkaModraJedna.Location = new Point(C14Z4Z34M24.Location.X + 12, C14Z4Z34M24.Location.Y + 12);
                        break;
                    case 25:
                        pbFigurkaModraJedna.Location = new Point(C15Z5Z35M25.Location.X + 12, C15Z5Z35M25.Location.Y + 12);
                        break;
                    case 26:
                        pbFigurkaModraJedna.Location = new Point(C16Z6Z36M26.Location.X + 12, C16Z6Z36M26.Location.Y + 12);
                        break;
                    case 27:
                        pbFigurkaModraJedna.Location = new Point(C17Z7M27.Location.X + 12, C17Z7M27.Location.Y + 12);
                        break;
                    case 28:
                        pbFigurkaModraJedna.Location = new Point(C18Z8M28.Location.X + 12, C18Z8M28.Location.Y + 12);
                        break;
                    case 29:
                        pbFigurkaModraJedna.Location = new Point(C19Z9M29.Location.X + 12, C19Z9M29.Location.Y + 12);
                        break;
                    case 30:
                        pbFigurkaModraJedna.Location = new Point(C20Z10M30.Location.X + 12, C20Z10M30.Location.Y + 12);
                        break;
                    case 31:
                        pbFigurkaModraJedna.Location = new Point(C21Z11Z1M31.Location.X + 12, C21Z11Z1M31.Location.Y + 12);
                        break;
                    case 32:
                        pbFigurkaModraJedna.Location = new Point(C22Z12Z2M32.Location.X + 12, C22Z12Z2M32.Location.Y + 12);
                        break;
                    case 33:
                        pbFigurkaModraJedna.Location = new Point(C23Z13Z3M33.Location.X + 12, C23Z13Z3M33.Location.Y + 12);
                        break;
                    case 34:
                        pbFigurkaModraJedna.Location = new Point(C24Z14Z4M34.Location.X + 12, C24Z14Z4M34.Location.Y + 12);
                        break;
                    case 35:
                        pbFigurkaModraJedna.Location = new Point(C25Z15Z5M35.Location.X + 12, C25Z15Z5M35.Location.Y + 12);
                        break;
                    case 36:
                        pbFigurkaModraJedna.Location = new Point(C26Z16Z6M36.Location.X + 12, C26Z16Z6M36.Location.Y + 12);
                        break;
                    case 37:
                        pbFigurkaModraJedna.Location = new Point(M37.Location.X + 12, M37.Location.Y + 12);
                        break;
                    case 38:
                        pbFigurkaModraJedna.Location = new Point(M38.Location.X + 12, M38.Location.Y + 12);
                        break;
                    case 39:
                        pbFigurkaModraJedna.Location = new Point(M39.Location.X + 12, M39.Location.Y + 12);
                        break;
                    case 40:
                        pbFigurkaModraJedna.Location = new Point(M40.Location.X + 12, M40.Location.Y + 12);
                        break;
                    default:
                        pozice[12] -= hozeneCislo;
                        goto umisteni;
                }
            }
            pbKostka.Enabled = true;
            tah = "CE";
            pbFigurkaModraJedna.Enabled = false;
            pbFigurkaModraDva.Enabled = false;
            pbFigurkaModraTri.Enabled = false;
            pbFigurkaModraCtyri.Enabled = false;
            souradniceX[12] = pbFigurkaModraJedna.Location.X;
            souradniceY[12] = pbFigurkaModraJedna.Location.Y;
            for (int i = 0; i <= 11; i++)
            {
                if (souradniceX[12] == souradniceX[i] && souradniceY[12] == souradniceY[i])
                {
                    pozice[i] = 0;
                    Vyhazovani(i);
                    break;
                }
            }
            for (int i = 12; i <= 15; i++)
            {
                for (int j = 12; j <= 15; j++)
                {
                    for (int k = 12; k <= 15; k++)
                    {
                        for (int l = 12; l <= 15; l++)
                        {
                            if (pozice[i] == 37 && pozice[j] == 38 && pozice[k] == 39 && pozice[l] == 40)
                            {
                                MessageBox.Show("Vyhrává" + lbHracCtyri);
                                zpetDoMenu.Show();
                                Hide();
                            }
                        }
                    }
                }
            }
        }

        private void pbFigurkaModraDva_Click(object sender, EventArgs e)
        {
            if (pozice[13] == 0 && hozeneCislo == 6)
            {
                hozeneCislo = 0;
                pozice[13] = 1;
            }
            if (pozice[13] != 0)
            {
                pozice[13] += hozeneCislo;
                if (pozice[13] == pozice[12] || pozice[13] == pozice[14] || pozice[13] == pozice[15])
                {
                    if (pozice[13] == 1)
                    {
                        pozice[13] = 0;
                    }
                    pozice[13] -= hozeneCislo;
                }
            umisteni:
                switch (pozice[13])
                {
                    case 1:
                        pbFigurkaModraDva.Location = new Point(C31Z21Z11M1.Location.X + 12, C31Z21Z11M1.Location.Y + 12);
                        break;
                    case 2:
                        pbFigurkaModraDva.Location = new Point(C32Z22Z12M2.Location.X + 12, C32Z22Z12M2.Location.Y + 12);
                        break;
                    case 3:
                        pbFigurkaModraDva.Location = new Point(C33Z23Z13M3.Location.X + 12, C33Z23Z13M3.Location.Y + 12);
                        break;
                    case 4:
                        pbFigurkaModraDva.Location = new Point(C34Z24Z14M4.Location.X + 12, C34Z24Z14M4.Location.Y + 12);
                        break;
                    case 5:
                        pbFigurkaModraDva.Location = new Point(C35Z25Z15M5.Location.X + 12, C35Z25Z15M5.Location.Y + 12);
                        break;
                    case 6:
                        pbFigurkaModraDva.Location = new Point(C36Z26Z16M6.Location.X + 12, C36Z26Z16M6.Location.Y + 12);
                        break;
                    case 7:
                        pbFigurkaModraDva.Location = new Point(Z27Z17M7.Location.X + 12, Z27Z17M7.Location.Y + 12);
                        break;
                    case 8:
                        pbFigurkaModraDva.Location = new Point(Z28Z18M8.Location.X + 12, Z28Z18M8.Location.Y + 12);
                        break;
                    case 9:
                        pbFigurkaModraDva.Location = new Point(Z29Z19M9.Location.X + 12, Z29Z19M9.Location.Y + 12);
                        break;
                    case 10:
                        pbFigurkaModraDva.Location = new Point(Z30Z20M10.Location.X + 12, Z30Z20M10.Location.Y + 12);
                        break;
                    case 11:
                        pbFigurkaModraDva.Location = new Point(C1Z31Z21M11.Location.X + 12, C1Z31Z21M11.Location.Y + 12);
                        break;
                    case 12:
                        pbFigurkaModraDva.Location = new Point(C2Z32Z22M12.Location.X + 12, C2Z32Z22M12.Location.Y + 12);
                        break;
                    case 13:
                        pbFigurkaModraDva.Location = new Point(C3Z33Z23M13.Location.X + 12, C3Z33Z23M13.Location.Y + 12);
                        break;
                    case 14:
                        pbFigurkaModraDva.Location = new Point(C4Z34Z24M14.Location.X + 12, C4Z34Z24M14.Location.Y + 12);
                        break;
                    case 15:
                        pbFigurkaModraDva.Location = new Point(C5Z35Z25M15.Location.X + 12, C5Z35Z25M15.Location.Y + 12);
                        break;
                    case 16:
                        pbFigurkaModraDva.Location = new Point(C6Z36Z26M16.Location.X + 12, C6Z36Z26M16.Location.Y + 12);
                        break;
                    case 17:
                        pbFigurkaModraDva.Location = new Point(C7Z27M17.Location.X + 12, C7Z27M17.Location.Y + 12);
                        break;
                    case 18:
                        pbFigurkaModraDva.Location = new Point(C8Z28M18.Location.X + 12, C8Z28M18.Location.Y + 12);
                        break;
                    case 19:
                        pbFigurkaModraDva.Location = new Point(C9Z29M19.Location.X + 12, C9Z29M19.Location.Y + 12);
                        break;
                    case 20:
                        pbFigurkaModraDva.Location = new Point(C10Z30M20.Location.X + 12, C10Z30M20.Location.Y + 12);
                        break;
                    case 21:
                        pbFigurkaModraDva.Location = new Point(C11Z1Z31M21.Location.X + 12, C11Z1Z31M21.Location.Y + 12);
                        break;
                    case 22:
                        pbFigurkaModraDva.Location = new Point(C12Z2Z32M22.Location.X + 12, C12Z2Z32M22.Location.Y + 12);
                        break;
                    case 23:
                        pbFigurkaModraDva.Location = new Point(C13Z3Z33M23.Location.X + 12, C13Z3Z33M23.Location.Y + 12);
                        break;
                    case 24:
                        pbFigurkaModraDva.Location = new Point(C14Z4Z34M24.Location.X + 12, C14Z4Z34M24.Location.Y + 12);
                        break;
                    case 25:
                        pbFigurkaModraDva.Location = new Point(C15Z5Z35M25.Location.X + 12, C15Z5Z35M25.Location.Y + 12);
                        break;
                    case 26:
                        pbFigurkaModraDva.Location = new Point(C16Z6Z36M26.Location.X + 12, C16Z6Z36M26.Location.Y + 12);
                        break;
                    case 27:
                        pbFigurkaModraDva.Location = new Point(C17Z7M27.Location.X + 12, C17Z7M27.Location.Y + 12);
                        break;
                    case 28:
                        pbFigurkaModraDva.Location = new Point(C18Z8M28.Location.X + 12, C18Z8M28.Location.Y + 12);
                        break;
                    case 29:
                        pbFigurkaModraDva.Location = new Point(C19Z9M29.Location.X + 12, C19Z9M29.Location.Y + 12);
                        break;
                    case 30:
                        pbFigurkaModraDva.Location = new Point(C20Z10M30.Location.X + 12, C20Z10M30.Location.Y + 12);
                        break;
                    case 31:
                        pbFigurkaModraDva.Location = new Point(C21Z11Z1M31.Location.X + 12, C21Z11Z1M31.Location.Y + 12);
                        break;
                    case 32:
                        pbFigurkaModraDva.Location = new Point(C22Z12Z2M32.Location.X + 12, C22Z12Z2M32.Location.Y + 12);
                        break;
                    case 33:
                        pbFigurkaModraDva.Location = new Point(C23Z13Z3M33.Location.X + 12, C23Z13Z3M33.Location.Y + 12);
                        break;
                    case 34:
                        pbFigurkaModraDva.Location = new Point(C24Z14Z4M34.Location.X + 12, C24Z14Z4M34.Location.Y + 12);
                        break;
                    case 35:
                        pbFigurkaModraDva.Location = new Point(C25Z15Z5M35.Location.X + 12, C25Z15Z5M35.Location.Y + 12);
                        break;
                    case 36:
                        pbFigurkaModraDva.Location = new Point(C26Z16Z6M36.Location.X + 12, C26Z16Z6M36.Location.Y + 12);
                        break;
                    case 37:
                        pbFigurkaModraDva.Location = new Point(M37.Location.X + 12, M37.Location.Y + 12);
                        break;
                    case 38:
                        pbFigurkaModraDva.Location = new Point(M38.Location.X + 12, M38.Location.Y + 12);
                        break;
                    case 39:
                        pbFigurkaModraDva.Location = new Point(M39.Location.X + 12, M39.Location.Y + 12);
                        break;
                    case 40:
                        pbFigurkaModraDva.Location = new Point(M40.Location.X + 12, M40.Location.Y + 12);
                        break;
                    default:
                        pozice[13] -= hozeneCislo;
                        goto umisteni;
                }
            }
            pbKostka.Enabled = true;
            tah = "CE";
            pbFigurkaModraJedna.Enabled = false;
            pbFigurkaModraDva.Enabled = false;
            pbFigurkaModraTri.Enabled = false;
            pbFigurkaModraCtyri.Enabled = false;
            souradniceX[13] = pbFigurkaModraDva.Location.X;
            souradniceY[13] = pbFigurkaModraDva.Location.Y;
            for (int i = 0; i <= 11; i++)
            {
                if (souradniceX[13] == souradniceX[i] && souradniceY[13] == souradniceY[i])
                {
                    pozice[i] = 0;
                    Vyhazovani(i);
                    break;
                }
            }
            for (int i = 12; i <= 15; i++)
            {
                for (int j = 12; j <= 15; j++)
                {
                    for (int k = 12; k <= 15; k++)
                    {
                        for (int l = 12; l <= 15; l++)
                        {
                            if (pozice[i] == 37 && pozice[j] == 38 && pozice[k] == 39 && pozice[l] == 40)
                            {
                                MessageBox.Show("Vyhrává" + lbHracCtyri);
                                zpetDoMenu.Show();
                                Hide();
                            }
                        }
                    }
                }
            }
        }

        private void pbFigurkaModraTri_Click(object sender, EventArgs e)
        {
            if (pozice[14] == 0 && hozeneCislo == 6)
            {
                hozeneCislo = 0;
                pozice[14] = 1;
            }
            if (pozice[14] != 0)
            {
                pozice[14] += hozeneCislo;
                if (pozice[14] == pozice[13] || pozice[14] == pozice[12] || pozice[14] == pozice[15])
                {
                    if (pozice[14] == 1)
                    {
                        pozice[14] = 0;
                    }
                    pozice[14] -= hozeneCislo;
                }
            umisteni:
                switch (pozice[14])
                {
                    case 1:
                        pbFigurkaModraTri.Location = new Point(C31Z21Z11M1.Location.X + 12, C31Z21Z11M1.Location.Y + 12);
                        break;
                    case 2:
                        pbFigurkaModraTri.Location = new Point(C32Z22Z12M2.Location.X + 12, C32Z22Z12M2.Location.Y + 12);
                        break;
                    case 3:
                        pbFigurkaModraTri.Location = new Point(C33Z23Z13M3.Location.X + 12, C33Z23Z13M3.Location.Y + 12);
                        break;
                    case 4:
                        pbFigurkaModraTri.Location = new Point(C34Z24Z14M4.Location.X + 12, C34Z24Z14M4.Location.Y + 12);
                        break;
                    case 5:
                        pbFigurkaModraTri.Location = new Point(C35Z25Z15M5.Location.X + 12, C35Z25Z15M5.Location.Y + 12);
                        break;
                    case 6:
                        pbFigurkaModraTri.Location = new Point(C36Z26Z16M6.Location.X + 12, C36Z26Z16M6.Location.Y + 12);
                        break;
                    case 7:
                        pbFigurkaModraTri.Location = new Point(Z27Z17M7.Location.X + 12, Z27Z17M7.Location.Y + 12);
                        break;
                    case 8:
                        pbFigurkaModraTri.Location = new Point(Z28Z18M8.Location.X + 12, Z28Z18M8.Location.Y + 12);
                        break;
                    case 9:
                        pbFigurkaModraTri.Location = new Point(Z29Z19M9.Location.X + 12, Z29Z19M9.Location.Y + 12);
                        break;
                    case 10:
                        pbFigurkaModraTri.Location = new Point(Z30Z20M10.Location.X + 12, Z30Z20M10.Location.Y + 12);
                        break;
                    case 11:
                        pbFigurkaModraTri.Location = new Point(C1Z31Z21M11.Location.X + 12, C1Z31Z21M11.Location.Y + 12);
                        break;
                    case 12:
                        pbFigurkaModraTri.Location = new Point(C2Z32Z22M12.Location.X + 12, C2Z32Z22M12.Location.Y + 12);
                        break;
                    case 13:
                        pbFigurkaModraTri.Location = new Point(C3Z33Z23M13.Location.X + 12, C3Z33Z23M13.Location.Y + 12);
                        break;
                    case 14:
                        pbFigurkaModraTri.Location = new Point(C4Z34Z24M14.Location.X + 12, C4Z34Z24M14.Location.Y + 12);
                        break;
                    case 15:
                        pbFigurkaModraTri.Location = new Point(C5Z35Z25M15.Location.X + 12, C5Z35Z25M15.Location.Y + 12);
                        break;
                    case 16:
                        pbFigurkaModraTri.Location = new Point(C6Z36Z26M16.Location.X + 12, C6Z36Z26M16.Location.Y + 12);
                        break;
                    case 17:
                        pbFigurkaModraTri.Location = new Point(C7Z27M17.Location.X + 12, C7Z27M17.Location.Y + 12);
                        break;
                    case 18:
                        pbFigurkaModraTri.Location = new Point(C8Z28M18.Location.X + 12, C8Z28M18.Location.Y + 12);
                        break;
                    case 19:
                        pbFigurkaModraTri.Location = new Point(C9Z29M19.Location.X + 12, C9Z29M19.Location.Y + 12);
                        break;
                    case 20:
                        pbFigurkaModraTri.Location = new Point(C10Z30M20.Location.X + 12, C10Z30M20.Location.Y + 12);
                        break;
                    case 21:
                        pbFigurkaModraTri.Location = new Point(C11Z1Z31M21.Location.X + 12, C11Z1Z31M21.Location.Y + 12);
                        break;
                    case 22:
                        pbFigurkaModraTri.Location = new Point(C12Z2Z32M22.Location.X + 12, C12Z2Z32M22.Location.Y + 12);
                        break;
                    case 23:
                        pbFigurkaModraTri.Location = new Point(C13Z3Z33M23.Location.X + 12, C13Z3Z33M23.Location.Y + 12);
                        break;
                    case 24:
                        pbFigurkaModraTri.Location = new Point(C14Z4Z34M24.Location.X + 12, C14Z4Z34M24.Location.Y + 12);
                        break;
                    case 25:
                        pbFigurkaModraTri.Location = new Point(C15Z5Z35M25.Location.X + 12, C15Z5Z35M25.Location.Y + 12);
                        break;
                    case 26:
                        pbFigurkaModraTri.Location = new Point(C16Z6Z36M26.Location.X + 12, C16Z6Z36M26.Location.Y + 12);
                        break;
                    case 27:
                        pbFigurkaModraTri.Location = new Point(C17Z7M27.Location.X + 12, C17Z7M27.Location.Y + 12);
                        break;
                    case 28:
                        pbFigurkaModraTri.Location = new Point(C18Z8M28.Location.X + 12, C18Z8M28.Location.Y + 12);
                        break;
                    case 29:
                        pbFigurkaModraTri.Location = new Point(C19Z9M29.Location.X + 12, C19Z9M29.Location.Y + 12);
                        break;
                    case 30:
                        pbFigurkaModraTri.Location = new Point(C20Z10M30.Location.X + 12, C20Z10M30.Location.Y + 12);
                        break;
                    case 31:
                        pbFigurkaModraTri.Location = new Point(C21Z11Z1M31.Location.X + 12, C21Z11Z1M31.Location.Y + 12);
                        break;
                    case 32:
                        pbFigurkaModraTri.Location = new Point(C22Z12Z2M32.Location.X + 12, C22Z12Z2M32.Location.Y + 12);
                        break;
                    case 33:
                        pbFigurkaModraTri.Location = new Point(C23Z13Z3M33.Location.X + 12, C23Z13Z3M33.Location.Y + 12);
                        break;
                    case 34:
                        pbFigurkaModraTri.Location = new Point(C24Z14Z4M34.Location.X + 12, C24Z14Z4M34.Location.Y + 12);
                        break;
                    case 35:
                        pbFigurkaModraTri.Location = new Point(C25Z15Z5M35.Location.X + 12, C25Z15Z5M35.Location.Y + 12);
                        break;
                    case 36:
                        pbFigurkaModraTri.Location = new Point(C26Z16Z6M36.Location.X + 12, C26Z16Z6M36.Location.Y + 12);
                        break;
                    case 37:
                        pbFigurkaModraTri.Location = new Point(M37.Location.X + 12, M37.Location.Y + 12);
                        break;
                    case 38:
                        pbFigurkaModraTri.Location = new Point(M38.Location.X + 12, M38.Location.Y + 12);
                        break;
                    case 39:
                        pbFigurkaModraTri.Location = new Point(M39.Location.X + 12, M39.Location.Y + 12);
                        break;
                    case 40:
                        pbFigurkaModraTri.Location = new Point(M40.Location.X + 12, M40.Location.Y + 12);
                        break;
                    default:
                        pozice[14] -= hozeneCislo;
                        goto umisteni;
                }
            }
            pbKostka.Enabled = true;
            tah = "CE";
            pbFigurkaModraJedna.Enabled = false;
            pbFigurkaModraDva.Enabled = false;
            pbFigurkaModraTri.Enabled = false;
            pbFigurkaModraCtyri.Enabled = false;
            souradniceX[14] = pbFigurkaModraTri.Location.X;
            souradniceY[14] = pbFigurkaModraTri.Location.Y;
            for (int i = 0; i <= 11; i++)
            {
                if (souradniceX[14] == souradniceX[i] && souradniceY[14] == souradniceY[i])
                {
                    pozice[i] = 0;
                    Vyhazovani(i);
                    break;
                }
            }
            for (int i = 12; i <= 15; i++)
            {
                for (int j = 12; j <= 15; j++)
                {
                    for (int k = 12; k <= 15; k++)
                    {
                        for (int l = 12; l <= 15; l++)
                        {
                            if (pozice[i] == 37 && pozice[j] == 38 && pozice[k] == 39 && pozice[l] == 40)
                            {
                                MessageBox.Show("Vyhrává" + lbHracCtyri);
                                zpetDoMenu.Show();
                                Hide();
                            }
                        }
                    }
                }
            }
        } 

        private void pbFigurkaModraCtyri_Click(object sender, EventArgs e)
        {
            if (pozice[15] == 0 && hozeneCislo == 6)
            {
                hozeneCislo = 0;
                pozice[15] = 1;
            }
            if (pozice[15] != 0)
            {
                pozice[15] += hozeneCislo;
                if (pozice[15] == pozice[13] || pozice[15] == pozice[14] || pozice[15] == pozice[12])
                {
                    if (pozice[15] == 1)
                    {
                        pozice[15] = 0;
                    }
                    pozice[15] -= hozeneCislo;
                }
            umisteni:
                switch (pozice[15])
                {
                    case 1:
                        pbFigurkaModraCtyri.Location = new Point(C31Z21Z11M1.Location.X + 12, C31Z21Z11M1.Location.Y + 12);
                        break;
                    case 2:
                        pbFigurkaModraCtyri.Location = new Point(C32Z22Z12M2.Location.X + 12, C32Z22Z12M2.Location.Y + 12);
                        break;
                    case 3:
                        pbFigurkaModraCtyri.Location = new Point(C33Z23Z13M3.Location.X + 12, C33Z23Z13M3.Location.Y + 12);
                        break;
                    case 4:
                        pbFigurkaModraCtyri.Location = new Point(C34Z24Z14M4.Location.X + 12, C34Z24Z14M4.Location.Y + 12);
                        break;
                    case 5:
                        pbFigurkaModraCtyri.Location = new Point(C35Z25Z15M5.Location.X + 12, C35Z25Z15M5.Location.Y + 12);
                        break;
                    case 6:
                        pbFigurkaModraCtyri.Location = new Point(C36Z26Z16M6.Location.X + 12, C36Z26Z16M6.Location.Y + 12);
                        break;
                    case 7:
                        pbFigurkaModraCtyri.Location = new Point(Z27Z17M7.Location.X + 12, Z27Z17M7.Location.Y + 12);
                        break;
                    case 8:
                        pbFigurkaModraCtyri.Location = new Point(Z28Z18M8.Location.X + 12, Z28Z18M8.Location.Y + 12);
                        break;
                    case 9:
                        pbFigurkaModraCtyri.Location = new Point(Z29Z19M9.Location.X + 12, Z29Z19M9.Location.Y + 12);
                        break;
                    case 10:
                        pbFigurkaModraCtyri.Location = new Point(Z30Z20M10.Location.X + 12, Z30Z20M10.Location.Y + 12);
                        break;
                    case 11:
                        pbFigurkaModraCtyri.Location = new Point(C1Z31Z21M11.Location.X + 12, C1Z31Z21M11.Location.Y + 12);
                        break;
                    case 12:
                        pbFigurkaModraCtyri.Location = new Point(C2Z32Z22M12.Location.X + 12, C2Z32Z22M12.Location.Y + 12);
                        break;
                    case 13:
                        pbFigurkaModraCtyri.Location = new Point(C3Z33Z23M13.Location.X + 12, C3Z33Z23M13.Location.Y + 12);
                        break;
                    case 14:
                        pbFigurkaModraCtyri.Location = new Point(C4Z34Z24M14.Location.X + 12, C4Z34Z24M14.Location.Y + 12);
                        break;
                    case 15:
                        pbFigurkaModraCtyri.Location = new Point(C5Z35Z25M15.Location.X + 12, C5Z35Z25M15.Location.Y + 12);
                        break;
                    case 16:
                        pbFigurkaModraCtyri.Location = new Point(C6Z36Z26M16.Location.X + 12, C6Z36Z26M16.Location.Y + 12);
                        break;
                    case 17:
                        pbFigurkaModraCtyri.Location = new Point(C7Z27M17.Location.X + 12, C7Z27M17.Location.Y + 12);
                        break;
                    case 18:
                        pbFigurkaModraCtyri.Location = new Point(C8Z28M18.Location.X + 12, C8Z28M18.Location.Y + 12);
                        break;
                    case 19:
                        pbFigurkaModraCtyri.Location = new Point(C9Z29M19.Location.X + 12, C9Z29M19.Location.Y + 12);
                        break;
                    case 20:
                        pbFigurkaModraCtyri.Location = new Point(C10Z30M20.Location.X + 12, C10Z30M20.Location.Y + 12);
                        break;
                    case 21:
                        pbFigurkaModraCtyri.Location = new Point(C11Z1Z31M21.Location.X + 12, C11Z1Z31M21.Location.Y + 12);
                        break;
                    case 22:
                        pbFigurkaModraCtyri.Location = new Point(C12Z2Z32M22.Location.X + 12, C12Z2Z32M22.Location.Y + 12);
                        break;
                    case 23:
                        pbFigurkaModraCtyri.Location = new Point(C13Z3Z33M23.Location.X + 12, C13Z3Z33M23.Location.Y + 12);
                        break;
                    case 24:
                        pbFigurkaModraCtyri.Location = new Point(C14Z4Z34M24.Location.X + 12, C14Z4Z34M24.Location.Y + 12);
                        break;
                    case 25:
                        pbFigurkaModraCtyri.Location = new Point(C15Z5Z35M25.Location.X + 12, C15Z5Z35M25.Location.Y + 12);
                        break;
                    case 26:
                        pbFigurkaModraCtyri.Location = new Point(C16Z6Z36M26.Location.X + 12, C16Z6Z36M26.Location.Y + 12);
                        break;
                    case 27:
                        pbFigurkaModraCtyri.Location = new Point(C17Z7M27.Location.X + 12, C17Z7M27.Location.Y + 12);
                        break;
                    case 28:
                        pbFigurkaModraCtyri.Location = new Point(C18Z8M28.Location.X + 12, C18Z8M28.Location.Y + 12);
                        break;
                    case 29:
                        pbFigurkaModraCtyri.Location = new Point(C19Z9M29.Location.X + 12, C19Z9M29.Location.Y + 12);
                        break;
                    case 30:
                        pbFigurkaModraCtyri.Location = new Point(C20Z10M30.Location.X + 12, C20Z10M30.Location.Y + 12);
                        break;
                    case 31:
                        pbFigurkaModraCtyri.Location = new Point(C21Z11Z1M31.Location.X + 12, C21Z11Z1M31.Location.Y + 12);
                        break;
                    case 32:
                        pbFigurkaModraCtyri.Location = new Point(C22Z12Z2M32.Location.X + 12, C22Z12Z2M32.Location.Y + 12);
                        break;
                    case 33:
                        pbFigurkaModraCtyri.Location = new Point(C23Z13Z3M33.Location.X + 12, C23Z13Z3M33.Location.Y + 12);
                        break;
                    case 34:
                        pbFigurkaModraCtyri.Location = new Point(C24Z14Z4M34.Location.X + 12, C24Z14Z4M34.Location.Y + 12);
                        break;
                    case 35:
                        pbFigurkaModraCtyri.Location = new Point(C25Z15Z5M35.Location.X + 12, C25Z15Z5M35.Location.Y + 12);
                        break;
                    case 36:
                        pbFigurkaModraCtyri.Location = new Point(C26Z16Z6M36.Location.X + 12, C26Z16Z6M36.Location.Y + 12);
                        break;
                    case 37:
                        pbFigurkaModraCtyri.Location = new Point(M37.Location.X + 12, M37.Location.Y + 12);
                        break;
                    case 38:
                        pbFigurkaModraCtyri.Location = new Point(M38.Location.X + 12, M38.Location.Y + 12);
                        break;
                    case 39:
                        pbFigurkaModraCtyri.Location = new Point(M39.Location.X + 12, M39.Location.Y + 12);
                        break;
                    case 40:
                        pbFigurkaModraCtyri.Location = new Point(M40.Location.X + 12, M40.Location.Y + 12);
                        break;
                    default:
                        pozice[15] -= hozeneCislo;
                        goto umisteni;
                }
            }
            pbKostka.Enabled = true;
            tah = "CE";
            pbFigurkaModraJedna.Enabled = false;
            pbFigurkaModraDva.Enabled = false;
            pbFigurkaModraTri.Enabled = false;
            pbFigurkaModraCtyri.Enabled = false;
            souradniceX[15] = pbFigurkaModraCtyri.Location.X;
            souradniceY[15] = pbFigurkaModraCtyri.Location.Y;
            for (int i = 0; i <= 11; i++)
            {
                if (souradniceX[15] == souradniceX[i] && souradniceY[15] == souradniceY[i])
                {
                    pozice[i] = 0;
                    Vyhazovani(i);
                    break;
                }
            }
            for (int i = 12; i <= 15; i++)
            {
                for (int j = 12; j <= 15; j++)
                {
                    for (int k = 12; k <= 15; k++)
                    {
                        for (int l = 12; l <= 15; l++)
                        {
                            if (pozice[i] == 37 && pozice[j] == 38 && pozice[k] == 39 && pozice[l] == 40)
                            {
                                MessageBox.Show("Vyhrává" + lbHracCtyri);
                                zpetDoMenu.Show();
                                Hide();
                            }
                        }
                    }
                }
            }
        }

        private void pbKostka_Click(object sender, EventArgs e)
        {
            //zablokování kostky
            pbKostka.Enabled = false;
            //kontrola zda - li minulé číslo bylo 6, je na tahu stále stejná barva
            if (minuleCislo == 6)
            {
                tah = minulyTah;
            }
            //generování hozeného čísla
            hozeneCislo = hodKostkou.Next(1, 7);
            //kontrola zda-li nejsou stejná
            while (hozeneCislo == minuleCislo)
            {
                //pouze šestka se může opakovat (Pouze mé přizpůsobení pravidel, aby se opakovali pouze čísla 6)
                if (hozeneCislo == 6 && minuleCislo == 6)
                {
                    break;
                }
                hozeneCislo = hodKostkou.Next(1, 7);
            }
            //změna obrázku na kostce podle hozeného čísla
            switch (hozeneCislo)
            {
                case 1:
                    pbKostka.Image = Properties.Resources.KostkaJedna;
                    break;
                case 2:
                    pbKostka.Image = Properties.Resources.KostkaDva;
                    break;
                case 3:
                    pbKostka.Image = Properties.Resources.KostkaTri;
                    break;
                case 4:
                    pbKostka.Image = Properties.Resources.KostkaCtyri;
                    break;
                case 5:
                    pbKostka.Image = Properties.Resources.KostkaPet;
                    break;
                case 6:
                    pbKostka.Image = Properties.Resources.KostkaSest;
                    break;
            }
            //odblokování figurek v závislosti na pořadí
            switch (tah)
            {
                case "CE":
                    pbFigurkaCervenaCtyri.Enabled = true;
                    pbFigurkaCervenaTri.Enabled = true;
                    pbFigurkaCervenaDva.Enabled = true;
                    pbFigurkaCervenaJedna.Enabled = true;
                    lbTah.BackColor = Color.Red;
                    lbTah.ForeColor = Color.Red;
                    break;
                case "ZL":
                    pbFigurkaZlutaCtyri.Enabled = true;
                    pbFigurkaZlutaTri.Enabled = true;
                    pbFigurkaZlutaDva.Enabled = true;
                    pbFigurkaZlutaJedna.Enabled = true;
                    lbTah.BackColor = Color.Yellow;
                    lbTah.ForeColor = Color.Yellow;
                    break;
                case "ZE":
                    pbFigurkaZelenaCtyri.Enabled = true;
                    pbFigurkaZelenaTri.Enabled = true;
                    pbFigurkaZelenaDva.Enabled = true;
                    pbFigurkaZelenaJedna.Enabled = true;
                    lbTah.BackColor = Color.Green;
                    lbTah.ForeColor = Color.Green;
                    break;
                case "MO":
                    pbFigurkaModraCtyri.Enabled = true;
                    pbFigurkaModraTri.Enabled = true;
                    pbFigurkaModraDva.Enabled = true;
                    pbFigurkaModraJedna.Enabled = true;
                    lbTah.BackColor = Color.Blue;
                    lbTah.ForeColor = Color.Blue;
                    break;
            }
            //kontrola zda-li je s figurkou možno někam pohnout, když není ani jedna nasazena, pokud ne, přechází tah na dalšího v pořadí
            if (tah == "CE" && pozice[0] == 0 && pozice[1] == 0 && pozice[2] == 0 && pozice[3] == 0 && hozeneCislo != 6)
            {
                pbKostka.Enabled = true;
                tah = "ZL";
                goto konec;
            }
            if (tah == "ZL" && pozice[4] == 0 && pozice[5] == 0 && pozice[6] == 0 && pozice[7] == 0 && hozeneCislo != 6)
            {
                pbKostka.Enabled = true;
                tah = "ZE";
                goto konec;
            }
            if (tah == "ZE" && pozice[8] == 0 && pozice[9] == 0 && pozice[10] == 0 && pozice[11] == 0 && hozeneCislo != 6)
            {
                pbKostka.Enabled = true;
                tah = "MO";
                goto konec;
            }
            if (tah == "MO" && pozice[12] == 0 && pozice[13] == 0 && pozice[14] == 0 && pozice[15] == 0 && hozeneCislo != 6)
            {
                pbKostka.Enabled = true;
                tah = "CE";
                goto konec;
            }
            konec:
            //zapsání si aktuální hozené číslo a aktuální tah
            minuleCislo = hozeneCislo;
            minulyTah = tah;
        }

    }
}
