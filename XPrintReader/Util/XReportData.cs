using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPrintReader.Util
{
    class XReportData : DRSDocData
    {

        private List<XLineInfo> xLines = new List<XLineInfo>();
        private string xReportFileName;
        public List<XLineInfo> Lines
        {
            get { return xLines; }
            internal set { xLines = value; }
        }

        public string ReportFileName
        {
            get { return xReportFileName; }
            internal set { xReportFileName = value; }
        }
        public XReportData()
        {
        }

        public void parseReport(string sContent)
        {
            try
            {
                bool flgline_info = false;
                bool flglabel_string = false;
                bool flgblock_info = false;
                bool flgpicture = false;
                bool flgbarcode = false;
                bool flgcopy = false;
                bool flgpagemethod = false;
                bool flgwatermark = false;
                bool flgcfz = false;
                bool flgprintertitle = false;
                bool flgprintername = false;

                string[] sLines = sContent.Split(Environment.NewLine.ToCharArray());
                foreach (string line in sLines)
                {
                    string[] sInfo = line.Split('\t');
                    if(sInfo[0].Length>3)
                    {
                        if(sInfo[0].Substring(0,4)==@"/dtd")
                        {
                            string[] f = sInfo[0].Split(@" ".ToCharArray());
                            xReportFileName = f[1];
                        }
                    }
                    switch (sInfo[0].ToLower())
                    {
                        case "line_info":
                            flgline_info = true;
                            flglabel_string = false;
                            flgblock_info = false;
                            flgpicture = false;
                            flgbarcode = false;
                            flgcopy = false;
                            flgpagemethod = false;
                            flgwatermark = false;
                            flgcfz = false;
                            flgprintertitle = false;
                            flgprintername = false;
                            continue;
                        case "label_string":
                            flgline_info = false;
                            flglabel_string = true;
                            flgblock_info = false;
                            flgpicture = false;
                            flgbarcode = false;
                            flgcopy = false;
                            flgpagemethod = false;
                            flgwatermark = false;
                            flgcfz = false;
                            flgprintertitle = false;
                            flgprintername = false;
                            continue;
                        case "block_info":
                            flgline_info = false;
                            flglabel_string = false;
                            flgblock_info = true;
                            flgpicture = false;
                            flgbarcode = false;
                            flgcopy = false;
                            flgpagemethod = false;
                            flgwatermark = false;
                            flgcfz = false;
                            flgprintertitle = false;
                            flgprintername = false;
                            continue;
                        case "picture":
                            flgline_info = false;
                            flglabel_string = false;
                            flgblock_info = false;
                            flgpicture = true;
                            flgbarcode = false;
                            flgcopy = false;
                            flgpagemethod = false;
                            flgwatermark = false;
                            flgcfz = false;
                            flgprintertitle = false;
                            flgprintername = false;
                            continue;
                        case "barcode":
                            flgline_info = false;
                            flglabel_string = false;
                            flgblock_info = false;
                            flgpicture = false;
                            flgbarcode = true;
                            flgcopy = false;
                            flgpagemethod = false;
                            flgwatermark = false;
                            flgcfz = false;
                            flgprintertitle = false;
                            flgprintername = false;
                            continue;
                        case "copy":
                            flgline_info = false;
                            flglabel_string = false;
                            flgblock_info = false;
                            flgpicture = false;
                            flgbarcode = false;
                            flgcopy = true;
                            flgpagemethod = false;
                            flgwatermark = false;
                            flgcfz = false;
                            flgprintertitle = false;
                            flgprintername = false;
                            continue;
                        case "pagemethod":
                            flgline_info = false;
                            flglabel_string = false;
                            flgblock_info = false;
                            flgpicture = false;
                            flgbarcode = false;
                            flgcopy = false;
                            flgpagemethod = true;
                            flgwatermark = false;
                            flgcfz = false;
                            flgprintertitle = false;
                            flgprintername = false;
                            continue;
                        case "watermark":
                            flgline_info = false;
                            flglabel_string = false;
                            flgblock_info = false;
                            flgpicture = false;
                            flgbarcode = false;
                            flgcopy = false;
                            flgpagemethod = false;
                            flgwatermark = true;
                            flgcfz = false;
                            flgprintertitle = false;
                            flgprintername = false;
                            continue;
                        case "cfz":
                            flgline_info = false;
                            flglabel_string = false;
                            flgblock_info = false;
                            flgpicture = false;
                            flgbarcode = false;
                            flgcopy = false;
                            flgpagemethod = false;
                            flgwatermark = false;
                            flgcfz = true;
                            flgprintertitle = false;
                            flgprintername = false;
                            continue;
                        case "printertitle":
                            flgline_info = false;
                            flglabel_string = false;
                            flgblock_info = false;
                            flgpicture = false;
                            flgbarcode = false;
                            flgcopy = false;
                            flgpagemethod = false;
                            flgwatermark = false;
                            flgcfz = false;
                            flgprintertitle = true;
                            flgprintername = false;
                            continue;
                        case "printername":
                            flgline_info = false;
                            flglabel_string = false;
                            flgblock_info = false;
                            flgpicture = false;
                            flgbarcode = false;
                            flgcopy = false;
                            flgpagemethod = false;
                            flgwatermark = false;
                            flgcfz = false;
                            flgprintertitle = false;
                            flgprintername = true;
                            continue;
                    }
                    //LINE_INFO線條
                    if (flgline_info)
                    {
                        string[] data = line.Split('\t');
                        if(data.Length==1)
                        {
                            if(data[0].Length==0)
                            {
                                continue;
                            }
                        }
                        XLineInfo ReportLine = new XLineInfo();
                        for (int i = 0; i < data.Length; i++)
                        {                            
                            switch (i)
                            {
                                case 0:
                                    ReportLine.Style = data[i];
                                    break;
                                case 1:
                                    ReportLine.Width = data[i];
                                    break;
                                case 2:
                                    ReportLine.SX = data[i];
                                    break;
                                case 3:
                                    ReportLine.SY = data[i];
                                    break;
                                case 4:
                                    ReportLine.EX = data[i];
                                    break;
                                case 5:
                                    ReportLine.EY = data[i];
                                    break;

                            }
                        }
                        xLines.Add(ReportLine);
                    }
                    //LABEL_STRING標籤
                    if (flglabel_string)
                    {
                    }
                    //BLOCK_INFO           
                    if (flgblock_info)
                    {
                    }
                    //PICTURE圖片
                    if (flgpicture)
                    {
                    }
                    //BARCODE條碼
                    if (flgbarcode)
                    {
                    }
                    //COPY列印範圍
                    if (flgcopy)
                    {
                    }
                    //PAGEMETHOD分頁方式
                    if (flgpagemethod)
                    {
                    }
                    //WATERMARK浮水印
                    if (flgwatermark)
                    {
                    }
                    //cfz騎縫章
                    if (flgcfz)
                    {
                    }
                    //printertitle表頭
                    if (flgprintertitle)
                    {
                    }
                    //printername印表機名稱
                    if (flgprintername)
                    {
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
