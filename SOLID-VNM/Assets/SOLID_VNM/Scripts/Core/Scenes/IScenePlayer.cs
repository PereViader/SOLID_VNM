﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SOLID_VNM.Core.Scenes.TextScene
{
    public interface IScenePlayer<T> where T : ISceneDefinition
    {
        void Play(T sceneDefinition);
        void End();
    }
}