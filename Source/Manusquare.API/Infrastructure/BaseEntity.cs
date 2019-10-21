using System;

namespace Manusquare.API.Infrastructure
{
    public class BaseEntity : IBaseIdentity
    {
        public DateTimeOffset Modified => default;

        public DateTimeOffset GetModifiedTime()
        {
            return Modified;
        }
    }
}