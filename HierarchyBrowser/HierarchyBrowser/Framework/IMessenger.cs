using System;

namespace HierarchyBrowser.Framework
{
    internal interface IMessenger
    {
        void Register<TMessage>(object recipient, Action<TMessage> action);
        void Send<TMessage>(TMessage message);
    }
}