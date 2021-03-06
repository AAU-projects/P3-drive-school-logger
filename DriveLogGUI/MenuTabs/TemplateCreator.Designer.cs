﻿using DriveLogGUI.CustomControls;

namespace DriveLogGUI.MenuTabs
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
            this.logoutButton = new System.Windows.Forms.Button();
            this.pageTitle = new System.Windows.Forms.Label();
            this.rightPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.errorLabel = new System.Windows.Forms.Label();
            this.radioTheoretical = new System.Windows.Forms.RadioButton();
            this.radioPractical = new System.Windows.Forms.RadioButton();
            this.saveButton = new System.Windows.Forms.Button();
            this.typeLabel = new System.Windows.Forms.Label();
            this.readingTextbox = new DriveLogGUI.CustomControls.TextboxBorderColor();
            this.timeAmountLabel = new System.Windows.Forms.Label();
            this.timeAmount = new System.Windows.Forms.NumericUpDown();
            this.descriptionTextbox = new DriveLogGUI.CustomControls.TextboxBorderColor();
            this.titleTextBox = new DriveLogGUI.CustomControls.TextboxBorderColor();
            this.readingLabel = new System.Windows.Forms.Label();
            this.timeLabel = new System.Windows.Forms.Label();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.leftPanel = new System.Windows.Forms.Panel();
            this.leftPanelLabel = new System.Windows.Forms.Label();
            this.removebutton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.headerPanel.SuspendLayout();
            this.rightPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeAmount)).BeginInit();
            this.leftPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.headerPanel.Controls.Add(this.logoutButton);
            this.headerPanel.Controls.Add(this.pageTitle);
            this.headerPanel.Location = new System.Drawing.Point(12, 12);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(873, 56);
            this.headerPanel.TabIndex = 1;
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
            this.pageTitle.Location = new System.Drawing.Point(3, 6);
            this.pageTitle.Name = "pageTitle";
            this.pageTitle.Size = new System.Drawing.Size(767, 44);
            this.pageTitle.TabIndex = 0;
            this.pageTitle.Text = "Lesson Templates";
            // 
            // rightPanel
            // 
            this.rightPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.rightPanel.Controls.Add(this.label1);
            this.rightPanel.Controls.Add(this.errorLabel);
            this.rightPanel.Controls.Add(this.radioTheoretical);
            this.rightPanel.Controls.Add(this.radioPractical);
            this.rightPanel.Controls.Add(this.saveButton);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(132)))), ((int)(((byte)(144)))));
            this.label1.Location = new System.Drawing.Point(325, 416);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 19);
            this.label1.TabIndex = 57;
            this.label1.Text = "* Required field";
            // 
            // errorLabel
            // 
            this.errorLabel.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorLabel.ForeColor = System.Drawing.Color.Red;
            this.errorLabel.Location = new System.Drawing.Point(501, 359);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(145, 33);
            this.errorLabel.TabIndex = 56;
            // 
            // radioTheoretical
            // 
            this.radioTheoretical.AutoSize = true;
            this.radioTheoretical.Font = new System.Drawing.Font("Calibri", 12F);
            this.radioTheoretical.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(132)))), ((int)(((byte)(144)))));
            this.radioTheoretical.Location = new System.Drawing.Point(385, 69);
            this.radioTheoretical.Name = "radioTheoretical";
            this.radioTheoretical.Size = new System.Drawing.Size(149, 23);
            this.radioTheoretical.TabIndex = 55;
            this.radioTheoretical.TabStop = true;
            this.radioTheoretical.Text = "Theoretical Lesson";
            this.radioTheoretical.UseVisualStyleBackColor = true;
            // 
            // radioPractical
            // 
            this.radioPractical.AutoSize = true;
            this.radioPractical.Font = new System.Drawing.Font("Calibri", 12F);
            this.radioPractical.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(132)))), ((int)(((byte)(144)))));
            this.radioPractical.Location = new System.Drawing.Point(385, 46);
            this.radioPractical.Name = "radioPractical";
            this.radioPractical.Size = new System.Drawing.Size(132, 23);
            this.radioPractical.TabIndex = 54;
            this.radioPractical.TabStop = true;
            this.radioPractical.Text = "Practical Lesson";
            this.radioPractical.UseVisualStyleBackColor = true;
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
            // typeLabel
            // 
            this.typeLabel.AutoSize = true;
            this.typeLabel.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.typeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(132)))), ((int)(((byte)(144)))));
            this.typeLabel.Location = new System.Drawing.Point(379, 10);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(159, 33);
            this.typeLabel.TabIndex = 50;
            this.typeLabel.Text = "Lesson Type*";
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
            this.timeAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
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
            this.timeLabel.Size = new System.Drawing.Size(162, 33);
            this.timeLabel.TabIndex = 43;
            this.timeLabel.Text = "Lesson Time*";
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(132)))), ((int)(((byte)(144)))));
            this.descriptionLabel.Location = new System.Drawing.Point(13, 95);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(232, 33);
            this.descriptionLabel.TabIndex = 42;
            this.descriptionLabel.Text = "Lesson Description*";
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(132)))), ((int)(((byte)(144)))));
            this.titleLabel.Location = new System.Drawing.Point(13, 10);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(155, 33);
            this.titleLabel.TabIndex = 41;
            this.titleLabel.Text = "Lesson Title*";
            // 
            // leftPanel
            // 
            this.leftPanel.AutoScroll = true;
            this.leftPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.leftPanel.Controls.Add(this.leftPanelLabel);
            this.leftPanel.Location = new System.Drawing.Point(685, 74);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(200, 434);
            this.leftPanel.TabIndex = 3;
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
        private System.Windows.Forms.Label typeLabel;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button removebutton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.RadioButton radioTheoretical;
        private System.Windows.Forms.RadioButton radioPractical;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.Label label1;
    }
}
