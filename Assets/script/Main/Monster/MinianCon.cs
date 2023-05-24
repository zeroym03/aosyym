using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MinianCon : MonoBehaviour
{
    List<Orangefox> _minianList = new List<Orangefox>();
    GameObject _minian;
    LinePaths[] _LinePaths;
    public LinePaths[] _GatPahts()
    {
        if (_LinePaths == null)
        {
            GameObject temp = Resources.Load("Prefab/TowerFile") as GameObject;// Resources.Load("Prefab/TowerFile")���ִ�  ��ũ��Ʈ
            _LinePaths = Instantiate(temp).GetComponentsInChildren<LinePaths>();
            DontDestroyOnLoad(temp);
        }
        return _LinePaths;
    }
    public void Addmonster(int _Line, ETeamColor eTeamColor)
    {
        if (_minian == null)
        {
            _minian = Resources.Load("Prefab/OrangeFox") as GameObject;
        }
        _GatPahts();
        Orangefox mon = Instantiate(_minian).GetComponent<Orangefox>();
        mon.transform.position = _LinePaths[_Line].transform.position;
        Debug.Log(mon.transform.position);
        Minian tempmon = new Minian();
        tempmon.LINE = _Line;
        tempmon.Transform = _LinePaths[_Line].transform;
        tempmon.HP = 200;
        tempmon.SPEED = 3f;
        tempmon.NAME = "��������";
        tempmon._eTeamColor = eTeamColor;
        tempmon.EDefType = EDefType.None; 
        mon.init(tempmon);
        _minianList.Add(mon);
    }
        public class Minian 
    {
        public Transform Transform;
        public int LINE;
        public int HP;
        public float SPEED;
        public string NAME;
        public ETeamColor _eTeamColor;
        public EDefType EDefType;
    }
    //public Minian GetTarget(Vector3 position, float dist)
    //{
    //    Minian ret = (from m in _minianList//������ ����
    //                  where Vector3.Distance(position, m.transform.position) < dist//����
    //                  orderby Vector3.Distance(position, m.transform.position) ascending
    //                  select m).FirstOrDefault();
    //    return ret;//���尡��� �����ϳ�
    //}
}
public enum EDefType
{
    None,
    Magic,
    Physics,
}

