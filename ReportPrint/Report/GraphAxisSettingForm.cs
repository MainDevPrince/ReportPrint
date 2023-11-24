using System;
using System.Windows.Forms;

namespace ReportPrint.Report
{
    /// <summary>
    /// Class <c>GraphAxisSettingForm</c> set min, max and interval value of verital axis.
    /// </summary>
    internal partial class GraphAxisSettingForm : Form
    {
        public GraphAxisSettingForm()
        {
            InitializeComponent();
        }

        private void TUGAddForm_Load(object sender, EventArgs e)
        {
            InitData();
        }

        //initialize value in config value stored in registry.
        void InitData()
        {
            numericUpDown1.Value = (decimal)Config.Axis_ashiag_y_min;
            numericUpDown2.Value = (decimal)Config.Axis_ashiag_y_max;
            numericUpDown3.Value = (decimal)Config.Axis_ashiag_y_intv;

            numericUpDown6.Value = (decimal)Config.Axis_ssfive_y_min;
            numericUpDown5.Value = (decimal)Config.Axis_ssfive_y_max;
            numericUpDown4.Value = (decimal)Config.Axis_ssfive_y_intv;

            numericUpDown9.Value = (decimal)Config.Axis_tug_y_min;
            numericUpDown8.Value = (decimal)Config.Axis_tug_y_max;
            numericUpDown7.Value = (decimal)Config.Axis_tug_y_intv;

            numericUpDown12.Value = (decimal)Config.Axis_log_y_min;
            numericUpDown11.Value = (decimal)Config.Axis_log_y_max;
            numericUpDown10.Value = (decimal)Config.Axis_log_y_intv;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value >= numericUpDown2.Value)
            {
                MessageBox.Show("最小値が最大値を超えることはできません。");
                numericUpDown1.Focus();
                return;
            }

            if (numericUpDown3.Value <= 0)
            {
                MessageBox.Show("間隔が 0 以上であることはできません。");
                numericUpDown3.Focus();
            }

            if (numericUpDown6.Value >= numericUpDown5.Value)
            {
                MessageBox.Show("最小値が最大値を超えることはできません。");
                numericUpDown6.Focus();
                return;
            }

            if (numericUpDown4.Value <= 0)
            {
                MessageBox.Show("間隔が 0 以上であることはできません。");
                numericUpDown4.Focus();
            }

            if (numericUpDown9.Value >= numericUpDown8.Value)
            {
                MessageBox.Show("最小値が最大値を超えることはできません。");
                numericUpDown9.Focus();
                return;
            }

            if (numericUpDown7.Value <= 0)
            {
                MessageBox.Show("間隔が 0 以上であることはできません。");
                numericUpDown7.Focus();
            }

            if (numericUpDown12.Value >= numericUpDown11.Value)
            {
                MessageBox.Show("最小値が最大値を超えることはできません。");
                numericUpDown12.Focus();
                return;
            }

            if (numericUpDown10.Value <= 0)
            {
                MessageBox.Show("間隔が 0 以上であることはできません。");
                numericUpDown10.Focus();
            }

            Config.Axis_ashiag_y_min = (float)numericUpDown1.Value;
            Config.Axis_ashiag_y_max = (float)numericUpDown2.Value;
            Config.Axis_ashiag_y_intv = (float)numericUpDown3.Value;

            Config.Axis_ssfive_y_min = (float)numericUpDown6.Value;
            Config.Axis_ssfive_y_max = (float)numericUpDown5.Value;
            Config.Axis_ssfive_y_intv = (float)numericUpDown4.Value;

            Config.Axis_tug_y_min = (float)numericUpDown9.Value;
            Config.Axis_tug_y_max = (float)numericUpDown8.Value;
            Config.Axis_tug_y_intv = (float)numericUpDown7.Value;

            Config.Axis_log_y_min = (float)numericUpDown12.Value;
            Config.Axis_log_y_max = (float)numericUpDown11.Value;
            Config.Axis_log_y_intv = (float)numericUpDown10.Value;

            this.DialogResult = DialogResult.OK;
        }
    }
}
