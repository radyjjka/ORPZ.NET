using System.IO;
namespace Text;

public abstract class FileProcessor
{
    public string Text { get; set; }

    protected FileProcessor(string text)
    {
        Text = text;
    }

    public abstract void Transformation();

    public virtual string Read(string name)
    {
        string result;
        using (StreamReader sr = new StreamReader(name))
        {
            result = sr.ReadToEnd();
        }

        return result;
    }

    public virtual void Write(string name)
    {
        using (StreamWriter writer = new StreamWriter(name))
        {
            writer.WriteLine(Text);
        }
    }
}