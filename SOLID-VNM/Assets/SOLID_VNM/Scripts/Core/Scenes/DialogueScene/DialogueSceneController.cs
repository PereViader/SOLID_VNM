using SOLID_VNM.InputManagement;

namespace SOLID_VNM.Core.Scenes.DialogueScene
{
    public class DialogueSceneController : ISceneController, INextHandler
    {
        private readonly GameLoop _gameLoop;
        private readonly IDialogueScenePlayer _dialogueScenePlayer;
        private readonly NextEventRaiser _nextEventRaiser;

        private IDialogueScene _dialogueScene;

        public IDialogueScene DialogueScene { get { return _dialogueScene; } set { _dialogueScene = value; } }

        public DialogueSceneController(
            GameLoop gameLoop,
            IDialogueScenePlayer dialogueScenePlayer,
            NextEventRaiser nextInputEventRaiser)
        {
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
            _dialogueScene = null;
            _dialogueScenePlayer.End();
        }

        void INextHandler.OnNext()
        {
            _gameLoop.Play(_dialogueScene.NextSceneFacade.Scene);
        }
    }
}