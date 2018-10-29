using SOLID_VNM.Core.Scenes.TextScene;

namespace SOLID_VNM.Core.Scenes.ChoiceScene
{
    public class ChoiceSceneController : ISceneController, IChoiceHandler
    {
        readonly private GameLoop _gameLoop;
        readonly private IChoiceScenePlayer _choiceScenePlayer;
        readonly private ChoiceEventRaiser _choiceEventRaiser;


        private ChoiceSceneDefinition _choiceSceneDefinition;
        public ChoiceSceneDefinition ChoiceSceneDefinition { get { return _choiceSceneDefinition; } set { _choiceSceneDefinition = value; } }


        public ChoiceSceneController(GameLoop gameLoop, IChoiceScenePlayer choiceScenePlayer, ChoiceEventRaiser choiceEventRaiser)
        {
            _gameLoop = gameLoop;
            _choiceScenePlayer = choiceScenePlayer;
            _choiceEventRaiser = choiceEventRaiser;
        }

        void ISceneController.Play()
        {
            _choiceEventRaiser.ChoiceHandler = this;
            _choiceScenePlayer.Play(_choiceSceneDefinition);
        }

        void ISceneController.End()
        {
            _choiceEventRaiser.ChoiceHandler = null;
            _choiceSceneDefinition = null;
            _choiceScenePlayer.End();
        }

        void IChoiceHandler.OnChoice(int choice)
        {
            _gameLoop.Play(_choiceSceneDefinition.SceneDefinitionFacades[choice].SceneDefinition);
        }
    }
}
