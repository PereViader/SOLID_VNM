using System.Linq;

using Zenject;

namespace SOLID_VNM.Scenes.Choice
{
    public interface ChoiceScene : Scene
    {
        ChoiceSceneModel ChoiceSceneModel { get; }
        SceneFacade[] NextSceneFacades { get; }
    }

    public interface ChoiceSceneFactory : IFactory<ChoiceNode, ChoiceScene> { }

    public interface ChoiceSceneFacadeFactory : IFactory<ChoiceNode, SceneFacade> { }


    public class ChoiceSceneImpl : ChoiceScene
    {
        private readonly ChoiceSceneModel _choiceSceneModel;
        private readonly SceneFacade[] _sceneFacades;

        public ChoiceSceneModel ChoiceSceneModel { get { return _choiceSceneModel; } }
        public SceneFacade[] NextSceneFacades { get { return _sceneFacades; } }

        public ChoiceSceneImpl(ChoiceSceneModel choiceSceneModel, SceneFacade[] sceneFacades)
        {
            _choiceSceneModel = choiceSceneModel;
            _sceneFacades = sceneFacades;
        }

        void Scene.Accept(SceneVisitor visitor)
        {
            visitor.Visit(this);
        }

        public class Facade : SceneFacade
        {
            private readonly ChoiceSceneFactory _choiceSceneFactory;
            private readonly ChoiceNode _choiceNode;


            public Facade(ChoiceSceneFactory choiceSceneFactory, ChoiceNode choiceNode)
            {
                _choiceSceneFactory = choiceSceneFactory;
                _choiceNode = choiceNode;
            }

            Scene SceneFacade.Scene
            {
                get
                {
                    return _choiceSceneFactory.Create(_choiceNode);
                }
            }

            public class Factory : PlaceholderFactory<ChoiceNode, Facade>, ChoiceSceneFacadeFactory
            {
                SceneFacade IFactory<ChoiceNode, SceneFacade>.Create(ChoiceNode choiceNode)
                {
                    return Create(choiceNode);
                }
            }
        }

        public class Factory : PlaceholderFactory<ChoiceSceneModel, SceneFacade[], ChoiceSceneImpl>, ChoiceSceneFactory
        {
            private readonly SceneFacadeSelectorFactory _sceneFacadeFactory;

            public Factory(SceneFacadeSelectorFactory sceneFacadeFactory)
            {
                _sceneFacadeFactory = sceneFacadeFactory;
            }

            public ChoiceScene Create(ChoiceNode choiceNode)
            {
                SceneFacade[] sceneFacades = choiceNode.Choices.Select(node => _sceneFacadeFactory.Create(node)).ToArray();
                ChoiceSceneModel sceneModel = choiceNode.ChoiceSceneModel;

                return Create(sceneModel, sceneFacades);
            }
        }
    }
}