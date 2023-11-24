using ReportPrint.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace ReportPrint.OwnControls
{
    /// <summary>
    /// Class <c>UserListView</c> models User Info Listview Control.
    /// ListView control uses VirtualList mode.
    /// </summary>
    public partial class UserListView : ListView
    {
        private IEnumerable<Model.User> users = null;
        /// <summary>
        /// List Of User Information.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal IEnumerable<Model.User> Users
        {
            get { return this.users; }
            set
            {
                this.users = value;

                if (this.users != null)
                {
                    this.VirtualListSize = this.users.Count();

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
        /// Selected User in ListView
        /// </summary>
        internal Model.User SelectedUser
        {
            get
            {
                if (SelectedIndices.Count > 0)
                {
                    int selectedIndex = SelectedIndices[0];

                    User user = (User)Items[selectedIndex].Tag;

                    return user;
                }
                else
                {
                    return null;
                }
            }
        }

        private ListViewItem[] myCache; //array to cache items for the virtual list
        private int firstItem; //stores the index of the first item in the cache

        public UserListView()
        {
            InitializeComponent();

            this.FullRowSelect = true;

            this.Columns.AddRange(new ColumnHeader[] {
                new ColumnHeader() { Text = "ID", Width = 70 },
                new ColumnHeader() { Text = "名前", Width = 179 }
            });

            this.RetrieveVirtualItem += new RetrieveVirtualItemEventHandler(OnRetrieveVirtualItem);
            this.CacheVirtualItems += new CacheVirtualItemsEventHandler(OnCacheVirtualItems);
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
            if (this.users == null ||
                this.users.Count() <= Index ||
                Index < 0)
            {
                return null;
            }

            Model.User user = users.ElementAt(Index);

            ListViewItem item = new ListViewItem(user.ID.ToString());

            item.SubItems.Add(user.Name);
            item.Tag = user;

            return item;
        }
    }
}
