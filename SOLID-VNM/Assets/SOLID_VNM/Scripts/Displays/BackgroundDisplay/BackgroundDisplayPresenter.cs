using System;
using Zenject;

namespace SOLID_VNM.Displays.BackgroundDisplay
{
    public interface BackgroundDisplayPresenter
    {
        void Start();
        void Tick();
        void Reset();
        void Hide();
    }
}