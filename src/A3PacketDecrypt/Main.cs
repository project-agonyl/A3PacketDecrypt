using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace A3PacketDecrypt
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var chooseFile = new OpenFileDialog();
            DialogResult result = chooseFile.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                var fileName = path.Text = chooseFile.FileName.Split('\\')[chooseFile.FileName.Split('\\').Length - 1];
                using (var b = new BinaryReader(File.Open(chooseFile.FileName, FileMode.Open)))
                {
                    var data = b.ReadBytes((int) b.BaseStream.Length);
                    try
                    {
                        data = Crypt.Decrypt(data);
                        MyLogger.ByteArrayToFile("Decrypted_" + Environment.TickCount + "_" + fileName, data);
                        MessageBox.Show(fileName + " decrypted successfull!", "A3 Packet Decrypt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("ERROR: " + ex.Message, "A3 Packet Decrypt", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
