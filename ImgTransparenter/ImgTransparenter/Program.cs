using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ImgTransparenter {
    static class Program {

        public static FormTransparenter MainForm = new FormTransparenter();

        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.Run(MainForm);
        }
    }
}
