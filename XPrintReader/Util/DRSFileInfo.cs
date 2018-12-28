using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPrintReader.Util
{
    class DRSFileInfo
    {
        public string FullFileName = string.Empty;
        public string FileName = string.Empty;
        public string[] FileFolder = new string[] { };
        public string ExtName = string.Empty;
        public DRSFileInfo()
        {

        }
        public DRSFileInfo(string filepath)
        {
            try
            {
                if (filepath.Length > 0 && File.Exists(filepath))
                {
                    //判斷是否為網路路徑
                    if (filepath.Contains("\\") && filepath.IndexOf("\\") == 0)
                    {
                        FullFileName = filepath;
                        FileName = filepath.Replace("\\", "");
                        string[] folder = FileName.Split("\"".ToCharArray());
                        if (folder.Length > 1)
                        {
                            Array.Resize(ref FileFolder, folder.Length - 1);
                        }
                        for (int i = 0; i < folder.Length; i++)
                        {
                            if (i == (folder.Length - 1))
                            {
                                FileName = folder[i];
                                if (FileName.Contains("."))
                                {
                                    FileName = FileName.Split(".".ToCharArray())[0];
                                    ExtName = FileName.Split(".".ToCharArray())[1];
                                }
                            }
                            else
                            {
                                FileFolder[i] = folder[i];
                            }
                        }
                    }
                    else if (filepath.Contains(@":\"))//本機實體路徑
                    {
                        FullFileName = filepath;
                        int srcPo = filepath.IndexOf(@":\");
                        FileName = filepath.Substring(srcPo, filepath.Length - srcPo);
                        string[] folder = FileName.Split(@"\".ToCharArray());
                        if (folder.Length > 1)
                        {
                            Array.Resize(ref FileFolder, folder.Length - 1);
                        }
                        for (int i = 0; i < folder.Length; i++)
                        {
                            if (i == (folder.Length - 1))
                            {
                                FileName = folder[i];
                                if (FileName.Contains("."))
                                {
                                    string[] f = FileName.Split(".".ToCharArray());
                                    FileName = f[0];
                                    ExtName = f[1];
                                }
                            }
                            else
                            {
                                FileFolder[i] = folder[i+1];
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
