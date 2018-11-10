using System.Linq;

using Zenject;

using SOLID_VNM.Graph;

namespace SOLID_VNM.Core.Scenes.ChoiceScene
{
    public class ChoiceSceneDefinition : ISceneDefinition
    {
        private readonly IChoiceSceneModel _choiceSceneModel;
        private readonly ISceneDefinitionFacade[] _sceneDefinitionFacades;

        public IChoiceSceneModel ChoiceSceneModel { get { return _choiceSceneModel; } }
        public ISceneDefinitionFacade[] SceneDefinitionFacades { get { return _sceneDefinitionFacades; } }

        public ChoiceSceneDefinition(IChoiceSceneModel choiceSceneModel, ISceneDefinitionFacade[] sceneDefinitionFacades)
        {
            _choiceSceneModel = choiceSceneModel;
            _sceneDefinitionFacades = sceneDefinitionFacades;
        }

        void ISceneDefinition.Accept(ISceneDefinitionVisitor visitor)
        {
            visitor.Accept(this);
        }

        public class Facade : ISceneDefinitionFacade
        {
            private readonly ChoiceSceneDefinition.Factory _choiceSceneDefinitionFactory;
            private readonly ChoiceNode _choiceNode;


            public Facade(ChoiceSceneDefinition.Factory choiceSceneDefinitionFactory, ChoiceNode choiceNode)
            {
                _choiceSceneDefinitionFactory = choiceSceneDefinitionFactory;
                _choiceNode = choiceNode;
            }

            ISceneDefinition ISceneDefinitionFacade.SceneDefinition
            {
                get
                {
                    return _choiceSceneDefinitionFactory.Create(_choiceNode);
                }
            }

            public class Factory : PlaceholderFactory<ChoiceNode, Facade> { }
        }

        public class Factory : PlaceholderFactory<IChoiceSceneModel, ISceneDefinitionFacade[], ChoiceSceneDefinition>, IFactory<ChoiceNode, ChoiceSceneDefinition>
        {
            private readonly SceneDefinitionFacadeFactory _sceneDefinitionFacadeFactory;

            public Factory(SceneDefinitionFacadeFactory sceneDefinitionFacadeFactory)
            {
                _sceneDefinitionFacadeFactory = sceneDefinitionFacadeFactory;
            }

            public ChoiceSceneDefinition Create(ChoiceNode choiceNode)
            {
                ISceneDefinitionFacade[] sceneDefinitionFacades = choiceNode.Choices.Select(node => _sceneDefinitionFacadeFactory.Create(node)).ToArray();
                return Create(choiceNode.choiceSceneModel, sceneDefinitionFacades);
            }
        }
    }
}