using UnityEngine;

namespace SOLID_VNM.Actors
{
    public interface Actor
    {
        string Name { get; }
        Sprite Sprite { get; }
    }

    [CreateAssetMenu(menuName = "SOLID VNM/Actor")]
    public class ScriptableObjectActor : ScriptableObject, Actor
    {
        [SerializeField]
        private string _name;

        [SerializeField]
        private Sprite _sprite;

        string Actor.Name { get { return _name; } }

        Sprite Actor.Sprite { get { return _sprite; } }
    }
}
