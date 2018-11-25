using UnityEngine;

namespace SOLID_VNM.Actors
{
    public interface IActor
    {
        string Name { get; }
        Sprite Sprite { get; }
    }

    [System.Serializable]
    public class Actor : IActor
    {
        [SerializeField]
        private string _name;

        [SerializeField]
        private Sprite _sprite;

        string IActor.Name { get { return _name; } }

        Sprite IActor.Sprite { get { return _sprite; } }
    }
}
