using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SOLID_VNM.Actors
{
    [CreateAssetMenu(menuName = "SOLID VNM/ActorDatabase")]
    public class ActorDatabase : ScriptableObject
    {
        public List<ScriptableObjectActor> actors;
    }
}
