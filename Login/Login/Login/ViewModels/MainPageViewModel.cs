using Newtonsoft.Json;
using PCLStorage;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Login.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        #region YourName
        private string _YourName;
        /// <summary>
        /// YourName
        /// </summary>
        public string YourName
        {
            get { return this._YourName; }
            set { this.SetProperty(ref this._YourName, value); }
        }
        #endregion

        #region YourAccount
        private string _YourAccount;
        /// <summary>
        /// YourAccount
        /// </summary>
        public string YourAccount
        {
            get { return this._YourAccount; }
            set { this.SetProperty(ref this._YourAccount, value); }
        }
        #endregion

        #region YourPassword
        private string _YourPassword;
        /// <summary>
        /// YourPassword
        /// </summary>
        public string YourPassword
        {
            get { return this._YourPassword; }
            set { this.SetProperty(ref this._YourPassword, value); }
        }
        #endregion
        使用這登入資訊 使用這登入資訊紀錄 = new 使用這登入資訊();
        public DelegateCommand SaveCommand { get; set; }

        public MainPageViewModel()
        {
            SaveCommand = new DelegateCommand(async () =>
            {
                // 取得這個應用程式的所在目錄
                IFolder rootFolder = FileSystem.Current.LocalStorage;
                // 產生要儲存資料的資料夾
                IFolder sourceFolder = await rootFolder.CreateFolderAsync("MyDatas", CreationCollisionOption.ReplaceExisting);
                // 建立要儲存資料的檔案
                IFile sourceFile = await sourceFolder.CreateFileAsync("使用這登入資訊紀錄.dat", CreationCollisionOption.ReplaceExisting);

                // 深層複製該物件的所有值
                使用這登入資訊紀錄 = new 使用這登入資訊();
                使用這登入資訊紀錄.姓名 = YourName;
                使用這登入資訊紀錄.帳號 = YourAccount;
                使用這登入資訊紀錄.密碼 = YourPassword;

                var bar使用這登入資訊紀錄 = 使用這登入資訊紀錄.ShallowCopy();
                // 若不需要記憶密碼，則不需要將密碼儲存到手機內
                // 將使用者輸入的登入資訊，序列化成為 Json 文字
                var foo使用這登入資訊紀錄 = JsonConvert.SerializeObject(bar使用這登入資訊紀錄);
                // 寫入到檔案中
                await sourceFile.WriteAllTextAsync(foo使用這登入資訊紀錄);
            });
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public async void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("title"))
                Title = (string)parameters["title"] + " and Prism";

            try
            {
                // 取得這個應用程式的所在目錄
                IFolder rootFolder = FileSystem.Current.LocalStorage;
                // 取得要讀取資料的資料夾目錄
                IFolder sourceFolder = await rootFolder.GetFolderAsync("MyDatas");
                // 判斷這個資料夾內是否有這個檔案存在
                if (await sourceFolder.CheckExistsAsync("使用這登入資訊紀錄.dat") == ExistenceCheckResult.FileExists)
                {
                    // 開啟這個檔案
                    IFile sourceFile = await sourceFolder.GetFileAsync("使用這登入資訊紀錄.dat");

                    // 將檔案內的文字都讀出來
                    string foo使用這登入資訊紀錄 = await sourceFile.ReadAllTextAsync();
                    // 將 Json 文字反序列會成為 .NET 物件
                    var bar使用這登入資訊紀錄 = JsonConvert.DeserializeObject<使用這登入資訊>(foo使用這登入資訊紀錄);

                    // 將讀出的物件，設定到檢視模型內的屬性上
                    YourName = bar使用這登入資訊紀錄.姓名;
                    YourPassword = bar使用這登入資訊紀錄.密碼;
                    YourAccount = bar使用這登入資訊紀錄.帳號;
                }
            }
            catch { }

        }
    }
}
