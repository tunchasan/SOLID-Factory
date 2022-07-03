using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace NodeSystem.Nodes.Base
{
    public abstract class NodesControllerBase : MonoBehaviour
    {
        [SerializeField] protected List<GameObject> trash = new();

        protected List<INode> Nodes = new();

        private void Awake()
        {
            Initialize();
        }

        protected virtual void Initialize()
        {
            Nodes = GetComponentsInChildren<INode>().ToList();

            foreach (var node in Nodes)
            {
                node.InitializeNode();
                node.OnOutput += OnReceiveOutput;
            }
        }

        protected abstract void OnReceiveOutput(INode from, List<GameObject> output);
    }
}