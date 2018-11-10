using UnityEngine;

using Zenject;

using SOLID_VNM.Graph;
using SOLID_VNM.Core.Scenes;
using SOLID_VNM.Core.Scenes.DialogueScene;
using SOLID_VNM.InputManagement;
using SOLID_VNM.Core.Scenes.ChoiceScene;
using SOLID_VNM.Displays.TextDisplay;
using SOLID_VNM.Displays.ImageDisplay;
using SOLID_VNM.Displays.BackgroundDisplay;
using SOLID_VNM.Displays.ChoiceDisplay;
using System;

namespace SOLID_VNM.Core.Installers
{
    public class GameBehaviourInstaller : MonoInstaller<GameBehaviourInstaller>
    {
        public override void InstallBindings()
        {
            InstallCore();
            InstallFactories();
            InstallDialogueScene();
            InstallChoiceScene();
        }

        private void InstallCore()
        {
            Container.Bind<GameLoop>().AsSingle();
        }

        private void InstallFactories()
        {
            Container.Bind<SceneControllerDiscriminator>().AsSingle();
            Container.Bind<SceneFactory>().AsSingle();
            Container.Bind<SceneFacadeFactory>().AsSingle();
        }

        private void InstallDialogueScene()
        {
            Container.Bind<DialogueSceneController>().AsSingle();
            Container.Bind<IDialogueScenePlayer>().To<ConcreteDialogueScenePlayer>().AsSingle();

            Container.BindFactoryCustomInterface<IDialogueSceneModel, ISceneFacade, ConcreteDialogueScene, ConcreteDialogueScene.Factory, IDialogueSceneFactory>();
            Container.BindFactoryCustomInterface<IDialogueNode, ConcreteDialogueScene.Facade, ConcreteDialogueScene.Facade.Factory, IDialogueSceneFacadeFactory>();

            Container.Bind<IDialogueSceneModelTextDisplayContentExtractor>().To<ConcreteDialogueSceneModelTextDisplayContentExtractor>().AsSingle();
            Container.Bind<IDialogueSceneModelImageDisplayContentExtractor>().To<ConcreteDialogueSceneModelImageDisplayContentExtractor>().AsSingle();
            Container.Bind<IDialogueSceneModelBackgroundDisplayContentExtractor>().To<ConcreteDialogueSceneModelBackgroundDisplayContentExtractor>().AsSingle();
        }

        private void InstallChoiceScene()
        {
            Container.Bind<ChoiceSceneController>().AsSingle();
            Container.Bind<IChoiceScenePlayer>().To<ConcreteChoiceScenePlayer>().AsSingle();

            Container.BindFactoryCustomInterface<IChoiceSceneModel, ISceneFacade[], ConcreteChoiceScene, ConcreteChoiceScene.Factory, IChoiceSceneFactory>();
            Container.BindFactoryCustomInterface<IChoiceNode, ConcreteChoiceScene.Facade, ConcreteChoiceScene.Facade.Factory, IChoiceSceneFacadeFactory>();


            Container.Bind<IChoiceScenModelChoiceChoiceDisplayContentExtractor>().To<ConcreteChoiceScenModelChoiceChoiceDisplayContentExtractor>().AsSingle();
            Container.Bind<IChoiceSceneModelBackgroundDisplayContentExtractor>().To<ConcreteChoiceSceneModelBackgroundDisplayContentExtractor>().AsSingle();
        }
    }
}