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

    public class SceneControllerDiscriminator : ISceneVisitor
    {
        private readonly LazyInject<DialogueSceneController> _dialogueSceneController;
        private readonly LazyInject<ChoiceSceneController> _choiceSceneController;

        private ISceneController _sceneController;

        public SceneControllerDiscriminator(LazyInject<DialogueSceneController> dialogueSceneController, LazyInject<ChoiceSceneController> choiceSceneController)
        {
            _dialogueSceneController = dialogueSceneController;
            _choiceSceneController = choiceSceneController;
        }

        public ISceneController Choose(IScene scene)
        {
            scene.Accept(this);
            return _sceneController;
        }

        void ISceneVisitor.Visit(IDialogueScene dialogueScene)
        {
            _dialogueSceneController.Value.DialogueScene = dialogueScene;
            _sceneController = _dialogueSceneController.Value;
        }

        void ISceneVisitor.Visit(IChoiceScene choiceScene)
        {
            _choiceSceneController.Value.ChoiceScene = choiceScene;
            _sceneController = _choiceSceneController.Value;
        }
    }
}