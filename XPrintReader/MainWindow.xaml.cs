using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using XPrintReader.Util;
using Microsoft.VisualBasic.Devices;
using System.IO;

namespace XPrintReader
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public string strInput_filename = string.Empty;
        public string FileTempName = string.Empty;
        #region Windows Method
        public MainWindow()
        {
            strInput_filename = @"E:\temp\test.drs";
            InitializeComponent();
            Loaded += Form_Load;
        }

        private void Form_Load(object sender, RoutedEventArgs e)
        {
            try
            {
                if (strInput_filename.Length > 0)
                {
                    LoadFile(strInput_filename);
                    Close();
                }
                else
                {
                    Close();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Close();
            }
            catch (Exception ex)
            {
                throw ex;
                throw;
            }
        }
        #endregion
        #region CustomMethod
        /// <summary>
        /// 實體路徑與檔名
        /// </summary>
        /// <param name="filename"></param>
        private void LoadFile(string filename)
        {
            try
            {
                DRSFileInfo drsFI = new DRSFileInfo(filename);
                DRSDocData drsDD = new DRSDocData(drsFI);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
    }
}
