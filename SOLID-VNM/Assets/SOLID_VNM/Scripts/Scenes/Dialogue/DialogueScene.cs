using Zenject;

namespace SOLID_VNM.Scenes.Dialogue
{
    public interface DialogueScene : Scene
    {
        DialogueSceneModel DialogueSceneModel { get; }
        SceneFacade NextSceneFacade { get; }
    }

    public interface DialogueSceneFactory : IFactory<DialogueNode, DialogueScene> { }
    public interface DialogueSceneFacadeFactory : IFactory<DialogueNode, SceneFacade> { }

    public class DialogueSceneImpl : DialogueScene
    {
        private readonly DialogueSceneModel _dialogueSceneModel;
        private readonly SceneFacade _nextSceneFacade;

        DialogueSceneModel DialogueScene.DialogueSceneModel { get { return _dialogueSceneModel; } }

        SceneFacade DialogueScene.NextSceneFacade { get { return _nextSceneFacade; } }

        public DialogueSceneImpl(DialogueSceneModel dialogueSceneModel, SceneFacade nextSceneFacade)
        {
            _dialogueSceneModel = dialogueSceneModel;
            _nextSceneFacade = nextSceneFacade;
        }

        void Scene.Accept(SceneVisitor visitor)
        {
            visitor.Visit(this);
        }

        public class Facade : SceneFacade
        {
            private readonly DialogueSceneFactory _dialogueSceneFactory;
            private readonly DialogueNode _dialogueNode;

            public Facade(DialogueNode textNode, DialogueSceneFactory dialogueSceneFactory)
            {
                _dialogueNode = textNode;

                _dialogueSceneFactory = dialogueSceneFactory;
            }

            public Scene Scene
            {
                get
                {
                    return _dialogueSceneFactory.Create(_dialogueNode);
                }
            }

            public class Factory : PlaceholderFactory<DialogueNode, Facade>, DialogueSceneFacadeFactory
            {
                SceneFacade IFactory<DialogueNode, SceneFacade>.Create(DialogueNode dialogueNode)
                {
                    return Create(dialogueNode);
                }
            }
        }

        public class Factory : PlaceholderFactory<DialogueSceneModel, SceneFacade, DialogueSceneImpl>, DialogueSceneFactory
        {
            private readonly SceneFacadeSelectorFactory _sceneFacadeFactory;

            public Factory(SceneFacadeSelectorFactory sceneFacadeFactory)
            {
                _sceneFacadeFactory = sceneFacadeFactory;
            }

            DialogueScene IFactory<DialogueNode, DialogueScene>.Create(DialogueNode dialogueNode)
            {
                return Create(dialogueNode.DialogueSceneModel, _sceneFacadeFactory.Create(dialogueNode.NextNode));
            }
        }
    }
}