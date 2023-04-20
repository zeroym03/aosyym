using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDatas : MonoBehaviour
{

    private TowerData[] arr = null;
    // Start is called before the first frame update
    public TowerData this[ETowerLatitude type]//¿Œµ¶º≠
    {
        get
        {
            if (arr == null)
            {
                readData();
            }
            foreach (var data in arr)
            {
                if (data.LatitudeID == type) return data;
            }
            return new TowerData();
        }
    }
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
            Td.LatitudeID = (ETowerLatitude)Enum.Parse(typeof(ETowerLatitude), lineItem[0]);
            Td.Hp = int.Parse(lineItem[1]);
            Td.Dmg = int.Parse(lineItem[2]);
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
    public ETowerLatitude LatitudeID;
    public int Hp;
    public int Dmg;
}
public enum ETowerLatitude
{
    top1,
    top2,
    top3,
    mid1,
    mid2,
    mid3,
    bot1,
    bot2,
    bot3,
}
