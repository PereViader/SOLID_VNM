using System;

using UnityEngine;

namespace SOLID_VNM.Core.Scenes.ChoiceScene
{
    public interface IChoiceSceneModel : ISceneModel
    {
        Sprite Background { get; }
        IChoiceModel[] Choices { get; }
    }

    public interface IChoiceModel
    {
        string Text { get; }
    }

    [Serializable]
    public class ConcreteChoiceSceneModel : IChoiceSceneModel
    {
        [SerializeField]
        private Sprite _background;

        [SerializeField]
        private ConcreteChoiceModel[] _choices;

        Sprite IChoiceSceneModel.Background { get { return _background; } }

        IChoiceModel[] IChoiceSceneModel.Choices { get { return _choices; } }

        public void Accept(ISceneModelVisitor sceneModelVisitor)
        {
            sceneModelVisitor.Visit(this);
        }
    }

    [Serializable]
    public class ConcreteChoiceModel : IChoiceModel
    {
        [SerializeField]
        private string _text;

        public string Text { get { return _text; } }
    }
}