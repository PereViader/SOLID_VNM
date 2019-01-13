using UnityEngine;
using XNode;
using System.Linq;


using SOLID_VNM.Core.Scenes.ChoiceScene;

namespace SOLID_VNM.Graph.XNode
{
    public class ChoiceNode : Node, IGraphNode
    {
        [Input]
        public Node previous;

        [Output(backingValue = ShowBackingValue.Never, connectionType = ConnectionType.Multiple)]
        public Node choices;


        [SerializeField]
        private ConcreteChoiceSceneModel _choiceSceneModel;


        public IChoiceSceneModel ChoiceSceneModel { get { return _choiceSceneModel; } }
        public IGraphNode[] Choices { get { return this.GetOutputConnections("choices").Select(choice => (IGraphNode)choice).ToArray(); } }

        public void Visit(IGraphNodeVisitor visitor)
        {
            visitor.Accept(this);
        }
    }
}