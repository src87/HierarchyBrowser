using System;
using System.Collections.Generic;

namespace HierarchyBrowser.Framework
{
    internal class Messenger : IMessenger
    {
        private readonly Dictionary<Type, List<Action<object>>> _registeredActions;

        private Messenger()
        {
            _registeredActions = new Dictionary<Type, List<Action<object>>>();
        }

        public static IMessenger Instance => new Messenger();

        public void Register<TMessage>(object recipient, Action<TMessage> action)
        {
            if (_registeredActions.TryGetValue(typeof(TMessage), out var actions))
            {
                actions.Add(o => action((TMessage) o));
            }
            else
            {
                var actionList = new List<Action<object>>
                {
                    o => action((TMessage) o)
                };
                _registeredActions.Add(typeof(TMessage), actionList);
            }
        }

        public void Send<TMessage>(TMessage message)
        {
            if (_registeredActions.TryGetValue(typeof(TMessage), out var actions))
            {
                foreach (var action in actions)
                    action.Invoke(message);
            }
        }
    }
}