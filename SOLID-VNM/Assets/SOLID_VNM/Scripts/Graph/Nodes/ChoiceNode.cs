using System.Linq;

using UnityEngine;
using XNode;

using SOLID_VNM.Core.Scenes.ChoiceScene;

namespace SOLID_VNM.Graph
{
    public interface IChoiceNode : INode
    {
        IChoiceSceneModel ChoiceSceneModel { get; }
        INode[] Choices { get; }
    }

    public class ChoiceNode : BaseNode, IChoiceNode
    {
        [Input] public BaseNode previous;

        [Output(backingValue = ShowBackingValue.Never, connectionType = ConnectionType.Multiple)]
        public BaseNode choices;


        [SerializeField]
        private ConcreteChoiceSceneModel _choiceSceneModel;


        IChoiceSceneModel IChoiceNode.ChoiceSceneModel { get { return _choiceSceneModel; } }
        INode[] IChoiceNode.Choices { get { return this.GetOutputConnections("choices").Select(choice => (INode)choice).ToArray(); } }

        void INode.Accept(INodeVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}