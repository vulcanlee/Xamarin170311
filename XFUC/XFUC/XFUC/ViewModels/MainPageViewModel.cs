using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace XFUC.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        #region Name
        private EntryCheckViewModel _Name;
        /// <summary>
        /// 這個屬性，將會用於綁定到 姓名 欄位輸入
        /// </summary>
        public EntryCheckViewModel Name
        {
            get { return this._Name; }
            set { this.SetProperty(ref this._Name, value); }
        }
        #endregion

        public MainPageViewModel()
        {
            Name = new EntryCheckViewModel();
            Name.更新文字輸入盒的浮水印文字設定("Name");
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("title"))
                Title = (string)parameters["title"] + " and Prism";
        }
    }
}
