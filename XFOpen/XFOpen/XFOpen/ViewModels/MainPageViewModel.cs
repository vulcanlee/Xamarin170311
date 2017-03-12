using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;

namespace XFOpen.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
    
        #region DownloadText
        private string _DownloadText;
        /// <summary>
        /// PropertyDescription
        /// </summary>
        public string DownloadText
        {
            get { return this._DownloadText; }
            set { this.SetProperty(ref this._DownloadText, value); }
        }
        #endregion
        #region 營建署所屬景點活動清單
        private ObservableCollection<營建署所屬景點活動> _營建署所屬景點活動清單=new ObservableCollection<營建署所屬景點活動>();
        /// <summary>
        /// 營建署所屬景點活動清單
        /// </summary>
        public ObservableCollection<營建署所屬景點活動> 營建署所屬景點活動清單
        {
            get { return _營建署所屬景點活動清單; }
            set { SetProperty(ref _營建署所屬景點活動清單, value); }
        }
        #endregion

        public MainPageViewModel()
        {

        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public async void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("title"))
                Title = (string)parameters["title"] + " and Prism";

            using (var client = new HttpClient())
            {
                DownloadText = await client.GetStringAsync("http://data.gov.tw/iisi/logaccess/37612?dataUrl=http://data.moi.gov.tw/MoiOD/System/DownloadFile.aspx?DATA=D768074E-932A-4670-B908-0BE1402A7662&ndctype=JSON&ndcnid=7509");

                List<營建署所屬景點活動> fooList = JsonConvert.DeserializeObject<List<營建署所屬景點活動>>(DownloadText);

                營建署所屬景點活動清單.Clear();
                foreach (var item in fooList)
                {
                    營建署所屬景點活動清單.Add(item);
                }
            }
        }
    }


    public class 營建署所屬景點活動
    {
        public string id { get; set; }
        public string orgname { get; set; }
        public string startdate { get; set; }
        public string enddate { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string location { get; set; }
        public string contact { get; set; }
        public string extraurl { get; set; }
        public string created { get; set; }
        public string introtext { get; set; }
    }

}
