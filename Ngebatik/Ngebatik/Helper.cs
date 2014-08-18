using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using Ngebatik.Kelas;
using Ngebatik.View_Model;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Ngebatik
{
    class Helper
    {
        public const String BASE = "http://playmybatik.com/";
        public const String img_BASE = "http://playmybatik.com/modul/mod_filosofi_batik/img_batik/";
        public static string Level = "";
        public static List<Line> hasilNgelowong;
        public static getfilosofi hasilDownload;
        public static List<Line> hasilNembok;
        public static Brush selectedColor;
        public static BitmapImage TrueGambarBatik;
        public static WriteableBitmap wbGambarBatik;
        public static string GambarBatik { get; set; }
    }
}
