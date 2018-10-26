using System;

using UnityEditor;
using UnityEngine;

using Malee;
using Malee.Editor;


using SOLID_VNM.Actors;

namespace SOLID_VNM_EDITOR.Actors
{
    [CustomEditor(typeof(ActorDatabase))]
    public class ActorDatabaseEditor : Editor
    {
        private ReorderableList _actors;

        private void OnEnable()
        {
            _actors = new ReorderableList(serializedObject.FindProperty("actors"));
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            _actors.DoLayoutList();
            serializedObject.ApplyModifiedProperties();
        }
    }
}