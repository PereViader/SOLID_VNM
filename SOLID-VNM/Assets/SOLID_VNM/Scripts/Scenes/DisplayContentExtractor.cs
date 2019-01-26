using SOLID_VNM.Displays;

namespace SOLID_VNM.Scenes
{
    public interface SceneModelDisplayContentMapper<M, C>
        where M : SceneModel
        where C : DisplayContent
    {
        C From(M model);
    }
}