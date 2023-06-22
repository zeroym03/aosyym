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
    public Minian Mondata {  get { return _mondata; } }
    NavMeshAgent _agent;
    LinePaths[] _midLine;
    int _pathindex = 0;
    float dis1;
    float dis2 = 20;
    bool monAttack = true;
    Efox _efox;
    [SerializeField] GameObject _rotate;
    [SerializeField] float _hp;
    [SerializeField] int _attack;
    [SerializeField] Animator _ani;
    GameObject _herotransform;
    private void OnTriggerEnter(Collider other)//���� �÷��̾ �����ݸ��� Ʈ���ŷ� ���ظ� �������� �Ǿ��־� Ʈ���ŷ� ���ظ� �Ե�����
    {
        if (GenericSinglngton<AllDataSingletun>.Instance._eHeroTeamColor != _mondata._eTeamColor)
        {
            Debug.Log("OnTriggerEnter");

            if (other.gameObject.layer == 9)//���̾ 9�� �Ʒ�����
            {
                _hp -= GenericSinglngton<AllDataSingletun>.Instance._heroDmg;//HeroDmg
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
            if (_efox == Efox.move) MinianTowerMove();//GetTarget�� ���̸�
            if (_efox == Efox.attack) MinianAttack(_herotransform.transform);
            if(GenericSinglngton<MinianCon>.Instance.GetTarget(gameObject.transform.position, dis2, _mondata._eTeamColor) == null)
            {
                Debug.Log("< MinianCon >.Instance.GetTarget == null");

            }
            if (GenericSinglngton<MinianCon>.Instance.GetTarget(gameObject.transform.position, dis2, _mondata._eTeamColor) != null)
            {
                MinianAttack(GenericSinglngton<MinianCon>.Instance.GetTarget(gameObject.transform.position, dis2, _mondata._eTeamColor).transform);
                Debug.Log("< MinianCon >.Instance.GetTarget");
            }
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
        dis1 = Vector3.Distance(herotrans.position, transform.position); //�Ÿ�üũ//_hero �ֿ��� �� �̴Ͼ� ��ƾߵ�
        if (dis1 < dis2)//�� ã�Ƽ� �̵����۰Ÿ�
        { _efox = Efox.attack; }
        else
        {
            _efox = Efox.move;// _efox ������ ���º�ȭ��
        }
    }
    void MinianAttack(Transform herotrans)//������ �̴Ͼ������� ��ġ��?
    {
        if (dis1 < 3)//���� ���۰Ÿ�
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
                GenericSinglngton<MainSoundCon>.Instance.MinianEffectSound(_mondata.minianAudioSource);
                yield return new WaitForSecondsRealtime(0.35f);
                GenericSinglngton<HeroUnitData>.Instance.hp -= 3;
                Debug.Log(GenericSinglngton<HeroUnitData>.Instance.hp);
                yield return new WaitForSecondsRealtime(0.4f);
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
        _mondata.minianAudioSource = GetComponent<AudioSource>();
        gameObject.transform.position = _mondata.Transform.position;
        if (_mondata._eTeamColor == ETeamColor.Red) GetComponentInChildren<SkinnedMeshRenderer>().material.color = new Color(1,0.1f,0.1f);

        else GetComponentInChildren<SkinnedMeshRenderer>().material.color =  new Color(1, 200 / 255f, 3 / 255f);
        Debug.Log(GetComponentInChildren<SkinnedMeshRenderer>().material.color);
    }
}
