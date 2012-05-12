using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Archivizor_Project.Forms.Search_Forms
{
    public partial class SearchFormOptions : Form
    {
        private String chosenPath;

        #region "Properties"
        public String ChosenPath
        {
            get { return chosenPath; }
            set { chosenPath = value; }
        }
        #endregion

        public SearchFormOptions()
        {
            InitializeComponent();
        }

        private void SearchFormOptions_Load(object sender, EventArgs e)
        {
            pathTextBox.Text = chosenPath;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(pathTextBox.Text) && searchedTextBox.Text.Contains("*."))
            {
                chosenPath = pathTextBox.Text;
                SearchForm form = new SearchForm();
                form.FolderPath = chosenPath;
                form.Argument = searchedTextBox.Text;
                if (searchOptionCheckBox.Checked == true)
                {
                    form.Option = true;
                }
                else
                {
                    form.Option = false;
                }
                form.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid arguments!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
