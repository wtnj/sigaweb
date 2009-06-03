using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace SigaControls.Report
{
    class pictureResourceHandler : Gizmox.WebGUI.Common.Resources.ImageResourceHandle
    {
        public pictureResourceHandler(string filename)
        {
            this.File=filename;
        }

        public Image getImage()
        {
            return ToImage();
        }

        public Icon getIcon()
        {
            return ToIcon();
        }
    }
}
