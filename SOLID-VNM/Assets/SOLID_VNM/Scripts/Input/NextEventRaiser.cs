using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Zenject;

namespace SOLID_VNM.InputManagement
{
    public class NextEventRaiser : ITickable
    {
        public INextHandler NextHandler { get; set; }

        public void Tick()
        {
            if (Input.anyKeyDown && NextHandler != null)
            {
                NextHandler.OnNext();
            }
        }
    }
}
