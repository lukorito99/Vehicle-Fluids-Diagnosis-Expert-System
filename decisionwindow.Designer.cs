namespace VehicleFluidDiagnosis
{
    partial class decisionwindow
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
            this.cancelbutton = new System.Windows.Forms.Button();
            this.continuebutton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cancelbutton
            // 
            this.cancelbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.cancelbutton.AutoSize = true;
            this.cancelbutton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cancelbutton.BackColor = System.Drawing.Color.Transparent;
            this.cancelbutton.FlatAppearance.BorderColor = System.Drawing.Color.Crimson;
            this.cancelbutton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.cancelbutton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.cancelbutton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cancelbutton.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelbutton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(128)))), ((int)(((byte)(25)))));
            this.cancelbutton.Location = new System.Drawing.Point(7, 280);
            this.cancelbutton.Name = "cancelbutton";
            this.cancelbutton.Size = new System.Drawing.Size(100, 42);
            this.cancelbutton.TabIndex = 32;
            this.cancelbutton.Text = "Cancel";
            this.cancelbutton.UseVisualStyleBackColor = false;
            this.cancelbutton.Click += new System.EventHandler(this.cancelbutton_Click);
            // 
            // continuebutton
            // 
            this.continuebutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.continuebutton.AutoSize = true;
            this.continuebutton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.continuebutton.BackColor = System.Drawing.Color.Transparent;
            this.continuebutton.FlatAppearance.BorderColor = System.Drawing.Color.Crimson;
            this.continuebutton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.continuebutton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.continuebutton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.continuebutton.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.continuebutton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(128)))), ((int)(((byte)(25)))));
            this.continuebutton.Location = new System.Drawing.Point(7, 216);
            this.continuebutton.Name = "continuebutton";
            this.continuebutton.Size = new System.Drawing.Size(129, 42);
            this.continuebutton.TabIndex = 31;
            this.continuebutton.Text = "Continue";
            this.continuebutton.UseVisualStyleBackColor = false;
            this.continuebutton.Click += new System.EventHandler(this.continuebutton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(9, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(486, 51);
            this.label1.TabIndex = 30;
            this.label1.Text = "You are now exiting the system";
            // 
            // decisionwindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 702);
            this.Controls.Add(this.cancelbutton);
            this.Controls.Add(this.continuebutton);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "decisionwindow";
            this.Text = "decisionwindow";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.decisionwindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelbutton;
        private System.Windows.Forms.Button continuebutton;
        private System.Windows.Forms.Label label1;
    }
}