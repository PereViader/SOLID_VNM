using Zenject;

namespace SOLID_VNM.Actors
{
    public interface ActorProvider
    {
        Actor GetActorById(string id);
    }

    public class ActorProviderImpl : ActorProvider
    {
        private readonly ActorDatabase _actorDatabase;

        public ActorProviderImpl(ActorDatabase actorDatabase)
        {
            _actorDatabase = actorDatabase;
        }

        Actor ActorProvider.GetActorById(string id)
        {
            return _actorDatabase.actors.Find(x => ((UnityEngine.Object)x).name.Equals(id));
        }
    }
}