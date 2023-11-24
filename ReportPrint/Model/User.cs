using System;

namespace ReportPrint.Model
{
    /// <summary>
    /// Class <c>User</c> models user information in Userdata.xlsx.
    /// </summary>
    internal class User
    {
        /// <summary>
        /// ID in Userdata.xlsx
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 名前 in Userdata.xlsx
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 生年月日 in Userdata.xlsx
        /// </summary>
        public DateTime Birth { get; set; }
        /// <summary>
        /// 性別 in Userdata.xlsx
        /// </summary>
        public string Sex { get; set; }
        /// <summary>
        /// Age from 生年月日
        /// </summary>
        public int Age => DateTime.Now.Year - Birth.Year;
    }
}
