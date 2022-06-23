using System;
namespace Text;

public class FullUpper : TextTransformer
{
    public FullUpper(FileProcessor FileProcessor, string text) : base(FileProcessor, text)
    {
    }

    public override void Transformation()
    {
        Text = Text.ToUpper();
    }
}