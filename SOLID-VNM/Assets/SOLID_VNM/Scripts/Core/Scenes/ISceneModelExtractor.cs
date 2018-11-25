using SOLID_VNM.Displays;

namespace SOLID_VNM.Core.Scenes
{
    public interface ISceneModelExtractor<S, D>
        where S : ISceneModel
        where D : IDisplayModel
    {
        D Extract(S content);
    }
}