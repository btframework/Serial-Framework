using System;
using System.Windows.Forms;

using wclCommon;

namespace OsVer
{
    public partial class fmMain : Form
    {
        public fmMain()
        {
            InitializeComponent();
        }

        private void fmMain_Load(object sender, EventArgs e)
        {
            String Str;
            switch (wclOsVersion.OsType)
            {
                case wclOsType.osUnknown:
                    Str = "OS unknown";
                    break;
                case wclOsType.osMacOS:
                    Str = "Mac OS";
                    break;
                case wclOsType.osWinXP:
                    Str = "Windows XP";
                    break;
                case wclOsType.osWinVista:
                    Str = "Windows Vista";
                    break;
                case wclOsType.osWin7:
                    Str = "Windows 7";
                    break;
                case wclOsType.osWin8:
                    Str = "Windows 8";
                    break;
                case wclOsType.osWin81:
                    Str = "Windows 8.1";
                    break;
                case wclOsType.osWin10:
                    Str = "Windows 10";
                    break;
                case wclOsType.osWin11:
                    Str = "Windows 11";
                    break;
                default:
                    Str = "Undefined OS";
                    break;
            }

            Str = Str + " " + wclOsVersion.Major.ToString() + "." +
                wclOsVersion.Minor.ToString() + "." + wclOsVersion.Build.ToString();
            laOsVersion.Text = Str;
        }
    }
}
