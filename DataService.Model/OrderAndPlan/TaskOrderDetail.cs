using SqlSugar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iFactory.DataService.Model
{
    [SugarTable("task_order_detail")]
    public class TaskOrderDetail: BaseNotifyModel
    {
        public int order_id { set; get; }
        private string _box_barcode;
        /// <summary>
        /// 箱子条码
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public string box_barcode
        {
            set
            {
                _box_barcode = value;
                NotifyPropertyChanged("box_barcode");
            }
            get { return _box_barcode; }
        }

        private DateTime _insert_time;
        /// <summary>
        /// 数据插入时间
        /// </summary>
        [SugarColumn]
        public DateTime insert_time
        {
            set
            {
                _insert_time = value;
                NotifyPropertyChanged("insert_time");
            }
            get { return _insert_time; }
        }
    }
}
