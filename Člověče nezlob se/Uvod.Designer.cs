namespace Člověče_nezlob_se
{
    partial class Uvod
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Uvod));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pbZelenaFigurka = new System.Windows.Forms.PictureBox();
            this.pbCervenaFigurka = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbZelenaFigurka)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCervenaFigurka)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pbZelenaFigurka
            // 
            this.pbZelenaFigurka.Location = new System.Drawing.Point(12, 34);
            this.pbZelenaFigurka.Name = "pbZelenaFigurka";
            this.pbZelenaFigurka.Size = new System.Drawing.Size(190, 473);
            this.pbZelenaFigurka.TabIndex = 0;
            this.pbZelenaFigurka.TabStop = false;
            // 
            // pbCervenaFigurka
            // 
            this.pbCervenaFigurka.Location = new System.Drawing.Point(851, 34);
            this.pbCervenaFigurka.Name = "pbCervenaFigurka";
            this.pbCervenaFigurka.Size = new System.Drawing.Size(190, 473);
            this.pbCervenaFigurka.TabIndex = 1;
            this.pbCervenaFigurka.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(85)))), ((int)(((byte)(147)))));
            this.ClientSize = new System.Drawing.Size(1053, 561);
            this.Controls.Add(this.pbCervenaFigurka);
            this.Controls.Add(this.pbZelenaFigurka);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Člověče nezlob se!";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.pbZelenaFigurka)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCervenaFigurka)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pbZelenaFigurka;
        private System.Windows.Forms.PictureBox pbCervenaFigurka;
    }
}

