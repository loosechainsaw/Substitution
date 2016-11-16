using System;

namespace Substitution
{
    public class UsingExpression<T>
        where T : IDisposable
    {
        public UsingExpression(Func<T> f)
        {
            _f = f;
        }

        public U Yield<U>(Func<T, U> accessor)
        {
            using (var disposable = _f())
            {
                return accessor(disposable);
            }
        }

        public void ExecuteSideEffect(Action<T> process)
        {
            using (var disposable = _f())
                process(disposable);
        }

        private readonly Func<T> _f;

    }
}
