using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDatas : MonoBehaviour
{

    private TowerData[] arr = null;
    // Start is called before the first frame update
    void Start()
    {
        readData();
    }
    void readData()
    {
        var data = CsvReader.readFileData("TowerData");
        if (data.Length < 2) return;
        arr = new TowerData[data.Length - 1];
        for (int i = 1; i < data.Length; i++)
        {
            var lineItem = data[i].Split(',');
            TowerData Td;
            Td.Id = int.Parse(lineItem[0]);
            Td.Latitude = (ETowerLatitude)Enum.Parse(typeof(ETowerLatitude), lineItem[1]);
            Td.Hp = float.Parse(lineItem[2]);
            Td.Dmg = int.Parse(lineItem[3]);
            arr[i - 1] = Td;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
public struct TowerData
{
    public int Id;
    public ETowerLatitude Latitude;
    public float Hp;
    public int Dmg;
}
public enum ETowerLatitude
{
    top,
    mid,
    bot,
}
