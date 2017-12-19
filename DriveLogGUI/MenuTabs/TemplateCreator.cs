using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DriveLogCode.DataAccess;

namespace DriveLogGUI.MenuTabs
{
    public partial class TemplateCreator : UserControl
    {
        private CheckBox _lastChecked;
        private Button _activeButton = null;
        private string _currentId = null;

        /// <summary>
        /// Class constructor, Initializes component and calls GetTemplates
        /// </summary>
        public TemplateCreator()
        {
            InitializeComponent();
            GetTemplates();
        }

        private List<Button> _templates = new List<Button>();

        /// <summary>
        /// Gets all current templates and adds them to leftPanel
        /// </summary>
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

        /// <summary>
        /// Updates the templates list
        /// </summary>
        private void UpdateTemplateButtons()
        {
            foreach (Button button in _templates)
            {
                button.Dispose();
            }
            _templates.Clear();
            GetTemplates();
        }

        /// <summary>
        /// Loads the clicked template
        /// </summary>
        /// <param name="sender">The object sender</param>
        /// <param name="e">the EventArgs</param>
        private void Template_Clicked(object sender, EventArgs e)
        {
            if(_activeButton != null) _activeButton.BackColor = Color.FromArgb(251, 251, 251);

            _activeButton = sender as Button;
            _activeButton.BackColor = Color.FromArgb(148, 197, 204);
            LoadTemplateValues(_activeButton.Text);

        }

        /// <summary>
        /// Loads the template with the given templateName
        /// </summary>
        /// <param name="templateName">The name of the template</param>
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

        /// <summary>
        /// Saves the new template if all reuired fields have been filled out
        /// </summary>
        /// <param name="sender">The object sender</param>
        /// <param name="e">the EventArgs</param>
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

        /// <summary>
        /// Checks if all the required fields have been filled out
        /// </summary>
        /// <returns>A bool with the result</returns>
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

        /// <summary>
        /// Removes the selected template
        /// </summary>
        /// <param name="sender">The object sender</param>
        /// <param name="e">the EventArgs</param>
        private void removebutton_Click(object sender, EventArgs e)
        {
            _templates.Remove(_activeButton);
            _activeButton.Dispose();
            DatabaseParser.DeleteTemplate(Convert.ToInt32(_currentId));
            _activeButton = null;

            foreach (Button template in _templates)
            {
                template.Location = new Point(20, 30 + template.Height * (_templates.IndexOf(template) + 1) + 5 * _templates.IndexOf(template));
            }
        }

        /// <summary>
        /// Adds a new clean template to be edited by the user
        /// </summary>
        /// <param name="sender">The object sender</param>
        /// <param name="e">the EventArgs</param>
        private void addButton_Click(object sender, EventArgs e)
        {
            if (_activeButton != null) _activeButton.BackColor = Color.FromArgb(251, 251, 251);
            _activeButton = null;
            _currentId = null;

            titleTextBox.Text = "";
            descriptionTextbox.Text = "";
            readingTextbox.Text = "";
            timeAmount.Value = 0;
            if (_lastChecked != null) _lastChecked.Checked = false;
        }
    }
}
