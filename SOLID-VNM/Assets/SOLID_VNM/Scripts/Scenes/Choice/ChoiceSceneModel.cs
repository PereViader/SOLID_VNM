using UnityEngine;
using Zenject;

namespace SOLID_VNM.Scenes.Choice
{
    public interface ChoiceSceneModel : SceneModel
    {
        Sprite Background { get; }
        ChoiceModel[] Choices { get; }
    }

    public interface ChoiceModel
    {
        string Text { get; }
    }


    public class ChoiceSceneModelImpl : ChoiceSceneModel
    {
        private Sprite _background;
        private ChoiceModelImpl[] _choices;


        Sprite ChoiceSceneModel.Background { get { return _background; } }
        ChoiceModel[] ChoiceSceneModel.Choices { get { return _choices; } }


        public ChoiceSceneModelImpl(Sprite background, ChoiceModelImpl[] choices)
        {
            _background = background;
            _choices = choices;
        }

        public void Accept(SceneModelVisitor sceneModelVisitor)
        {
            sceneModelVisitor.Visit(this);
        }

        public class Factory : PlaceholderFactory<Sprite, ChoiceModelImpl[], ChoiceSceneModelImpl> { }
    }

    public class ChoiceModelImpl : ChoiceModel
    {
        private string _text;

        public string Text { get { return _text; } }

        public ChoiceModelImpl(string text)
        {
            _text = text;
        }

        public class Factory : PlaceholderFactory<string, ChoiceModelImpl> { }
    }
}