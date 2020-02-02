namespace Torri_Hanoi
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Inizio = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.Storia = new System.Windows.Forms.Button();
            this.Istruzioni = new System.Windows.Forms.Button();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Scoreboard = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            this.SuspendLayout();
            // 
            // Inizio
            // 
            this.Inizio.AutoSize = true;
            this.Inizio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.Inizio.Location = new System.Drawing.Point(211, 434);
            this.Inizio.Name = "Inizio";
            this.Inizio.Size = new System.Drawing.Size(75, 32);
            this.Inizio.TabIndex = 3;
            this.Inizio.Text = "Inizio";
            this.Inizio.UseVisualStyleBackColor = true;
            this.Inizio.Click += new System.EventHandler(this.Inizio_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.numericUpDown1.Location = new System.Drawing.Point(75, 135);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(75, 27);
            this.numericUpDown1.TabIndex = 4;
            this.numericUpDown1.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // Storia
            // 
            this.Storia.AutoSize = true;
            this.Storia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.Storia.Location = new System.Drawing.Point(453, 233);
            this.Storia.Name = "Storia";
            this.Storia.Size = new System.Drawing.Size(75, 32);
            this.Storia.TabIndex = 5;
            this.Storia.Text = "Storia";
            this.Storia.UseVisualStyleBackColor = true;
            this.Storia.Click += new System.EventHandler(this.Storia_Click);
            // 
            // Istruzioni
            // 
            this.Istruzioni.AutoSize = true;
            this.Istruzioni.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.Istruzioni.Location = new System.Drawing.Point(50, 291);
            this.Istruzioni.Name = "Istruzioni";
            this.Istruzioni.Size = new System.Drawing.Size(110, 57);
            this.Istruzioni.TabIndex = 6;
            this.Istruzioni.Text = "Istruzioni";
            this.Istruzioni.UseVisualStyleBackColor = true;
            this.Istruzioni.Click += new System.EventHandler(this.Istruzioni_Click);
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.AutoSize = true;
            this.numericUpDown2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.numericUpDown2.Increment = new decimal(new int[] {
            150,
            0,
            0,
            0});
            this.numericUpDown2.Location = new System.Drawing.Point(188, 234);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            900,
            0,
            0,
            0});
            this.numericUpDown2.Minimum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(75, 27);
            this.numericUpDown2.TabIndex = 8;
            this.numericUpDown2.Value = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.numericUpDown2.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.AutoSize = true;
            this.numericUpDown3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.numericUpDown3.Increment = new decimal(new int[] {
            150,
            0,
            0,
            0});
            this.numericUpDown3.Location = new System.Drawing.Point(289, 363);
            this.numericUpDown3.Maximum = new decimal(new int[] {
            900,
            0,
            0,
            0});
            this.numericUpDown3.Minimum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(75, 27);
            this.numericUpDown3.TabIndex = 9;
            this.numericUpDown3.Value = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.numericUpDown3.ValueChanged += new System.EventHandler(this.numericUpDown3_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(368, 197);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Dischi";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label2.Location = new System.Drawing.Point(277, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 22);
            this.label2.TabIndex = 11;
            this.label2.Text = "Larghezza";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label3.Location = new System.Drawing.Point(360, 197);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 22);
            this.label3.TabIndex = 12;
            this.label3.Text = "Altezza";
            // 
            // Scoreboard
            // 
            this.Scoreboard.AutoSize = true;
            this.Scoreboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.Scoreboard.Location = new System.Drawing.Point(453, 101);
            this.Scoreboard.Name = "Scoreboard";
            this.Scoreboard.Size = new System.Drawing.Size(115, 32);
            this.Scoreboard.TabIndex = 13;
            this.Scoreboard.Text = "ScoreBoard";
            this.Scoreboard.UseVisualStyleBackColor = true;
            this.Scoreboard.Click += new System.EventHandler(this.Scoreboard_Click);
            // 
            // Form1
            // 
            this.AutoSize = true;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(582, 553);
            this.Controls.Add(this.Scoreboard);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown3);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.Istruzioni);
            this.Controls.Add(this.Storia);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.Inizio);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Inizio;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button Storia;
        private System.Windows.Forms.Button Istruzioni;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Scoreboard;
    }
}

