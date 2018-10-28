using UnityEngine;

using Zenject;

using SOLID_VNM.Dialogue;
using SOLID_VNM.Core.Scenes;
using SOLID_VNM.Core.Scenes.TextScene;
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
            InstallTextScene();
            InstallChoiceScene();
        }

        private void InstallCore()
        {
            Container.Bind<GameLoop>().AsSingle();
        }

        private void InstallFactories()
        {
            Container.Bind<SceneControllerDiscriminator>().AsSingle();
            Container.Bind<SceneDefinitionFactory>().AsSingle();
            Container.Bind<SceneDefinitionFacadeFactory>().AsSingle();
        }

        private void InstallTextScene()
        {
            Container.Bind<TextSceneController>().AsSingle();
            Container.Bind<ITextScenePlayer>().To<TextScenePlayer>().AsSingle();

            Container.BindFactory<SceneContentDialogue, ISceneDefinitionFacade, TextSceneDefinition, TextSceneDefinition.Factory>();
            Container.BindFactory<TextNode, TextSceneDefinition.Facade, TextSceneDefinition.Facade.Factory>();

            Container.Bind<ISceneContentDialogueTextDisplayContentExtractor>().To<SceneContentDialogueTextDisplayContentExtractor>().AsSingle();
            Container.Bind<ISceneContentDialogueImageDisplayContentExtractor>().To<SceneContentDialogueImageDisplayContentExtractor>().AsSingle();
            Container.Bind<ISceneContentDialogueBackgroundDisplayContentExtractor>().To<SceneContentDialogueBackgroundDisplayContentExtractor>().AsSingle();
        }

        private void InstallChoiceScene()
        {
            Container.Bind<ChoiceSceneController>().AsSingle();
            Container.Bind<IChoiceScenePlayer>().To<ChoiceScenePlayer>().AsSingle();

            Container.BindFactory<SceneContentChoice, ISceneDefinitionFacade[], ChoiceSceneDefinition, ChoiceSceneDefinition.Factory>();
            Container.BindFactory<ChoiceNode, ChoiceSceneDefinition.Facade, ChoiceSceneDefinition.Facade.Factory>();

            Container.Bind<ISceneContentChoiceChoiceDisplayContentExtractor>().To<SceneContentChoiceChoiceDisplayContentExtractor>().AsSingle();
            Container.Bind<ISceneContentChoiceBackgroundDisplayContentExtractor>().To<SceneContentChoiceBackgroundDisplayContentExtractor>().AsSingle();
        }
    }
}