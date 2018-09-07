using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestProject
{
    class CustomAttribute
    {
        [Test]
        public void HandleCustomAttribute()
        {
            List<ReportType> reportTypes = Enum.GetValues(typeof(ReportType)).Cast<ReportType>().ToList();
            var members = reportTypes.Select(x=> typeof(ReportType).GetMember(x.ToString()));
            var attributes = members.Select(x=>x[0].GetCustomAttributes(typeof(ReportDescriptionAttribute), false));
            List<string> description = attributes.Select(x=>((ReportDescriptionAttribute)x[0]).Description).ToList();
        }
    }

    enum ReportType
    {
        /// 310 全部發送清單 
        /// <summary>
        /// 310 全部發送清單
        /// </summary>
        [ReportDescription("全部發送清單")]
        All = 310,

        /// 320 成功發送清單
        /// <summary>
        /// 320 成功發送清單
        /// </summary>
        [ReportDescription("成功發送清單")]
        Succeed = 320,

        /// 330 傳送中清單
        /// <summary>
        /// 330 傳送中清單
        /// </summary>
        [ReportDescription("傳送中清單")]
        Sending = 330,

        /// 340 預約簡訊清單
        /// <summary>
        /// 340 預約簡訊清單
        /// </summary>
        [ReportDescription("預約簡訊清單")]
        PreSend = 340,

        /// 350 逾期簡訊清單
        /// <summary>
        /// 350 逾期簡訊清單
        /// </summary>
        [ReportDescription("逾期簡訊清單")]
        Timeout = 350,

        /// 360 發送失敗清單
        /// <summary>
        /// 360 發送失敗清單
        /// </summary>
        [ReportDescription("發送失敗清單")]
        Fail = 360,

        /// 370 回覆簡訊清單
        /// <summary>
        /// 370 回覆簡訊清單
        /// </summary>
        [ReportDescription("回覆簡訊清單")]
        Reply = 370,
    }


    class ReportDescriptionAttribute : Attribute
    {
        public string Description { get; set; }

        public ReportDescriptionAttribute(string Description)
        {
            this.Description = Description;
        }

        public override string ToString()
        {
            return this.Description.ToString();
        }
    }
}
