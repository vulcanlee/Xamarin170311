using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XFListView1.ViewModels
{

    public class DetailPageViewModel : BindableBase, INavigationAware
    {
        #region Repositories (遠端或本地資料存取)

        #endregion

        #region ViewModel Property (用於在 View 中作為綁定之用)

        #region Title
        private string _Title;
        /// <summary>
        /// Title
        /// </summary>
        public string Title
        {
            get { return this._Title; }
            set { this.SetProperty(ref this._Title, value); }
        }
        #endregion

        #region 姓名
        private string _;
        /// <summary>
        /// 姓名
        /// </summary>
        public string 姓名
        {
            get { return this._; }
            set { this.SetProperty(ref this._, value); }
        }
        #endregion

        #endregion

        #region Field 欄位
        public string OldName { get; set; }
        public DelegateCommand 更新Command { get; set; }

        private readonly IEventAggregator _eventAggregator;
        private readonly INavigationService _navigationService;
        #endregion

        #region Constructor 建構式
        public DetailPageViewModel(INavigationService navigationService,
            IEventAggregator eventAggregator)
        {

            #region 相依性服務注入的物件

            _eventAggregator = eventAggregator;
            _navigationService = navigationService;
            #endregion

            #region 頁面中綁定的命令
            更新Command = new DelegateCommand(async () =>
            {
                _eventAggregator.GetEvent<更新學生資料Event>().
                Publish(new 要更新的學生資料
                {
                    oldname = OldName,
                    newname = 姓名,
                });
                await _navigationService.GoBackAsync();


            });
            #endregion

            #region 事件聚合器訂閱

            #endregion
        }

        #endregion

        #region Navigation Events (頁面導航事件)
        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public async void OnNavigatedTo(NavigationParameters parameters)
        {
            var foo學生 = parameters["Stud"] as 學生;
            Title = foo學生.姓名 + "的詳細資料";
            姓名 = foo學生.姓名;
            OldName = foo學生.姓名;
            await ViewModelInit();
        }
        #endregion

        #region 設計時期或者執行時期的ViewModel初始化
        #endregion

        #region 相關事件
        #endregion

        #region 相關的Command定義
        #endregion

        #region 其他方法

        /// <summary>
        /// ViewModel 資料初始化
        /// </summary>
        /// <returns></returns>
        private async Task ViewModelInit()
        {
            await Task.Delay(100);
        }
        #endregion

    }
}
