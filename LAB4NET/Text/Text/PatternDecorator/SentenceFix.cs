using System;
using System.Text;

namespace Text;

public class SentenceFix : TextTransformer
{
    public SentenceFix(FileProcessor FileProcessor, string text) : base(FileProcessor, text)
    {
    }

    public override void Transformation()
    {
        StringBuilder sb = new StringBuilder(Text);
        sb[0] = char.ToUpper(sb[0]);
        for (int i = 1; i < sb.Length; i++)
        {
            sb[i] = char.ToLower(sb[i]);
        }

        Text = sb.ToString();

    }
}