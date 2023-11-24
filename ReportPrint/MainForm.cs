using PdfSharp.Drawing;
using PdfSharp.Pdf;
using ReportPrint.Model;
using ReportPrint.Model.Statistics;
using ReportPrint.Report;
using ReportPrinting;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ReportPrint
{
    /// <summary>
    /// Class <c>MainForm</c> is  a Main fomr of this program.
    /// </summary>
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            
            Icon = global::ReportPrint.Properties.Resources.app;

            listViewUserDatas.ColorAll_ashiage_none_bk = lbMarkNone.BackColor;
            listViewUserDatas.ColorAll_ashiage_none_fr = lbMarkNone.ForeColor;
            listViewUserDatas.ColorAll_ashiage_left_bk = lbMarkLeft.BackColor;
            listViewUserDatas.ColorAll_ashiage_left_fr = lbMarkLeft.ForeColor;
            listViewUserDatas.ColorAll_ashiage_right_bk = lbMarkRight.BackColor;
            listViewUserDatas.ColorAll_ashiage_right_fr = lbMarkRight.ForeColor;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        //Load data from data files.
        //Data file is specifed by Config.DataPath
        private int LoadData()
        {
            // Check whether path exists
            string dataPath = Config.DataPath;

            if (!Directory.Exists(dataPath))
            {
                MessageBox.Show("データ ディレクトリが存在しません。");
                return -1;
            }

            IEnumerable<User> users = Model.ModelManager.Users;

            AddUsersToListView(users);

            return users.Count();
        }

        //Add Users to list view.
        private int AddUsersToListView(IEnumerable<User> users)
        {
            listViewUsers.Users = users;
            return listViewUsers.Items.Count;
        }

        private void listViewUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            User user = listViewUsers.SelectedUser;
            bool isEnable = user != null;

            if (isEnable)
            {
                listViewUserDatas.UserDatas = Model.ModelManager.GetUserDatas(user.ID);
            }
            else
            {
                listViewUserDatas.UserDatas = null;
            }

            btnTUGAdd.Enabled = isEnable;
            buttonMakeReport.Enabled = isEnable;
            btnSavePDF.Enabled = isEnable;
            btnPrint.Enabled = isEnable;
        }

        private void listViewUserDatas_SelectedIndexChanged(object sender, EventArgs e)
        {
            IUserData userData = listViewUserDatas.SelectedUserData;
            bool isEnable = userData != null;
            bool isVisible = false;

            if (userData != null)
            {
                panelGame.Enabled = true;

                labelGameName.Text = userData.GameTitle.Replace("&", "&&"); //& is displayed as "_", so prevent it.
                textBoxGameScore.Text = userData.GameScore.ToString();

                if (userData is Model.UserDataAll)
                {
                    bool? isLeft = ((Model.UserDataAll)userData).IsLeft;
                    isVisible = true;

                    cbAllashiage.SelectedIndex = isLeft == null ? 0 : (isLeft.Value ? 1 : 2);
                }
            }
            else
            {
                panelGame.Enabled = false;
            }

            labelGameName.Enabled = isEnable;
            cbAllashiage.Visible = isVisible;
            textBoxGameScore.Enabled = isEnable;
            btnDeleteUserData.Enabled = isEnable;
            btnModifyUserData.Enabled = isEnable;
        }

        //Retrives User Datas from selected User.
        private void LoadUserDatas()
        {
            User user = listViewUsers.SelectedUser;

            listViewUserDatas.UserDatas = Model.ModelManager.GetUserDatas(user.ID);
        }

        private void btnDeleteUserData_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ユーザーデータを削除しますか？", "警告", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }

            if (UserDataFileManager.DeleteUserData(listViewUserDatas.SelectedUserData))
            {
                LoadUserDatas();
                textBoxGameScore.Text = "";
                MessageBox.Show("データが削除されました。", "通知");
            }
            else
            {
                MessageBox.Show("データの削除に失敗しました。", "警告");
            }

            LoadUserDatas();
        }

        private void btnTUGAdd_Click(object sender, EventArgs e)
        {
            TUGAddForm formAdd = new TUGAddForm(listViewUsers.SelectedUser);

            if (formAdd.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            if (UserDataFileManager.AppendTUGData(listViewUsers.SelectedUser.ID, formAdd.MeasureTime, formAdd.GameScore))
            {
                LoadUserDatas();
                MessageBox.Show("TUGデータが追加されました。", "通知");
            }
            else
            {
                MessageBox.Show("TUGデータの追加に失敗しました。", "警告");
            }
        }

        private void btnModifyUserData_Click(object sender, EventArgs e)
        {
            bool? isLeft = null;
            textBoxGameScore.Text = textBoxGameScore.Text.Trim();

            if (string.IsNullOrEmpty(textBoxGameScore.Text))
            {
                MessageBox.Show("数値を入力する必要があります。", "警告");
                return;
            }

            if (!float.TryParse(textBoxGameScore.Text, out float gameScore))
            {
                MessageBox.Show("数値を正確に入力する必要があります。", "警告");
                return;
            }

            if (cbAllashiage.Visible &&
                cbAllashiage.SelectedIndex > 0)
            {
                isLeft = cbAllashiage.SelectedIndex == 1;
            }

            if (UserDataFileManager.ModifyGameScore(listViewUserDatas.SelectedUserData, gameScore, isLeft))
            {
                LoadUserDatas();
                textBoxGameScore.Text = "";
                MessageBox.Show("データが変更されました。", "通知");
            }
            else
            {
                MessageBox.Show("データの変更に失敗しました。", "警告");
            }
        }

        private void buttonMakeReport_Click(object sender, EventArgs e)
        {
            ReportDocument reportDoc = new ReportDocument();

            StatisticItem s_item = StatisticItem.Calc(listViewUsers.SelectedUser, DateTime.Now, tbNotes.Text);

            reportDoc.ReportMaker = new Report.PrintReportIItem(s_item);

            //printPreviewControlReport.AutoZoom = true;
            printPreviewControlReport.Document = reportDoc;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            ReportDocument reportDoc = new ReportDocument();

            StatisticItem s_item = StatisticItem.Calc(listViewUsers.SelectedUser, DateTime.Now, tbNotes.Text);

            reportDoc.ReportMaker = new Report.PrintReportIItem(s_item);

            reportDoc.Print();
        }

        private void btnSavePDF_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialogPDF = new SaveFileDialog
            {
                FileName = "report",
                Filter = "PDFファイル|*.pdf"
            };

            if (saveFileDialogPDF.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            UseWaitCursor = true;

            ReportDocument document = new ReportDocument();

            StatisticItem s_item = StatisticItem.Calc(listViewUsers.SelectedUser, DateTime.Now, tbNotes.Text);

            document.ReportMaker = new Report.PrintReportIItem(s_item);

            PrintingPermission SafePrinting = new PrintingPermission(PrintingPermissionLevel.SafePrinting);
            SafePrinting.Demand();

            PrintController printController = document.PrintController;
            PreviewPrintController previewPrintController = new PreviewPrintController
            {
                UseAntiAlias = true
            };
            document.PrintController = new PrintControllerWithStatusDialog(previewPrintController, "");
            document.Print();
            PreviewPageInfo[] pageInfo = previewPrintController.GetPreviewPageInfo();
            document.PrintController = printController;

            PdfDocument pdf = new PdfDocument();

            using (MemoryStream ms = new MemoryStream())
            {
                pageInfo[0].Image.Save(ms, ImageFormat.Png);

                XImage image = XImage.FromStream(ms);

                // Creating an XGraphics object from the PDF document's page
                PdfPage page = pdf.AddPage();
                page.Size = PdfSharp.PageSize.A4;
                XGraphics graphics = XGraphics.FromPdfPage(page);

                // Drawing the image onto the PDF page
                graphics.DrawImage(image, new XRect(0, 0, page.Width, page.Height));

                pdf.Save(saveFileDialogPDF.FileName);
            }

            UseWaitCursor = false;

            MessageBox.Show("pdfファイルで保存しました。", "通知");
        }

        private void btnSettingPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog
            {
                SelectedPath = Config.DataPath
            };

            if (folderBrowserDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            Config.DataPath = folderBrowserDialog.SelectedPath;

            LoadData();
        }

        private void btnSettingGraph_Click(object sender, EventArgs e)
        {
            GraphAxisSettingForm form = new GraphAxisSettingForm();

            form.ShowDialog();
        }
    }
}
