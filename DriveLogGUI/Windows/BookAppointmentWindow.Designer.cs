namespace DriveLogGUI.Windows
{
    partial class BookAppointmentWindow
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
            this.TitleDateLabel = new System.Windows.Forms.Label();
            this.TitleTimeLabel = new System.Windows.Forms.Label();
            this.lessonTypeLabel = new System.Windows.Forms.Label();
            this.timeDifferenceLabel = new System.Windows.Forms.Label();
            this.lessonsComboBox = new System.Windows.Forms.ComboBox();
            this.EndTimelabel = new System.Windows.Forms.Label();
            this.StartTimelabel = new System.Windows.Forms.Label();
            this.instructorLabel = new System.Windows.Forms.Label();
            this.StartTimecomboBox = new System.Windows.Forms.ComboBox();
            this.CancelButton1 = new System.Windows.Forms.Button();
            this.AddAppointmentButton = new System.Windows.Forms.Button();
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
            this.topPanel.TabIndex = 3;
            this.topPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.topPanel_Paint);
            this.topPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.topPanel_MouseDown);
            this.topPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.topPanel_MouseMove);
            // 
            // TitleDateLabel
            // 
            this.TitleDateLabel.AutoSize = true;
            this.TitleDateLabel.Font = new System.Drawing.Font("Calibri Light", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleDateLabel.Location = new System.Drawing.Point(2, 25);
            this.TitleDateLabel.Name = "TitleDateLabel";
            this.TitleDateLabel.Size = new System.Drawing.Size(378, 33);
            this.TitleDateLabel.TabIndex = 4;
            this.TitleDateLabel.Text = "Book appointment at 24-12-2012";
            // 
            // TitleTimeLabel
            // 
            this.TitleTimeLabel.AutoSize = true;
            this.TitleTimeLabel.Font = new System.Drawing.Font("Calibri Light", 16F);
            this.TitleTimeLabel.Location = new System.Drawing.Point(255, 58);
            this.TitleTimeLabel.Name = "TitleTimeLabel";
            this.TitleTimeLabel.Size = new System.Drawing.Size(125, 27);
            this.TitleTimeLabel.TabIndex = 5;
            this.TitleTimeLabel.Text = "09:00 - 13:00";
            // 
            // lessonTypeLabel
            // 
            this.lessonTypeLabel.AutoSize = true;
            this.lessonTypeLabel.Font = new System.Drawing.Font("Calibri Light", 12F);
            this.lessonTypeLabel.Location = new System.Drawing.Point(12, 58);
            this.lessonTypeLabel.Name = "lessonTypeLabel";
            this.lessonTypeLabel.Size = new System.Drawing.Size(66, 19);
            this.lessonTypeLabel.TabIndex = 6;
            this.lessonTypeLabel.Text = "Practical";
            // 
            // timeDifferenceLabel
            // 
            this.timeDifferenceLabel.AutoSize = true;
            this.timeDifferenceLabel.Font = new System.Drawing.Font("Calibri Light", 10F);
            this.timeDifferenceLabel.Location = new System.Drawing.Point(253, 131);
            this.timeDifferenceLabel.Name = "timeDifferenceLabel";
            this.timeDifferenceLabel.Size = new System.Drawing.Size(94, 17);
            this.timeDifferenceLabel.TabIndex = 20;
            this.timeDifferenceLabel.Text = "time difference";
            // 
            // lessonsComboBox
            // 
            this.lessonsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lessonsComboBox.FormattingEnabled = true;
            this.lessonsComboBox.Location = new System.Drawing.Point(113, 142);
            this.lessonsComboBox.Name = "lessonsComboBox";
            this.lessonsComboBox.Size = new System.Drawing.Size(134, 21);
            this.lessonsComboBox.TabIndex = 19;
            this.lessonsComboBox.SelectedIndexChanged += new System.EventHandler(this.lessonsComboBox_SelectedIndexChanged);
            // 
            // EndTimelabel
            // 
            this.EndTimelabel.AutoSize = true;
            this.EndTimelabel.Font = new System.Drawing.Font("Calibri Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EndTimelabel.Location = new System.Drawing.Point(13, 145);
            this.EndTimelabel.Name = "EndTimelabel";
            this.EndTimelabel.Size = new System.Drawing.Size(101, 18);
            this.EndTimelabel.TabIndex = 17;
            this.EndTimelabel.Text = "Lessons: (45 m)";
            // 
            // StartTimelabel
            // 
            this.StartTimelabel.AutoSize = true;
            this.StartTimelabel.Font = new System.Drawing.Font("Calibri Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartTimelabel.Location = new System.Drawing.Point(13, 115);
            this.StartTimelabel.Name = "StartTimelabel";
            this.StartTimelabel.Size = new System.Drawing.Size(74, 18);
            this.StartTimelabel.TabIndex = 16;
            this.StartTimelabel.Text = "Start time: ";
            // 
            // instructorLabel
            // 
            this.instructorLabel.AutoSize = true;
            this.instructorLabel.Font = new System.Drawing.Font("Calibri Light", 12F);
            this.instructorLabel.Location = new System.Drawing.Point(12, 77);
            this.instructorLabel.Name = "instructorLabel";
            this.instructorLabel.Size = new System.Drawing.Size(72, 19);
            this.instructorLabel.TabIndex = 21;
            this.instructorLabel.Text = "Instructor";
            // 
            // StartTimecomboBox
            // 
            this.StartTimecomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.StartTimecomboBox.FormattingEnabled = true;
            this.StartTimecomboBox.Location = new System.Drawing.Point(113, 115);
            this.StartTimecomboBox.Name = "StartTimecomboBox";
            this.StartTimecomboBox.Size = new System.Drawing.Size(134, 21);
            this.StartTimecomboBox.TabIndex = 18;
            this.StartTimecomboBox.SelectedIndexChanged += new System.EventHandler(this.StartTimecomboBox_SelectedIndexChanged);
            // 
            // CancelButton1
            // 
            this.CancelButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(132)))), ((int)(((byte)(144)))));
            this.CancelButton1.FlatAppearance.BorderSize = 0;
            this.CancelButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelButton1.Font = new System.Drawing.Font("Calibri Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelButton1.ForeColor = System.Drawing.Color.White;
            this.CancelButton1.Location = new System.Drawing.Point(291, 186);
            this.CancelButton1.Name = "CancelButton1";
            this.CancelButton1.Size = new System.Drawing.Size(89, 23);
            this.CancelButton1.TabIndex = 23;
            this.CancelButton1.Text = "Cancel";
            this.CancelButton1.UseVisualStyleBackColor = false;
            this.CancelButton1.Click += new System.EventHandler(this.CancelButton1_Click);
            // 
            // AddAppointmentButton
            // 
            this.AddAppointmentButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(108)))), ((int)(((byte)(112)))));
            this.AddAppointmentButton.FlatAppearance.BorderSize = 0;
            this.AddAppointmentButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddAppointmentButton.Font = new System.Drawing.Font("Calibri Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddAppointmentButton.ForeColor = System.Drawing.Color.White;
            this.AddAppointmentButton.Location = new System.Drawing.Point(16, 186);
            this.AddAppointmentButton.Name = "AddAppointmentButton";
            this.AddAppointmentButton.Size = new System.Drawing.Size(231, 23);
            this.AddAppointmentButton.TabIndex = 22;
            this.AddAppointmentButton.Text = "Book appointment";
            this.AddAppointmentButton.UseVisualStyleBackColor = false;
            this.AddAppointmentButton.Click += new System.EventHandler(this.AddAppointmentButton_Click);
            // 
            // BookAppointmentWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 221);
            this.Controls.Add(this.CancelButton1);
            this.Controls.Add(this.AddAppointmentButton);
            this.Controls.Add(this.instructorLabel);
            this.Controls.Add(this.timeDifferenceLabel);
            this.Controls.Add(this.lessonsComboBox);
            this.Controls.Add(this.StartTimecomboBox);
            this.Controls.Add(this.EndTimelabel);
            this.Controls.Add(this.StartTimelabel);
            this.Controls.Add(this.lessonTypeLabel);
            this.Controls.Add(this.TitleTimeLabel);
            this.Controls.Add(this.TitleDateLabel);
            this.Controls.Add(this.topPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BookAppointmentWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "BookAppointmentWindow";
            this.topPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label TitleDateLabel;
        private System.Windows.Forms.Label TitleTimeLabel;
        private System.Windows.Forms.Label lessonTypeLabel;
        private System.Windows.Forms.Label timeDifferenceLabel;
        private System.Windows.Forms.ComboBox lessonsComboBox;
        private System.Windows.Forms.Label EndTimelabel;
        private System.Windows.Forms.Label StartTimelabel;
        private System.Windows.Forms.Label instructorLabel;
        private System.Windows.Forms.ComboBox StartTimecomboBox;
        private System.Windows.Forms.Button CancelButton1;
        private System.Windows.Forms.Button AddAppointmentButton;
    }
}