using System;

namespace Portname.CDGamesTestTask
{
    public interface IDelete<out T>
    {
        event Action<T> DeleteEvent;
        void Delete();
    }
}