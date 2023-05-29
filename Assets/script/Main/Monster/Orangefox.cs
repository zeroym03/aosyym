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
    [SerializeField] GameObject _rotate;
    [SerializeField] float _hp;
    [SerializeField] int _attack;
    [SerializeField] Animator _ani;
    GameObject _herotransform;
    private void Start()
    {
        Debug.Log(transform.position);
 gameObject. transform.position=_mondata.Transform.position;
        Debug.Log(transform.position);

    }
    private void OnTriggerEnter(Collider other)//���� �÷��̾ �����ݸ��� Ʈ���ŷ� ���ظ� �������� �Ǿ��־� Ʈ���ŷ� ���ظ� �Ե�����
    {
        if (GenericSinglngton<AllDataSingletun>.Instance._eHeroTeamColor != _mondata._eTeamColor)
        {
            Debug.Log("OnTriggerEnter");

            if (other.gameObject.layer == 9)//���̾ 9�� �Ʒ�����
            {
                _hp -= GenericSinglngton<AllDataSingletun>.Instance._heroDmg;
                Debug.Log(_hp);
            }
        }
        if (_hp <= 0) { _efox = Efox.die; }
    }
    private void Update()
    {
        if (_efox != Efox.die)
        {
            _herotransform = GameObject.FindWithTag("Player");
            if (GenericSinglngton<AllDataSingletun>.Instance._eHeroTeamColor == _mondata._eTeamColor) { _efox = Efox.move; } //_eHeroTeamColor�� �Ű������� �޾Ƽ�

            else MinianSearch(_herotransform.transform);//_efox = Efox
            if (_efox == Efox.move) MinianTowerMove();
            if (_efox == Efox.attack) MinianAttack(_herotransform.transform);
        }
        if (_efox == Efox.die) StartCoroutine(MinianDie());
    }
    private void MinianTowerMove()
    {
        if (_midLine == null) return;
        if (Mathf.Abs(Vector3.Distance(transform.position, _midLine[_mondata.LINE].getPaths()[_pathindex].position)) < 4)// _paths �� �����ϸ� ����
        {
            Debug.Log("�̴Ͼ���");
            _pathindex++;
        }
        else
        {
            _agent.SetDestination(_midLine[_mondata.LINE].getPaths()[_pathindex].position);// ������ġ ����+�̵�
            _ani.SetInteger("legfox", (int)Efox.move);
        }
    }
    void MinianSearch(Transform herotrans)
    {

        dis = Vector3.Distance(herotrans.position, transform.position); //�Ÿ�üũ//_hero �ֿ��� �� �̴Ͼ� ��ƾߵ�
        if (dis < 20)//�� ã�Ƽ� �̵����۰Ÿ�
        { _efox = Efox.attack; }
        else
        {
            _efox = Efox.move;// _efox ������ ���º�ȭ��
        }
    }
    void MinianAttack(Transform herotrans)
    {
        if (dis < 3)//���� ���۰Ÿ�
        {
            _agent.isStopped = true;
            _ani.SetInteger("legfox", (int)Efox.attack);
            StartCoroutine(AttackCool());
        }
        else
        {
            _agent.isStopped = false;
            _agent.SetDestination(herotrans.position);// ������ġ ����
            _ani.SetInteger("legfox", (int)Efox.move);

        }
    }
    IEnumerator AttackCool()
    {
        if (GenericSinglngton<AllDataSingletun>.Instance._eHeroTeamColor != _mondata._eTeamColor)
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
    }
    IEnumerator MinianDie()
    {
        _ani.SetTrigger("New Trigger");
        _agent.isStopped = true;
        yield return new WaitForSecondsRealtime(1);
        Destroy(gameObject);
        Debug.Log("asd");
    }
    public void init(Minian monData)
    {
        _midLine = GenericSinglngton<MinianCon>.Instance._GatPahts();
        _mondata = monData;
        _agent = GetComponent<NavMeshAgent>();
        _nowhp = _mondata.HP;
        _speed = _mondata.SPEED;
    }
}
