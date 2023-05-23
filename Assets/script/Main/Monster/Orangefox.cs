using UnityEngine;
using static MinianCon;
using UnityEngine.AI;
using System.Collections;

enum Efox
{
    move,
    attack,
    die,
}
public class Orangefox : MonoBehaviour
{
    Minian _mondata;
    NavMeshAgent _agent;
    LinePaths[] _midLine;
    int _pathindex = 0;
    int _nowhp;
    float _speed;
    float dis;
    bool monAttack = true;
    Efox _efox;
    // [SerializeField] Transform _hero;
    [SerializeField] GameObject _rotate;
    [SerializeField] float _hp;
    [SerializeField] int _attack;
    [SerializeField] Animator _ani;
    Vector3 v3 = Vector3.zero;
    GameObject _herotransform;
    private void Start()
    {
        Debug.Log(transform.position);
        transform.position = _mondata.Transform.position;
    }
    private void OnCollisionEnter(Collision collision)
    {
        {
            if (collision.gameObject.layer == 6)
            {
                // collision.gameObject.GetComponent<Hero>().Hitted();
                _hp -= GenericSinglngton<HeroUnitData>.Instance.Damages;
                Debug.Log(_hp);
            }
        }
    }
    private void Update()
    {
        _herotransform = GameObject.FindWithTag("Player");
        minianSearch(_herotransform.transform);//_efox = Efox
        if (_efox == Efox.move) minianTowerMove();
        if (_efox == Efox.attack) minianAttack(_herotransform.transform);
    }
    private void minianTowerMove()
    {
        if (_midLine == null) return;
        if (Mathf.Abs(Vector3.Distance(transform.position, _midLine[_mondata.LINE].getPaths()[_pathindex].position)) < 4)// _paths 에 도착하면 실행
        {
            Debug.Log("미니언도착");
            _pathindex++;
        }
        else
        {
            _agent.SetDestination(_midLine[_mondata.LINE].getPaths()[_pathindex].position);// 도착위치 저장+이동
            _ani.SetInteger("legfox", (int)Efox.move);

        }
    }
    void minianSearch(Transform herotrans)
    {
        dis = Vector3.Distance(herotrans.position, transform.position);//거리체크//_hero 왜에도 적 미니언도 잡아야됨
        if (dis < 20)//적 찾아서 이동시작거리
        { _efox = Efox.attack; }
        else
        {
            _efox = Efox.move;// _efox 에따라 상태변화로
        }
    }
    void minianAttack(Transform herotrans)
    {
        if (dis < 3)//공격 시작거리
        {
            _agent.isStopped = true;
            _ani.SetInteger("legfox", (int)Efox.attack);
            StartCoroutine(AttackCool());
        }
        else
        {
            _agent.isStopped = false;
            _agent.SetDestination(herotrans.position);// 도착위치 저장
            _ani.SetInteger("legfox", (int)Efox.move);
        }
    }
    IEnumerator AttackCool()
    {
        if (monAttack == true)
        {
            monAttack = false;
            yield return new WaitForSecondsRealtime(0.7f);
            GenericSinglngton<HeroUnitData>.Instance.hp -= 3;
            Debug.Log(GenericSinglngton<HeroUnitData>.Instance.hp);
            monAttack = true;
        }
    }
    public void init(Minian monData)
    {
        _midLine = GenericSinglngton<MinianCon>.Instance._GatPahts();
        _mondata = monData;
        //_agent = GetComponentInChildren<NavMeshAgent>();
        _agent = GetComponent<NavMeshAgent>();
        _nowhp = _mondata.HP;
        _speed = _mondata.SPEED;
    }
}
