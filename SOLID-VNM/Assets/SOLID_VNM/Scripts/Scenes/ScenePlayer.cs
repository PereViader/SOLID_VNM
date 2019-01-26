using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SOLID_VNM.Scenes
{
    public interface ScenePlayer<S> where S : Scene
    {
        void Play(S scene);
        void End();
    }
}