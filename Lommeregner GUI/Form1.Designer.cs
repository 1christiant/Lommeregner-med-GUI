namespace Lommeregner_GUI
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.cResult = new System.Windows.Forms.TextBox();
            this.cRegnestykke = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(16, 52);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Udregn";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cResult
            // 
            this.cResult.Location = new System.Drawing.Point(106, 54);
            this.cResult.Name = "cResult";
            this.cResult.ReadOnly = true;
            this.cResult.Size = new System.Drawing.Size(117, 20);
            this.cResult.TabIndex = 7;
            // 
            // cRegnestykke
            // 
            this.cRegnestykke.Location = new System.Drawing.Point(16, 12);
            this.cRegnestykke.Name = "cRegnestykke";
            this.cRegnestykke.Size = new System.Drawing.Size(207, 20);
            this.cRegnestykke.TabIndex = 8;
            this.cRegnestykke.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cRegnestykke_KeyDown);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(62, 81);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(123, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Udregn areal af cirkel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(243, 116);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.cRegnestykke);
            this.Controls.Add(this.cResult);
            this.Controls.Add(this.button1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Lommeregner";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox cResult;
        private System.Windows.Forms.TextBox cRegnestykke;
        private System.Windows.Forms.Button button2;
    }
}

