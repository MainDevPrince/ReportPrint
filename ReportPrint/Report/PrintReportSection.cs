using ReportPrint.Model;
using ReportPrint.Model.Statistics;
using ReportPrint.Report.Charts;
using ReportPrinting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;

namespace ReportPrint.Report
{
    /// <summary>
    /// Class <c>PrintReportSection</c> implements section for making Report.
    /// </summary>
    internal class PrintReportSection : ReportSection
    {
        StatisticItem s_item;

        const int xLeftMargin = 105;
        const int xWidth = 2252;

        //chart for 片足立ち
        LineChart chart_ashiage = new LineChart() { Caption = Config.TitleOfAll_ashiage, YLabel = $"({Config.TitleOfAll_ashiage_unit})" };
        Legend legend_ashiage = new Legend();
        DataCollection dc_ashiage = new DataCollection();
        //chart for 立ち座り
        LineChart chart_ssfive = new LineChart() { Caption = Config.TitleOfAll_ssfive, YLabel = $"({Config.TitleOfAll_ssfive_unit})" };
        DataCollection dc_ssfive = new DataCollection();
        //chart for TUG
        LineChart chart_tug = new LineChart() { Caption = Config.TitleOfTUG, YLabel = $"({Config.TitleOfTUG_unit})" };
        DataCollection dc_tug = new DataCollection();
        //chart for 姿勢
        LineChart chart_log = new LineChart() { Caption = Config.TitleOfCarePitLog, YLabel = $"({Config.TitleOfCarePitLog_unit})" };
        DataCollection dc_log = new DataCollection();

        public PrintReportSection(StatisticItem s_item)
        {
            this.UseFullHeight = true;
            this.UseFullWidth = true;

            this.s_item = s_item;

            InitChat();
        }

        void InitChat()
        {
            chart_ashiage.ChartArea = new Rectangle(0, 0, 1120, 560);
            chart_ashiage.FirstMonth = s_item.CalcMonth;
            legend_ashiage.IsLegendVisible = true;
            chart_ashiage.YLimitMin = Config.Axis_ashiag_y_min;
            chart_ashiage.YLimitMax = Config.Axis_ashiag_y_max;
            chart_ashiage.YTick = Config.Axis_ashiag_y_intv;
            dc_ashiage.Add(
                new DataSeries()
                {
                    SeriesName = Config.TitleOfAll_ashiage_right,
                    PointList = GetPointsFromIndex((int)GameType.All_ashiage_right)
                }
            );
            dc_ashiage.Add(
                new DataSeries()
                {
                    SeriesName = Config.TitleOfAll_ashiage_left,
                    PointList = GetPointsFromIndex((int)GameType.All_ashiage_left)
                }
            );
            dc_ashiage.DataSeriesList[1].Symbol.SymbolType = SymbolTypeEnum.Circle;

            chart_ssfive.ChartArea = new Rectangle(xWidth - 1120, 0, 1120, 560);
            chart_ssfive.FirstMonth = s_item.CalcMonth;
            chart_ssfive.YLimitMin = Config.Axis_ssfive_y_min;
            chart_ssfive.YLimitMax = Config.Axis_ssfive_y_max;
            chart_ssfive.YTick = Config.Axis_ssfive_y_intv;
            dc_ssfive.Add(
                new DataSeries()
                {
                    PointList = GetPointsFromIndex((int)GameType.All_ssfive)
                });

            chart_tug.ChartArea = new Rectangle(0, 608, 1120, 560);
            chart_tug.FirstMonth = s_item.CalcMonth;
            chart_tug.YLimitMin = Config.Axis_tug_y_min;
            chart_tug.YLimitMax = Config.Axis_tug_y_max;
            chart_tug.YTick = Config.Axis_tug_y_intv;
            dc_tug.Add(
                new DataSeries()
                {
                    PointList = GetPointsFromIndex((int)GameType.TUG)
                });

            chart_log.ChartArea = new Rectangle(xWidth - 1120, 608, 1120, 560);
            chart_log.FirstMonth = s_item.CalcMonth;
            chart_log.YLimitMin = Config.Axis_log_y_min;
            chart_log.YLimitMax = Config.Axis_log_y_max;
            chart_log.YTick = Config.Axis_log_y_intv;
            dc_log.Add(
                new DataSeries()
                {
                    PointList = GetPointsFromIndex((int)GameType.CarePitLog)
                });
        }

        /// <summary>
        /// Get chart points from statistic value.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private List<PointF> GetPointsFromIndex(int index)
        {
            List<PointF> points = new List<PointF>();

            for (int i = 0; i < 12; i++)
            {
                if (Single.IsNaN(this.s_item.Values[index, i]))
                    continue;

                points.Add(new PointF(i + 1, this.s_item.Values[index, i]));
            }

            return points;
        }

        /// <summary>
        /// Setup for printing (do nothing)
        /// </summary>
        /// <param name="g">Graphics object</param>
        protected override void DoBeginPrint(Graphics g)
        {
        }

        protected override SectionSizeValues DoCalcSize(
            ReportDocument reportDocument,
            Graphics g,
            Bounds bounds
            )
        {
            SectionSizeValues retval = new SectionSizeValues();

            retval.Fits = true;

            return retval;
        }

        protected override void DoPrint(
            ReportDocument reportDocument,
            Graphics g,
            Bounds bounds
            )
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;

            DrawSkelton(g);
        }

        /// <summary>
        /// Draw skelton of Report Section.
        /// </summary>
        /// <param name="g">Graphics</param>
        private void DrawSkelton(Graphics g)
        {
            TransformGraphic(g, xLeftMargin, 74);
            DrawTitle(g);

            TransformGraphic(g, 0, 1 + 110);
            DrawInfo(g);

            TransformGraphic(g, 0, 40 + 285);
            DrawStatistics(g);

            TransformGraphic(g, 0, 48 + 642);
            DrawCharts(g);
            //charts region

            TransformGraphic(g, 0, 40 + 560 + 608);
            DrawNotes(g);
        }

        /// <summary>
        /// Draw Title of report section.
        /// </summary>
        /// <param name="g">Graphics</param>
        private void DrawTitle(Graphics g)
        {
            g.DrawHalfRoundedRectangle(0, 0, 700, 110, 23, new SolidBrush(Color.FromArgb(108, 108, 99)));

            Font fontTitle = new Font(Config.PrintFontName, 16, FontStyle.Regular);
            g.DrawString("身体機能測定結果", fontTitle, Brushes.White, new Point(70, 20));
        }

        /// <summary>
        /// Draw user information to Report Section.
        /// </summary>
        /// <param name="g">Graphics</param>
        private void DrawInfo(Graphics g)
        {
            Font font1 = new Font(Config.PrintFontName, 11, FontStyle.Bold);
            Font font2 = new Font(Config.PrintFontName, 11, FontStyle.Bold);
            Pen pen = new Pen(Color.Black, 3);
            CultureInfo japaneseCulture = new CultureInfo("ja-JP");
            japaneseCulture.DateTimeFormat.Calendar = new JapaneseCalendar();

            StringFormat stringFormatName = new StringFormat()
            {
                Alignment = StringAlignment.Far,
            };

            g.FillRoundRect(new SolidBrush(Color.FromArgb(197, 193, 183)), 0, 0, xWidth, 285, 25, 25, 23, 6);

            g.DrawString("ご利用者様氏名", font1, Brushes.Black, new Point(30, 30));
            g.DrawString($"(ID： {s_item.UserInfo.ID.ToString("D8")}  )", font2, Brushes.Black, new Point(430, 30));
            g.DrawString("様", font1, Brushes.Black, new Point(900, 190));
            g.DrawString(s_item.UserInfo.Name, font2, Brushes.Black, new Point(885, 190), stringFormatName);
            g.DrawLine(pen, 60, 250, 1010, 250);
            g.DrawString("生年月日", font1, Brushes.Black, new Point(1095, 30));
            g.DrawString(s_item.UserInfo.Birth.ToString("ggyy年M月d日", japaneseCulture), font2, Brushes.Black, new Point(1125, 85));
            g.DrawLine(pen, 1095, 150, 1800, 150);
            g.DrawString("年齢", font1, Brushes.Black, new Point(1850, 30));
            g.DrawString($"{s_item.UserInfo.Age}歳", font2, Brushes.Black, new Point(1860, 85));
            g.DrawLine(pen, 1850, 150, 2190, 150);

            g.DrawString("性別", font1, Brushes.Black, new Point(1095, 170));
            g.DrawString(s_item.UserInfo.Sex, font2, Brushes.Black, new Point(1260, 190));
            g.DrawLine(pen, 1095, 250, 1445, 250);
            g.DrawString("作成日", font1, Brushes.Black, new Point(1460, 170));
            g.DrawString(DateTime.Now.ToString("ggyy年M月d日", japaneseCulture), font2, Brushes.Black, new Point(1680, 190));
            g.DrawLine(pen, 1460, 250, 2190, 250);
        }

        /// <summary>
        /// Draw Statistic value to table.
        /// </summary>
        /// <param name="g">Graphics</param>
        private void DrawStatistics(Graphics g)
        {
            g.FillRoundRect(new SolidBrush(Color.FromArgb(152, 148, 140)), 0, 0, xWidth, 642, 10, 10, 32, 24);

            TransformGraphic(g, 136, 64);

            StaticsTable tbl = new StaticsTable(this.s_item);

            tbl.Draw(g);

            TransformGraphic(g, -136, -64);
        }

        /// <summary>
        /// Draw chart to Report Section.
        /// </summary>
        /// <param name="g">Graphics</param>
        private void DrawCharts(Graphics g)
        {
            chart_ashiage.AddChartStyle(g);
            dc_ashiage.AddLines(g, chart_ashiage);
            legend_ashiage.AddLegend(g, dc_ashiage, chart_ashiage);

            chart_ssfive.AddChartStyle(g);
            dc_ssfive.AddLines(g, chart_ssfive);

            chart_tug.AddChartStyle(g);
            dc_tug.AddLines(g, chart_tug);

            chart_log.AddChartStyle(g);
            dc_log.AddLines(g, chart_log);
        }

        /// <summary>
        /// Draw Notes to Report Section.
        /// </summary>
        /// <param name="g">Graphics</param>
        private void DrawNotes(Graphics g)
        {
            Font fontNotes = new Font(Config.PrintFontName, 12, FontStyle.Bold);

            g.FillRoundRect(new SolidBrush(Color.FromArgb(197, 193, 183)), 0, 0, xWidth, 826, 25, 25, 23, 6);

            g.DrawString("備考：", fontNotes, Brushes.Black, new Point(50, 60));
            g.DrawString(this.s_item.Notes, fontNotes, Brushes.Black, new Point(200, 60));
        }

        /// <summary>
        /// Transforms from logical coordinates to phsical coordinates.
        /// </summary>
        /// <param name="g">Graphics</param>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        void TransformGraphic(Graphics g, int x, int y)
        {
            var transform = g.Transform;

            transform.Translate(x, y, MatrixOrder.Append);

            g.Transform = transform;
        }
    }
}
