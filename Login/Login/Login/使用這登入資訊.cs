using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login
{
   public class 使用這登入資訊 : BindableBase
    {
        #region ViewModel Property (用於在 View 中作為綁定之用)

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

        #region 帳號
        private string _帳號;
        /// <summary>
        /// 帳號
        /// </summary>
        public string 帳號
        {
            get { return this._帳號; }
            set { this.SetProperty(ref this._帳號, value); }
        }
        #endregion

        #region 密碼
        private string _密碼;
        /// <summary>
        /// 密碼
        /// </summary>
        public string 密碼
        {
            get { return this._密碼; }
            set { this.SetProperty(ref this._密碼, value); }
        }
        #endregion

        #region 記憶密碼
        private bool _記憶密碼;
        /// <summary>
        /// 記憶密碼
        /// </summary>
        public bool 記憶密碼
        {
            get { return this._記憶密碼; }
            set { this.SetProperty(ref this._記憶密碼, value); }
        }
        #endregion

        #endregion
        public 使用這登入資訊 ShallowCopy()
        {
            return (使用這登入資訊)this.MemberwiseClone();
        }

    }
}
