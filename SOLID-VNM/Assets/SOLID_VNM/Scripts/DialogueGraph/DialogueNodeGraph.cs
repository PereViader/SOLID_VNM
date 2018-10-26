using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using Zenject;

namespace SOLID_VNM.Dialogue
{
    [CreateAssetMenu]
    public class DialogueNodeGraph : NodeGraph
    {
        public DialogueNode RootNode
        {
            get
            {
                List<Node> rootNodes = nodes.FindAll(x => x is DialogueStartNode);
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

                return ((DialogueStartNode)rootNodes[0]).Start;
            }
        }
    }
}