using System;

namespace Manusquare.API.Infrastructure
{
    public interface IBaseIdentity
    {
        DateTimeOffset GetModifiedTime();
    }
}