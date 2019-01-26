using Zenject;

using SOLID_VNM.Scenes.Choice;
using SOLID_VNM.Scenes.Dialogue;

namespace SOLID_VNM.Scenes
{
    public interface SceneController
    {
        void Play();
        void End();
    }

    public interface SceneControllerSelectorFactory
    {
        SceneController Create(Scene scene);
    }

    public class SceneControllerSelectorFactoryImpl : SceneControllerSelectorFactory, SceneVisitor
    {
        private readonly DialogueSceneController.Factory _dialogueSceneControllerFactory;
        private readonly ChoiceSceneController.Factory _choiceSceneControllerFactory;

        private SceneController _sceneController;

        public SceneControllerSelectorFactoryImpl(
            DialogueSceneController.Factory dialogueSceneControllerFactory,
            ChoiceSceneController.Factory choiceSceneControllerFactory)
        {
            _dialogueSceneControllerFactory = dialogueSceneControllerFactory;
            _choiceSceneControllerFactory = choiceSceneControllerFactory;
        }

        SceneController SceneControllerSelectorFactory.Create(Scene scene)
        {
            scene.Accept(this);
            return _sceneController;
        }

        void SceneVisitor.Visit(Dialogue.DialogueScene dialogueScene)
        {
            _sceneController = _dialogueSceneControllerFactory.Create(dialogueScene);
        }

        void SceneVisitor.Visit(Choice.ChoiceScene choiceScene)
        {
            _sceneController = _choiceSceneControllerFactory.Create(choiceScene);
        }
    }
}