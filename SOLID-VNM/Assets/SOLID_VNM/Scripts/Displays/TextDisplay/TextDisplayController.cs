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

        public void Display(TextDisplayContent content)
        {
            _textDisplayView.Display(content);
        }

        public void Hide()
        {
            _textDisplayView.Hide();
        }

    }
}

