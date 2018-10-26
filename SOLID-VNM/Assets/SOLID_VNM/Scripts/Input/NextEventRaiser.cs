using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Zenject;

namespace SOLID_VNM.InputManagement
{
    public class NextEventRaiser : ITickable
    {
        private Stack<INextHandler> _nextHandlers = new Stack<INextHandler>();

        public INextHandler CurrentNextHandler { get { return _nextHandlers.Peek(); } }

        public void Push(INextHandler nextHandler)
        {
            _nextHandlers.Push(nextHandler);
        }

        public void Pop()
        {
            _nextHandlers.Pop();
        }

        public void Tick()
        {
            if (Input.anyKeyDown && CurrentNextHandler != null)
            {
                CurrentNextHandler.OnNext();
            }
        }
    }
}
