using System.Collections.Generic;
using UnityEngine;

public class MinianCon : MonoBehaviour
{
    List<Orangefox> _minianList = new List<Orangefox>();
    GameObject _minian;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Addmonster()
    {
        if (_minian == null)
        {
            _minian = Resources.Load("Prefab/foxob") as GameObject;
        }
        Orangefox mon = Instantiate(_minian).GetComponent<Orangefox>();
        Monster tempmon = new Monster();
        tempmon.HP = 200;
        tempmon.SPEED = 3f;
        tempmon.NAME = "근접여우";
        tempmon.EDefType = EDefType.None; 
        mon.init(tempmon);
        _minianList.Add(mon);
    }
        public class Monster
    {
        public int HP;
        public float SPEED;
        public string NAME;
        public EDefType EDefType;
    }
}
public enum EDefType
{
    None,
    Magic,
    Physics,
}

