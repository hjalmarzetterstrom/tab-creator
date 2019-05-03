namespace TabCreator
{
    partial class TuningForm
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
            this.txtString1 = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtString2 = new System.Windows.Forms.TextBox();
            this.txtString3 = new System.Windows.Forms.TextBox();
            this.txtString4 = new System.Windows.Forms.TextBox();
            this.txtString5 = new System.Windows.Forms.TextBox();
            this.txtString6 = new System.Windows.Forms.TextBox();
            this.txtPreview = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(54, 111);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtString1
            // 
            this.txtString1.Location = new System.Drawing.Point(12, 12);
            this.txtString1.Name = "txtString1";
            this.txtString1.Size = new System.Drawing.Size(36, 20);
            this.txtString1.TabIndex = 1;
            this.txtString1.Text = "e";
            this.txtString1.TextChanged += new System.EventHandler(this.txtString_TextChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(54, 140);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // txtString2
            // 
            this.txtString2.Location = new System.Drawing.Point(12, 38);
            this.txtString2.Name = "txtString2";
            this.txtString2.Size = new System.Drawing.Size(36, 20);
            this.txtString2.TabIndex = 2;
            this.txtString2.Text = "B";
            this.txtString2.TextChanged += new System.EventHandler(this.txtString_TextChanged);
            // 
            // txtString3
            // 
            this.txtString3.Location = new System.Drawing.Point(12, 64);
            this.txtString3.Name = "txtString3";
            this.txtString3.Size = new System.Drawing.Size(36, 20);
            this.txtString3.TabIndex = 3;
            this.txtString3.Text = "G";
            this.txtString3.TextChanged += new System.EventHandler(this.txtString_TextChanged);
            // 
            // txtString4
            // 
            this.txtString4.Location = new System.Drawing.Point(12, 90);
            this.txtString4.Name = "txtString4";
            this.txtString4.Size = new System.Drawing.Size(36, 20);
            this.txtString4.TabIndex = 4;
            this.txtString4.Text = "D";
            this.txtString4.TextChanged += new System.EventHandler(this.txtString_TextChanged);
            // 
            // txtString5
            // 
            this.txtString5.Location = new System.Drawing.Point(12, 116);
            this.txtString5.Name = "txtString5";
            this.txtString5.Size = new System.Drawing.Size(36, 20);
            this.txtString5.TabIndex = 5;
            this.txtString5.Text = "A";
            this.txtString5.TextChanged += new System.EventHandler(this.txtString_TextChanged);
            // 
            // txtString6
            // 
            this.txtString6.Location = new System.Drawing.Point(12, 142);
            this.txtString6.Name = "txtString6";
            this.txtString6.Size = new System.Drawing.Size(36, 20);
            this.txtString6.TabIndex = 6;
            this.txtString6.Text = "E";
            this.txtString6.TextChanged += new System.EventHandler(this.txtString_TextChanged);
            // 
            // txtPreview
            // 
            this.txtPreview.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPreview.Location = new System.Drawing.Point(54, 12);
            this.txtPreview.Multiline = true;
            this.txtPreview.Name = "txtPreview";
            this.txtPreview.ReadOnly = true;
            this.txtPreview.Size = new System.Drawing.Size(75, 93);
            this.txtPreview.TabIndex = 8;
            this.txtPreview.WordWrap = false;
            // 
            // FormChangeTuning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(139, 171);
            this.Controls.Add(this.txtPreview);
            this.Controls.Add(this.txtString6);
            this.Controls.Add(this.txtString5);
            this.Controls.Add(this.txtString4);
            this.Controls.Add(this.txtString3);
            this.Controls.Add(this.txtString2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtString1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormChangeTuning";
            this.ShowIcon = false;
            this.Text = "Change Tuning";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtString1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtString2;
        private System.Windows.Forms.TextBox txtString3;
        private System.Windows.Forms.TextBox txtString4;
        private System.Windows.Forms.TextBox txtString5;
        private System.Windows.Forms.TextBox txtString6;
        private System.Windows.Forms.TextBox txtPreview;
    }
}