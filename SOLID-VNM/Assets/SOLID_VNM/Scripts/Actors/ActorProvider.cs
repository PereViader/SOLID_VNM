using Zenject;

namespace SOLID_VNM.Actors
{
    public class ActorProvider
    {
        readonly private ActorDatabase _actorDatabase;

        public ActorProvider(ActorDatabase actorDatabase)
        {
            _actorDatabase = actorDatabase;
        }

        public Actor GetActorById(int id)
        {
            if (id < 0 || id >= _actorDatabase.actors.Count)
            {
                return null;
            }

            return _actorDatabase.actors[id];
        }
    }
}