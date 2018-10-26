namespace SOLID_VNM.Assets.Scripts.Text
{
    public interface ITextDatabase
    {
        string GetText(int id);

        int CreateText(string text);

        void UpdateText(int id, string text);
    }
}