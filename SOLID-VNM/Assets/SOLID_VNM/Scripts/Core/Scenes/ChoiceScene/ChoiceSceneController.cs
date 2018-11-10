using SOLID_VNM.Core.Scenes.DialogueScene;

namespace SOLID_VNM.Core.Scenes.ChoiceScene
{
    public class ChoiceSceneController : ISceneController, IChoiceHandler
    {
        private readonly GameLoop _gameLoop;
        private readonly IChoiceScenePlayer _choiceScenePlayer;
        private readonly ChoiceEventRaiser _choiceEventRaiser;


        private IChoiceScene _choiceScene;
        public IChoiceScene ChoiceScene { get { return _choiceScene; } set { _choiceScene = value; } }


        public ChoiceSceneController(GameLoop gameLoop, IChoiceScenePlayer choiceScenePlayer, ChoiceEventRaiser choiceEventRaiser)
        {
            _gameLoop = gameLoop;
            _choiceScenePlayer = choiceScenePlayer;
            _choiceEventRaiser = choiceEventRaiser;
        }

        void ISceneController.Play()
        {
            _choiceEventRaiser.ChoiceHandler = this;
            _choiceScenePlayer.Play(_choiceScene);
        }

        void ISceneController.End()
        {
            _choiceEventRaiser.ChoiceHandler = null;
            _choiceScene = null;
            _choiceScenePlayer.End();
        }

        void IChoiceHandler.OnChoice(int choice)
        {
            _gameLoop.Play(_choiceScene.NextSceneFacades[choice].Scene);
        }
    }
}
