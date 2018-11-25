using UnityEngine;
using Zenject;

using SOLID_VNM.Actors;

namespace SOLID_VNM.Actors.Installers
{
    public class ActorsInstaller : MonoInstaller
    {
        [SerializeField] private ActorDatabase _actorDatabase;
        [SerializeField] private ActorActionSettings _actorActionSettings;

        public override void InstallBindings()
        {
            Container.Bind<ActorDatabase>().FromInstance(_actorDatabase);
            Container.Bind<ActorActionSettings>().FromInstance(_actorActionSettings);

            Container.Bind<IActorProvider>().To<ConcreteActorProvider>().AsSingle();
        }
    }
}