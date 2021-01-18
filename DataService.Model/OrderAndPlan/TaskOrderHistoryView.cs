using SqlSugar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iFactory.DataService.Model
{
    /// <summary>
    /// 已完成的任务单信息
    /// </summary>
    [SugarTable("task_order_history_view")]
    public class TaskOrderHistoryView : TaskOrderHistory
    {
        /// <summary>
        /// 盒子条码
        /// </summary>
        public string box_barcode { set; get; }
        /// <summary>
        /// 插入时间
        /// </summary>
        public DateTime box_insert_time { set; get; }
    }
}
