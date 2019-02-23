using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

using SOLID_VNM.Displays.BackgroundDisplay.NoTransitionBehaviour;
using SOLID_VNM.Displays.BackgroundDisplay.FadeInTransitionBehaviour;


namespace SOLID_VNM.Displays.BackgroundDisplay
{
    public interface BackgroundDisplayModel : DisplayModel
    {
        void Visit(BackgroundDisplayModelVisitor visitor);
    }

    public interface BackgroundDisplayModelVisitor
    {
        void Accept(NoTransitionBackgroundDisplayModel model);
        void Accept(FadeInTransitionBackgroundDisplayModel model);
    }
}

