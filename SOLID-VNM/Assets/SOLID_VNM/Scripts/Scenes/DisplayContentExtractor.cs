using SOLID_VNM.Displays;

namespace SOLID_VNM.Scenes
{
    public interface SceneModelDisplayContentMapper<M, C>
        where M : SceneModel
        where C : DisplayModel
    {
        C From(M model);
    }
}