﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using iFactory.CommonLibrary;
using iFactory.DataService.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iFactoryApp.ViewModel
{
    public interface ISystemLogViewModel
    {
        void AddMewStatus(string Content, bool IsRecordToFile = true);
    }
    public class SystemLogViewModel : ViewModelBase, ISystemLogViewModel
    {
        public SystemLogViewModel()
        {

        }

        private ObservableCollection<OperateStatus> operatesCollection = new ObservableCollection<OperateStatus>();
        /// <summary>
        /// 运行日志
        /// </summary>
        public ObservableCollection<OperateStatus> OperatesCollection
        {
            set { operatesCollection = value; }
            get { return operatesCollection; }
        }

        //private Action closeAction;
        public Action CloseAction { set; get; }

        #region 全局命令
        private RelayCommand logClearCmd;
        /// <summary>
        /// 执行提交命令的方法
        /// </summary>
        public RelayCommand LogClearCmd
        {
            get
            {
                if (logClearCmd == null) return new RelayCommand(() => ExcuteClearCommand(), CanExcute);
                return logClearCmd;
            }
            set { logClearCmd = value; }
        }

        #endregion

        #region 附属方法

        /// <summary>
        /// 执行提交方法
        /// </summary>
        private void ExcuteClearCommand()
        {
            operatesCollection.Clear();
        }
        /// <summary>
        /// 是否可执行（这边用表单是否验证通过来判断命令是否执行）
        /// </summary>
        /// <returns></returns>
        private bool CanExcute()
        {
            return true;
        }

        public void AddMewStatus(string Content, bool IsRecordToFile = true)
        {
            if (operatesCollection.Count >= 500)
            {
                ObservableCollectionHelper.ClearItem<OperateStatus>(operatesCollection);
            }
            OperateStatus operateStatus = new OperateStatus(Content);
            ObservableCollectionHelper.InsertItem<OperateStatus>(operatesCollection, operateStatus);//增加记录
        }
        #endregion
    }
}
