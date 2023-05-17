using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CsvPrintText
{
    void csvPrintText(string T)
    {
        var data = CsvReader.readFileData(T);
        foreach (var text in data)
        {
            Debug.Log(text);
        }
    }
}
