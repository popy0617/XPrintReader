using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPrintReader.Util
{
    class XBlockInfo
    {
        private string _style;
        private string _left;
        private string _top;
        private string _width;
        private string _height;
        private string _rowgap;
        private string _colgap;
        private string _distributed;
        private string _font;
        private string _ychar;
        private string _xmargin;
        private string _ymargin;
        private string _name;
        /// <summary>
        /// 樣式
        /// </summary>
        public string Style
        {
            get { return _style; }
            internal set { _style = value; }
        }
        /// <summary>
        /// 左上角Y座標
        /// </summary>
        public string Left
        {
            get { return _left; }
            internal set { _left = value; }
        }
        /// <summary>
        /// 左上角X座標
        /// </summary>
        public string Top
        {
            get { return _top; }
            internal set { _top = value; }
        }
        /// <summary>
        /// 寬度
        /// </summary>
        public string Width
        {
            get { return _width; }
            internal set { _width = value; }
        }
        /// <summary>
        /// 高度
        /// </summary>
        public string Height
        {
            get { return _height; }
            internal set { _height = value; }
        }
        /// <summary>
        /// 資料列距
        /// </summary>
        public string Rowgap
        {
            get { return _rowgap; }
            internal set { _rowgap = value; }
        }
        /// <summary>
        /// 資料行距
        /// </summary>
        public string Colgap
        {
            get { return _colgap; }
            internal set { _colgap = value; }
        }
        /// <summary>
        /// 分佈方式
        /// </summary>
        public string Distributed
        {
            get { return _distributed; }
            internal set { _distributed = value; }
        }
        /// <summary>
        /// 字型
        /// </summary>
        public string Font
        {
            get { return _font; }
            internal set { _font = value; }
        }
        /// <summary>
        /// 字型高度 FontHeight
        /// </summary>
        public string Ychar
        {
            get { return _ychar; }
            internal set { _ychar = value; }
        }
        /// <summary>
        /// block 框與資料的間距 -- X軸
        /// </summary>
        public string Xmargin
        {
            get { return _xmargin; }
            internal set { _xmargin = value; }
        }
        /// <summary>
        /// block 框與資料的間距 -- Y軸
        /// </summary>
        public string Ymargin
        {
            get { return _ymargin; }
            internal set { _ymargin = value; }
        }
        /// <summary>
        /// 名稱
        /// </summary>
        public string Name
        {
            get { return _name; }
            internal set { _name = value; }
        }

        public XBlockInfo()
        {

        }
    }
}
