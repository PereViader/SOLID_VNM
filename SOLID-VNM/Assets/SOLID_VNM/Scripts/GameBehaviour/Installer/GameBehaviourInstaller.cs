using UnityEngine;

using Zenject;

using SOLID_VNM.Dialogue;
using SOLID_VNM.GameBehaviour.Scenes;
using SOLID_VNM.GameBehaviour.Scenes.TextScene;
using SOLID_VNM.InputManagement;

namespace SOLID_VNM.GameBehaviour.Installers
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
            Container.Bind<TextSceneManager>().AsSingle();
            Container.BindFactory<SceneContentDialogue, ISceneDefinitionFacade, TextSceneDefinition, TextSceneDefinition.Factory>();
            Container.BindFactory<TextNode, TextSceneDefinition.Facade, TextSceneDefinition.Facade.Factory>();

            //Inputs
            Container.BindInterfacesAndSelfTo<NextEventRaiser>().AsSingle();
        }
    }
}