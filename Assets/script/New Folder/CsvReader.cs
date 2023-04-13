using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class CsvReader
{
    public static string[] readFileData(string name)
    {
        TextAsset textfile = Resources.Load($"csv/{name}") as TextAsset;

        using (StringReader sr = new StringReader(textfile.text))
        {
            string baseData = sr.ReadToEnd();
            return baseData.Split("\n\n");
        }
    }
}
