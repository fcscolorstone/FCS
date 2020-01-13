using Nethereum.Util;
using System.Collections.Generic;

namespace AoteNiu.Service
{
    public class SEvent
    {
        public const string SEvent_ZipFile = "SEvent_ZipFile";
        public const string SEvent_CacheChangedEvent = "SEvent_CacheChangedEvent";
        public const string SEvent_BlockTranEvent = "SEvent_BlockTranEvent";
        public const string SEvent_SyncBlockEvent = "SEvent_SyncBlockEvent";
        public const string SEvent_FlushEthereumBalanceEvent = "SEvent_FlushEthereumBalanceEvent";

        public const string SEvent_NodeUTakeEvent = "SEvent_NodeUTakeEvent";
        public const string SEvent_NodeUChargeEvent = "SEvent_NodeUChargeEvent";
        public const string SEvent_NodeSuperBounsEvent = "SEvent_NodeSuperBounsEvent";

        public const string SEvent_RedPacketEvent = "SEvent_RedPacketEvent";
        public const string SEvent_RedPacketPayProtocolEvent = "SEvent_RedPacketPayProtocolEvent";
    }

    public class ZipFileEvent
    {
        /// <summary>
        /// 放单号
        /// </summary>
        public string ktaskno { get; set; }

        /// <summary>
        /// 待压缩的文件附件
        /// </summary>
        public List<string> attchments { get; set; }

        /// <summary>
        /// 压缩后的文件名
        /// </summary>
        public string zipfile { get; set; }

        /// <summary>
        /// 处理路径
        /// </summary>
        public string handlePath { get; set; }
    }
}
