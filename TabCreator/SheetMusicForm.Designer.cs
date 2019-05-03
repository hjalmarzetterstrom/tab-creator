namespace TabCreator_Exclude
{
    partial class SheetMusicForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SheetMusicForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioSharp = new System.Windows.Forms.RadioButton();
            this.radioFlat = new System.Windows.Forms.RadioButton();
            this.radioNatural = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.sheetMusicContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cItemMove = new System.Windows.Forms.ToolStripMenuItem();
            this.cItemClear = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.sheetMusicContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel1.ContextMenuStrip = this.sheetMusicContextMenu;
            this.panel1.Controls.Add(this.radioSharp);
            this.panel1.Controls.Add(this.radioFlat);
            this.panel1.Controls.Add(this.radioNatural);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(931, 120);
            this.panel1.TabIndex = 0;
            this.panel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FormSheetMusic_MouseClick);
            // 
            // radioSharp
            // 
            this.radioSharp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.radioSharp.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioSharp.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("radioSharp.BackgroundImage")));
            this.radioSharp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.radioSharp.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gainsboro;
            this.radioSharp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.radioSharp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.radioSharp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioSharp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioSharp.Location = new System.Drawing.Point(900, 72);
            this.radioSharp.Name = "radioSharp";
            this.radioSharp.Size = new System.Drawing.Size(23, 23);
            this.radioSharp.TabIndex = 30;
            this.radioSharp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioSharp.UseVisualStyleBackColor = true;
            // 
            // radioFlat
            // 
            this.radioFlat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.radioFlat.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioFlat.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("radioFlat.BackgroundImage")));
            this.radioFlat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.radioFlat.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gainsboro;
            this.radioFlat.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.radioFlat.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.radioFlat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioFlat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioFlat.Location = new System.Drawing.Point(900, 26);
            this.radioFlat.Name = "radioFlat";
            this.radioFlat.Size = new System.Drawing.Size(23, 23);
            this.radioFlat.TabIndex = 29;
            this.radioFlat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioFlat.UseVisualStyleBackColor = true;
            // 
            // radioNatural
            // 
            this.radioNatural.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.radioNatural.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioNatural.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("radioNatural.BackgroundImage")));
            this.radioNatural.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.radioNatural.Checked = true;
            this.radioNatural.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gainsboro;
            this.radioNatural.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.radioNatural.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.radioNatural.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioNatural.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioNatural.Location = new System.Drawing.Point(900, 49);
            this.radioNatural.Name = "radioNatural";
            this.radioNatural.Size = new System.Drawing.Size(23, 23);
            this.radioNatural.TabIndex = 28;
            this.radioNatural.TabStop = true;
            this.radioNatural.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioNatural.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(392, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Queue: ";
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(844, 133);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save Queue";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(443, 135);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(395, 20);
            this.textBox1.TabIndex = 3;
            // 
            // sheetMusicContextMenu
            // 
            this.sheetMusicContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cItemMove,
            this.cItemClear});
            this.sheetMusicContextMenu.Name = "sheetMusicContextMenu";
            this.sheetMusicContextMenu.ShowImageMargin = false;
            this.sheetMusicContextMenu.Size = new System.Drawing.Size(152, 48);
            // 
            // cItemMove
            // 
            this.cItemMove.Name = "cItemMove";
            this.cItemMove.Size = new System.Drawing.Size(151, 22);
            this.cItemMove.Text = "Move notes to start";
            // 
            // cItemClear
            // 
            this.cItemClear.Name = "cItemClear";
            this.cItemClear.Size = new System.Drawing.Size(151, 22);
            this.cItemClear.Text = "Clear sheet";
            // 
            // FormSheetMusic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(931, 168);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "FormSheetMusic";
            this.ShowIcon = false;
            this.Text = "Queue Notes";
            this.Load += new System.EventHandler(this.FormSheetMusic_Load);
            this.panel1.ResumeLayout(false);
            this.sheetMusicContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioSharp;
        private System.Windows.Forms.RadioButton radioFlat;
        private System.Windows.Forms.RadioButton radioNatural;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ContextMenuStrip sheetMusicContextMenu;
        private System.Windows.Forms.ToolStripMenuItem cItemMove;
        private System.Windows.Forms.ToolStripMenuItem cItemClear;


    }
}