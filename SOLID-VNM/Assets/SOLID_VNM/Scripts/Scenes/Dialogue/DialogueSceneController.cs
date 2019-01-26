using Zenject;

using SOLID_VNM.InputManagement;

namespace SOLID_VNM.Scenes.Dialogue
{
    public class DialogueSceneController : SceneController, NextHandler
    {
        private readonly Core _core;
        private readonly DialogueScenePlayer _dialogueScenePlayer;
        private readonly NextEventRaiser _nextEventRaiser;

        private readonly DialogueScene _dialogueScene;

        public DialogueSceneController(
            DialogueScene dialogueScene,
            Core core,
            DialogueScenePlayer dialogueScenePlayer,
            NextEventRaiser nextInputEventRaiser)
        {
            _dialogueScene = dialogueScene;
            _core = core;
            _dialogueScenePlayer = dialogueScenePlayer;
            _nextEventRaiser = nextInputEventRaiser;
        }

        void SceneController.Play()
        {
            _nextEventRaiser.NextHandler = this;
            _dialogueScenePlayer.Play(_dialogueScene);
        }

        void SceneController.End()
        {
            _nextEventRaiser.NextHandler = null;
            _dialogueScenePlayer.End();
        }

        void NextHandler.OnNext()
        {
            _core.Play(_dialogueScene.NextSceneFacade.Scene);
        }

        public class Factory : PlaceholderFactory<DialogueScene, DialogueSceneController>
        {
        }
    }
}