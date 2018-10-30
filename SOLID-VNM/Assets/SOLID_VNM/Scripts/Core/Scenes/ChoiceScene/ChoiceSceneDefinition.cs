using System.Linq;

using Zenject;

using SOLID_VNM.Graph;

namespace SOLID_VNM.Core.Scenes.ChoiceScene
{
    public class ChoiceSceneDefinition : ISceneDefinition
    {
        private readonly SceneContentChoice _sceneContentChoice;
        private readonly ISceneDefinitionFacade[] _sceneDefinitionFacades;

        public SceneContentChoice SceneContentChoice { get { return _sceneContentChoice; } }
        public ISceneDefinitionFacade[] SceneDefinitionFacades { get { return _sceneDefinitionFacades; } }

        public ChoiceSceneDefinition(SceneContentChoice sceneContentChoice, ISceneDefinitionFacade[] sceneDefinitionFacades)
        {
            _sceneContentChoice = sceneContentChoice;
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

        public class Factory : PlaceholderFactory<SceneContentChoice, ISceneDefinitionFacade[], ChoiceSceneDefinition>, IFactory<ChoiceNode, ChoiceSceneDefinition>
        {
            private readonly SceneDefinitionFacadeFactory _sceneDefinitionFacadeFactory;

            public Factory(SceneDefinitionFacadeFactory sceneDefinitionFacadeFactory)
            {
                _sceneDefinitionFacadeFactory = sceneDefinitionFacadeFactory;
            }

            public ChoiceSceneDefinition Create(ChoiceNode choiceNode)
            {
                ISceneDefinitionFacade[] sceneDefinitionFacades = choiceNode.Choices.Select(node => _sceneDefinitionFacadeFactory.Create(node)).ToArray();
                return Create(choiceNode.sceneContentChoice, sceneDefinitionFacades);
            }
        }
    }
}