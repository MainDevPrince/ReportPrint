using ReportPrint.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace ReportPrint.OwnControls
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NMHDR
    {
        public IntPtr hwndFrom;
        public IntPtr idFrom;
        public int code;
    }
    
    /// <summary>
    /// Class <c>UserDataListView</c> models User Data Listview Control.
    /// ListView control uses VirtualList mode.
    /// </summary>
    public partial class UserDataListView : ListView
    {
        private IEnumerable<Model.IUserData> userDatas = null;
        private bool isInWmPaintMsg = false;
        Font fontTUG = new Font("Arial", 9f);

        public Color ColorAll_ashiage_none_bk { get; set; }
        public Color ColorAll_ashiage_none_fr { get; set; }
        public Color ColorAll_ashiage_left_bk { get; set; }
        public Color ColorAll_ashiage_left_fr { get; set; }
        public Color ColorAll_ashiage_right_bk { get; set; }
        public Color ColorAll_ashiage_right_fr { get; set; }

        /// <summary>
        /// List Of User data
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal IEnumerable<Model.IUserData> UserDatas
        {
            get { return this.userDatas; }
            set
            {
                this.userDatas = value;

                if (this.userDatas != null)
                {
                    this.VirtualListSize = this.userDatas.Count();
                }
                else
                {
                    this.VirtualListSize = 0;
                }

                myCache = null;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Selected User Data in ListView
        /// </summary>
        internal Model.IUserData SelectedUserData
        {
            get
            {
                if (SelectedIndices.Count > 0)
                {
                    int selectedIndex = SelectedIndices[0];

                    IUserData userData = (IUserData)Items[selectedIndex].Tag;

                    return userData;
                }
                else
                {
                    return null;
                }
            }
        }

        private ListViewItem[] myCache; //array to cache items for the virtual list
        private int firstItem; //stores the index of the first item in the cache

        public UserDataListView()
        {
            InitializeComponent();

            this.VirtualMode = true;
            this.OwnerDraw = true;
            this.FullRowSelect = true;
            this.DoubleBuffered = true;

            this.Columns.AddRange(new ColumnHeader[] {
                new ColumnHeader() { Text = "日付", Width = 90, TextAlign = HorizontalAlignment.Center },
                new ColumnHeader() { Text = "測定", Width = 90, TextAlign = HorizontalAlignment.Center },
                new ColumnHeader() { Text = "結果", Width = 60, TextAlign = HorizontalAlignment.Center }
            });

            this.RetrieveVirtualItem += new RetrieveVirtualItemEventHandler(OnRetrieveVirtualItem);
            this.CacheVirtualItems += new CacheVirtualItemsEventHandler(OnCacheVirtualItems);
            this.DrawColumnHeader += new DrawListViewColumnHeaderEventHandler(ListView_DrawColumnHeader);
            this.DrawItem += new DrawListViewItemEventHandler(ListView_DrawItem);
            this.DrawSubItem += new DrawListViewSubItemEventHandler(ListView_DrawSubItem);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        void OnRetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            //Caching is not required but improves performance on large sets.
            //To leave out caching, don't connect the CacheVirtualItems event 
            //and make sure myCache is null.

            //check to see if the requested item is currently in the cache
            if (myCache != null && e.ItemIndex >= firstItem && e.ItemIndex < firstItem + myCache.Length)
            {
                //A cache hit, so get the ListViewItem from the cache instead of making a new one.
                e.Item = myCache[e.ItemIndex - firstItem];
            }
            else
            {
                //A cache miss, so create a new ListViewItem and pass it back.
                e.Item = GetListViewItemFromUserIndex(e.ItemIndex);
            }
        }

        void OnCacheVirtualItems(object sender, CacheVirtualItemsEventArgs e)
        {
            //We've gotten a request to refresh the cache.
            //First check if it's really neccesary.
            if (myCache != null && e.StartIndex >= firstItem && e.EndIndex <= firstItem + myCache.Length)
            {
                //If the newly requested cache is a subset of the old cache, 
                //no need to rebuild everything, so do nothing.
                return;
            }

            //Now we need to rebuild the cache.
            firstItem = e.StartIndex;
            int length = e.EndIndex - e.StartIndex + 1; //indexes are inclusive
            myCache = new ListViewItem[length];

            //Fill the cache with the appropriate ListViewItems.
            for (int i = 0; i < length; i++)
            {
                myCache[i] = GetListViewItemFromUserIndex(i + firstItem);
            }
        }

        private ListViewItem GetListViewItemFromUserIndex(int Index)
        {
            if (this.userDatas == null ||
                this.userDatas.Count() <= Index ||
                Index < 0)
            {
                return null;
            }

            Model.IUserData userData = userDatas.ElementAt(Index);

            ListViewItem item = new ListViewItem(userData.MeasureTime.ToString("yyyy-M-d"));

            item.SubItems.Add(userData.GameTitle);
            item.SubItems.Add(userData.GameScore.ToString("#,#.0#"));
            item.Tag = userData;

            return item;
        }

        private void ListView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            // Not interested in changing the way columns are drawn - this works fine
            e.DrawDefault = true;
        }

        private void ListView_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            Model.IUserData userData = (IUserData)e.Item.Tag;

            if (userData is Model.UserDataAll)
            {
                Model.UserDataAll userAllData = (Model.UserDataAll)userData;

                if (userAllData.GameType != GameType.All_ssfive)
                {
                    if (userAllData.IsLeft == null)
                    {
                        e.Item.BackColor = ColorAll_ashiage_none_bk;
                    }
                    else
                    {
                        e.Item.BackColor = userAllData.IsLeft.Value ? ColorAll_ashiage_left_bk : ColorAll_ashiage_right_bk;
                    }
                }
            }

            if (e.Item.Selected)
            {
                // Draw the background and focus rectangle for a selected item.
                e.Graphics.FillRectangle(new SolidBrush(SystemColors.Highlight), e.Item.Bounds);
            }
            else
            {
                e.DrawBackground();
            }
        }

        private void ListView_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            Model.IUserData userData = (IUserData)e.Item.Tag;

            if (userData is Model.UserDataAll)
            {
                Model.UserDataAll userAllData = (Model.UserDataAll)userData;

                if (userAllData.GameType != GameType.All_ssfive)
                {
                    if (userAllData.IsLeft == null)
                    {
                        e.Item.ForeColor = ColorAll_ashiage_none_fr;
                    }
                    else
                    {
                        e.Item.ForeColor = userAllData.IsLeft.Value ? ColorAll_ashiage_left_fr : ColorAll_ashiage_right_fr;
                    }

                    e.SubItem.ForeColor = e.Item.ForeColor;
                }
            }
            else
            {
            }

            DrawText(e, userData);
        }

        private void DrawText(DrawListViewSubItemEventArgs e, Model.IUserData userData)
        {
            TextFormatFlags flags;
            int index = e.Item.SubItems.IndexOf(e.SubItem);
            Font font = ((e.ItemIndex == -1) ? e.Item.Font : e.SubItem.Font);
            string text = ((e.ItemIndex == -1) ? e.Item.Text : e.SubItem.Text);

            switch (index)
            {
                case 0: 
                    flags = TextFormatFlags.HorizontalCenter; 
                    break;
                case 1: 
                    flags = TextFormatFlags.HorizontalCenter;

                    if (userData.GameType == GameType.TUG)
                    {
                        //text = text.Replace("&", "&&");
                        font = fontTUG;
                    }

                    break;
                case 2: 
                    flags = TextFormatFlags.Right; 
                    break;
                default: 
                    flags = TextFormatFlags.HorizontalCenter; 
                    break;
            }

            flags |= TextFormatFlags.WordEllipsis | TextFormatFlags.NoPrefix;

            Color foreColor = ((e.ItemIndex == -1) ? e.Item.ForeColor : e.SubItem.ForeColor);
            TextRenderer.DrawText(e.Graphics, text, font, index == 0 ? e.Bounds : e.SubItem.Bounds, foreColor, flags);
        }
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x0F: // WM_PAINT
                    this.isInWmPaintMsg = true;
                    base.WndProc(ref m);
                    this.isInWmPaintMsg = false;
                    break;
                case 0x204E: // WM_REFLECT_NOTIFY
                    NMHDR nmhdr = (NMHDR)m.GetLParam(typeof(NMHDR));
                    if (nmhdr.code == -12)
                    { // NM_CUSTOMDRAW
                        if (this.isInWmPaintMsg)
                            base.WndProc(ref m);
                    }
                    else
                        base.WndProc(ref m);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
    }
}
