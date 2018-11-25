using System.Collections.Generic;

using UnityEngine;
using Zenject;

using SOLID_VNM.Actors;

namespace SOLID_VNM.Displays.ActorDisplay
{
    public class ActorDisplayInstaller : MonoInstaller<ActorDisplayInstaller>
    {
        [SerializeField]
        private ActorDisplayView _actorDisplayView;

        [SerializeField]
        private SimpleActorDisplayBehaviour.Settings _actorDisplayBehaviourSettings;

        private void OnValidate()
        {
            Debug.Assert(_actorDisplayView != null, "ActorDisplayView not assigned", this);
        }

        public override void InstallBindings()
        {
            Container.BindInstance<ActorDisplayView>(_actorDisplayView);
            Container.BindInstance<SimpleActorDisplayBehaviour.Settings>(_actorDisplayBehaviourSettings);


            Container.BindInterfacesTo<ConcreteActorDisplay>().AsSingle().NonLazy();

            Container.Bind<IActorDisplayBehaviour>().To<SimpleActorDisplayBehaviour>().AsSingle();

            Container.BindFactory<List<IActor>, List<IActor>, ConcreteActorDisplayModel, ConcreteActorDisplayModel.Factory>();
        }
    }
}