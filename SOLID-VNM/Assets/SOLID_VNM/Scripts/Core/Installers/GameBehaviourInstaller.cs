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
            Container.Bind<SceneControllerDiscriminator>().AsSingle();
            Container.Bind<SceneFactory>().AsSingle();
            Container.Bind<SceneFacadeFactory>().AsSingle();
        }

        private void InstallGraph()
        {
            Container.BindFactory<VNGraph, VisualNovelGraphImpl, VisualNovelGraphImpl.Factory>();
            Container.BindFactory<IGraphNode, INode, NodeGraphNodeFactory>().FromFactory<NodeGraphNodeFactoryImpl>();
        }

        private void InstallDialogue()
        {
            Container.BindFactory<DialogueNode, DialogueNodeImpl, DialogueNodeImpl.Factory>();

            Container.Bind<DialogueSceneController>().AsSingle();
            Container.Bind<IDialogueScenePlayer>().To<ConcreteDialogueScenePlayer>().AsSingle();

            Container.BindFactoryCustomInterface<IDialogueSceneModel, ISceneFacade, ConcreteDialogueScene, ConcreteDialogueScene.Factory, IDialogueSceneFactory>();
            Container.BindFactoryCustomInterface<IDialogueNode, ConcreteDialogueScene.Facade, ConcreteDialogueScene.Facade.Factory, IDialogueSceneFacadeFactory>();

            Container.Bind<IDialogueSceneModelTextDisplayContentExtractor>().To<ConcreteDialogueSceneModelTextDisplayContentExtractor>().AsSingle();
            Container.Bind<IDialogueSceneModelActorDisplayContentExtractor>().To<ConcreteDialogueSceneModelActorDisplayModelExtractor>().AsSingle();
            Container.Bind<IDialogueSceneModelBackgroundDisplayContentExtractor>().To<ConcreteDialogueSceneModelBackgroundDisplayContentExtractor>().AsSingle();
        }

        private void InstallChoice()
        {
            Container.BindFactory<ChoiceNode, ChoiceNodeImpl, ChoiceNodeImpl.Factory>();

            Container.Bind<ChoiceSceneController>().AsSingle();
            Container.Bind<IChoiceScenePlayer>().To<ConcreteChoiceScenePlayer>().AsSingle();

            Container.BindFactoryCustomInterface<IChoiceSceneModel, ISceneFacade[], ConcreteChoiceScene, ConcreteChoiceScene.Factory, IChoiceSceneFactory>();
            Container.BindFactoryCustomInterface<IChoiceNode, ConcreteChoiceScene.Facade, ConcreteChoiceScene.Facade.Factory, IChoiceSceneFacadeFactory>();

            Container.Bind<IChoiceScenModelChoiceChoiceDisplayContentExtractor>().To<ConcreteChoiceScenModelChoiceChoiceDisplayContentExtractor>().AsSingle();
            Container.Bind<IChoiceSceneModelBackgroundDisplayContentExtractor>().To<ConcreteChoiceSceneModelBackgroundDisplayContentExtractor>().AsSingle();
        }
    }
}