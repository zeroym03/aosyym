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
    Monster _mondata;
    int _pathindex = 0;
    int _nowhp;
    float _speed;
    NavMeshAgent _agent;
    Efox _efox;
    [SerializeField] Transform _hero;
    [SerializeField] GameObject _rotate;
    [SerializeField] float _hp;
    [SerializeField] int _attack;
    [SerializeField] Animator _ani;
    Vector3 v3 = Vector3.zero;
    private void OnCollisionEnter(Collision collision)
    {
        {
            if (collision.gameObject.name == "Hero")
            {
                // collision.gameObject.GetComponent<Hero>().Hitted();
                _hp -= 5;
                Debug.Log(_hp);
            }
        }
    }
    private void Update()
    {
    //    if (Mathf.Abs(Vector3.Distance(transform.position, _paths.getPaths()[_pathindex].position)) < 0.45f)// _paths �� �����ϸ� ����
        {
            _pathindex++;
          //  if (_pathindex >= _paths.getPaths().Length) _pathindex = 0;//_pathindex ��_paths�� ������  �ʱ�ȭ
        }
       // else
        {
           // _agent.SetDestination(_paths.getPaths()[_pathindex].position);// ������ġ ����
        }
    }
    private void Move()
    {
        float dis = Vector3.Distance(_hero.position, transform.position);//_hero �ֿ��� �� �̴Ͼ� ��ƾߵ�
        if (dis < 30)//�� ã�Ƽ� �̵����۰Ÿ�
        {
            if (dis < 5)//���� ���۰Ÿ�
            {
                _efox = Efox.attack;
            }
            else
            {
                v3 += (Vector3.forward).normalized * Time.deltaTime * _speed;
                Vector3 Loocdir = _hero.position - transform.position;
                transform.rotation = Quaternion.LookRotation(new Vector3(Loocdir.x, 0, Loocdir.z));
                transform.position = Vector3.MoveTowards(transform.position, _hero.position, Time.deltaTime * _speed);
            }
        }
        else
        {
            _efox = Efox.move;
       //     StartCoroutine(CoRanDumMove());
        }
    }
    public void init(Monster monData)
    {
        _mondata = monData;
        _agent = GetComponent<NavMeshAgent>();
        _nowhp = _mondata.HP;
        _speed = _mondata.SPEED;
    }
}
