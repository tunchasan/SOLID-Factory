using System.Collections.Generic;
using NodeSystem.Nodes.Base;
using UnityEngine;

namespace NodeSystem.Nodes.Class
{
    public class SinglyLinkedNodesController : NodesControllerBase
    {
        protected override void OnReceiveOutput(INode @from, List<GameObject> output)
        {
            Debug.Log($"NodesControllerBase :: Receive {output.Count} outputs from {from}");

            var nodeIndex = Nodes.IndexOf(from);

            if (nodeIndex != -1 && nodeIndex < Nodes.Count - 1)
            {
                var nextNode = Nodes[nodeIndex + 1];
                trash.AddRange(nextNode.Input(output));
            }
        }
    }
}