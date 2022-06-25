using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NodeSystem
{
    public interface INode<T> : INode
    {
        Queue<T> Elements { get; }
        void Output(T output);
    }

    public interface INode
    {
        public Action<INode, List<GameObject>> OnOutput { get; set; }
        float Duration { get; }
        IEnumerator Process();
        void InitializeNode();
        IEnumerable<GameObject> Input(IEnumerable<GameObject> elements);
    }
}