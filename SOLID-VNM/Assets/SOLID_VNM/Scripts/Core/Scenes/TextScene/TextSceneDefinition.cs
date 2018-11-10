using Zenject;

using SOLID_VNM.Graph;

namespace SOLID_VNM.Core.Scenes.DialogueScene
{
    public class TextSceneDefinition : ISceneDefinition
    {
        private readonly IDialogueSceneModel _dialogueSceneModel;
        private readonly ISceneDefinitionFacade _nextSceneDefinitionFacade;

        public IDialogueSceneModel DialogueSceneModel { get { return _dialogueSceneModel; } }

        public ISceneDefinitionFacade NextSceneDefinitionFacade { get { return _nextSceneDefinitionFacade; } }

        public TextSceneDefinition(IDialogueSceneModel dialogueSceneModel, ISceneDefinitionFacade nextSceneDefinitionFacade)
        {
            _dialogueSceneModel = dialogueSceneModel;
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

        public class Factory : PlaceholderFactory<IDialogueSceneModel, ISceneDefinitionFacade, TextSceneDefinition>
        {
            private readonly SceneDefinitionFacadeFactory _sceneDefinitionFacadeFactory;

            public Factory(SceneDefinitionFacadeFactory sceneDefinitionFacadeFactory)
            {
                _sceneDefinitionFacadeFactory = sceneDefinitionFacadeFactory;
            }

            public TextSceneDefinition Create(DialogueNode dialogueNode)
            {
                return Create(dialogueNode.dialogueSceneModel, _sceneDefinitionFacadeFactory.Create(dialogueNode.Next));
            }
        }
    }
}