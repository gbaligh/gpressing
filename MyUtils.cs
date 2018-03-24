using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace GP
{
    class MyUtils
    {
        #region Read Photo from filesystem
        public string PhotoPath()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            string strFName = string.Empty;

            dlg.Title = "Open Photo";
            dlg.Filter = "Windows Bitmap Files (*.bmp)|*.bmp"
                + "|png Files (*.png)|*.png"
                + "|gif Files (*.gif)|*.gif"
                + "|jpg Files (*.jpg)|*.jpg"
                + "|All files (*.*)|*.*";

            dlg.InitialDirectory = Application.StartupPath;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //pbxPhoto.Image = new Bitmap(dlg.OpenFile());
                    strFName = dlg.FileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unable to load file: " + ex.Message);
                }
            }

            return strFName;
            //dlg.Dispose();
        }
        #endregion

        #region Read Image into Byte Array from Filesystem
        public byte[] GetPhoto(string filePath)
        {
            //if (filePath == string.Empty) return ;
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(new BufferedStream(fs));

            byte[] photo;
            try
            {
                photo = br.ReadBytes((Int32)fs.Length);
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                br.Close();
                fs.Close();
            }

            return photo;
        }
        #endregion

        #region Get Host
        public string getHostName()
        {
            string hostName = Dns.GetHostName();
            return hostName;
        }
        #endregion

    }
}
