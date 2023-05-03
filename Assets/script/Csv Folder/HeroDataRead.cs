using UnityEngine;
public class HeroDataRead : MonoBehaviour
{
    private HeroStat[] arr = null;
    public HeroStat this[int a]//¿Œµ¶º≠
    {
        get
        {
            if (arr == null)
            {
                readData();
            }
            foreach (var data in arr)
            {
                if (data.Id == a) return data;
            }
            return new HeroStat();
        }
    }
    private void Start()
    {
        readData();
    }
    public void readData()
    {
        var data = CsvReader.readFileData("HeroData");
        if (data.Length < 2) return;
        arr = new HeroStat[data.Length - 1];
        for (int i = 1; i < data.Length; i++)
        {
            var lineItem = data[i].Split(',');
            HeroStat HS;
            HS.Id = int.Parse(lineItem[0]);
            HS.Name = (lineItem[1]);
            HS.Hp = int.Parse(lineItem[2]);
            HS.Dmg = int.Parse(lineItem[3]);
            HS.Speed = float.Parse(lineItem[4]);
            arr[i - 1] = HS;
        }
    }
}
public struct HeroStat
{
    public int Id;
    public string Name;
    public int Hp;
    public int Dmg;
    public float Speed;
}



