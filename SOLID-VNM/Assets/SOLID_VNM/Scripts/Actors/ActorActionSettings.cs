using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SOLID_VNM.Actors
{
    [CreateAssetMenu(menuName = "Custom/ActorActionSettings")]
    public class ActorActionSettings : ScriptableObject
    {
        [SerializeField]
        private KeyValue[] actionToAnimationClip;

        public AnimationClip GetAnimationClipByAction(string action)
        {
            for (int i = 0; i < actionToAnimationClip.Length; i++)
            {
                if (actionToAnimationClip[i].key == action)
                {
                    return actionToAnimationClip[i].value;
                }
            }
            return null;
        }


        [System.Serializable]
        private struct KeyValue
        {
            public string key;
            public AnimationClip value;
        }
    }
}