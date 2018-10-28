
using System;
using Zenject;

namespace SOLID_VNM.Displays.ChoiceDisplay
{
    public class ChoiceDisplayContent : IDisplayContent, IDisposable
    {
        private Choice[] _choices;

        public Choice[] Choices { get { return _choices; } }

        public ChoiceDisplayContent(Choice[] choices)
        {
            _choices = choices;
        }

        void IDisposable.Dispose()
        {
        }

        public class Choice
        {
            public string text;
        }

        public class Factory : PlaceholderFactory<Choice[], ChoiceDisplayContent> { }
    }
}

