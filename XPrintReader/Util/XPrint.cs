using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace XPrintReader.Util
{
    class XPrint
    {

        private int DPI;


        private int page_num, current_page; //從1開始
        private int size;
        private int xoffset;
        private int yoffset;
        private int xoffset2;
        private int yoffset2;
        private int pwidth;
        private int pheight;
        private int LineNum;
        private XBlockInfo BlockInfo;
        private string FileName;
        private string RptDir;
        private int preview;

        public int isprint;
        public FileStream pFile;
        public int BlockNum;

        public void Clean()
        {
        }
        //public void PrepareImage(PreviewForm pForm)
        //{

        //}
        public void DrawTable()
        {

        }
        public void DrawLine(int xStart, int yStart, int xEnd, int yEnd, int iStyle, int iWidth)
        {

        }
        public void DrawLabel()
        {

        }
        public void OutputText(Rectangle rect, int style, int distributed, int font, int height, string data, int colgap, int rowgap)
        {

        }
        public int RowNum(Rectangle rect, int xmove, string data, int wcharcount, int bcharcount, int colgap)
        {
            return 0;
        }
        public int ColNum(Rectangle rect, int font, int xmove, int ymove, string data, int wcharcount, int bcharcount)
        {
            return 0;
        }
        public void GetBlockInfo()
        {

        }
        public void Add(string label, string data, float xdisp, float ydisp) //new
        {

        }
        public void AddReal(int field, string data, float xdisp, float ydisp)
        {

        }
        public void AddReal(string label, string data, float xdisp, float ydisp)
        {

        }
        public void AddPicture(string block, string picture, float xoffset, float yoffset, float width, float height)
        {

        }
        public void AddBarcode(string block, string barcode, float xoffset, float yoffset, float width, float height)
        {

        }
        public void AddBarcode25(string block, string barcode, float xoffset, float yoffset, float width, float height)
        {

        }
        public void NewPage()
        {

        }
        public void NewPage(string filename)
        {

        }
        public void AddLine(int style, int width, float xdisp, float ydisp, float xdisp1, float ydisp1) //add by peggy 20070402 新增任意線功能
        {

        }
        public void Draw_AddLine(int style, int width, int xdisp, int ydisp, int xdisp1, int ydisp1) //add by peggy 20070402 新增任意線功能
        {

        }
        public bool IsChinese(string data)
        {
            return false;
        }

        public XPrint()
        {

        }

        public XPrint(string filename, int IsPreview)
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void NewFile(string filename)
        {

        }
    }
}
