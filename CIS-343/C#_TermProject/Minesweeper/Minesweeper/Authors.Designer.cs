namespace Minesweeper
{
    partial class Authors
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
            this.projInfo = new System.Windows.Forms.Label();
            this.authorsLabel = new System.Windows.Forms.Label();
            this.benLafeldt = new System.Windows.Forms.Label();
            this.mattiePhillips = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // projInfo
            // 
            this.projInfo.AutoSize = true;
            this.projInfo.Location = new System.Drawing.Point(57, 117);
            this.projInfo.Name = "projInfo";
            this.projInfo.Size = new System.Drawing.Size(35, 13);
            this.projInfo.TabIndex = 0;
            this.projInfo.Text = "label1";
            // 
            // authorsLabel
            // 
            this.authorsLabel.AutoSize = true;
            this.authorsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.authorsLabel.Location = new System.Drawing.Point(94, 9);
            this.authorsLabel.Name = "authorsLabel";
            this.authorsLabel.Size = new System.Drawing.Size(108, 31);
            this.authorsLabel.TabIndex = 1;
            this.authorsLabel.Text = "Authors";
            // 
            // benLafeldt
            // 
            this.benLafeldt.AutoSize = true;
            this.benLafeldt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.benLafeldt.Location = new System.Drawing.Point(100, 64);
            this.benLafeldt.Name = "benLafeldt";
            this.benLafeldt.Size = new System.Drawing.Size(84, 17);
            this.benLafeldt.TabIndex = 2;
            this.benLafeldt.Text = "Ben LaFeldt";
            // 
            // mattiePhillips
            // 
            this.mattiePhillips.AutoSize = true;
            this.mattiePhillips.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mattiePhillips.Location = new System.Drawing.Point(100, 81);
            this.mattiePhillips.Name = "mattiePhillips";
            this.mattiePhillips.Size = new System.Drawing.Size(94, 17);
            this.mattiePhillips.TabIndex = 3;
            this.mattiePhillips.Text = "Mattie Phillips";
            // 
            // Authors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 194);
            this.Controls.Add(this.mattiePhillips);
            this.Controls.Add(this.benLafeldt);
            this.Controls.Add(this.authorsLabel);
            this.Controls.Add(this.projInfo);
            this.Name = "Authors";
            this.Text = "Authors";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label projInfo;
        private System.Windows.Forms.Label authorsLabel;
        private System.Windows.Forms.Label benLafeldt;
        private System.Windows.Forms.Label mattiePhillips;
    }
}