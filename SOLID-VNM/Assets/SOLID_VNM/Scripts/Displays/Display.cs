namespace SOLID_VNM.Displays
{
    public interface DisplayModel
    {
    }

    public interface Display<T> where T : DisplayModel
    {
        void Display(T model);
        void Stop();
    }
}
