using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPrintReader.Util
{
    class XLineInfo
    {
        private string _style;
        private string _width;
        private string _SX;
        private string _SY;
        private string _EX;
        private string _EY;

        public string Style
        {
            get { return _style; }
            internal set { _style = value; }
        }
        public string Width
        {
            get { return _width; }
            internal set { _width = value; }
        }
        public string SX
        {
            get { return _SX; }
            internal set { _SX = value; }
        }
        public string SY
        {
            get { return _SY; }
            internal set { _SY = value; }
        }

        public string EX
        {
            get { return _EX; }
            internal set { _EX = value; }
        }

        public string EY
        {
            get { return _EY; }
            internal set { _EY = value; }
        }

        public XLineInfo()
        {

        }
    }
}
