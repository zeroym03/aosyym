using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MinianCon : MonoBehaviour
{
    List<Orangefox> _minianList = new List<Orangefox>();
    GameObject _minian;
    MidLine _MidPaths;
    public MidLine _GatPahts()
    {
        if (_MidPaths == null)
        {
            GameObject temp = Resources.Load("Prefab/TowerFile") as GameObject;// Resources.Load("Prefab/TowerFile")에있는  스크립트
            _MidPaths = Instantiate(temp).GetComponent<MidLine>();
            DontDestroyOnLoad(temp);
        }
        return _MidPaths;
    }
    public void Addmonster()
    {
        if (_minian == null)
        {
            _minian = Resources.Load("Prefab/foxob") as GameObject;
        }
        _GatPahts();
        Orangefox mon = Instantiate(_minian).GetComponent<Orangefox>();
        mon.transform.position = _MidPaths.transform.position;
        Minian tempmon = new Minian();
        tempmon.HP = 200;
        tempmon.SPEED = 3f;
        tempmon.NAME = "근접여우";
        tempmon.EDefType = EDefType.None; 
        mon.init(tempmon);
        _minianList.Add(mon);
    }
        public class Minian 
    {
        public int HP;
        public float SPEED;
        public string NAME;
        public EDefType EDefType;
    }
    //public Minian GetTarget(Vector3 position, float dist)
    //{
    //    Minian ret = (from m in _minianList//가져올 정보
    //                  where Vector3.Distance(position, m.transform.position) < dist//조건
    //                  orderby Vector3.Distance(position, m.transform.position) ascending
    //                  select m).FirstOrDefault();
    //    return ret;//가장가까운 몬스터하나
    //}
}
public enum EDefType
{
    None,
    Magic,
    Physics,
}

