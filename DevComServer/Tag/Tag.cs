﻿using System;
using System.ComponentModel;

namespace iFactory.DevComServer
{
    /// <summary>
    /// 标签基础属性接口
    /// </summary>
    public interface ITag
    {
        /// <summary>
        /// 名字
        /// </summary>
        string TagName { set; get; }
        /// <summary>
        /// 地址
        /// </summary>
        string TagAddr { set; get; }
        /// <summary>
        /// 数据类型
        /// </summary>
        TagDataType DataType { set; get; }
    }

    public class BaseTag<T> : INotifyPropertyChanged
    {
        /// <summary>
        /// Tag值写入事件
        /// </summary>
        public delegate bool TagWriteValueEvent(string Addr, T value);

        /// <summary>
        /// Tag值写入事件。当Tag所在组被激活之后，检测到值变化，自动触发此事件
        /// </summary>
        public event TagWriteValueEvent WriteValueEvent;

        protected virtual void SendWriteValueEvent(string Addr, T value)
        {
            if (this.WriteValueEvent != null && value != null)
            {
                this.WriteValueEvent(Addr, value);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanged(String propertyName)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
    /// <summary>
    /// 标签
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Tag<T> : BaseTag<T>, ITag 
    {
        public int GroupId { set; get; }
        public Tag()
        {
            GetDataType();
        }
        public Tag(string Name, string Addr)
        {
            this.TagName = Name;
            this.TagAddr = Addr;
            this.CycleRead = false;
            GetDataType();
        }
        public Tag(string Name, string Addr, bool ReadBit)
        {
            this.TagName = Name;
            this.TagAddr = Addr;
            this.CycleRead = ReadBit;
            GetDataType();
        }
        /// <summary>
        /// 周期读取标识位
        /// </summary>
        public bool CycleRead { set; get; } = false;
       
        private T _TagValue;
        /// <summary>
        /// 值
        /// </summary>
        public T TagValue
        {
            set
            {
                if (TagValue == null || !_TagValue.Equals(value))
                {
                    _TagValue = value;
                    this.SendPropertyChanged("TagValue");
                    LastTime = DateTime.Now;//最近一次更新时间
                }
            }
            get { return _TagValue; }
        }
        /// <summary>
        /// 标签的单个长度
        /// </summary>
        public int Length { set; get; }
        private string tagName;
        public string TagName
        {
            get => tagName;
            set => tagName = value;
        }
        private string tagAddr;
        public string TagAddr
        {
            get => tagAddr;
            set => tagAddr = value;
        }
        private TagDataType dataType = TagDataType.Int;
        /// <summary>
        /// 数据类型
        /// </summary>
        public TagDataType DataType
        {
            get
            {
                return dataType;

            }
            set => dataType=value;
        }
        private DateTime _LastTime=DateTime.Now;
        /// <summary>
        /// 最近一次刷新时间
        /// </summary>
        public DateTime LastTime
        {
            set
            {
                _LastTime = value;
                this.SendPropertyChanged("LastTime");
            }
            get { return _LastTime; }
        }
        /// <summary>
        /// 确定标签类型
        /// </summary>
        private void GetDataType()
        {
            Type type = _TagValue.GetType();

            if (type == typeof(bool))
            {
                dataType = TagDataType.Bool;
            }
            else if (type == typeof(short))
            {
                dataType = TagDataType.Short;
            }
            else if (type == typeof(int))
            {
                dataType = TagDataType.Int;
            }
            else if (type == typeof(float))
            {
                dataType = TagDataType.Float;
            }
            else
            {
                dataType = TagDataType.String;
            }
        }
       
        /// <summary>
        /// 写入值
        /// </summary>
        /// <param name="Value"></param>
        public void Write(T Value)
        {
            SendWriteValueEvent(this.TagAddr,Value);
        }
        /// <summary>
        /// 描述信息
        /// </summary>
       public string description { set; get; }
    }

}
