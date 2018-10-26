using UnityEngine;
using Zenject;

namespace SOLID_VNM.Displays.ImageDisplay
{
    public class ImageDisplayInstaller : MonoInstaller
    {
        [SerializeField]
        private ImageDisplayView _imageDisplayView;

        public override void InstallBindings()
        {
            Container.BindInstance(_imageDisplayView);

            Container.Bind<ImageDisplayController>().AsSingle().NonLazy();
            Container.Bind<ImageDisplayContentExtractor>().AsSingle().NonLazy();

            Container.BindFactory<Sprite, ImageDisplayConentSprited, ImageDisplayConentSprited.Factory>()
                .FromPoolableMemoryPool(x =>
                    x.WithInitialSize(1)
            );

            Container.BindFactory<Sprite, AnimationClip, ImageDisplayConentSpritedAnimated, ImageDisplayConentSpritedAnimated.Factory>()
                .FromPoolableMemoryPool(x =>
                    x.WithInitialSize(1)
            );
        }
    }
}