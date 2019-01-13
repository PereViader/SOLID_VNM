using System.Linq;

using Zenject;

using SOLID_VNM.Graph;

namespace SOLID_VNM.Core.Scenes.ChoiceScene
{
    public interface IChoiceScene : IScene
    {
        IChoiceSceneModel ChoiceSceneModel { get; }
        ISceneFacade[] NextSceneFacades { get; }
    }

    public interface IChoiceSceneFactory : IFactory<IChoiceNode, IChoiceScene> { }

    public interface IChoiceSceneFacadeFactory : IFactory<IChoiceNode, ISceneFacade> { }


    public class ChoiceSceneImpl : IChoiceScene
    {
        private readonly IChoiceSceneModel _choiceSceneModel;
        private readonly ISceneFacade[] _sceneFacades;

        public IChoiceSceneModel ChoiceSceneModel { get { return _choiceSceneModel; } }
        public ISceneFacade[] NextSceneFacades { get { return _sceneFacades; } }

        public ChoiceSceneImpl(IChoiceSceneModel choiceSceneModel, ISceneFacade[] sceneFacades)
        {
            _choiceSceneModel = choiceSceneModel;
            _sceneFacades = sceneFacades;
        }

        void IScene.Accept(ISceneVisitor visitor)
        {
            visitor.Visit(this);
        }

        public class Facade : ISceneFacade
        {
            private readonly IChoiceSceneFactory _choiceSceneFactory;
            private readonly IChoiceNode _choiceNode;


            public Facade(IChoiceSceneFactory choiceSceneFactory, IChoiceNode choiceNode)
            {
                _choiceSceneFactory = choiceSceneFactory;
                _choiceNode = choiceNode;
            }

            IScene ISceneFacade.Scene
            {
                get
                {
                    return _choiceSceneFactory.Create(_choiceNode);
                }
            }

            public class Factory : PlaceholderFactory<IChoiceNode, Facade>, IChoiceSceneFacadeFactory
            {
                ISceneFacade IFactory<IChoiceNode, ISceneFacade>.Create(IChoiceNode choiceNode)
                {
                    return Create(choiceNode);
                }
            }
        }

        public class Factory : PlaceholderFactory<IChoiceSceneModel, ISceneFacade[], ChoiceSceneImpl>, IChoiceSceneFactory
        {
            private readonly SceneFacadeFactory _sceneFacadeFactory;

            public Factory(SceneFacadeFactory sceneFacadeFactory)
            {
                _sceneFacadeFactory = sceneFacadeFactory;
            }

            public IChoiceScene Create(IChoiceNode choiceNode)
            {
                ISceneFacade[] sceneFacades = choiceNode.Choices.Select(node => _sceneFacadeFactory.Create(node)).ToArray();
                IChoiceSceneModel sceneModel = choiceNode.ChoiceSceneModel;

                return Create(sceneModel, sceneFacades);
            }
        }
    }
}