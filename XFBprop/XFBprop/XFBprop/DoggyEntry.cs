using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFBprop
{
    public class DoggyEntry : Entry
    {
                #region EntryType BindableProperty
        public static readonly BindableProperty EntryTypeProperty =
            BindableProperty.Create("EntryType", // 屬性名稱 
                typeof(string), // 回傳類型 
                typeof(DoggyEntry), // 宣告類型 
                "None", // 預設值 
                propertyChanged: OnEntryTypeChanged);

        private static void OnEntryTypeChanged(
            BindableObject bindable, object oldValue, object newValue)
        {
            // 取得現在控制項的物件
            var fooEntry = bindable as DoggyEntry;

            // 取得該可綁定屬性，變更前的值
            var foooldValue = (oldValue as string).ToLower();
            // 取得該可綁定屬性，變更後的值
            var foonewValue = (newValue as string).ToLower();

            #region 根據可綁定屬性設定的值內容，進行相關客製化的處理動作
            switch (foonewValue)
            {
                case "None":
                    break;
                case "email":
                    fooEntry.SetValue(PlaceholderProperty, "請輸入電子郵件");
                    fooEntry.Keyboard = Keyboard.Email;
                    fooEntry.FontSize = 20;
                    break;
                case "phone":
                    fooEntry.SetValue(PlaceholderProperty, "請輸入電話號碼");
                    fooEntry.Keyboard = Keyboard.Telephone;
                    fooEntry.FontSize = 20;
                    break;
                case "number":
                    fooEntry.SetValue(PlaceholderProperty, "請輸入數值");
                    fooEntry.Keyboard = Keyboard.Numeric;
                    fooEntry.FontSize = 20;
                    break;
                default:
                    break;
            }
            #endregion
        }

        public string EntryType
        {
            set
            {
                SetValue(EntryTypeProperty, value);
            }
            get
            {
                return (string)GetValue(EntryTypeProperty);
            }
        }
        #endregion

    }
}
