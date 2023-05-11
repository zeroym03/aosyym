using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class HeroData :MonoBehaviour
{
    int _Damages = 70;
    public int Damages { get { return _Damages; } set { _Damages = value; } }

    float _speed = 20;
    public float speed { get { return _speed; } set { _speed = value; } }

    int _hp = 20;
    public int hp { get { return _hp; } set { _hp = value; } }

    float _cortimer = 0f;
    public float cortimer { get { return _cortimer; } set { _cortimer = value; } }

    float _dietimer = 5f;
    public float dietimer { get { return _dietimer; } set { _dietimer = value; } }

    float _attacktime = 0f;
    public float attacktime { get { return _attacktime; } set { _attacktime = value; } }

    bool _hit = false;
    public bool hit { get { return _hit; } set { _hit = value; } }

    bool _move = false;
    public bool move { get { return _move; } set { _move = value; } }

    bool _attack = false;
    public bool attack { get { return _attack; } set { _attack = value; } }

    string _name = "yym";
    public string Name { get { return _name; } set { _name = value; } }

    //    public SkinnedMeshRenderer _Render
    //    {
    //        get { return _render; }
    //        set
    //        {
    //            _render = value;
    //            _heroColor = _render.material.color;
    //        }
    //    }
    //    public Transform _Hero
    //    {
    //        get { return _hero; }
    //        set
    //        {
    //            _hero = value;
    //            _hero.transform.position = gameObject.transform.position;
    //        }
    //    }

    //    public NavMeshAgent _HeroAgent
    //    {
    //        get { return _Agent; }
    //        set
    //        {
    //            _Agent = value;
    //            _Agent = gameObject.GetComponent<NavMeshAgent>();
    //        }
    //    }
    Animator _ani;
    public Animator _HeroAni // Hero에 데이터 전부 이런현식으로 변경 
    {
        get { return _ani; }
        set { _ani = value; }
    }

//    public Image _HeroHP
//    {
//        get { return _herohp; }
//        set { _herohp = value; }
//    }
//    public GameObject _UiPanel
//    {
//        get { return _uiPanel; }
//        set { _uiPanel = value;  }
//    } public HpDown _HPImage
//    {
//        get { return _hpimage; }
//        set { _hpimage = value; }
//    } 

//public BoxCollider _HeroSword
//    {
//        get { return _Sword; }
//        set { _Sword = value; }
//    }
}
