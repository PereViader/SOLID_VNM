using System;

using UnityEngine;

using Zenject;

using SOLID_VNM.Actors;
using SOLID_VNM.InputManagement;

using SOLID_VNM.Scenes;
using SOLID_VNM.Scenes.Dialogue;
using SOLID_VNM.Scenes.Choice;

using SOLID_VNM.Displays.TextDisplay;
using SOLID_VNM.Displays.BackgroundDisplay;
using SOLID_VNM.Displays.ChoiceDisplay;

namespace SOLID_VNM.Installers
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
            Container.Bind<Core>().AsSingle();
            Container.Bind<SceneControllerSelectorFactory>().To<SceneControllerSelectorFactoryImpl>().AsSingle();
            Container.Bind<SceneFacadeSelectorFactory>().To<SceneFacadeSelectorFactoryImpl>().AsSingle();
            Container.Bind<SceneSelectorFactory>().To<SceneSelectorFactoryImpl>().AsSingle();
        }

        private void InstallGraph()
        {
            Container.BindFactory<XNodeVisualNovelGraph, VisualNovelGraphImpl, VisualNovelGraphImpl.Factory>();
            Container.Bind<XNodeSceneNodeFactorySelector>().To<XNodeSceneNodeFactorySelectorImpl>().AsSingle();
        }

        private void InstallDialogue()
        {
            Container.BindFactory<XNodeDialogueNode, DialogueNodeImpl, DialogueNodeImpl.Factory>();

            Container.BindFactory<DialogueScene, DialogueSceneController, DialogueSceneController.Factory>();
            Container.Bind<DialogueScenePlayer>().To<ConcreteDialogueScenePlayer>().AsSingle();

            Container.BindFactory<Actor, Actor[], string, Sprite, DialogueSceneModelImpl, DialogueSceneModelImpl.Factory>();
            Container.Bind<XNodeDialogueNodeSceneModelMapper>().To<XNodeDialogueNodeSceneModelMapperImpl>().AsSingle();

            Container.BindFactoryCustomInterface<DialogueSceneModel, SceneFacade, DialogueSceneImpl, DialogueSceneImpl.Factory, DialogueSceneFactory>();
            Container.BindFactoryCustomInterface<DialogueNode, DialogueSceneImpl.Facade, DialogueSceneImpl.Facade.Factory, DialogueSceneFacadeFactory>();

            Container.Bind<DialogueSceneModelTextDisplayContentMapper>().To<DialogueSceneModelTextDisplayContentMapperImpl>().AsSingle();
            Container.Bind<DialogueSceneModelActorDisplayContentMapper>().To<DialogueSceneModelActorDisplayModelMapperImpl>().AsSingle();
            Container.Bind<DialogueSceneModelBackgroundDisplayContentMapper>().To<DialogueSceneModelBackgroundDisplayContentMapperImpl>().AsSingle();
        }

        private void InstallChoice()
        {
            Container.BindFactory<XNodeChoiceNode, ChoiceNodeImpl, ChoiceNodeImpl.Factory>();

            Container.BindFactory<ChoiceScene, ChoiceSceneController, ChoiceSceneController.Factory>();
            Container.Bind<ChoiceScenePlayer>().To<ConcreteChoiceScenePlayer>().AsSingle();

            Container.BindFactory<Sprite, ChoiceModelImpl[], ChoiceSceneModelImpl, ChoiceSceneModelImpl.Factory>();
            Container.BindFactory<string, ChoiceModelImpl, ChoiceModelImpl.Factory>();

            Container.Bind<XNodeChoiceNodeSceneModelMapper>().To<XNodeChoiceNodeSceneModelMapperImpl>().AsSingle();

            Container.BindFactoryCustomInterface<ChoiceSceneModel, SceneFacade[], ChoiceSceneImpl, ChoiceSceneImpl.Factory, ChoiceSceneFactory>();
            Container.BindFactoryCustomInterface<ChoiceNode, ChoiceSceneImpl.Facade, ChoiceSceneImpl.Facade.Factory, ChoiceSceneFacadeFactory>();

            Container.Bind<ChoiceScenModelChoiceChoiceDisplayContentExtractor>().To<ChoiceScenModelChoiceChoiceDisplayContentExtractorImpl>().AsSingle();
            Container.Bind<ChoiceSceneModelBackgroundDisplayContentExtractor>().To<ChoiceSceneModelBackgroundDisplayContentExtractorImpl>().AsSingle();
        }
    }
}