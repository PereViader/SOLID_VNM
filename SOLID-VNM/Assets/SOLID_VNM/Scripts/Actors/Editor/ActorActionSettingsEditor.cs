using UnityEngine;
using UnityEditor;

using SOLID_VNM.Actors;
using Malee.Editor;

namespace SOLID_VNM_Editor.Actors
{
    [CustomEditor(typeof(ActorActionSettings))]
    public class ActorActionSettingsEditor : Editor
    {
        private ReorderableList _actionToAnimationClip;

        private void OnEnable()
        {
            _actionToAnimationClip = new ReorderableList(serializedObject.FindProperty("actionToAnimationClip"));
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            _actionToAnimationClip.DoLayoutList();
            serializedObject.ApplyModifiedProperties();
        }
    }
}
