using System.Collections.Generic;

using UnityEngine;
using XNode;

namespace SOLID_VNM.Graph.XNode
{
    [CreateAssetMenu]
    public class VNGraph : NodeGraph
    {
        public IGraphNode RootNode
        {
            get
            {
                List<Node> rootNodes = nodes.FindAll(x => x is StartNode);
                if (rootNodes.Count == 0)
                {
                    Debug.LogError("Dialogue Graph does not have dialogue start", this);
                    return null;
                }
                if (rootNodes.Count > 1)
                {
                    Debug.LogError("Dialogue Graph has more than one dialogue start", this);
                    return null;
                }

                return ((StartNode)rootNodes[0]).Start;
            }
        }
    }
}