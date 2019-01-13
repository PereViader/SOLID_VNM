using Zenject;

using SOLID_VNM.Graph;

namespace SOLID_VNM.Core.Scenes.DialogueScene
{
    public interface IDialogueScene : IScene
    {
        IDialogueSceneModel DialogueSceneModel { get; }
        ISceneFacade NextSceneFacade { get; }
    }

    public interface IDialogueSceneFactory : IFactory<IDialogueNode, IDialogueScene> { }
    public interface IDialogueSceneFacadeFactory : IFactory<IDialogueNode, ISceneFacade> { }

    public class DialogueSceneImpl : IDialogueScene
    {
        private readonly IDialogueSceneModel _dialogueSceneModel;
        private readonly ISceneFacade _nextSceneFacade;

        IDialogueSceneModel IDialogueScene.DialogueSceneModel { get { return _dialogueSceneModel; } }

        ISceneFacade IDialogueScene.NextSceneFacade { get { return _nextSceneFacade; } }

        public DialogueSceneImpl(IDialogueSceneModel dialogueSceneModel, ISceneFacade nextSceneFacade)
        {
            _dialogueSceneModel = dialogueSceneModel;
            _nextSceneFacade = nextSceneFacade;
        }

        void IScene.Accept(ISceneVisitor visitor)
        {
            visitor.Visit(this);
        }

        public class Facade : ISceneFacade
        {
            private readonly IDialogueSceneFactory _dialogueSceneFactory;
            private readonly IDialogueNode _dialogueNode;

            public Facade(IDialogueNode textNode, IDialogueSceneFactory dialogueSceneFactory)
            {
                _dialogueNode = textNode;

                _dialogueSceneFactory = dialogueSceneFactory;
            }

            public IScene Scene
            {
                get
                {
                    return _dialogueSceneFactory.Create(_dialogueNode);
                }
            }

            public class Factory : PlaceholderFactory<IDialogueNode, Facade>, IDialogueSceneFacadeFactory
            {
                ISceneFacade IFactory<IDialogueNode, ISceneFacade>.Create(IDialogueNode dialogueNode)
                {
                    return Create(dialogueNode);
                }
            }
        }

        public class Factory : PlaceholderFactory<IDialogueSceneModel, ISceneFacade, DialogueSceneImpl>, IDialogueSceneFactory
        {
            private readonly SceneFacadeFactory _sceneFacadeFactory;

            public Factory(SceneFacadeFactory sceneFacadeFactory)
            {
                _sceneFacadeFactory = sceneFacadeFactory;
            }

            IDialogueScene IFactory<IDialogueNode, IDialogueScene>.Create(IDialogueNode dialogueNode)
            {
                return Create(dialogueNode.DialogueSceneModel, _sceneFacadeFactory.Create(dialogueNode.NextNode));
            }
        }
    }
}