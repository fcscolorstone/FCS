using System;

namespace AoteNiu.Core
{
    public class ActionDisposable : IDisposable
    {
        readonly Action _action;

        public static readonly ActionDisposable Empty = new ActionDisposable(() => { });

        public ActionDisposable(Action action)
        {
            _action = action;
        }

        public void Dispose()
        {
            _action();
        }
    }
}
