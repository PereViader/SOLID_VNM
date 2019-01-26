namespace SOLID_VNM.Scenes
{
    public interface XNodeSceneModelSceneModelMapper<T, R>
            where T : XNodeSceneModel
            where R : SceneModel
    {
        R From(T graphNode);
    }
}