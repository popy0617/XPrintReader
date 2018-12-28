using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPrintReader.Util
{
    class XContentData
    {
        private string xReportFileName;
        private List<XLineInfo> addLines = new List<XLineInfo>();
        public XContentData()
        {

        }

        public void parseContent(string sContent)
        {
            try
            {
                //addline線條
                //addpicture圖片
                //addbarcode條碼
                //add資料
                //newpage新頁

                    bool flgAddline = false;
                    bool flgAdddata = false;
                    bool flgAddpicture = false;
                    bool flgAddbarcode = false;
                bool flgAddnewpage = false;

                    string[] sLines = sContent.Split(Environment.NewLine.ToCharArray());
                    foreach (string line in sLines)
                    {
                        string[] sInfo = line.Split('\t');
                        if (sInfo[0].Length > 3)
                        {
                            if (sInfo[0].Substring(0, 4) == @"/init")
                            {
                                string[] f = sInfo[0].Split(@" ".ToCharArray());
                                xReportFileName = f[1];
                            }
                        }
                        #region 判讀目前讀取區段
                        switch (sInfo[0].ToLower())
                        {
                            case "/addline":
                                flgAddline = true;
                                flgAdddata = false;
                                flgAddpicture = false;
                                flgAddbarcode = false;
                                flgAddnewpage = false;
                                continue;
                            case "/add":
                            flgAddline = false;
                            flgAdddata = true;
                            flgAddpicture = false;
                            flgAddbarcode = false;
                            flgAddnewpage = false;
                            continue;
                            case "/addpicture":
                            flgAddline = false;
                            flgAdddata = false;
                            flgAddpicture = true;
                            flgAddbarcode = false;
                            flgAddnewpage = false;
                            continue;
                            case "/addbarcode":
                            flgAddline = false;
                            flgAdddata = false;
                            flgAddpicture = false;
                            flgAddbarcode = true;
                            flgAddnewpage = false;
                            continue;
                            case "/newpage":
                            flgAddline = false;
                            flgAdddata = false;
                            flgAddpicture = false;
                            flgAddbarcode = false;
                            flgAddnewpage = true;
                            continue;                            
                        }
                        #endregion
                        #region Add LINE線條
                        //LINE_INFO線條
                        if (flgAddline)
                        {
                            string[] data = line.Split(' ');
                            if (data.Length == 1)
                            {
                                if (data[0].Length == 0)
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
                            addLines.Add(ReportLine);
                        }
                        #endregion
                        #region LABEL_STRING標籤
                        //LABEL_STRING標籤
                        if (flgAdddata)
                        {
                            string[] data = line.Split(' ');
                            if (data.Length == 1)
                            {
                                if (data[0].Length == 0)
                                {
                                    continue;
                                }
                            }
                            XBlockInfo blockString = new XBlockInfo();
                            for (int i = 0; i < data.Length; i++)
                            {
                                switch (i)
                                {
                                    case 0:
                                        blockString.Style = data[i];
                                        break;
                                    case 1:
                                        blockString.Left = data[i];
                                        break;
                                    case 2:
                                        blockString.Top = data[i];
                                        break;
                                    case 3:
                                        blockString.Width = data[i];
                                        break;
                                    case 4:
                                        blockString.Height = data[i];
                                        break;
                                    case 5:
                                        blockString.Rowgap = data[i];
                                        break;
                                    case 6:
                                        blockString.Colgap = data[i];
                                        break;
                                    case 7:
                                        blockString.Distributed = data[i];
                                        break;
                                    case 8:
                                        blockString.Font = data[i];
                                        break;
                                    case 9:
                                        blockString.Ychar = data[i];
                                        break;
                                    case 10:
                                        blockString.Xmargin = data[i];
                                        break;
                                    case 11:
                                        blockString.Ymargin = data[i];
                                        break;
                                    case 12:
                                        blockString.TextValue = data[i];
                                        break;
                                }
                            }
                            xBlockString.Add(blockString);
                        }
                        #endregion
                        #region BLOCK_INFO  
                        //BLOCK_INFO           
                        if (flgblock_info)
                        {
                            string[] data = line.Split('\t');
                            if (data.Length == 1)
                            {
                                if (data[0].Length == 0)
                                {
                                    continue;
                                }
                            }
                            XBlockInfo blockInfo = new XBlockInfo();
                            for (int i = 0; i < data.Length; i++)
                            {
                                switch (i)
                                {
                                    case 0:
                                        blockInfo.Style = data[i];
                                        break;
                                    case 1:
                                        blockInfo.Left = data[i];
                                        break;
                                    case 2:
                                        blockInfo.Top = data[i];
                                        break;
                                    case 3:
                                        blockInfo.Width = data[i];
                                        break;
                                    case 4:
                                        blockInfo.Height = data[i];
                                        break;
                                    case 5:
                                        blockInfo.Rowgap = data[i];
                                        break;
                                    case 6:
                                        blockInfo.Colgap = data[i];
                                        break;
                                    case 7:
                                        blockInfo.Distributed = data[i];
                                        break;
                                    case 8:
                                        blockInfo.Font = data[i];
                                        break;
                                    case 9:
                                        blockInfo.Ychar = data[i];
                                        break;
                                    case 10:
                                        blockInfo.Xmargin = data[i];
                                        break;
                                    case 11:
                                        blockInfo.Ymargin = data[i];
                                        break;
                                    case 12:
                                        blockInfo.TextValue = data[i];
                                        break;
                                }
                            }
                            xBlockInfo.Add(blockInfo);
                        }
                        #endregion
                        #region PICTURE圖片
                        //PICTURE圖片
                        if (flgpicture)
                        {
                        }
                        #endregion
                        #region BARCODE條碼
                        //BARCODE條碼
                        if (flgbarcode)
                        {
                        }
                        #endregion
                        #region COPY列印範圍
                        //COPY列印範圍
                        if (flgcopy)
                        {
                        }
                        #endregion
                        #region PAGEMETHOD分頁方式
                        //PAGEMETHOD分頁方式
                        if (flgpagemethod)
                        {
                        }
                        #endregion
                        #region WATERMARK浮水印
                        //WATERMARK浮水印
                        if (flgwatermark)
                        {
                        }
                        #endregion
                        #region cfz騎縫章
                        //cfz騎縫章
                        if (flgcfz)
                        {
                        }
                        #endregion
                        #region printertitle表頭
                        //printertitle表頭
                        if (flgprintertitle)
                        {
                        }
                        #endregion
                        #region printername印表機名稱
                        //printername印表機名稱
                        if (flgprintername)
                        {
                        }
                        #endregion
                    }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
