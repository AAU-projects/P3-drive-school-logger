namespace DriveLogGUI.Windows
{
    partial class ConfirmLessonForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfirmLessonForm));
            this.closeButton = new System.Windows.Forms.Button();
            this.topPanel = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.headerLabel = new System.Windows.Forms.Label();
            this.lessonTitleLabel = new System.Windows.Forms.Label();
            this.dateLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.attendingStudentLabel = new System.Windows.Forms.Label();
            this.attendingStudentsList = new System.Windows.Forms.ListView();
            this.attendedColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.studentColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.saveButton = new System.Windows.Forms.Button();
            this.lessonColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.topPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // closeButton
            // 
            this.closeButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("closeButton.BackgroundImage")));
            this.closeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(71)))), ((int)(((byte)(71)))));
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Location = new System.Drawing.Point(355, 0);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(25, 22);
            this.closeButton.TabIndex = 44;
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(108)))), ((int)(((byte)(112)))));
            this.topPanel.Controls.Add(this.closeButton);
            this.topPanel.Controls.Add(this.button1);
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(380, 22);
            this.topPanel.TabIndex = 48;
            this.topPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.topPanel_MouseDown);
            this.topPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.topPanel_MouseMove);
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(71)))), ((int)(((byte)(71)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(873, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(25, 22);
            this.button1.TabIndex = 1;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // headerLabel
            // 
            this.headerLabel.Font = new System.Drawing.Font("Calibri", 25F);
            this.headerLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(144)))), ((int)(((byte)(150)))));
            this.headerLabel.Location = new System.Drawing.Point(14, 25);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(354, 48);
            this.headerLabel.TabIndex = 49;
            this.headerLabel.Text = "Complete Lesson";
            this.headerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lessonTitleLabel
            // 
            this.lessonTitleLabel.AutoSize = true;
            this.lessonTitleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(132)))), ((int)(((byte)(144)))));
            this.lessonTitleLabel.Location = new System.Drawing.Point(12, 87);
            this.lessonTitleLabel.Name = "lessonTitleLabel";
            this.lessonTitleLabel.Size = new System.Drawing.Size(70, 13);
            this.lessonTitleLabel.TabIndex = 50;
            this.lessonTitleLabel.Text = "Lesson Title: ";
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(132)))), ((int)(((byte)(144)))));
            this.dateLabel.Location = new System.Drawing.Point(12, 117);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(39, 13);
            this.dateLabel.TabIndex = 51;
            this.dateLabel.Text = "Date:  ";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(132)))), ((int)(((byte)(144)))));
            this.panel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(132)))), ((int)(((byte)(144)))));
            this.panel2.Location = new System.Drawing.Point(15, 162);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(350, 2);
            this.panel2.TabIndex = 53;
            // 
            // attendingStudentLabel
            // 
            this.attendingStudentLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(132)))), ((int)(((byte)(144)))));
            this.attendingStudentLabel.Location = new System.Drawing.Point(12, 147);
            this.attendingStudentLabel.Name = "attendingStudentLabel";
            this.attendingStudentLabel.Size = new System.Drawing.Size(153, 19);
            this.attendingStudentLabel.TabIndex = 52;
            this.attendingStudentLabel.Text = "Attending Students:";
            // 
            // attendingStudentsList
            // 
            this.attendingStudentsList.CheckBoxes = true;
            this.attendingStudentsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.attendedColumn,
            this.studentColumn,
            this.lessonColumn});
            this.attendingStudentsList.Location = new System.Drawing.Point(15, 170);
            this.attendingStudentsList.Name = "attendingStudentsList";
            this.attendingStudentsList.Size = new System.Drawing.Size(353, 126);
            this.attendingStudentsList.TabIndex = 54;
            this.attendingStudentsList.UseCompatibleStateImageBehavior = false;
            this.attendingStudentsList.View = System.Windows.Forms.View.Details;
            // 
            // attendedColumn
            // 
            this.attendedColumn.DisplayIndex = 2;
            this.attendedColumn.Text = "Attended?";
            this.attendedColumn.Width = 63;
            // 
            // studentColumn
            // 
            this.studentColumn.DisplayIndex = 0;
            this.studentColumn.Text = "Student:";
            this.studentColumn.Width = 132;
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(144)))), ((int)(((byte)(150)))));
            this.saveButton.FlatAppearance.BorderSize = 0;
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.Font = new System.Drawing.Font("Calibri Light", 12F);
            this.saveButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.saveButton.Location = new System.Drawing.Point(125, 307);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(98, 28);
            this.saveButton.TabIndex = 55;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // lessonColumn
            // 
            this.lessonColumn.DisplayIndex = 1;
            this.lessonColumn.Text = "Lesson Title";
            this.lessonColumn.Width = 129;
            // 
            // ConfirmLessonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(380, 347);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.attendingStudentsList);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.attendingStudentLabel);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.lessonTitleLabel);
            this.Controls.Add(this.headerLabel);
            this.Controls.Add(this.topPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ConfirmLessonForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ConfirmLessonForm";
            this.topPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.Label lessonTitleLabel;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label attendingStudentLabel;
        private System.Windows.Forms.ListView attendingStudentsList;
        private System.Windows.Forms.ColumnHeader studentColumn;
        private System.Windows.Forms.ColumnHeader attendedColumn;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.ColumnHeader lessonColumn;
    }
}