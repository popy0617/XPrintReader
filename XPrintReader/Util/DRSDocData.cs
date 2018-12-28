using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPrintReader.Util
{
    class DRSDocData
    {
        #region Data Member
        private XContentData _content = null;
        private XReportData _report = null;
        #endregion

        public XContentData Content
        {
            get { return _content; }
        }

        public XReportData Report
        {
            get { return _report; }
        }
        public DRSDocData()
        {

        }

        public DRSDocData(string filepath)
        {
            try
            {
                _content = new XContentData();
                _report = new XReportData();

                parseDoc(filepath);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DRSDocData(DRSFileInfo drsFI)
        {
            try
            {
                _content = new XContentData();
                _report = new XReportData();

                parseDoc(drsFI.FullFileName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void parseDoc(string filepath)
        {
            try
            {
                if (!File.Exists(filepath))
                {
                    return;
                }
                FileInfo fi = new FileInfo(filepath);
                byte[] file = File.ReadAllBytes(filepath);
                EncodingUtilities ET = new EncodingUtilities();
                string line;
                string sReport = string.Empty;
                string sContent = string.Empty;
                bool boolReportSection = false;
                bool boolContentSection = true;

                using (StreamReader sr = new StreamReader(new MemoryStream(file), ET.CheckFileEncoding(filepath), false))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line.Length > 3 && line.Substring(0, 4) == @"/dtd")
                        {
                            boolReportSection = !boolReportSection;
                            boolContentSection = !boolContentSection;
                        }
                        if (boolReportSection)
                        {
                            if (sReport.Length > 0)
                            {
                                sReport += Environment.NewLine;
                            }
                            sReport += line;
                        }
                        if (boolContentSection)
                        {
                            if (sContent.Length > 0)
                            {
                                sContent += Environment.NewLine;
                            }
                            sContent += line;
                        }
                    }
                    //報表檔
                    if (sReport.Length > 0)
                    {
                        Report.parseReport(sReport);
                    }
                    //資料檔
                    if (sContent.Length > 0)
                    {
                        Content.parseContent(sContent);
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
