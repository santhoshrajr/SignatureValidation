using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SignatureValidation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private static readonly Regex sWhitespace = new Regex(@"\s+"); 
        //Remove WhiteSpaces in the string
        public static string ReplaceWhitespace(string input) 
        { 
            return sWhitespace.Replace(input, ""); 
        }

        //Check case-sensitive comparison
        public static bool CheckString(String s1,String s2)
        {
            return (String.Compare(s1,s2,false) == 0);
        }
 

        /**
         * 
         * Load Results data to grid view and show to user
         * **/

        private void loadData(string path)
        {
            try 
                {
                    

                    List<string[]> rows = File.ReadAllLines(path).Select(x => x.Replace("\"", string.Empty).Split(',')).Skip(1).ToList();
                    
                    List<string[]> columns = File.ReadAllLines(path).Select(x =>x.Replace("\"", string.Empty).Split(',')).ToList();
                    string[] col = columns.First();

                    DataTable dt = new DataTable();

                    foreach (var v in col)
                    {
                        
                        dt.Columns.Add(v);
                    }

                  

                    rows.ForEach(x =>
                    {

                        dt.Rows.Add(x);
                    });
                    dataGridcsv.DataSource = dt;
                  

                }
            catch (Exception)
                {
                    MessageBox.Show("Grid view Error.PLease check if the file is open");
                }
            
        }

        /**
         * 
         * Load Repository data
         **/

        private void btnLoadRepo_Click(object sender, EventArgs e)
        {

            OpenFileDialog result = new OpenFileDialog();
           
            result.Title = "Select Repository set";
            result.Filter = "CSV files (*.csv)|*.csv|XML files (*.xml)|*.xml";
            result.ValidateNames = true;
            if (result.ShowDialog() == DialogResult.OK) // Test result.
            {
                string file = result.FileName;
                string onlyFileName =System.IO.Path.GetFileNameWithoutExtension( result.SafeFileName);
                if (onlyFileName == "HashRepository")
                {
                    try
                    {
                        txtRepo.Text = file;
                        loadDataRepo(file);
                        MessageBox.Show("Repository Data has been loaded");

                    }
                    catch (IOException)
                    {
                        MessageBox.Show("Inavlid File");
                    }
                }
                else
                {
                    MessageBox.Show("Please select HashRepository File");
                }
            }
            
        }

        DataTable dtRepo = new DataTable();


        /*
         * This method Loads Repository into datatable
         * */

        private void loadDataRepo(string file)
        {
            try
            {
                clearRepo();  
                List<string[]> rows = File.ReadAllLines(file).Select(x => x.Replace("\"", string.Empty).Split(',')).Skip(1).ToList();
                List<string[]> columns = File.ReadAllLines(file).Select(x => x.Replace("\"", string.Empty).Split(',')).ToList();
                string[] col = columns.First();



                foreach (var v in col)
                {
                    dtRepo.Columns.Add(v);
                }
                

                rows.ForEach(x =>
                {

                    dtRepo.Rows.Add(x);
                });
                

            }
            catch (Exception)
            {
                MessageBox.Show("Loading Error. PLease check if the file is open");
            }
        }

        /**
         * Clears Repository before loading a new one 
         */
        private void clearRepo()
        {
            if (dtRepo != null)
            {
                if (dtRepo.Rows.Count > 0)
                {
                    
                    dtRepo.Clear();
                    dtRepo.Columns.Clear();
                }
            }
            
        }

       /**
        * This method clears Results dataset in gridview 
        */
        private void btnClearResult_Click(object sender, EventArgs e)
        {
            try
            {
                if(dataGridcsv.DataSource!=null)
                dataGridcsv.DataSource = null;
                if (dataGridcsv.ColumnCount > 0)
                {
                    dataGridcsv.Columns.Remove("Column");
                }
                txtFilePath.Text = String.Empty;
                progressBar.Minimum = 0;
                progressBar.Value = 0;
                lblProcessing.Text = string.Empty;
                lblStatus.Text = string.Empty;
            }
            catch (Exception )
            {
                MessageBox.Show("Error in clearing gridview");
            }
        }

        /**
         * This method performs Signature validation of reuslts with repository 
         */
        private void btnValidate_Click(object sender, EventArgs e)
        {
            if (dataGridcsv.DataSource != null && dtRepo!=null &&dtRepo.Rows.Count>0)
            {
                int checkstatus = 0;
                //Adding a result column for individual record
                if (!(dataGridcsv.Columns.Contains("Column")) )
                {
                    dataGridcsv.Columns.Add("Column", "Result");
                }

                foreach (DataGridViewRow row in dataGridcsv.Rows)
                {
                    int count = 0;
                    try
                    {
                        if (
                            row.Cells[@"FileFolderName"].Value != null ||
                            row.Cells[@"SignatureType"].Value != null ||
                            row.Cells[@"Signature"].Value != null
                            )
                        {

                            string filename = row.Cells[@"FileFolderName"].Value.ToString().Trim();
                            string SignatureType = row.Cells[@"SignatureType"].Value.ToString().Trim();
                            string Signature = ReplaceWhitespace(row.Cells[@"Signature"].Value.ToString().Trim()).ToUpper();
                            string repoSignatureType = String.Empty;
                            string signatureRepo = String.Empty;
                            //assigning signature hash code to check based on Siganture type of Results
                            switch (SignatureType)
                            {
                                case @"SHA1":
                                    repoSignatureType = "sigtype1";
                                    signatureRepo = "sig1";
                                    break;
                                case @"MD5":
                                    repoSignatureType = "sigtype2";
                                    signatureRepo = "sig2";
                                    break;
                                case @"CRC16":
                                    repoSignatureType = "sigtype3";
                                    signatureRepo = "sig3";
                                    break;
                                case @"CRC32":
                                    repoSignatureType = "sigtype4";
                                    signatureRepo = "sig4";
                                    break;
                                case @"HMACSHA1":
                                    repoSignatureType = "sigtype5";
                                    signatureRepo = "sig5";
                                    break;

                            }


                            foreach (DataRow rowRepo in dtRepo.Rows)
                            {
                                if (rowRepo["imageName"].ToString() != null)
                                {
                                    string check = rowRepo["imageName"].ToString().Trim();
                                    //Checking Filename of results --case sensitive
                                    bool result = CheckString(filename, check);
                                    if (result)
                                    {
                                        count++;
                                        //if filename is present check their signature types
                                        if (SignatureType == rowRepo[repoSignatureType].ToString().Trim())
                                        {
                                            //If filename and signature types are validated validate the corresponding hash--Upper case
                                            if (Signature == ReplaceWhitespace(rowRepo[signatureRepo].ToString().Trim()).ToUpper())
                                            {
                                                row.Cells[4].Value = "Match";
                                                row.Cells[4].Style.ForeColor = Color.Green;
                                                break;
                                            }
                                            //If hash is not matched
                                            else
                                            {
                                                checkstatus++;
                                                row.Cells[4].Value = "No Match";
                                                row.Cells[4].Style.ForeColor = Color.Red;


                                            }

                                        }

                                    }

                                }

                            }

                            //If there is no file
                            if (count == 0)
                            {
                                checkstatus++;
                                row.Cells[4].Value = "No File";
                                row.Cells[4].Style.ForeColor = Color.Red;

                            }


                        }



                        
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Exception");

                       
                    }
                }

                if (checkstatus == 0)
                {
                    lblStatus.Text = "PASS";
                    lblStatus.ForeColor = Color.Green;
                    lblStatus.Visible = true;
                }
                else
                {
                    lblStatus.Text = "FAIL";
                    lblStatus.ForeColor = Color.Red;
                    lblStatus.Visible = true;
                }
            }
            else
            {
                MessageBox.Show("Upload Results and Repository");
            }
        }

        /**
         * Data parameter to store filename 
         */
        struct DataParameter
        {
           
            public string FileName { get; set; }
 
        }

        DataParameter _inputParameter;

        /**
         * Background work for exporting gridview to csv
         * */
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                int index = 1;
                int rows = dataGridcsv.RowCount;
                string fileName = ((DataParameter)e.Argument).FileName;

                using (StreamWriter sw = new StreamWriter(new FileStream(fileName, FileMode.Create), Encoding.UTF8))
                {
                    var sb = new StringBuilder();

                    var headers = dataGridcsv.Columns.Cast<DataGridViewColumn>();
                    sb.AppendLine(string.Join(",", headers.Select(column => "\"" + column.HeaderText + "\"").ToArray()));

                    foreach (DataGridViewRow row in dataGridcsv.Rows)
                    {
                        if (!backgroundWorker.CancellationPending)
                        {
                            backgroundWorker.ReportProgress(index++ * 100 / rows);
                            var cells = row.Cells.Cast<DataGridViewCell>();
                            sb.AppendLine(string.Join(",", cells.Select(cell => "\"" + cell.Value + "\"").ToArray()));
                        }

                    }

                    sw.Write(sb.ToString());

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Exporting Error");
            }
        }
        /**
         * Intimate Porgress bar on the number of rows progressed 
         */
        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                progressBar.Value = e.ProgressPercentage;
                lblProcessing.Text = string.Format("Processing..{0}%", e.ProgressPercentage);
                progressBar.Update();
            }
            catch (Exception)
            {
                MessageBox.Show("Exporting Error");
            }

        }
        /**
         * Display result after Exporting 
         */
        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Thread.Sleep(100);
            lblProcessing.Text = "Data has been succesfully exported";

        }
        /*
        *  Exporting grid view to csv file
        * */
        private void btnExport2_Click(object sender, EventArgs e)
        {
            if (backgroundWorker.IsBusy)
                return;
            try
            {
                if (dataGridcsv.DataSource != null)
                {
                    using (SaveFileDialog sfd = new SaveFileDialog { Filter = "CSV|*.csv", ValidateNames = true })
                    {
                        if (sfd.ShowDialog() == DialogResult.OK)
                        {

                            _inputParameter.FileName = sfd.FileName;
                            progressBar.Minimum = 0;
                            progressBar.Value = 0;
                            backgroundWorker.RunWorkerAsync(_inputParameter);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Upload a file");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Exporting error");
            }

        }

        //Select csv file for Results and upload
        private void btnLoadResults_Click(object sender, EventArgs e)
        {
            if (dataGridcsv.Columns.Contains("Column") && dataGridcsv.Columns["Column"].Visible)
            {
                dataGridcsv.Columns.Remove("Column");
            }
            OpenFileDialog result = new OpenFileDialog();
            
            result.Title = "Select Result set";
            result.Filter = "CSV files (*.csv)|*.csv|XML files (*.xml)|*.xml";
            result.ValidateNames = true;
            if (result.ShowDialog() == DialogResult.OK) // Test result.
            {
                string file = result.FileName;
                string onlyFileName =System.IO.Path.GetFileNameWithoutExtension( result.SafeFileName);
                if (onlyFileName == "HashResults")
                {
                   
                    try
                    {
                        txtFilePath.Text = file;
                        loadData(file);

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Inavlid File");
                    }
                }
                else 
                {
                    MessageBox.Show("Please select HashResults file");
                }
            }
        }

      
        
    }
}
