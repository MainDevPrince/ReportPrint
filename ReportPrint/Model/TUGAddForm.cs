using System;
using System.Globalization;
using System.Windows.Forms;

namespace ReportPrint.Model
{
    /// <summary>
    /// Class <c>TUGAddForm</c> is form for add TUG data to file.
    /// It uses User object.
    /// </summary>
    internal partial class TUGAddForm : Form
    {
        private readonly Model.User user;

        /// <summary>
        /// Measured Game Score
        /// </summary>
        public float GameScore { get; private set; }
        /// <summary>
        /// Measure Time in yyyy-M-d
        /// </summary>
        public DateTime MeasureTime { get { return dtpMeasureTime.Value; } }

        public TUGAddForm(Model.User user)
        {
            InitializeComponent();

            this.user = user;
        }

        private void TUGAddForm_Load(object sender, EventArgs e)
        {
            InitData();
        }

        void InitData()
        {
            CultureInfo japaneseCulture = new CultureInfo("ja-JP", true);
            japaneseCulture.DateTimeFormat.Calendar = new JapaneseCalendar();

            lbID.Text = user.ID.ToString("D8");
            lbName.Text = user.Name;
            lbSex.Text = user.Sex;
            lbBirth.Text = user.Birth.ToString("ggyy年M月d日", japaneseCulture);
        }

        private void btnTUGAdd_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxGameScore.Text))
            {
                MessageBox.Show("数値を入力する必要があります。", "警告");
                return;
            }

            if (!float.TryParse(textBoxGameScore.Text, out float value))
            {
                MessageBox.Show("数値を正確に入力する必要があります。", "警告");
                return;
            }

            this.GameScore = value;

            this.DialogResult = DialogResult.OK;
        }
    }
}
