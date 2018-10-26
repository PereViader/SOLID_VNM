using UnityEngine;
using Zenject;

namespace SOLID_VNM.Displays.TextDisplay
{
    public class TextDisplayInstaller : MonoInstaller
    {
        [SerializeField]
        private TextDisplayView _textDisplayView;

        private void OnValidate()
        {
            Debug.Assert(_textDisplayView != null, "TextDisplayView not assigned", this);
        }

        public override void InstallBindings()
        {
            Container.BindInstance(_textDisplayView);

            Container.BindFactory<string, string, TextDisplayContent, TextDisplayContent.Factory>();

            Container.Bind<TextDisplayController>().AsSingle().NonLazy();
            Container.Bind<TextDisplayContentFactory>().AsSingle();
        }
    }
}