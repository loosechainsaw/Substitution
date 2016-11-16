using System;

namespace Substitution
{
    public static class Using
    {
        public static UsingExpression<T> From<T>(Func<T> f) where T : IDisposable => new UsingExpression<T>(f);
    }
}