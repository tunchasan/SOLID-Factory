using System;
using System.Collections;
using System.Collections.Generic;

namespace NodeSystem
{
    public interface INode<T>
    {
        Queue<T> Elements { get; }
        float Duration { get; }
        Action<T> OnOutput { get; }
        void InitializeNode();
        void Input(IEnumerable<T> elements);
        IEnumerator Process();
        void Output(T output);
    }
}