namespace DriveLogGUI
{
    partial class TemplateCreator
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.headerPanel = new System.Windows.Forms.Panel();
            this.menuButton = new System.Windows.Forms.Button();
            this.logoutButton = new System.Windows.Forms.Button();
            this.pageTitle = new System.Windows.Forms.Label();
            this.rightPanel = new System.Windows.Forms.Panel();
            this.saveButton = new System.Windows.Forms.Button();
            this.checkboxTheoratical = new System.Windows.Forms.CheckBox();
            this.checkBoxPractical = new System.Windows.Forms.CheckBox();
            this.typeLabel = new System.Windows.Forms.Label();
            this.readingTextbox = new TextboxBorderColor();
            this.timeAmountLabel = new System.Windows.Forms.Label();
            this.timeAmount = new System.Windows.Forms.NumericUpDown();
            this.descriptionTextbox = new TextboxBorderColor();
            this.titleTextBox = new TextboxBorderColor();
            this.readingLabel = new System.Windows.Forms.Label();
            this.timeLabel = new System.Windows.Forms.Label();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.leftPanel = new System.Windows.Forms.Panel();
            this.removebutton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.leftPanelLabel = new System.Windows.Forms.Label();
            this.headerPanel.SuspendLayout();
            this.rightPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeAmount)).BeginInit();
            this.leftPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.headerPanel.Controls.Add(this.menuButton);
            this.headerPanel.Controls.Add(this.logoutButton);
            this.headerPanel.Controls.Add(this.pageTitle);
            this.headerPanel.Location = new System.Drawing.Point(12, 12);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(873, 56);
            this.headerPanel.TabIndex = 1;
            // 
            // menuButton
            // 
            this.menuButton.BackColor = System.Drawing.Color.Transparent;
            this.menuButton.BackgroundImage = global::DriveLogGUI.Properties.Resources.ic_menu_black_24dp_1x;
            this.menuButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.menuButton.FlatAppearance.BorderSize = 0;
            this.menuButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menuButton.Location = new System.Drawing.Point(3, 12);
            this.menuButton.Name = "menuButton";
            this.menuButton.Size = new System.Drawing.Size(36, 32);
            this.menuButton.TabIndex = 4;
            this.menuButton.UseVisualStyleBackColor = false;
            this.menuButton.Click += new System.EventHandler(this.menuButton_Click);
            // 
            // logoutButton
            // 
            this.logoutButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(187)))), ((int)(((byte)(191)))));
            this.logoutButton.FlatAppearance.BorderSize = 0;
            this.logoutButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(71)))), ((int)(((byte)(71)))));
            this.logoutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logoutButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.logoutButton.Location = new System.Drawing.Point(808, 6);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(52, 44);
            this.logoutButton.TabIndex = 1;
            this.logoutButton.Text = "Logout";
            this.logoutButton.UseVisualStyleBackColor = false;
            // 
            // pageTitle
            // 
            this.pageTitle.BackColor = System.Drawing.Color.Transparent;
            this.pageTitle.Font = new System.Drawing.Font("Calibri", 25F);
            this.pageTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(132)))), ((int)(((byte)(144)))));
            this.pageTitle.Location = new System.Drawing.Point(35, 6);
            this.pageTitle.Name = "pageTitle";
            this.pageTitle.Size = new System.Drawing.Size(767, 44);
            this.pageTitle.TabIndex = 0;
            this.pageTitle.Text = "Lesson Templates";
            // 
            // rightPanel
            // 
            this.rightPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.rightPanel.Controls.Add(this.saveButton);
            this.rightPanel.Controls.Add(this.checkboxTheoratical);
            this.rightPanel.Controls.Add(this.checkBoxPractical);
            this.rightPanel.Controls.Add(this.typeLabel);
            this.rightPanel.Controls.Add(this.readingTextbox);
            this.rightPanel.Controls.Add(this.timeAmountLabel);
            this.rightPanel.Controls.Add(this.timeAmount);
            this.rightPanel.Controls.Add(this.descriptionTextbox);
            this.rightPanel.Controls.Add(this.titleTextBox);
            this.rightPanel.Controls.Add(this.readingLabel);
            this.rightPanel.Controls.Add(this.timeLabel);
            this.rightPanel.Controls.Add(this.descriptionLabel);
            this.rightPanel.Controls.Add(this.titleLabel);
            this.rightPanel.Location = new System.Drawing.Point(12, 74);
            this.rightPanel.Name = "rightPanel";
            this.rightPanel.Size = new System.Drawing.Size(667, 457);
            this.rightPanel.TabIndex = 2;
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(144)))), ((int)(((byte)(150)))));
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.Font = new System.Drawing.Font("Calibri Light", 16.25F);
            this.saveButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.saveButton.Location = new System.Drawing.Point(505, 395);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(141, 40);
            this.saveButton.TabIndex = 53;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // checkboxTheoratical
            // 
            this.checkboxTheoratical.AutoSize = true;
            this.checkboxTheoratical.Font = new System.Drawing.Font("Calibri", 12F);
            this.checkboxTheoratical.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(132)))), ((int)(((byte)(144)))));
            this.checkboxTheoratical.Location = new System.Drawing.Point(385, 69);
            this.checkboxTheoratical.Name = "checkboxTheoratical";
            this.checkboxTheoratical.Size = new System.Drawing.Size(150, 23);
            this.checkboxTheoratical.TabIndex = 52;
            this.checkboxTheoratical.Text = "Theoretical Lesson";
            this.checkboxTheoratical.UseVisualStyleBackColor = true;
            this.checkboxTheoratical.CheckedChanged += new System.EventHandler(this.TypeCheckBox_CheckedChanged);
            // 
            // checkBoxPractical
            // 
            this.checkBoxPractical.AutoSize = true;
            this.checkBoxPractical.Font = new System.Drawing.Font("Calibri", 12F);
            this.checkBoxPractical.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(132)))), ((int)(((byte)(144)))));
            this.checkBoxPractical.Location = new System.Drawing.Point(385, 46);
            this.checkBoxPractical.Name = "checkBoxPractical";
            this.checkBoxPractical.Size = new System.Drawing.Size(133, 23);
            this.checkBoxPractical.TabIndex = 51;
            this.checkBoxPractical.Text = "Practical Lesson";
            this.checkBoxPractical.UseVisualStyleBackColor = true;
            this.checkBoxPractical.CheckedChanged += new System.EventHandler(this.TypeCheckBox_CheckedChanged);
            // 
            // typeLabel
            // 
            this.typeLabel.AutoSize = true;
            this.typeLabel.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.typeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(132)))), ((int)(((byte)(144)))));
            this.typeLabel.Location = new System.Drawing.Point(379, 10);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(146, 33);
            this.typeLabel.TabIndex = 50;
            this.typeLabel.Text = "Lesson Type";
            // 
            // readingTextbox
            // 
            this.readingTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(212)))), ((int)(((byte)(225)))));
            this.readingTextbox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(212)))), ((int)(((byte)(225)))));
            this.readingTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.readingTextbox.DefaultText = "";
            this.readingTextbox.Font = new System.Drawing.Font("Calibri Light", 14F);
            this.readingTextbox.ForeColor = System.Drawing.Color.Black;
            this.readingTextbox.Location = new System.Drawing.Point(385, 201);
            this.readingTextbox.MaxLength = 255;
            this.readingTextbox.Multiline = true;
            this.readingTextbox.Name = "readingTextbox";
            this.readingTextbox.Size = new System.Drawing.Size(261, 111);
            this.readingTextbox.TabIndex = 49;
            // 
            // timeAmountLabel
            // 
            this.timeAmountLabel.AutoSize = true;
            this.timeAmountLabel.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeAmountLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(132)))), ((int)(((byte)(144)))));
            this.timeAmountLabel.Location = new System.Drawing.Point(428, 128);
            this.timeAmountLabel.Name = "timeAmountLabel";
            this.timeAmountLabel.Size = new System.Drawing.Size(75, 23);
            this.timeAmountLabel.TabIndex = 48;
            this.timeAmountLabel.Text = "x 45 min";
            // 
            // timeAmount
            // 
            this.timeAmount.Location = new System.Drawing.Point(385, 131);
            this.timeAmount.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.timeAmount.Name = "timeAmount";
            this.timeAmount.Size = new System.Drawing.Size(37, 20);
            this.timeAmount.TabIndex = 47;
            // 
            // descriptionTextbox
            // 
            this.descriptionTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(212)))), ((int)(((byte)(225)))));
            this.descriptionTextbox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(212)))), ((int)(((byte)(225)))));
            this.descriptionTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.descriptionTextbox.DefaultText = "";
            this.descriptionTextbox.Font = new System.Drawing.Font("Calibri Light", 14F);
            this.descriptionTextbox.ForeColor = System.Drawing.Color.Black;
            this.descriptionTextbox.Location = new System.Drawing.Point(19, 131);
            this.descriptionTextbox.MaxLength = 2000;
            this.descriptionTextbox.Multiline = true;
            this.descriptionTextbox.Name = "descriptionTextbox";
            this.descriptionTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.descriptionTextbox.Size = new System.Drawing.Size(300, 304);
            this.descriptionTextbox.TabIndex = 46;
            // 
            // titleTextBox
            // 
            this.titleTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(212)))), ((int)(((byte)(225)))));
            this.titleTextBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(212)))), ((int)(((byte)(225)))));
            this.titleTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.titleTextBox.DefaultText = "";
            this.titleTextBox.Font = new System.Drawing.Font("Calibri Light", 14F);
            this.titleTextBox.ForeColor = System.Drawing.Color.Black;
            this.titleTextBox.Location = new System.Drawing.Point(19, 46);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(300, 23);
            this.titleTextBox.TabIndex = 45;
            // 
            // readingLabel
            // 
            this.readingLabel.AutoSize = true;
            this.readingLabel.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.readingLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(132)))), ((int)(((byte)(144)))));
            this.readingLabel.Location = new System.Drawing.Point(379, 165);
            this.readingLabel.Name = "readingLabel";
            this.readingLabel.Size = new System.Drawing.Size(183, 33);
            this.readingLabel.TabIndex = 44;
            this.readingLabel.Text = "Lesson Reading";
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(132)))), ((int)(((byte)(144)))));
            this.timeLabel.Location = new System.Drawing.Point(379, 95);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(149, 33);
            this.timeLabel.TabIndex = 43;
            this.timeLabel.Text = "Lesson Time";
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(132)))), ((int)(((byte)(144)))));
            this.descriptionLabel.Location = new System.Drawing.Point(13, 95);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(219, 33);
            this.descriptionLabel.TabIndex = 42;
            this.descriptionLabel.Text = "Lesson Description";
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(132)))), ((int)(((byte)(144)))));
            this.titleLabel.Location = new System.Drawing.Point(13, 10);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(142, 33);
            this.titleLabel.TabIndex = 41;
            this.titleLabel.Text = "Lesson Title";
            // 
            // leftPanel
            // 
            this.leftPanel.HorizontalScroll.Maximum = 0;
            this.leftPanel.AutoScroll = false;
            this.leftPanel.VerticalScroll.Visible = false;
            this.leftPanel.AutoScroll = true;
            this.leftPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.leftPanel.Controls.Add(this.leftPanelLabel);
            this.leftPanel.Location = new System.Drawing.Point(685, 74);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(200, 434);
            this.leftPanel.TabIndex = 3;
            // 
            // removebutton
            // 
            this.removebutton.BackColor = System.Drawing.Color.Transparent;
            this.removebutton.BackgroundImage = global::DriveLogGUI.Properties.Resources.ic_remove_black_24dp_1x;
            this.removebutton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.removebutton.FlatAppearance.BorderSize = 0;
            this.removebutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.removebutton.Location = new System.Drawing.Point(718, 508);
            this.removebutton.Name = "removebutton";
            this.removebutton.Size = new System.Drawing.Size(24, 23);
            this.removebutton.TabIndex = 3;
            this.removebutton.UseVisualStyleBackColor = false;
            this.removebutton.Click += new System.EventHandler(this.removebutton_Click);
            // 
            // addButton
            // 
            this.addButton.BackColor = System.Drawing.Color.Transparent;
            this.addButton.BackgroundImage = global::DriveLogGUI.Properties.Resources.ic_add_black_24dp_1x;
            this.addButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.addButton.FlatAppearance.BorderSize = 0;
            this.addButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addButton.Location = new System.Drawing.Point(688, 508);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(24, 23);
            this.addButton.TabIndex = 2;
            this.addButton.UseVisualStyleBackColor = false;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // leftPanelLabel
            // 
            this.leftPanelLabel.BackColor = System.Drawing.Color.Transparent;
            this.leftPanelLabel.Font = new System.Drawing.Font("Calibri", 20.25F);
            this.leftPanelLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(132)))), ((int)(((byte)(144)))));
            this.leftPanelLabel.Location = new System.Drawing.Point(10, 10);
            this.leftPanelLabel.Name = "leftPanelLabel";
            this.leftPanelLabel.Size = new System.Drawing.Size(177, 33);
            this.leftPanelLabel.TabIndex = 1;
            this.leftPanelLabel.Text = "Templates";
            // 
            // TemplateCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.removebutton);
            this.Controls.Add(this.leftPanel);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.rightPanel);
            this.Controls.Add(this.headerPanel);
            this.Name = "TemplateCreator";
            this.Size = new System.Drawing.Size(897, 544);
            this.headerPanel.ResumeLayout(false);
            this.rightPanel.ResumeLayout(false);
            this.rightPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeAmount)).EndInit();
            this.leftPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.Label pageTitle;
        private System.Windows.Forms.Panel rightPanel;
        private System.Windows.Forms.Panel leftPanel;
        private System.Windows.Forms.Label leftPanelLabel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.Label readingLabel;
        private System.Windows.Forms.Label timeLabel;
        private TextboxBorderColor titleTextBox;
        private TextboxBorderColor descriptionTextbox;
        private TextboxBorderColor readingTextbox;
        private System.Windows.Forms.Label timeAmountLabel;
        private System.Windows.Forms.NumericUpDown timeAmount;
        private System.Windows.Forms.CheckBox checkboxTheoratical;
        private System.Windows.Forms.CheckBox checkBoxPractical;
        private System.Windows.Forms.Label typeLabel;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button removebutton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button menuButton;
    }
}
