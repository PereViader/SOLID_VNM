using Zenject;

namespace SOLID_VNM.Displays.BackgroundDisplay
{
    public interface BackgroundDisplay : Display<BackgroundDisplayModel> { }

    public class BackgroundDisplayImp : BackgroundDisplay, IInitializable, ITickable
    {
        private readonly BackgroundDisplayPresenterSelectorFactory _presenterSelectorFactory;

        private BackgroundDisplayPresenter _activePresenter;

        public BackgroundDisplayImp(BackgroundDisplayPresenterSelectorFactory backgroundDisplayPresenterSelector)
        {
            _presenterSelectorFactory = backgroundDisplayPresenterSelector;
        }

        void IInitializable.Initialize()
        {
        }

        void Display<BackgroundDisplayModel>.Display(BackgroundDisplayModel backgroundDisplayModel)
        {
            if (_activePresenter != null)
            {
                _activePresenter.Hide();
                _activePresenter = null;
            }

            _activePresenter = _presenterSelectorFactory.Create(backgroundDisplayModel);
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
                _activePresenter.Reset();
                _activePresenter.Reset();
            }
        }
    }
}
