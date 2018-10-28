using Zenject;

using SOLID_VNM.Core.Scenes.ChoiceScene;
using SOLID_VNM.Core.Scenes.TextScene;

namespace SOLID_VNM.Core.Scenes
{
    public interface ISceneController
    {
        void Play();
        void End();
    }

    public class SceneControllerDiscriminator : ISceneDefinitionVisitor
    {
        readonly private LazyInject<TextSceneController> _textSceneController;
        readonly private LazyInject<ChoiceSceneController> _choiceSceneController;

        private ISceneController _sceneController;

        public SceneControllerDiscriminator(LazyInject<TextSceneController> textSceneManager, LazyInject<ChoiceSceneController> choiceScenePlayer)
        {
            _textSceneController = textSceneManager;
            _choiceSceneController = choiceScenePlayer;
        }

        public ISceneController Choose(ISceneDefinition sceneDefinition)
        {
            sceneDefinition.Accept(this);
            return _sceneController;
        }

        void ISceneDefinitionVisitor.Accept(TextSceneDefinition textSceneDefinition)
        {
            _textSceneController.Value.TextSceneDefinition = textSceneDefinition;
            _sceneController = _textSceneController.Value;
        }

        void ISceneDefinitionVisitor.Accept(ChoiceSceneDefinition choiceSceneDefinition)
        {
            _choiceSceneController.Value.ChoiceSceneDefinition = choiceSceneDefinition;
            _sceneController = _choiceSceneController.Value;
        }
    }
}