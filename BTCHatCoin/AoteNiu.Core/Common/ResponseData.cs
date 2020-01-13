using System;

namespace AoteNiu
{
    public class ResponseData
    {
        private int _code;
        private string _msg;
        private object _data;

        public ResponseData()
        {
            _code = RspInfo.Handle_Success.code;
            _msg = GetLangMessage(RspInfo.Handle_Success, Lang.Chinese);
        }

        public ResponseData(string lang = Lang.Chinese)
        {
            _code = RspInfo.Handle_Success.code;
            _msg = GetLangMessage(RspInfo.Handle_Success, lang);
        }

        public ResponseData(object data, string lang = Lang.Chinese)
        {
            _code = RspInfo.Handle_Success.code;
            _msg = GetLangMessage(RspInfo.Handle_Success, lang);

            _data = data;
        }

        public ResponseData(ErrorInfo info, string lang = Lang.Chinese)
        {
            var err = CommonHelper.GetRspInfo(info);
            if (null != err)
            {
                _code = err.code;
                _msg = GetLangMessage(err, lang);
            }
            else
            {
                _code = info.code;
                _msg = GetLangMessage(info, lang);
            }
        }

        public ResponseData(ErrorInfo info, object data)
        {
            _code = info.code;
            _msg = info.msg;
            _data = data;
        }

        public static string GetLangMessage(ErrorInfo info, string lang)
        {
            lang = lang?.ToLower()??string.Empty;

            if (lang == Lang.Chinese || lang == Lang.Chinese_Simple)
            {
                return info.msg;
            }
            else if (lang == Lang.Chinese_Traditional || lang == Lang.Chinese_TraditionalR)
            {
                return info.msg_zh_tw;
            }
            else if (lang == Lang.English)
            {
                return info.msg_en;
            }

            return info.msg;
        }

        public int code
        {
            get { return this._code; }
            set { this._code = value; }
        }

        public string msg
        {
            get { return this._msg; }
            set { this._msg = value; }
        }

        public object data
        {
            get { return this._data; }
            set { this._data = value; }
        }
    }
}
