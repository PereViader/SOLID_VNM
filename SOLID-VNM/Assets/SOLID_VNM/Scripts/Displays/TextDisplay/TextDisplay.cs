using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using Zenject;
using TMPro;
using ModestTree;

using SOLID_VNM.Actors;

namespace SOLID_VNM.Displays.TextDisplay
{
    public interface ITextDisplay : IDisplay<TextDisplayContent> { }

    public class TextDisplayController : ITextDisplay, IInitializable
    {
        private readonly TextDisplayView _textDisplayView;

        public TextDisplayController(TextDisplayView textDisplayView)
        {
            _textDisplayView = textDisplayView;
        }

        void IInitializable.Initialize()
        {
            Hide();
        }

        void IDisplay<TextDisplayContent>.Display(TextDisplayContent content)
        {
            _textDisplayView.Display(content);
        }

        void IDisplay<TextDisplayContent>.Hide()
        {
            Hide();
        }

        private void Hide()
        {
            _textDisplayView.Hide();
        }
    }
}

