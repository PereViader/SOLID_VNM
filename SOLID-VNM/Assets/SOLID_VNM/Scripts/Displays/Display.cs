namespace SOLID_VNM.Displays
{
    public interface IDisplayModel
    {
    }

    public interface IDisplay<T> where T : IDisplayModel
    {
        void Display(T content);
        void Hide();
    }
}
