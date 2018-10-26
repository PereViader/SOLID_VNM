using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SOLID_VNM.Actors
{
    [CreateAssetMenu(menuName = "Custom/ActorDatabase")]
    public class ActorDatabase : ScriptableObject
    {
        public List<Actor> actors;
    }
}
