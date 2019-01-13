using Zenject;

using SOLID_VNM.Core.Scenes.ChoiceScene;
using SOLID_VNM.Core.Scenes.DialogueScene;

namespace SOLID_VNM.Core.Scenes
{
    public interface ISceneController
    {
        void Play();
        void End();
    }

    public class SceneControllerFactory : PlaceholderFactory<IScene, ISceneController>
    {
    }

    public class SceneControllerFactoryImpl : IFactory<IScene, ISceneController>, ISceneVisitor
    {
        private readonly DialogueSceneController.Factory _dialogueSceneControllerFactory;
        private readonly ChoiceSceneController.Factory _choiceSceneControllerFactory;

        private ISceneController _sceneController;

        public SceneControllerFactoryImpl(
            DialogueSceneController.Factory dialogueSceneControllerFactory,
            ChoiceSceneController.Factory choiceSceneControllerFactory)
        {
            _dialogueSceneControllerFactory = dialogueSceneControllerFactory;
            _choiceSceneControllerFactory = choiceSceneControllerFactory;
        }

        public ISceneController Create(IScene scene)
        {
            scene.Accept(this);
            return _sceneController;
        }

        void ISceneVisitor.Visit(IDialogueScene dialogueScene)
        {
            _sceneController = _dialogueSceneControllerFactory.Create(dialogueScene);
        }

        void ISceneVisitor.Visit(IChoiceScene choiceScene)
        {
            _sceneController = _choiceSceneControllerFactory.Create(choiceScene);
        }
    }
}