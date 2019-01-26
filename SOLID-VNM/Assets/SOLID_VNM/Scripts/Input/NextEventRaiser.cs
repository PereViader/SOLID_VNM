using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Zenject;

namespace SOLID_VNM.InputManagement
{
    public class NextEventRaiser : MonoBehaviour
    {
        private NextHandler _nextHandler;

        public NextHandler NextHandler
        {
            get { return _nextHandler; }
            set
            {
                _nextHandler = value;
                enabled = _nextHandler != null;
            }
        }

        private void Update()
        {
            if (NextHandler != null && Input.anyKeyDown)
            {
                NextHandler.OnNext();
            }
        }
    }
}
