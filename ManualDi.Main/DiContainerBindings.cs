﻿using System;
using System.Collections.Generic;

namespace ManualDi.Main
{
    public class DiContainerBindings : IDiContainerBindings
    {
        private readonly List<Action> disposeActions = new List<Action>();

        public IReadOnlyList<Action> DisposeActions => disposeActions;
        public Dictionary<Type, List<ITypeBinding>> TypeBindings { get; } = new Dictionary<Type, List<ITypeBinding>>();

        public void AddBinding<T>(ITypeBinding<T> typeBinding)
        {
            Type type = typeof(T);
            if (!TypeBindings.TryGetValue(type, out var bindings))
            {
                bindings = new List<ITypeBinding>();
                TypeBindings[type] = bindings;
            }

            bindings.Add(typeBinding);
        }

        public void QueueDispose(Action action)
        {
            disposeActions.Add(action);
        }
    }
}
