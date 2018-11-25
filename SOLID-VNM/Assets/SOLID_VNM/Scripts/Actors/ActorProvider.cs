using Zenject;

namespace SOLID_VNM.Actors
{
    public interface IActorProvider
    {
        IActor GetActorById(string id);
    }

    public class ConcreteActorProvider : IActorProvider
    {
        private readonly ActorDatabase _actorDatabase;

        public ConcreteActorProvider(ActorDatabase actorDatabase)
        {
            _actorDatabase = actorDatabase;
        }

        IActor IActorProvider.GetActorById(string id)
        {
            return _actorDatabase.actors.Find(x => ((UnityEngine.Object)x).name.Equals(id));
        }
    }
}