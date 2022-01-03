namespace Člověče_nezlob_se
{
    partial class Nastaveni
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Nastaveni));
            this.tbHracCtyri = new System.Windows.Forms.TextBox();
            this.tbHracTri = new System.Windows.Forms.TextBox();
            this.tbHracDva = new System.Windows.Forms.TextBox();
            this.tbHracJedna = new System.Windows.Forms.TextBox();
            this.btStart = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbHracCtyri
            // 
            this.tbHracCtyri.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tbHracCtyri.Location = new System.Drawing.Point(241, 328);
            this.tbHracCtyri.Name = "tbHracCtyri";
            this.tbHracCtyri.Size = new System.Drawing.Size(100, 20);
            this.tbHracCtyri.TabIndex = 13;
            this.tbHracCtyri.Text = "Hráč 4";
            this.tbHracCtyri.Click += new System.EventHandler(this.tbHracCtyri_Click);
            // 
            // tbHracTri
            // 
            this.tbHracTri.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tbHracTri.Location = new System.Drawing.Point(241, 302);
            this.tbHracTri.Name = "tbHracTri";
            this.tbHracTri.Size = new System.Drawing.Size(100, 20);
            this.tbHracTri.TabIndex = 12;
            this.tbHracTri.Text = "Hráč 3";
            this.tbHracTri.Click += new System.EventHandler(this.tbHracTri_Click);
            // 
            // tbHracDva
            // 
            this.tbHracDva.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tbHracDva.Location = new System.Drawing.Point(241, 276);
            this.tbHracDva.Name = "tbHracDva";
            this.tbHracDva.Size = new System.Drawing.Size(100, 20);
            this.tbHracDva.TabIndex = 11;
            this.tbHracDva.Text = "Hráč 2";
            this.tbHracDva.Click += new System.EventHandler(this.tbHracDva_Click);
            // 
            // tbHracJedna
            // 
            this.tbHracJedna.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.tbHracJedna.Location = new System.Drawing.Point(241, 250);
            this.tbHracJedna.Name = "tbHracJedna";
            this.tbHracJedna.Size = new System.Drawing.Size(100, 20);
            this.tbHracJedna.TabIndex = 10;
            this.tbHracJedna.Text = "Hráč 1";
            this.tbHracJedna.Click += new System.EventHandler(this.tbHracJedna_Click);
            // 
            // btStart
            // 
            this.btStart.Location = new System.Drawing.Point(223, 360);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(138, 23);
            this.btStart.TabIndex = 9;
            this.btStart.Text = "Začít hrát!";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(525, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(60, 35);
            this.panel1.TabIndex = 14;
            this.panel1.Click += new System.EventHandler(this.panel1_Click);
            this.panel1.MouseLeave += new System.EventHandler(this.panel1_MouseLeave);
            this.panel1.MouseHover += new System.EventHandler(this.panel1_MouseHover);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(20, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 20);
            this.label1.TabIndex = 15;
            this.label1.Text = "X";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            this.label1.MouseHover += new System.EventHandler(this.label1_MouseHover);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(526, 35);
            this.panel2.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Window;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(3, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Člověče, nezlob se!";
            // 
            // Nastaveni
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tbHracCtyri);
            this.Controls.Add(this.tbHracTri);
            this.Controls.Add(this.tbHracDva);
            this.Controls.Add(this.tbHracJedna);
            this.Controls.Add(this.btStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Nastaveni";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Člověče, nezlob se!";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbHracCtyri;
        private System.Windows.Forms.TextBox tbHracTri;
        private System.Windows.Forms.TextBox tbHracDva;
        private System.Windows.Forms.TextBox tbHracJedna;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
    }
}