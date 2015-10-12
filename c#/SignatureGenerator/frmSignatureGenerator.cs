using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Org.BouncyCastle.Bcpg;
using Org.BouncyCastle.Bcpg.OpenPgp;
using Org.BouncyCastle.Security;
using System.Web;

namespace SignatureGenerator
{
    public partial class frmSignatureGenerator : Form
    {
        public frmSignatureGenerator()
        {
            InitializeComponent();
        }

        private void FormLoad(object sender, EventArgs e)
        {
            string Version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            lblVersion.Text = Version + " - " + lblVersion.Text;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            string userinput = txtPassword.Text;
            byte[] clearData = Encoding.UTF8.GetBytes(txtCustomerNumber.Text + ":" + txtUserName.Text);
            char[] passArray = userinput.ToCharArray();
            const string fileName = "iway";

            string result = PgpGenerator.GenerateDatSignature(clearData, passArray, fileName);

            //Expected lenght will vary based on clearData, passPhrase etc. 
            //Therefore, before giving the assert its value you will need to manually 
            //verify that the encrypted result is actually accepted by the DAT authentication process. 
            //const int expectedResultLenght = 76;

            txtResultPgpRaw.Text = result;
            txtResultPgpUrlEnc.Text = System.Web.HttpUtility.UrlEncode(result);

            txtResultPgpBase64.Text = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(result));

            txtResultSha256.Text = Hash.calculateSHA256Hash(txtCustomerNumber.Text + ":" + txtUserName.Text + ":" + txtPassword.Text, Encoding.UTF8);

            Cursor.Current = Cursors.Default;

            //Assert.AreEqual(expectedResultLenght, result.Length);
        }

        private void txtResult_Click(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.SelectAll();
            System.Windows.Forms.Clipboard.SetText(tb.Text);

            ToolTip ttSignature = new ToolTip();
            ttSignature.Show("Signature is copied to clipboard.", tb); // Message of the toolTip
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string Saved_File = "";

            saveFileDialog.InitialDirectory = "C:";
            saveFileDialog.Title = "Save Signatures to File";
            saveFileDialog.FileName = "Signature.txt";

            saveFileDialog.Filter = "Text Files|*.txt|All Files|*.*";

            if (saveFileDialog.ShowDialog() != DialogResult.Cancel)
            {
                Saved_File = saveFileDialog.FileName;

                // Compose a string that consists of three lines.
                //string lines = "First line.\r\nSecond line.\r\nThird line.";
                //string[] lines = { "First line", "Second line", "Third line" };
                string lines = "";
                lines += "Customer Number = " + txtCustomerNumber.Text + "\r\n";
                lines += "User Name       = " + txtUserName.Text + "\r\n";
                lines += "\r\n";
                lines += "Signatures :\r\n";
                lines += "RAW           = " + txtResultPgpRaw.Text + "\r\n";
                lines += "URL encoded   = " + txtResultPgpUrlEnc.Text + "\r\n";
                lines += "Base64 (SOAP) = " + txtResultPgpBase64.Text + "\r\n";
                lines += "SHA-256       = " + txtResultSha256.Text + "\r\n";

                // Write the string to a file.
                //System.IO.StreamWriter file = new System.IO.StreamWriter("Saved_File");
                //System.IO.File.WriteAllLines(@"Saved_File", lines);
                //file.WriteLine(lines);

                //file.Close();

                WriteToFile(Saved_File, lines);
            }

        }

        private void WriteToFile(string path, string lines)
        {
            //string path = @"c:\temp\MyTest.txt";

            try
            {

                // Delete the file if it exists.
                if (File.Exists(path))
                {
                    // Note that no lock is put on the
                    // file and the possibility exists
                    // that another process could do
                    // something with it between
                    // the calls to Exists and Delete.
                    File.Delete(path);
                }

                // Create the file.
                using (FileStream fs = File.Create(path))
                {
                    //Byte[] info = new UTF8Encoding(true).GetBytes("This is some text in the file.");
                    Byte[] info = new UTF8Encoding(true).GetBytes(lines);
                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }

                // Open the stream and read it back.
                using (StreamReader sr = File.OpenText(path))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                }
            }

            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
        }
    }
}
