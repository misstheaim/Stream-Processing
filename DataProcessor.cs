namespace Stream_Processing;

internal static class DataProcessor
{
    public static void FilterListByWord(List<string> list, string word)
    {
        CheckList(list);

        if (String.IsNullOrEmpty(word)) return;

        List<string> linesToRemove = new List<string>();

        foreach (string line in list)
        {
            if (line.Contains(word, StringComparison.OrdinalIgnoreCase)) linesToRemove.Add(line);
        }
        foreach (string line in linesToRemove)
        {
            list.Remove(line);
        }
    }

    public static void ListToUppercase(List<string> list)
    {
        CheckList(list);

        for (int i = 0; i < list.Count; i++)
        {
            list[i] = list[i].ToUpper();
        }
    }

    public static void SortListByAlphabet(List<string> list)
    {
        CheckList(list);

        list.Sort();
    }

    private static void CheckList(List<string> list)
    {
        if (list == null) throw new ArgumentNullException("List is null.");
    }
}
