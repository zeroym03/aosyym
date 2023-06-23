using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MinianCon : MonoBehaviour
{
    List<Orangefox> _minianList = new List<Orangefox>();
    GameObject _minian;
    LinePaths[] _LinePaths;
    public void SetClearPath()
    {
        _LinePaths = null;
    }
    public LinePaths[] _GatPahts()
    {
        if (_LinePaths == null)
        {
            GameObject temp = Resources.Load("Prefab/Object/TowerFile") as GameObject;// Resources.Load("Prefab/TowerFile")에있는  스크립트
            _LinePaths = Instantiate(temp).GetComponentsInChildren<LinePaths>();
            DontDestroyOnLoad(temp);
        }
        return _LinePaths;
    }
    public void Addmonster(int _Line, ETeamColor eTeamColor)
    {
        if (_minian == null)
        {
            _minian = Resources.Load("Prefab/Object/OrangeFox") as GameObject;
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
        tempmon.NAME = "근접여우";
        tempmon._eTeamColor = eTeamColor;
        tempmon.EDefType = EDefType.None;
        mon.init(tempmon);
        _minianList.Add(mon);
    }
    GameObject hero;
    public void HeroLoad()
    {
        hero = Resources.Load("Prefab/Object/CharacterParent") as GameObject;
        Instantiate(hero).GetComponent<Hero>();
    }
    public Orangefox GetTarget(Vector3 position, float dist, ETeamColor eTeamColor)
    {
        { Orangefox ret = (from m in _minianList//가져올 정보
                           where m.GetComponent<Orangefox>().Mondata._eTeamColor != eTeamColor//적체크
                           where Vector3.Distance(position, m.transform.position) < dist//거리체크조건
                           orderby Vector3.Distance(position, m.transform.position) ascending
                           select m).FirstOrDefault();
                return ret;//가장가까운 몬스터하나
        }
    }
    public void MinianDestloy(Orangefox destOrangefox)
    {
        Destroy(destOrangefox.gameObject);
        _minianList.Remove(destOrangefox);
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
        public AudioSource minianAudioSource;
    }
}
public enum EDefType
{
    None,
    Magic,
    Physics,
}

