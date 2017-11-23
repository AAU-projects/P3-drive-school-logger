namespace DriveLogGUI
{
    partial class AddAppointmentWindow
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
            if (disposing && (components != null)) {
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
            this.CloseButton = new System.Windows.Forms.Button();
            this.topPanel = new System.Windows.Forms.Panel();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.LessonTypelabel = new System.Windows.Forms.Label();
            this.StartTimelabel = new System.Windows.Forms.Label();
            this.EndTimelabel = new System.Windows.Forms.Label();
            this.LessonTypecomboBox = new System.Windows.Forms.ComboBox();
            this.StartTimecomboBox = new System.Windows.Forms.ComboBox();
            this.EndTimecomboBox = new System.Windows.Forms.ComboBox();
            this.AddAppointmentButton = new System.Windows.Forms.Button();
            this.CancelButton1 = new System.Windows.Forms.Button();
            this.timeDifferenceLabel = new System.Windows.Forms.Label();
            this.topPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // CloseButton
            // 
            this.CloseButton.BackgroundImage = global::DriveLogGUI.Properties.Resources.exit6;
            this.CloseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.CloseButton.FlatAppearance.BorderSize = 0;
            this.CloseButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(71)))), ((int)(((byte)(71)))));
            this.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseButton.Location = new System.Drawing.Point(368, 0);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(25, 22);
            this.CloseButton.TabIndex = 1;
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(108)))), ((int)(((byte)(112)))));
            this.topPanel.Controls.Add(this.CloseButton);
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(393, 22);
            this.topPanel.TabIndex = 2;
            this.topPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.topPanel_MouseDown);
            this.topPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.topPanel_MouseMove);
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Calibri Light", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.Location = new System.Drawing.Point(12, 25);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(368, 33);
            this.TitleLabel.TabIndex = 3;
            this.TitleLabel.Text = "Add appointment to 24-12-2012";
            // 
            // LessonTypelabel
            // 
            this.LessonTypelabel.AutoSize = true;
            this.LessonTypelabel.Font = new System.Drawing.Font("Calibri Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LessonTypelabel.Location = new System.Drawing.Point(15, 70);
            this.LessonTypelabel.Name = "LessonTypelabel";
            this.LessonTypelabel.Size = new System.Drawing.Size(86, 18);
            this.LessonTypelabel.TabIndex = 4;
            this.LessonTypelabel.Text = "Lesson type: ";
            // 
            // StartTimelabel
            // 
            this.StartTimelabel.AutoSize = true;
            this.StartTimelabel.Font = new System.Drawing.Font("Calibri Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartTimelabel.Location = new System.Drawing.Point(15, 111);
            this.StartTimelabel.Name = "StartTimelabel";
            this.StartTimelabel.Size = new System.Drawing.Size(74, 18);
            this.StartTimelabel.TabIndex = 5;
            this.StartTimelabel.Text = "Start time: ";
            // 
            // EndTimelabel
            // 
            this.EndTimelabel.AutoSize = true;
            this.EndTimelabel.Font = new System.Drawing.Font("Calibri Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EndTimelabel.Location = new System.Drawing.Point(15, 141);
            this.EndTimelabel.Name = "EndTimelabel";
            this.EndTimelabel.Size = new System.Drawing.Size(59, 18);
            this.EndTimelabel.TabIndex = 6;
            this.EndTimelabel.Text = "Lessons:";
            // 
            // LessonTypecomboBox
            // 
            this.LessonTypecomboBox.FormattingEnabled = true;
            this.LessonTypecomboBox.Items.AddRange(new object[] {
            "Theoretical",
            "Practical"});
            this.LessonTypecomboBox.Location = new System.Drawing.Point(107, 70);
            this.LessonTypecomboBox.Name = "LessonTypecomboBox";
            this.LessonTypecomboBox.Size = new System.Drawing.Size(142, 21);
            this.LessonTypecomboBox.TabIndex = 8;
            // 
            // StartTimecomboBox
            // 
            this.StartTimecomboBox.FormattingEnabled = true;
            this.StartTimecomboBox.Location = new System.Drawing.Point(107, 111);
            this.StartTimecomboBox.Name = "StartTimecomboBox";
            this.StartTimecomboBox.Size = new System.Drawing.Size(142, 21);
            this.StartTimecomboBox.TabIndex = 9;
            this.StartTimecomboBox.SelectedValueChanged += new System.EventHandler(this.StartTimecomboBox_SelectedValueChanged);
            // 
            // EndTimecomboBox
            // 
            this.EndTimecomboBox.FormattingEnabled = true;
            this.EndTimecomboBox.Location = new System.Drawing.Point(107, 138);
            this.EndTimecomboBox.Name = "EndTimecomboBox";
            this.EndTimecomboBox.Size = new System.Drawing.Size(142, 21);
            this.EndTimecomboBox.TabIndex = 10;
            this.EndTimecomboBox.SelectedValueChanged += new System.EventHandler(this.EndTimecomboBox_SelectedValueChanged);
            // 
            // AddAppointmentButton
            // 
            this.AddAppointmentButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(108)))), ((int)(((byte)(112)))));
            this.AddAppointmentButton.FlatAppearance.BorderSize = 0;
            this.AddAppointmentButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddAppointmentButton.Font = new System.Drawing.Font("Calibri Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddAppointmentButton.ForeColor = System.Drawing.Color.White;
            this.AddAppointmentButton.Location = new System.Drawing.Point(18, 186);
            this.AddAppointmentButton.Name = "AddAppointmentButton";
            this.AddAppointmentButton.Size = new System.Drawing.Size(231, 23);
            this.AddAppointmentButton.TabIndex = 13;
            this.AddAppointmentButton.Text = "Add appointment";
            this.AddAppointmentButton.UseVisualStyleBackColor = false;
            // 
            // CancelButton1
            // 
            this.CancelButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(132)))), ((int)(((byte)(144)))));
            this.CancelButton1.FlatAppearance.BorderSize = 0;
            this.CancelButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelButton1.Font = new System.Drawing.Font("Calibri Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelButton1.ForeColor = System.Drawing.Color.White;
            this.CancelButton1.Location = new System.Drawing.Point(292, 186);
            this.CancelButton1.Name = "CancelButton1";
            this.CancelButton1.Size = new System.Drawing.Size(89, 23);
            this.CancelButton1.TabIndex = 14;
            this.CancelButton1.Text = "Cancel";
            this.CancelButton1.UseVisualStyleBackColor = false;
            this.CancelButton1.Click += new System.EventHandler(this.CancelButton1_Click);
            // 
            // timeDifferenceLabel
            // 
            this.timeDifferenceLabel.AutoSize = true;
            this.timeDifferenceLabel.Font = new System.Drawing.Font("Calibri Light", 10F);
            this.timeDifferenceLabel.Location = new System.Drawing.Point(255, 126);
            this.timeDifferenceLabel.Name = "timeDifferenceLabel";
            this.timeDifferenceLabel.Size = new System.Drawing.Size(94, 17);
            this.timeDifferenceLabel.TabIndex = 15;
            this.timeDifferenceLabel.Text = "time difference";
            // 
            // AddAppointmentWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 221);
            this.Controls.Add(this.timeDifferenceLabel);
            this.Controls.Add(this.CancelButton1);
            this.Controls.Add(this.AddAppointmentButton);
            this.Controls.Add(this.EndTimecomboBox);
            this.Controls.Add(this.StartTimecomboBox);
            this.Controls.Add(this.LessonTypecomboBox);
            this.Controls.Add(this.EndTimelabel);
            this.Controls.Add(this.StartTimelabel);
            this.Controls.Add(this.LessonTypelabel);
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.topPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddAppointmentWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "AddAppointmentWindow";
            this.topPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label LessonTypelabel;
        private System.Windows.Forms.Label StartTimelabel;
        private System.Windows.Forms.Label EndTimelabel;
        private System.Windows.Forms.ComboBox LessonTypecomboBox;
        private System.Windows.Forms.ComboBox StartTimecomboBox;
        private System.Windows.Forms.ComboBox EndTimecomboBox;
        private System.Windows.Forms.Button AddAppointmentButton;
        private System.Windows.Forms.Button CancelButton1;
        private System.Windows.Forms.Label timeDifferenceLabel;
    }
}