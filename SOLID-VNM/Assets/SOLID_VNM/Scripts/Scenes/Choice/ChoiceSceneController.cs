using Zenject;

namespace SOLID_VNM.Scenes.Choice
{
    public class ChoiceSceneController : SceneController, ChoiceHandler
    {
        private readonly Core _gameLoop;
        private readonly ChoiceScenePlayer _choiceScenePlayer;
        private readonly ChoiceEventRaiser _choiceEventRaiser;


        private readonly ChoiceScene _choiceScene;

        public ChoiceSceneController(
            ChoiceScene choiceScene,
            Core gameLoop,
            ChoiceScenePlayer choiceScenePlayer,
            ChoiceEventRaiser choiceEventRaiser)
        {
            _choiceScene = choiceScene;
            _gameLoop = gameLoop;
            _choiceScenePlayer = choiceScenePlayer;
            _choiceEventRaiser = choiceEventRaiser;
        }

        void SceneController.Play()
        {
            _choiceEventRaiser.ChoiceHandler = this;
            _choiceScenePlayer.Play(_choiceScene);
        }

        void SceneController.End()
        {
            _choiceEventRaiser.ChoiceHandler = null;
            _choiceScenePlayer.End();
        }

        void ChoiceHandler.OnChoice(int choice)
        {
            _gameLoop.Play(_choiceScene.NextSceneFacades[choice].Scene);
        }

        public class Factory : PlaceholderFactory<ChoiceScene, ChoiceSceneController>
        {
        }
    }
}
