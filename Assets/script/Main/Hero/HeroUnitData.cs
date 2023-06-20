using UnityEngine;
using UnityEngine.AI;

public class HeroUnitData : MonoBehaviour
{// 파일에서 정보불러와서 입력받아 저장받고 각각에 전달하는걸로
    private void Start()
    {
        DontDestroyOnLoad(this);
    }
    int _Damages = 70;//o
    public int Damages { get { return _Damages; } set { _Damages = value; } }

    float _speed = 20;//xo
    public float speed { get { return _speed; } set { _speed = value; } }

    int _hp = 500;//o
    public int hp { get { return _hp; } set { _hp = value; } }

    float _cortimer = 0f;//x
    public float cortimer { get { return _cortimer; } set { _cortimer = value; } }

    float _dietimer = 5f;//x
    public float dietimer { get { return _dietimer; } set { _dietimer = value; } }

    float _attacktime = 0f;//x
    public float attacktime { get { return _attacktime; } set { _attacktime = value; } }

    bool _hit = false;//x
    public bool hit { get { return _hit; } set { _hit = value; } }

    bool _move = true;//x
    public bool move { get { return _move; } set { _move = value; } }

    bool _attack = false;//x
    public bool attack { get { return _attack; } set { _attack = value; } }

    string _name = "yym";//o
    public string Name { get { return _name; } set { _name = value; } }
    bool _teamBlue = true;// 게임 시작시 팀설정o
    public bool teamBlue { get { return _teamBlue; } set { _teamBlue = value; } }
    NavMeshAgent _Agent;//x
    public NavMeshAgent _HeroAgent
    { get { return _Agent; } set { _Agent = value; } }
    Animator _ani;//x
    public Animator _HeroAni
    { get { return _ani; } set { _ani = value; } }
    BoxCollider _Sword;//x
    public BoxCollider _HeroSword
    { get { return _Sword; } set { _Sword = value; } }
    Transform HeroTransform;//x
    public Transform _herotransform
    { get { return HeroTransform; } set { HeroTransform = value; } }
}
