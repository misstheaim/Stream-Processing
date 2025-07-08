namespace Stream_Processing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using Logger logger = new Logger();
            try
            {
                using FileWorker inputWorker = new FileWorker("files/input.txt", logger);
                using FileWorker outputWorker = new FileWorker("files/output.txt", logger);

                List<string> strings = inputWorker.ReadTextLines();

                DataProcessor.FilterListByWord(strings, "skip");
                DataProcessor.ListToUppercase(strings);
                DataProcessor.SortListByAlphabet(strings);

                outputWorker.WriteTextLines(strings);
            }
            catch (Exception ex)
            {
                logger.Log($"Some exception occurred with message:\n{ex.ToString()}");
                Console.WriteLine(ex.Message);
            }

            logger.Dispose();
            Console.WriteLine("Your file is processed!\nEnter any key to delete it and exit the program.");
            Console.ReadKey();
            File.Delete("files/output.txt");
        }
    }
}
