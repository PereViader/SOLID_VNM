using UnityEngine;

using Zenject;

using SOLID_VNM.Graph;
using SOLID_VNM.Core.Scenes;
using SOLID_VNM.Core.Scenes.DialogueScene;
using SOLID_VNM.InputManagement;
using SOLID_VNM.Core.Scenes.ChoiceScene;
using SOLID_VNM.Displays.TextDisplay;
using SOLID_VNM.Displays.BackgroundDisplay;
using SOLID_VNM.Displays.ChoiceDisplay;
using System;
using SOLID_VNM.Graph.XNode;

namespace SOLID_VNM.Core.Installers
{
    public class GameBehaviourInstaller : MonoInstaller<GameBehaviourInstaller>
    {
        public override void InstallBindings()
        {
            InstallCore();
            InstallGraph();
            InstallDialogue();
            InstallChoice();
        }

        private void InstallCore()
        {
            Container.Bind<GameLoop>().AsSingle();
            Container.BindFactory<IScene, ISceneController, SceneControllerFactory>().FromFactory<SceneControllerFactoryImpl>();
            Container.BindFactory<INode, ISceneFacade, SceneFacadeFactory>().FromFactory<SceneFacadeFactoryImpl>();
            Container.BindFactory<INode, IScene, SceneFactory>().FromFactory<SceneFactoryImpl>();
        }

        private void InstallGraph()
        {
            Container.BindFactory<VNGraph, VisualNovelGraphImpl, VisualNovelGraphImpl.Factory>();
            Container.BindFactory<IGraphNode, INode, NodeGraphNodeFactory>().FromFactory<NodeGraphNodeFactoryImpl>();
        }

        private void InstallDialogue()
        {
            Container.BindFactory<DialogueNode, DialogueNodeImpl, DialogueNodeImpl.Factory>();

            Container.BindFactory<IDialogueScene, DialogueSceneController, DialogueSceneController.Factory>();
            Container.Bind<IDialogueScenePlayer>().To<ConcreteDialogueScenePlayer>().AsSingle();

            Container.BindFactoryCustomInterface<IDialogueSceneModel, ISceneFacade, DialogueSceneImpl, DialogueSceneImpl.Factory, IDialogueSceneFactory>();
            Container.BindFactoryCustomInterface<IDialogueNode, DialogueSceneImpl.Facade, DialogueSceneImpl.Facade.Factory, IDialogueSceneFacadeFactory>();

            Container.Bind<IDialogueSceneModelTextDisplayContentExtractor>().To<ConcreteDialogueSceneModelTextDisplayContentExtractor>().AsSingle();
            Container.Bind<IDialogueSceneModelActorDisplayContentExtractor>().To<ConcreteDialogueSceneModelActorDisplayModelExtractor>().AsSingle();
            Container.Bind<IDialogueSceneModelBackgroundDisplayContentExtractor>().To<ConcreteDialogueSceneModelBackgroundDisplayContentExtractor>().AsSingle();
        }

        private void InstallChoice()
        {
            Container.BindFactory<ChoiceNode, ChoiceNodeImpl, ChoiceNodeImpl.Factory>();

            Container.BindFactory<IChoiceScene, ChoiceSceneController, ChoiceSceneController.Factory>();
            Container.Bind<IChoiceScenePlayer>().To<ConcreteChoiceScenePlayer>().AsSingle();

            Container.BindFactoryCustomInterface<IChoiceSceneModel, ISceneFacade[], ChoiceSceneImpl, ChoiceSceneImpl.Factory, IChoiceSceneFactory>();
            Container.BindFactoryCustomInterface<IChoiceNode, ChoiceSceneImpl.Facade, ChoiceSceneImpl.Facade.Factory, IChoiceSceneFacadeFactory>();

            Container.Bind<IChoiceScenModelChoiceChoiceDisplayContentExtractor>().To<ConcreteChoiceScenModelChoiceChoiceDisplayContentExtractor>().AsSingle();
            Container.Bind<IChoiceSceneModelBackgroundDisplayContentExtractor>().To<ConcreteChoiceSceneModelBackgroundDisplayContentExtractor>().AsSingle();
        }
    }
}