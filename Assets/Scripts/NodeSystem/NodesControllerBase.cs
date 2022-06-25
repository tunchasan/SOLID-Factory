using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace NodeSystem
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

        protected virtual void OnReceiveOutput(INode from, List<GameObject> output)
        {
            Debug.Log($"Receive {output.Count} outputs from {from}");

            var nodeIndex = Nodes.IndexOf(from);

            if (nodeIndex != -1 && nodeIndex < Nodes.Count - 1)
            {
                var nextNode = Nodes[nodeIndex + 1];
                trash.AddRange(nextNode.Input(output));
            }
        }
    }
}