﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DriveLogCode.DataAccess;

namespace DriveLogGUI.MenuTabs
{
    public partial class TemplateCreator : UserControl
    {
        public delegate void SlideEvent();
        public SlideEvent ActivateSlide;

        private CheckBox _lastChecked;
        private Button _actriveButton = null;
        private string _currentId = null;

        public TemplateCreator()
        {
            InitializeComponent();
            GetTemplates();
        }

        private List<Button> _templates = new List<Button>();

        private void GetTemplates()
        {
            List<string> templateNames = DatabaseParser.GetLessonTemplates();

            foreach (string template in templateNames)
            {
                Button tempButton = new Button
                {
                    Size = new Size(leftPanel.Width - 40, 30),
                    Text = template,
                    FlatStyle = FlatStyle.Flat,
                    FlatAppearance = {BorderSize = 0},
                    TextAlign = ContentAlignment.MiddleLeft,
                    Font = new Font("Calibri Light", 12F),
                    ForeColor = Color.FromArgb(127, 132, 144)
            };

                tempButton.Location = new Point(20, 30 + tempButton.Height * (templateNames.IndexOf(template)+1) + 5 * templateNames.IndexOf(template));
                tempButton.Click += Template_Clicked;

                leftPanel.Controls.Add(tempButton);
                _templates.Add(tempButton);
            }
        }

        private void UpdateTemplateButtons()
        {
            foreach (Button button in _templates)
            {
                button.Dispose();
            }
            _templates.Clear();
            GetTemplates();
        }

        private void Template_Clicked(object sender, EventArgs e)
        {
            if(_actriveButton != null) _actriveButton.BackColor = Color.FromArgb(251, 251, 251);

            _actriveButton = sender as Button;
            _actriveButton.BackColor = Color.FromArgb(148, 197, 204);
            LoadTemplateValues(_actriveButton.Text);

        }

        private void LoadTemplateValues(string templateName)
        {
            Dictionary<string,string> template = DatabaseParser.GetTemplate(templateName);
            _currentId = template["id"];
            titleTextBox.Text = template["title"];
            descriptionTextbox.Text = template["description"];
            readingTextbox.Text = template["reading"];
            timeAmount.Value = Convert.ToInt32(template["time"]);

            if (template["type"] == "Practical")
            {
                radioPractical.Checked = true;
            }
            else
            {
                radioTheoretical.Checked = true;
            }
        }

        private void TypeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox activeCheckBox = sender as CheckBox;
            if (activeCheckBox != _lastChecked && _lastChecked != null) _lastChecked.Checked = false;
            _lastChecked = activeCheckBox.Checked ? activeCheckBox : null;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (IsAllRequiredFilledOut())
            {
                DatabaseParser.UploadTemplate(_currentId, titleTextBox.Text, descriptionTextbox.Text, radioPractical.Checked ? "Practical" : "Theoretical",
                    timeAmount.Value.ToString(), readingTextbox.Text);

                UpdateTemplateButtons();

            }
            else
            {
                errorLabel.Text = "Please fill out all required fields";
            }
        }

        private bool IsAllRequiredFilledOut()
        {
            Color normalColor = Color.FromArgb(127, 132, 144);
            bool temp = true;

            timeAmountLabel.ForeColor = normalColor;
            titleLabel.ForeColor = normalColor;
            descriptionLabel.ForeColor = normalColor;
            typeLabel.ForeColor = normalColor;

            if (string.IsNullOrWhiteSpace(titleTextBox.Text)) {titleLabel.ForeColor = Color.Red; temp = false;}
            if (string.IsNullOrWhiteSpace(descriptionTextbox.Text)) {descriptionLabel.ForeColor = Color.Red; temp = false;}
            if (!radioPractical.Checked && !radioTheoretical.Checked) {typeLabel.ForeColor = Color.Red; temp = false;}
            if (timeAmount.Value == 0) {timeLabel.ForeColor = Color.Red; temp = false;}

            return temp;
        }

        private void removebutton_Click(object sender, EventArgs e)
        {
            _templates.Remove(_actriveButton);
            _actriveButton.Dispose();
            DatabaseParser.DeleteTemplate(Convert.ToInt32(_currentId));
            _actriveButton = null;

            foreach (Button template in _templates)
            {
                template.Location = new Point(20, 30 + template.Height * (_templates.IndexOf(template) + 1) + 5 * _templates.IndexOf(template));
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (_actriveButton != null) _actriveButton.BackColor = Color.FromArgb(251, 251, 251);
            _actriveButton = null;
            _currentId = null;

            titleTextBox.Text = "";
            descriptionTextbox.Text = "";
            readingTextbox.Text = "";
            timeAmount.Value = 0;
            if (_lastChecked != null) _lastChecked.Checked = false;
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            ActivateSlide?.Invoke();
        }
    }
}