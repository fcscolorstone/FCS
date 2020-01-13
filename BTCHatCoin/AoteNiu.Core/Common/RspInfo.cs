namespace AoteNiu
{
    public class ErrorInfo
    {
        public int code { get; set; }

        public string msg { get; set; }
        public string msg_en { get; set; }
        public string msg_zh_tw { get; set; }

        public ErrorInfo(int code, string msg, string msg_en = null)
        {
            this.code = code;
            this.msg = msg;
            this.msg_en = msg_en;
        }

        public ErrorInfo()
        {
            this.code = 1000;
            this.msg = "success.";
        }
    }

    public class RspInfo
    {
        public static readonly ErrorInfo Handle_Success = new ErrorInfo(1000, "成功", "Success");

        // 客户端请求类响应码;  3000-3999
        public static readonly ErrorInfo Login_Info_Invalid = new ErrorInfo(3002, "请先登录", "Please log in");
        public static readonly ErrorInfo Request_Para_Invalid = new ErrorInfo(3006, "请求参数无效", "Invalid parameter");
    }

}
