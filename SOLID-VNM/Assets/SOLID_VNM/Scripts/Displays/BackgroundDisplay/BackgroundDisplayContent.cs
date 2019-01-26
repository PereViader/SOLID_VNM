using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace SOLID_VNM.Displays.BackgroundDisplay
{
    public class BackgroundDisplayContent : DisplayContent, IDisposable
    {
        private Sprite _backgroundSprite;

        public Sprite BackgroundSprite { get { return _backgroundSprite; } }

        public BackgroundDisplayContent(Sprite backgroundSprite)
        {
            _backgroundSprite = backgroundSprite;
        }

        public void Dispose()
        {
        }

        public class Factory : PlaceholderFactory<Sprite, BackgroundDisplayContent> { }
    }
}

