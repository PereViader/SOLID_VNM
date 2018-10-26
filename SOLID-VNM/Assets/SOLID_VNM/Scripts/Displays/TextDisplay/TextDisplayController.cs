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
    public class TextDisplayController : IDisplay, IInitializable
    {
        readonly private TextDisplayView _textDisplayView;
        readonly private TextDisplayContentFactory _textDisplayContentFactory;

        public TextDisplayController(TextDisplayView textDisplayView, TextDisplayContentFactory textDisplayContentFactory)
        {
            _textDisplayView = textDisplayView;
            _textDisplayContentFactory = textDisplayContentFactory;
        }

        void IInitializable.Initialize()
        {
            Hide();
        }

        public void Display(SceneContent sceneContent)
        {
            using (TextDisplayContent textDisplayContent = _textDisplayContentFactory.Create(sceneContent))
            {
                _textDisplayView.Display(textDisplayContent);
            }
        }

        public void Hide()
        {
            _textDisplayView.Hide();
        }
    }
}

