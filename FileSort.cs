using System;

class MergeSort
{

    static void ExternalSort(string inputFile)
    {
        // Reading data from the input file and splitting into chunksи

        string[] lines = File.ReadAllLines(inputFile);
        int chunkSize = lines.Length / 2 + 1;


        List<string> chunkFiles = new List<string>();

        using (StreamReader sr = new StreamReader(inputFile))
        {

            int i = 0;
            while (!sr.EndOfStream)
            {
                List<string> chunk = new List<string>();
                for (int j = 0; j < chunkSize && !sr.EndOfStream; j++)
                {
                    chunk.Add(sr.ReadLine());
                }
                chunk.Sort();
                string chunkFile = $"chunk_{i}.txt";
                chunkFiles.Add(chunkFile);
                File.WriteAllLines(chunkFile, chunk);
                i++;
            }
        }

        // segment merging
        using (StreamWriter sw = new StreamWriter(inputFile))
        {
            List<StreamReader> readers = new List<StreamReader>();
            List<string> currentLines = new List<string>();
            foreach (string chunkFile in chunkFiles)
            {
                StreamReader reader = new StreamReader(chunkFile);
                readers.Add(reader);
                currentLines.Add(reader.ReadLine());
            }

            while (readers.Count > 0)
            {
                int minIndex = -1;
                for (int i = 0; i < readers.Count; i++)
                {
                    if (currentLines[i] != null &&
                        (minIndex == -1 || String.Compare(currentLines[i], currentLines[minIndex]) < 0))
                    {
                        minIndex = i;
                    }
                }

                if (minIndex == -1)
                {
                    break;
                }

                sw.WriteLine(currentLines[minIndex]);
                currentLines[minIndex] = readers[minIndex].ReadLine();
                if (currentLines[minIndex] == null)
                {
                    readers[minIndex].Close();
                    readers.RemoveAt(minIndex);
                    currentLines.RemoveAt(minIndex);
                }
            }
        }

        
        foreach (string chunkFile in chunkFiles)
        {
            File.Delete(chunkFile);
        }

    }



    static void NaturalSort(string inputFile)
    {
        List<string> tempFiles = new List<string>();

        using (StreamReader reader = new StreamReader(inputFile))
        {
            int runNum = 0;
            List<string> run = new List<string>();
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                run.Add(line);
                if (run.Count == 1000)
                {
                    run.Sort();
                    string tempFile = $"{runNum}.txt";
                    tempFiles.Add(tempFile);
                    using (StreamWriter writer = new StreamWriter(tempFile))
                    {
                        foreach (var item in run)
                        {
                            writer.WriteLine(item);
                        }
                    }
                    runNum++;
                    run.Clear();
                }
            }
            if (run.Count > 0)
            {
                run.Sort();
                string tempFile = $"{runNum}.txt";
                tempFiles.Add(tempFile);
                using (StreamWriter writer = new StreamWriter(tempFile))
                {
                    foreach (var item in run)
                    {
                        writer.WriteLine(item);
                    }
                }
            }
        }

        using (StreamWriter writer = new StreamWriter(inputFile))
        {
            string[] lines = new string[tempFiles.Count];
            StreamReader[] readers = new StreamReader[tempFiles.Count];
            for (int i = 0; i < tempFiles.Count; i++)
            {
                readers[i] = new StreamReader(tempFiles[i]);
                lines[i] = readers[i].ReadLine();
            }

            while (true)
            {
                int minIndex = -1;
                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i] != null && (minIndex == -1 || string.Compare(lines[i], lines[minIndex]) < 0))
                    {
                        minIndex = i;
                    }
                }

                if (minIndex == -1)
                {
                    break;
                }

                writer.WriteLine(lines[minIndex]);
                lines[minIndex] = readers[minIndex].ReadLine();
                if (lines[minIndex] == null)
                {
                    readers[minIndex].Close();
                    File.Delete(tempFiles[minIndex]);
                    lines[minIndex] = null;
                }
            }
        }
    }
    
}