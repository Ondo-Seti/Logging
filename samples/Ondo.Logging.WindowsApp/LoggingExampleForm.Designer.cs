namespace Ondo.Logging.WindowsApp
{
    partial class LoggingExampleForm
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
            this.btnLogError = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLogError
            // 
            this.btnLogError.Location = new System.Drawing.Point(38, 35);
            this.btnLogError.Name = "btnLogError";
            this.btnLogError.Size = new System.Drawing.Size(75, 23);
            this.btnLogError.TabIndex = 1;
            this.btnLogError.Text = "Log Error";
            this.btnLogError.UseVisualStyleBackColor = true;
            this.btnLogError.Click += new System.EventHandler(this.btnLogError_Click);
            // 
            // LoggingExampleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 256);
            this.Controls.Add(this.btnLogError);
            this.Name = "LoggingExampleForm";
            this.Text = "Logging Example";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLogError;
    }
}

