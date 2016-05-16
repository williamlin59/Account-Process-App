using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/* This is the main program of the application playing a role as mediator. 
 * A backgroundworkers are implemented for tracking the progress of reading and uploading
 * data to database. Proper error handling are also being implemented.
 * 
 * 
 */


namespace Account_Info_Upload_Application
{
    public partial class MainForm : Form
    {
        private String filePath;
        private const String READ_FILE = "Reading files...";
        private const String UPLOAD_FILE = "Uploading files...";
        private const String UNABLE_READ_FILE = "Error: Could not read file from disk. Original error: ";
        private const String UNABLE_OPEN_FILE = "Unable to open file: ";
        private const String COMPLETE = "Complete";
        private const String UNABLE_CONNECT_DB = "Can't connect to database";
        private const String READ_IN_LINE = "Total Read in : ";
        private const String INVALIDE_LINE = "Total Invalid Line : ";
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
                    MessageBox.Show(UNABLE_READ_FILE + ex.Message);
                }
            }
        }
        private void upload_Click(object sender, EventArgs e)

        {
 
            if (FileReader.check(filePath) == true)
            {
                this.task.Text = READ_FILE;
                transactions = FileReader.read(filePath);
                uploadProgressBar.Maximum = transactions.Count<=1?1:transactions.Count-1;
                this.task.Text = UPLOAD_FILE;
                backgroundWorker1.RunWorkerAsync();
            }
            else
            {
                MessageBox.Show(UNABLE_OPEN_FILE + filePath);
            }

            
        }

        private void FileSelect_TextChanged(object sender, EventArgs e)
        {
            filePath = fileTextBox.Text; 
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.task.Text = COMPLETE;
            int line = FileReader.getLine();
            MessageBox.Show(READ_IN_LINE + line + "\n" + INVALIDE_LINE + (line - transactions.Count));
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            uploadProgressBar.Value = e.ProgressPercentage;
            decimal value = ((decimal)e.ProgressPercentage / (transactions.Count <1 ? 1 : transactions.Count - 1)) * 100;
            
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
                    MessageBox.Show(UNABLE_CONNECT_DB);
                }
        }

        private void fileSystemWatcher1_Changed(object sender, System.IO.FileSystemEventArgs e)
        {

        }


     

    }
}
