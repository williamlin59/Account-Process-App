using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Account_Info_Upload_Application
{
    public partial class MainForm : Form
    {
        private String filePath;
        private List<Transaction> transactions;
        public MainForm()
        {
            InitializeComponent();
        }

        private void choose_Click(object sender, EventArgs e)
        {

            if (filerOpener.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ( filerOpener.OpenFile() != null)
                    {
                        filePath = filerOpener.InitialDirectory + filerOpener.FileName;
                        fileTextBox.Text = filePath; 
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }
        private void upload_Click(object sender, EventArgs e)

        {
 
            if (FileReader.check(filePath) == true)
            {
                this.task.Text = "Reading files...";
                transactions = FileReader.read(filePath);
                uploadProgressBar.Maximum = transactions.Count<=1?1:transactions.Count-1;
                this.task.Text = "Updating data...";
                backgroundWorker1.RunWorkerAsync();
            }
            else
            {
                MessageBox.Show("Unable to open file: " + filePath);
            }

            
        }

        private void FileSelect_TextChanged(object sender, EventArgs e)
        {
            filePath = fileTextBox.Text; 
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.task.Text = "Complete";
            int line = FileReader.getLine();
            MessageBox.Show("Total Read in : "+line+"\n"+ "Total Invalid Line : " +(line-transactions.Count));
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            uploadProgressBar.Value = e.ProgressPercentage;
            decimal value = ((decimal)e.ProgressPercentage / (transactions.Count <=1 ? 1 : transactions.Count - 1)) * 100;
            
            percentage.Text = value.ToString("0.0") + "%";
             
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

                if (Database.connect())
                {
                    Database.insert(transactions, backgroundWorker1);
                   
                }
                else
                {
                    MessageBox.Show("Can't connect to database");
                }
        }

        private void fileSystemWatcher1_Changed(object sender, System.IO.FileSystemEventArgs e)
        {

        }


     

    }
}
