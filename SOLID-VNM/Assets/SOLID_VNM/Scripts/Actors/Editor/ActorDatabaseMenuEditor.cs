using UnityEngine;
using UnityEditor;

using SOLID_VNM.Actors;

namespace SOLID_VNM_EDITOR.Actors
{
    public class ActorDatabaseMenuEditor : EditorWindow
    {
        private readonly static string ACTOR_DATABASE_PATH = "Assets/Configurations/ActorDatabase.asset";
        private readonly static string WINDOW_TITLE = "Actor Database";

        private ActorDatabase _actorDatabase;
        private Editor _actorDatabaseEditor;

        [MenuItem("SOLID VNM/Actor Database")]
        public static void ShowWindow()
        {
            EditorWindow.GetWindow(typeof(ActorDatabaseMenuEditor), false, WINDOW_TITLE, true);
        }

        private void OnEnable()
        {
            if (_actorDatabase == null)
            {
                _actorDatabase = LoadOrCreateActorDatabase();
                _actorDatabaseEditor = Editor.CreateEditor(_actorDatabase);
            }
        }

        private ActorDatabase LoadOrCreateActorDatabase()
        {
            ActorDatabase actorDatabase = AssetDatabase.LoadAssetAtPath<ActorDatabase>(ACTOR_DATABASE_PATH);
            if (actorDatabase == null)
            {
                actorDatabase = ScriptableObject.CreateInstance<ActorDatabase>();
                AssetDatabase.CreateAsset(actorDatabase, ACTOR_DATABASE_PATH);
            }
            return actorDatabase;
        }

        private void OnGUI()
        {
            _actorDatabaseEditor.OnInspectorGUI();
        }
    }
}
