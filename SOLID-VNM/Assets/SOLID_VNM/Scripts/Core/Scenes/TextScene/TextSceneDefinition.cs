using Zenject;

using SOLID_VNM.Dialogue;

namespace SOLID_VNM.Core.Scenes.TextScene
{
    public class TextSceneDefinition : ISceneDefinition
    {
        readonly private SceneContentDialogue _sceneContentDialogue;
        readonly private ISceneDefinitionFacade _nextSceneDefinitionFacade;

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
            readonly private TextSceneDefinition.Factory _textSceneDefinitionFactory;

            readonly private TextNode _textNode;

            public Facade(TextNode textNode, TextSceneDefinition.Factory textSceneDefinitionFactory)
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

            public class Factory : PlaceholderFactory<TextNode, Facade> { }
        }

        public class Factory : PlaceholderFactory<SceneContentDialogue, ISceneDefinitionFacade, TextSceneDefinition>
        {
            readonly private SceneDefinitionFacadeFactory _sceneDefinitionFacadeFactory;

            public Factory(SceneDefinitionFacadeFactory sceneDefinitionFacadeFactory)
            {
                _sceneDefinitionFacadeFactory = sceneDefinitionFacadeFactory;
            }

            public TextSceneDefinition Create(TextNode textNode)
            {
                return Create(textNode.sceneContentDialogue, _sceneDefinitionFacadeFactory.Create(textNode.Next));
            }
        }
    }
}