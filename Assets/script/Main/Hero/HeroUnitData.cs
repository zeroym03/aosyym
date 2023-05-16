using UnityEngine;
using UnityEngine.AI;

public class HeroUnitData : MonoBehaviour
{// 파일에서 정보불러와서 입력받아 저장받고 각각에 전달하는걸로
    private void Start()
    {
        DontDestroyOnLoad(this);
    }
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

    bool _move = true;
    public bool move { get { return _move; } set { _move = value; } }

    bool _attack = false;
    public bool attack { get { return _attack; } set { _attack = value; } }

    string _name = "yym";
    public string Name { get { return _name; } set { _name = value; } }
    bool _teamBlue = true;// 게임 시작시 팀설정
    public bool teamBlue { get { return _teamBlue; } set { _teamBlue = value; } }
    NavMeshAgent _Agent;

    public NavMeshAgent _HeroAgent
    {
        get { return _Agent; }
        set
        {
            _Agent = value;
        }
    }
    Animator _ani;
    public Animator _HeroAni 
    {
        get { return _ani; }
        set { _ani = value; }
    }
     BoxCollider _Sword;
    public BoxCollider _HeroSword
    {
        get { return _Sword; }
        set { _Sword = value; }
    }
}
