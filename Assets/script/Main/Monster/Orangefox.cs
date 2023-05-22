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
        if (Mathf.Abs(Vector3.Distance(transform.position, _midLine.getPaths()[_pathindex].position)) < 4)// _paths �� �����ϸ� ����
        {
            Debug.Log("�̴Ͼ���");
            _pathindex++;
        }
        else
        {
            _agent.SetDestination(_midLine.getPaths()[_pathindex].position);// ������ġ ����
            _ani.SetInteger("legfox", (int)Efox.move);

        }
    }
    void minianSearch(Transform herotrans)
    {
        dis = Vector3.Distance(herotrans.position, transform.position);//_hero �ֿ��� �� �̴Ͼ� ��ƾߵ�
        if (dis < 20)//�� ã�Ƽ� �̵����۰Ÿ�
        { _efox = Efox.attack; }
        else
        {
            _efox = Efox.move;// _efox ������ ���º�ȭ��
        }
    }
    void minianAttack(Transform herotrans)
    {
        if (dis < 3)//���� ���۰Ÿ�
        {
            _agent.isStopped = true;
            _ani.SetInteger("legfox", (int)Efox.attack);
        }
        else
        {
            _agent.SetDestination(herotrans.position);// ������ġ ����
            Mathf.Abs(dis);
        }
        //v3 += (Vector3.forward).normalized * Time.deltaTime * _speed;
        //Vector3 Loocdir = herotrans.position - transform.position;
        //transform.rotation = Quaternion.LookRotation(new Vector3(Loocdir.x, 0, Loocdir.z));
        //transform.position = Vector3.MoveTowards(transform.position, herotrans.position, Time.deltaTime * _speed);
    }


    public void init(Minian monData)
    {
        Debug.Log("�̴Ͼ�");
        _midLine = GenericSinglngton<MinianCon>.Instance._GatPahts();
        _mondata = monData;
        //_agent = GetComponentInChildren<NavMeshAgent>();
        _agent = GetComponent<NavMeshAgent>();
        _nowhp = _mondata.HP;
        _speed = _mondata.SPEED;
    }
}
