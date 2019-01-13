using Zenject;

using SOLID_VNM.InputManagement;

namespace SOLID_VNM.Core.Scenes.DialogueScene
{
    public class DialogueSceneController : ISceneController, INextHandler
    {
        private readonly GameLoop _gameLoop;
        private readonly IDialogueScenePlayer _dialogueScenePlayer;
        private readonly NextEventRaiser _nextEventRaiser;

        private readonly IDialogueScene _dialogueScene;

        public DialogueSceneController(
            IDialogueScene dialogueScene,
            GameLoop gameLoop,
            IDialogueScenePlayer dialogueScenePlayer,
            NextEventRaiser nextInputEventRaiser)
        {
            _dialogueScene = dialogueScene;
            _gameLoop = gameLoop;
            _dialogueScenePlayer = dialogueScenePlayer;
            _nextEventRaiser = nextInputEventRaiser;
        }

        void ISceneController.Play()
        {
            _nextEventRaiser.NextHandler = this;
            _dialogueScenePlayer.Play(_dialogueScene);
        }

        void ISceneController.End()
        {
            _nextEventRaiser.NextHandler = null;
            _dialogueScenePlayer.End();
        }

        void INextHandler.OnNext()
        {
            _gameLoop.Play(_dialogueScene.NextSceneFacade.Scene);
        }

        public class Factory : PlaceholderFactory<IDialogueScene, DialogueSceneController>
        {
        }
    }
}