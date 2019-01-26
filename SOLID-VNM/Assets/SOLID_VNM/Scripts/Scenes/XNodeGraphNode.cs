using SOLID_VNM.Scenes.Choice;
using SOLID_VNM.Scenes.Dialogue;

namespace SOLID_VNM.Scenes
{
    public interface XNodeSceneNode
    {
        void Visit(XNodeSceneNodeVisitor visitor);
    }

    public interface XNodeSceneNodeVisitor
    {
        void Accept(XNodeChoiceNode choiceNode);
        void Accept(XNodeDialogueNode dialogueNode);
    }

    public interface XNodeSceneModel
    {
    }
}