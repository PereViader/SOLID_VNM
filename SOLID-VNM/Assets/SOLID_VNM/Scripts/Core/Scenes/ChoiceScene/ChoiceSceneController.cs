using Zenject;

using SOLID_VNM.Core.Scenes.DialogueScene;

namespace SOLID_VNM.Core.Scenes.ChoiceScene
{
    public class ChoiceSceneController : ISceneController, IChoiceHandler
    {
        private readonly GameLoop _gameLoop;
        private readonly IChoiceScenePlayer _choiceScenePlayer;
        private readonly ChoiceEventRaiser _choiceEventRaiser;


        private readonly IChoiceScene _choiceScene;

        public ChoiceSceneController(
            IChoiceScene choiceScene,
            GameLoop gameLoop,
            IChoiceScenePlayer choiceScenePlayer,
            ChoiceEventRaiser choiceEventRaiser)
        {
            _choiceScene = choiceScene;
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
            _choiceScenePlayer.End();
        }

        void IChoiceHandler.OnChoice(int choice)
        {
            _gameLoop.Play(_choiceScene.NextSceneFacades[choice].Scene);
        }

        public class Factory : PlaceholderFactory<IChoiceScene, ChoiceSceneController>
        {
        }
    }
}
