namespace Text
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var text = "text";
            FileProcessor fileWriter = new FileWriter(text);
            fileWriter.Transformation();
            

            fileWriter = new SentenceFix(fileWriter,fileWriter.Text);
            fileWriter.Transformation();
            fileWriter.Write("SentenceFix.txt");

            fileWriter = new FullUpper(fileWriter,fileWriter.Text);
            fileWriter.Transformation();
            fileWriter.Write("FullUpper.txt");
        }
    }
}