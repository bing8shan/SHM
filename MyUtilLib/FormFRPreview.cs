using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FastReport;

namespace FastReportPrint
{
    public partial class FormFRPreview : Form
    {

        public FastReport.Preview.PreviewControl pc = new FastReport.Preview.PreviewControl();
        public FormFRPreview()
        {
            InitializeComponent();
        }

        private void FormFRPreview_Load(object sender, EventArgs e)
        {
            pc.Left = 2;
            pc.Top = 2;
            pc.Width = this.Width - 15;
            pc.Height = this.Height - 35;
            this.Controls.Add(pc);

        }

        private void FormFRPreview_Resize(object sender, EventArgs e)
        {
            pc.Left = 2;
            pc.Top = 2;
            pc.Width = this.Width - 15;
            pc.Height = this.Height - 35;
        }

        public void CreateFr(Report FReport)
        {
            if (FReport != null && pc != null)
            {
                FReport.Preview = pc;
                FReport.Show();
            }
        }
    }
}
