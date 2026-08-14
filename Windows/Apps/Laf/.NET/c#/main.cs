using System;
using System.Collections.Generic;
using System.Windows.Forms;

using wclCommon;

namespace LafManager
{
    public partial class fmMain : Form
    {
        public fmMain()
        {
            InitializeComponent();
        }

        private void FormLoad(Object sender, EventArgs e)
        {
            String Pfn;
            String AppName;
            String Publisher;
            Int32 Res = wclLafManager.GetIdentity(out Pfn, out AppName, out Publisher);
            if (Res != wclErrors.WCL_E_SUCCESS)
                lbLog.Items.Add("Get identity failed: 0x" + Res.ToString("X8"));
            else
            {
                lbLog.Items.Add("PFN: " + Pfn);
                lbLog.Items.Add("AppName: " + AppName);
                lbLog.Items.Add("Publisher: " + Publisher);

                List<String> Laf = new List<String>();
                Res = wclLafManager.Enum(Laf);
                if (Res != wclErrors.WCL_E_SUCCESS)
                    lbLog.Items.Add("Enum LAF failed: 0x" + Res.ToString("X8"));
                else
                {
                    if (Laf.Count == 0)
                        lbLog.Items.Add("No LAF found");
                    else
                    {
                        for (Int32 i = 0; i < Laf.Count; i++)
                            cbLaf.Items.Add(Laf[i]);

                        cbLaf.SelectedIndex = 0;
                    }
                }
            }
        }

        private void btUnlockClick(object sender, EventArgs e)
        {
            if (cbLaf.SelectedIndex == -1)
                lbLog.Items.Add("No LAF found");
            else
            {
                String Laf = cbLaf.Text;
                Int32 Res = wclLafManager.Unlock(Laf);
                if (Res != wclErrors.WCL_E_SUCCESS)
                    lbLog.Items.Add("Unlock " + Laf + " failed: 0x" + Res.ToString("X8"));
                else
                    lbLog.Items.Add("LAF " + Laf + " unlocked");
            }
        }
    }
}
