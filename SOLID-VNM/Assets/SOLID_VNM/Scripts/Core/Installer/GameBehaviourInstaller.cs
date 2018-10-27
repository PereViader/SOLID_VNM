using UnityEngine;

using Zenject;

using SOLID_VNM.Dialogue;
using SOLID_VNM.Core.Scenes;
using SOLID_VNM.Core.Scenes.TextScene;
using SOLID_VNM.InputManagement;
using SOLID_VNM.Core.Scenes.ChoiceScene;

namespace SOLID_VNM.Core.Installers
{
    public class GameBehaviourInstaller : MonoInstaller<GameBehaviourInstaller>
    {
        public override void InstallBindings()
        {
            //-------------Classes-------------
            Container.Bind<GameLoop>().AsSingle();


            //-------------Factories-------------
            Container.Bind<ScenePlayerDiscriminator>().AsSingle();
            Container.Bind<SceneDefinitionFactory>().AsSingle();
            Container.Bind<SceneDefinitionFacadeFactory>().AsSingle();


            //TextScene
            Container.Bind<TextScenePlayer>().AsSingle();
            Container.BindFactory<SceneContentDialogue, ISceneDefinitionFacade, TextSceneDefinition, TextSceneDefinition.Factory>();
            Container.BindFactory<TextNode, TextSceneDefinition.Facade, TextSceneDefinition.Facade.Factory>();

            //TextScene
            Container.Bind<ChoiceScenePlayer>().AsSingle();
            Container.BindFactory<SceneContentChoice, ISceneDefinitionFacade[], ChoiceSceneDefinition, ChoiceSceneDefinition.Factory>();
            Container.BindFactory<ChoiceNode, ChoiceSceneDefinition.Facade, ChoiceSceneDefinition.Facade.Factory>();
        }
    }
}