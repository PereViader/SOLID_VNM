using Zenject;

using SOLID_VNM.Graph;

namespace SOLID_VNM.Core.Scenes.TextScene
{
    public class TextSceneDefinition : ISceneDefinition
    {
        private readonly SceneContentDialogue _sceneContentDialogue;
        private readonly ISceneDefinitionFacade _nextSceneDefinitionFacade;

        public SceneContentDialogue SceneContentDialogue { get { return _sceneContentDialogue; } }

        public ISceneDefinitionFacade NextSceneDefinitionFacade { get { return _nextSceneDefinitionFacade; } }

        public TextSceneDefinition(SceneContentDialogue sceneContentDialogue, ISceneDefinitionFacade nextSceneDefinitionFacade)
        {
            _sceneContentDialogue = sceneContentDialogue;
            _nextSceneDefinitionFacade = nextSceneDefinitionFacade;
        }

        void ISceneDefinition.Accept(ISceneDefinitionVisitor visitor)
        {
            visitor.Accept(this);
        }

        public class Facade : ISceneDefinitionFacade
        {
            private readonly TextSceneDefinition.Factory _textSceneDefinitionFactory;

            private readonly DialogueNode _textNode;

            public Facade(DialogueNode textNode, TextSceneDefinition.Factory textSceneDefinitionFactory)
            {
                _textNode = textNode;

                _textSceneDefinitionFactory = textSceneDefinitionFactory;
            }

            public ISceneDefinition SceneDefinition
            {
                get
                {
                    return _textSceneDefinitionFactory.Create(_textNode);
                }
            }

            public class Factory : PlaceholderFactory<DialogueNode, Facade> { }
        }

        public class Factory : PlaceholderFactory<SceneContentDialogue, ISceneDefinitionFacade, TextSceneDefinition>
        {
            private readonly SceneDefinitionFacadeFactory _sceneDefinitionFacadeFactory;

            public Factory(SceneDefinitionFacadeFactory sceneDefinitionFacadeFactory)
            {
                _sceneDefinitionFacadeFactory = sceneDefinitionFacadeFactory;
            }

            public TextSceneDefinition Create(DialogueNode textNode)
            {
                return Create(textNode.sceneContentDialogue, _sceneDefinitionFacadeFactory.Create(textNode.Next));
            }
        }
    }
}