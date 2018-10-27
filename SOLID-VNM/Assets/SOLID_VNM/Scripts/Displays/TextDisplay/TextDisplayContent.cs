using System;

using Zenject;
using ModestTree;

using SOLID_VNM.Actors;
using SOLID_VNM.Core.Scenes.TextScene;
using SOLID_VNM.Core.Scenes.ChoiceScene;

namespace SOLID_VNM.Displays.TextDisplay
{
    [Serializable]
    public class TextDisplayContent : IDisposable
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

        public class Factory : PlaceholderFactory<string, string, TextDisplayContent>
        {
        }

    }

    public class TextDisplayContentFactory : ISceneContentVisitor
    {
        readonly private TextDisplayContent.Factory _factory;
        readonly private ActorProvider _actorProvider;

        private TextDisplayContent _textDisplayContent;

        public TextDisplayContentFactory(ActorProvider actorProvider, TextDisplayContent.Factory factory)
        {
            _actorProvider = actorProvider;
            _factory = factory;
        }

        public TextDisplayContent Create(SceneContent sceneContent)
        {
            Assert.IsNotNull(sceneContent);
            sceneContent.Accept(this);
            return _textDisplayContent;
        }

        private TextDisplayContent Create(SceneContentDialogue sceneContentDialogue)
        {
            Assert.IsNotNull(sceneContentDialogue);

            Actor actor = _actorProvider.GetActorById(sceneContentDialogue.actorId);
            return _factory.Create(actor.name, sceneContentDialogue.text);
        }

        public void Visit(SceneContentDialogue sceneContentDialogue)
        {
            _textDisplayContent = Create(sceneContentDialogue);
        }

        public void Visit(SceneContentChoice sceneContentChoice)
        {
            _textDisplayContent = null;
        }
    }
}