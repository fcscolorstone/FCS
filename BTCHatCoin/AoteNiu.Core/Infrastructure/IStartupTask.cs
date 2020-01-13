/// 自处理任务接口 -- 预留

namespace AoteNiu.Core.Infrastructure
{
    public interface IStartupTask
    {
        void Execute();

        int Order
        {
            get;
        }
    }
}
