using System;

using Zenject;
using ModestTree;

using SOLID_VNM.Actors;
using SOLID_VNM.Core.Scenes.TextScene;
using SOLID_VNM.Core.Scenes.ChoiceScene;

namespace SOLID_VNM.Displays.TextDisplay
{
    [Serializable]
    public class TextDisplayContent : IDisplayContent, IDisposable
    {
        private string _actorName;
        private string _text;


        public string ActorName { get { return _actorName; } }
        public string Text { get { return _text; } }

        public TextDisplayContent(string actorName, string text)
        {
            _actorName = actorName;
            _text = text;
        }

        public void Dispose()
        {
        }

        public class Factory : PlaceholderFactory<string, string, TextDisplayContent> { }
    }
}