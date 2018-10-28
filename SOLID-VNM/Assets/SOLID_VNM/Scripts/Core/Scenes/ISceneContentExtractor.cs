using SOLID_VNM.Displays;

namespace SOLID_VNM.Core.Scenes
{
    public interface ISceneContentExtractor<C, V>
        where C : SceneContent
        where V : IDisplayContent
    {
        V Extract(C content);
    }
}