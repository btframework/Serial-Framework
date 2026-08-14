using System;
using System.Net;
using System.Windows.Forms;

using wclCommon;

namespace ErrorInfo
{
    public partial class fmMain : Form
    {
        public fmMain()
        {
            // Allows to access errors.xml from our site.
            ServicePointManager.Expect100Continue = true;
            // SecurityProtocolType.Tls12;
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)(0xc0 | 0x300 | 0xc00);

            InitializeComponent();
        }

        private void btGetDetails_Click(object sender, EventArgs e)
        {
            if (edError.Text == "")
            {
                MessageBox.Show("Enter error code.");
                return;
            }

            Int32 Base;
            if (edError.Text.StartsWith("0x") || edError.Text.StartsWith("$"))
                Base = 16;
            else
                Base = 10;
            Int32 Err = Convert.ToInt32(edError.Text, Base);
            
            lbErrorInfo.Items.Clear();

            wclErrorInformation Info = new wclErrorInformation();
            if (!Info.Open(edPath.Text))
            {
                MessageBox.Show("Open errors definition file failed");
                return;
            }

            try
            {
                wclErrorDetails Details = new wclErrorDetails();
                if (!Info.GetDetails(Err, ref Details))
                {
                    MessageBox.Show("Unable to get error details");
                    return;
                }

                lbErrorInfo.Items.Add("Error code: 0x" + Details.Error.ToString("X8"));
                lbErrorInfo.Items.Add("Framework: " + Details.Framework);
                lbErrorInfo.Items.Add("Category: " + Details.Category);
                lbErrorInfo.Items.Add("Constant name: " + Details.Constant);
                lbErrorInfo.Items.Add(Details.Description);
            }
            finally
            {
                Info.Close();
            }
        }
    }
}
