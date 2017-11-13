namespace DriveLogGUI
{
    partial class CalendarTabG
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelForCalendar = new System.Windows.Forms.Panel();
            this.backPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.weekSelectButton = new System.Windows.Forms.Button();
            this.gotoTodayButton = new System.Windows.Forms.Button();
            this.buttonRightWeek = new System.Windows.Forms.Label();
            this.buttonLeftWeek = new System.Windows.Forms.Label();
            this.datesInWeek = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.panelForCalendar.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelForCalendar
            // 
            this.panelForCalendar.BackColor = System.Drawing.Color.White;
            this.panelForCalendar.Controls.Add(this.backPanel);
            this.panelForCalendar.Location = new System.Drawing.Point(211, 93);
            this.panelForCalendar.Name = "panelForCalendar";
            this.panelForCalendar.Size = new System.Drawing.Size(686, 451);
            this.panelForCalendar.TabIndex = 1;
            this.panelForCalendar.Paint += new System.Windows.Forms.PaintEventHandler(this.panelForCalendar_Paint);
            // 
            // backPanel
            // 
            this.backPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.backPanel.Location = new System.Drawing.Point(0, 25);
            this.backPanel.Name = "backPanel";
            this.backPanel.Size = new System.Drawing.Size(686, 401);
            this.backPanel.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(132)))), ((int)(((byte)(144)))));
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.weekSelectButton);
            this.panel1.Controls.Add(this.gotoTodayButton);
            this.panel1.Controls.Add(this.buttonRightWeek);
            this.panel1.Controls.Add(this.buttonLeftWeek);
            this.panel1.Controls.Add(this.datesInWeek);
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(211, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(686, 93);
            this.panel1.TabIndex = 2;
            // 
            // weekSelectButton
            // 
            this.weekSelectButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(108)))), ((int)(((byte)(112)))));
            this.weekSelectButton.FlatAppearance.BorderSize = 0;
            this.weekSelectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.weekSelectButton.Font = new System.Drawing.Font("Calibri Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.weekSelectButton.Location = new System.Drawing.Point(597, 38);
            this.weekSelectButton.Name = "weekSelectButton";
            this.weekSelectButton.Size = new System.Drawing.Size(75, 23);
            this.weekSelectButton.TabIndex = 4;
            this.weekSelectButton.Text = "WEEK ↓";
            this.weekSelectButton.UseVisualStyleBackColor = false;
            // 
            // gotoTodayButton
            // 
            this.gotoTodayButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(108)))), ((int)(((byte)(112)))));
            this.gotoTodayButton.FlatAppearance.BorderSize = 0;
            this.gotoTodayButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gotoTodayButton.Font = new System.Drawing.Font("Calibri Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gotoTodayButton.Location = new System.Drawing.Point(536, 38);
            this.gotoTodayButton.Name = "gotoTodayButton";
            this.gotoTodayButton.Size = new System.Drawing.Size(58, 23);
            this.gotoTodayButton.TabIndex = 3;
            this.gotoTodayButton.Text = "TODAY";
            this.gotoTodayButton.UseVisualStyleBackColor = false;
            this.gotoTodayButton.Click += new System.EventHandler(this.gotoTodayButton_Click);
            // 
            // buttonRightWeek
            // 
            this.buttonRightWeek.AutoSize = true;
            this.buttonRightWeek.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonRightWeek.Font = new System.Drawing.Font("Calibri Light", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRightWeek.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.buttonRightWeek.Location = new System.Drawing.Point(344, 32);
            this.buttonRightWeek.Name = "buttonRightWeek";
            this.buttonRightWeek.Size = new System.Drawing.Size(25, 29);
            this.buttonRightWeek.TabIndex = 2;
            this.buttonRightWeek.Text = ">";
            this.buttonRightWeek.Click += new System.EventHandler(this.buttonRightWeek_Click);
            // 
            // buttonLeftWeek
            // 
            this.buttonLeftWeek.AutoSize = true;
            this.buttonLeftWeek.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonLeftWeek.Font = new System.Drawing.Font("Calibri Light", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLeftWeek.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.buttonLeftWeek.Location = new System.Drawing.Point(311, 32);
            this.buttonLeftWeek.Name = "buttonLeftWeek";
            this.buttonLeftWeek.Size = new System.Drawing.Size(25, 29);
            this.buttonLeftWeek.TabIndex = 1;
            this.buttonLeftWeek.Text = "<";
            this.buttonLeftWeek.Click += new System.EventHandler(this.buttonLeftWeek_Click);
            // 
            // datesInWeek
            // 
            this.datesInWeek.AutoSize = true;
            this.datesInWeek.Font = new System.Drawing.Font("Calibri Light", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datesInWeek.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.datesInWeek.Location = new System.Drawing.Point(55, 32);
            this.datesInWeek.Name = "datesInWeek";
            this.datesInWeek.Size = new System.Drawing.Size(216, 29);
            this.datesInWeek.TabIndex = 0;
            this.datesInWeek.Text = "6-12 November 2017";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(211, 544);
            this.panel2.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Lime;
            this.button1.ForeColor = System.Drawing.Color.Maroon;
            this.button1.Location = new System.Drawing.Point(401, 39);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "add ";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CalendarTabG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelForCalendar);
            this.Name = "CalendarTabG";
            this.Size = new System.Drawing.Size(897, 544);
            this.panelForCalendar.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelForCalendar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button gotoTodayButton;
        private System.Windows.Forms.Label buttonRightWeek;
        private System.Windows.Forms.Label buttonLeftWeek;
        private System.Windows.Forms.Label datesInWeek;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button weekSelectButton;
        private System.Windows.Forms.Panel backPanel;
        private System.Windows.Forms.Button button1;
    }
}
