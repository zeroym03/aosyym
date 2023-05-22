using UnityEngine;
using static MinianCon;
using UnityEngine.AI;

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
    MidLine _midLine;
    int _pathindex = 0;
    int _nowhp;
    float _speed;
    float dis;
    Efox _efox;
    // [SerializeField] Transform _hero;
    [SerializeField] GameObject _rotate;
    [SerializeField] float _hp;
    [SerializeField] int _attack;
    [SerializeField] Animator _ani;
    Vector3 v3 = Vector3.zero;
    GameObject _herotransform;
    private void OnCollisionEnter(Collision collision)
    {
        {
            if (collision.gameObject.layer == 6)
            {
                // collision.gameObject.GetComponent<Hero>().Hitted();
                _hp -= 5;
                Debug.Log(_hp);
            }
        }
    }
    private void Update()
    {
        _herotransform = GameObject.FindWithTag("Player");
        minianSearch(_herotransform.transform);
        if (_efox == Efox.move) minianTowerMove();
        if (_efox == Efox.attack) minianAttack(_herotransform.transform);
    }
    private void minianTowerMove()
    {
        if (_midLine == null) return;
        if (Mathf.Abs(Vector3.Distance(transform.position, _midLine.getPaths()[_pathindex].position)) < 4)// _paths 에 도착하면 실행
        {
            Debug.Log("미니언도착");
            _pathindex++;
        }
        else
        {
            _agent.SetDestination(_midLine.getPaths()[_pathindex].position);// 도착위치 저장
            _ani.SetInteger("legfox", (int)Efox.move);

        }
    }
    void minianSearch(Transform herotrans)
    {
        dis = Vector3.Distance(herotrans.position, transform.position);//_hero 왜에도 적 미니언도 잡아야됨
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
        }
        else
        {
            _agent.SetDestination(herotrans.position);// 도착위치 저장
            Mathf.Abs(dis);
        }
        //v3 += (Vector3.forward).normalized * Time.deltaTime * _speed;
        //Vector3 Loocdir = herotrans.position - transform.position;
        //transform.rotation = Quaternion.LookRotation(new Vector3(Loocdir.x, 0, Loocdir.z));
        //transform.position = Vector3.MoveTowards(transform.position, herotrans.position, Time.deltaTime * _speed);
    }


    public void init(Minian monData)
    {
        Debug.Log("미니언");
        _midLine = GenericSinglngton<MinianCon>.Instance._GatPahts();
        _mondata = monData;
        //_agent = GetComponentInChildren<NavMeshAgent>();
        _agent = GetComponent<NavMeshAgent>();
        _nowhp = _mondata.HP;
        _speed = _mondata.SPEED;
    }
}
