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
    public interface TextDisplay : Display<TextDisplayContent> { }

    public class TextDisplayImp : TextDisplay, IInitializable
    {
        private readonly TextDisplayBehaviour _textDisplayBehaviour;

        public TextDisplayImp(TextDisplayBehaviour textDisplayBehaviour)
        {
            _textDisplayBehaviour = textDisplayBehaviour;
        }

        void IInitializable.Initialize()
        {
            Hide();
        }

        void Display<TextDisplayContent>.Display(TextDisplayContent content)
        {
            _textDisplayBehaviour.Display(content);
            _textDisplayBehaviour.Show();
        }

        void Display<TextDisplayContent>.Stop()
        {
            Hide();
        }

        private void Hide()
        {
            _textDisplayBehaviour.Hide();
        }
    }
}

