﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Zenject;


namespace SOLID_VNM.Displays.ChoiceDisplay
{
    public class ChoiceDisplayInstaller : MonoInstaller
    {
        [SerializeField]
        private ChoiceDisplayView _choiceDisplayView;

        public override void InstallBindings()
        {
            Container.BindInstance(_choiceDisplayView);
        }
    }
}