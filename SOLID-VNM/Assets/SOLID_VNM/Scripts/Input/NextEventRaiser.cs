using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Zenject;

namespace SOLID_VNM.InputManagement
{
    public class NextEventRaiser : MonoBehaviour
    {
        private Stack<INextHandler> _nextHandlers = new Stack<INextHandler>();

        public INextHandler CurrentNextHandler { get { return _nextHandlers.Count > 0 ? _nextHandlers.Peek() : null; } }

        public void Push(INextHandler nextHandler)
        {
            _nextHandlers.Push(nextHandler);
        }

        public void Pop()
        {
            _nextHandlers.Pop();
        }

        private void Update()
        {
            if (Input.anyKeyDown && _nextHandlers.Count > 0)
            {
                _nextHandlers.Peek().OnNext();
            }
        }
    }
}
