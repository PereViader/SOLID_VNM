using UnityEngine;
using Zenject;

using SOLID_VNM.Actors;

namespace SOLID_VNM.Scenes.Dialogue
{
    public enum ActorPosition
    {
        Left,
        Right
    }

    public interface DialogueSceneModel : SceneModel
    {
        Actor MainActor { get; }
        Actor[] Actors { get; }
        string Text { get; }
        Sprite Background { get; }

        ActorPosition ActorPosition(Actor actor);
    }

    public class DialogueSceneModelImpl : DialogueSceneModel
    {
        private Actor _mainActor;
        private Actor[] _actors;
        private string _text;
        private Sprite _background;

        public DialogueSceneModelImpl(Actor mainActor, Actor[] actors, string text, Sprite background)
        {
            _mainActor = mainActor;
            _actors = actors;
            _text = text;
            _background = background;
        }

        Actor DialogueSceneModel.MainActor { get { return _mainActor; } }

        Actor[] DialogueSceneModel.Actors { get { return _actors; } }

        string DialogueSceneModel.Text { get { return _text; } }

        Sprite DialogueSceneModel.Background { get { return _background; } }

        void SceneModel.Accept(SceneModelVisitor visitor)
        {
            visitor.Visit(this);
        }

        ActorPosition DialogueSceneModel.ActorPosition(Actor actor)
        {
            return SOLID_VNM.Scenes.Dialogue.ActorPosition.Right;
        }

        public class Factory : PlaceholderFactory<Actor, Actor[], string, Sprite, DialogueSceneModelImpl> { }
    }
}