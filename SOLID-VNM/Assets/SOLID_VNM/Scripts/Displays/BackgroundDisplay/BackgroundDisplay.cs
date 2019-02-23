using Zenject;

namespace SOLID_VNM.Displays.BackgroundDisplay
{
    public interface BackgroundDisplay : Display<BackgroundDisplayModel> { }

    public class BackgroundDisplayImp : BackgroundDisplay, IInitializable, ITickable
    {
        private readonly BackgroundDisplayPresenterFactory _presenterFactory;

        private BackgroundDisplayPresenter _activePresenter;

        public BackgroundDisplayImp(BackgroundDisplayPresenterFactory backgroundDisplayPresenterSelector)
        {
            _presenterFactory = backgroundDisplayPresenterSelector;
        }

        void IInitializable.Initialize()
        {
        }

        void Display<BackgroundDisplayModel>.Display(BackgroundDisplayModel backgroundDisplayModel)
        {
            if (_activePresenter != null)
            {
                _activePresenter.End();
                _activePresenter = null;
            }

            _activePresenter = _presenterFactory.Create(backgroundDisplayModel);
            _activePresenter.Start();
        }

        public void Tick()
        {
            if (_activePresenter != null)
            {
                _activePresenter.Tick();
            }
        }

        void Display<BackgroundDisplayModel>.Stop()
        {
            if (_activePresenter != null)
            {
                _activePresenter.End();
            }
        }
    }
}
