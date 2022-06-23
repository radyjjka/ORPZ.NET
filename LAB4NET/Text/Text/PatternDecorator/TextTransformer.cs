namespace Text;

public abstract class TextTransformer : FileProcessor
{
    protected FileProcessor FileProcessor;
        
    protected TextTransformer(FileProcessor fileWriter, string text) : base(text)
    {
        this.FileProcessor = fileWriter;
    }

    public override void Write(string fileName)
    {
        if (FileProcessor != null)
        {
            FileProcessor.Text = this.Text;
            FileProcessor.Write(fileName);
        }
    }

    public override string Read(string fileName)
    {
        if (FileProcessor != null)
        {
            return FileProcessor.Read(fileName);
        }

        return string.Empty;
    }
}