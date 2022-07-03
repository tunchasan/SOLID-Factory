using System.Collections.Generic;
using NodeSystem.Nodes.Base;
using UnityEngine;

namespace NodeSystem.Nodes.Class
{
    public class CircularLinkedNodesController : NodesControllerBase
    {
        protected override void OnReceiveOutput(INode @from, List<GameObject> output)
        {
            Debug.Log($"NodesControllerBase :: Receive {output.Count} outputs from {from}");

            var nodeIndex = Nodes.IndexOf(from);

            if (nodeIndex != -1)
            {
                if (nodeIndex < Nodes.Count - 1)
                {
                    var nextNode = Nodes[nodeIndex + 1];
                    trash.AddRange(nextNode.Input(output));
                }

                else if(nodeIndex == Nodes.Count - 1)
                {
                    var nextNode = Nodes[0];
                    trash.AddRange(nextNode.Input(output));
                }
            }
        }
    }
}