using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SOLID_VNM.Core.Scenes
{
    public interface IScenePlayer<S> where S : IScene
    {
        void Play(S scene);
        void End();
    }
}