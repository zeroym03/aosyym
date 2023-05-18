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
    HeroUnitData heroUnitData = new HeroUnitData();
    int _pathindex = 0;
    int _nowhp;
    float _speed;
    Efox _efox;
   // [SerializeField] Transform _hero;
    [SerializeField] GameObject _rotate;
    [SerializeField] float _hp;
    [SerializeField] int _attack;
    [SerializeField] Animator _ani;
    Vector3 v3 = Vector3.zero;
    private void Start()
    {
    }
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
        Move();
 
    }
    private void Move()
    {
        Debug.Log(transform.position);
        Debug.Log(_midLine);
        if (Mathf.Abs(Vector3.Distance(transform.position, _midLine.getPaths()[_pathindex].position)) < 0.45f)// _paths �� �����ϸ� ����
        {
            _pathindex++;
            if (_pathindex >= _midLine.getPaths().Length) _pathindex = 0;//_pathindex ��_paths�� ������  �ʱ�ȭ
        }
        else
        {
            _agent.SetDestination(_midLine.getPaths()[_pathindex].position);// ������ġ ����
            _ani.SetInteger("", (int)Efox.move);

        }
        // float dis = Vector3.Distance(herotrans.position, transform.position);//_hero �ֿ��� �� �̴Ͼ� ��ƾߵ�
        // if (dis < 30)//�� ã�Ƽ� �̵����۰Ÿ�
        // {
        //     if (dis < 5)//���� ���۰Ÿ�
        //     {
        //         _efox = Efox.attack;
        //     }
        //     else
        //     {
        //         v3 += (Vector3.forward).normalized * Time.deltaTime * _speed;
        //         Vector3 Loocdir = herotrans.position - transform.position;
        //         transform.rotation = Quaternion.LookRotation(new Vector3(Loocdir.x, 0, Loocdir.z));
        //         transform.position = Vector3.MoveTowards(transform.position, herotrans.position, Time.deltaTime * _speed);
        //     }
        // }
        // else
        // {
        //     _efox = Efox.move;
        ////     StartCoroutine(CoRanDumMove());
        // }
    }
    public void init(Minian monData)
    {
        Debug.Log("�̴Ͼ�");
        _midLine=  GenericSinglngton<MinianCon>.Instance._GatPahts();
        _mondata = monData;
        _agent = GetComponent<NavMeshAgent>();
        _nowhp = _mondata.HP;
        _speed = _mondata.SPEED;
    }
}
