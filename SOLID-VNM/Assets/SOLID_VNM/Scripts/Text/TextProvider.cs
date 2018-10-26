namespace SOLID_VNM.Assets.Scripts.Text
{
    public class TextProvider
    {
        private readonly ITextDatabase _textDatabase;

        public TextProvider(ITextDatabase textDatabase)
        {
            _textDatabase = textDatabase;
        }

        public string GetText(int id)
        {
            return _textDatabase.GetText(id);
        }
    }
}