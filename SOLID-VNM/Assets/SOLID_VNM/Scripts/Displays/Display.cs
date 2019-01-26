namespace SOLID_VNM.Displays
{
    public interface DisplayContent
    {
    }

    public interface Display<T> where T : DisplayContent
    {
        void Display(T content);
        void Hide();
    }
}
