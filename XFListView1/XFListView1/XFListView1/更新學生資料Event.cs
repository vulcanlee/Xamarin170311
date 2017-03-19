using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Events;

namespace XFListView1
{
    public class 要更新的學生資料
    {
        public string oldname { get; set; }
        public string newname { get; set; }
    }
    public  class 更新學生資料Event :PubSubEvent<要更新的學生資料>
    {
    }
}
