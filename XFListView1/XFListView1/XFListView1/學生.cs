using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFListView1
{
    public class 學生 : BindableBase
    {

        #region 姓名
        private string _姓名;
        /// <summary>
        /// 姓名
        /// </summary>
        public string 姓名
        {
            get { return this._姓名; }
            set { this.SetProperty(ref this._姓名, value); }
        }
        #endregion

    }
}
