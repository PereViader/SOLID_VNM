namespace SOLID_VNM.Displays
{
    public interface IDisplayContent
    {
    }

    public interface IDisplay<T> where T : IDisplayContent
    {
        void Display(T content);
        void Hide();
    }
}
