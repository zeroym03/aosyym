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
    public Minian Mondata { get { return _mondata; } }
    NavMeshAgent _agent;
    LinePaths[] _midLine;
    int _pathindex = 0;
    float dis2 = 20;
    bool monAttack = true;
    Efox _efox;
    [SerializeField] GameObject _rotate;
    [SerializeField] float _hp;
    [SerializeField] int _attackPower;
    [SerializeField] Animator _ani;
    GameObject _hero;
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
    }
    private void Update()
    {
        if (_efox == Efox.die) StartCoroutine(MinianDie());
        else if (_efox != Efox.die)
        {
            _hero = GameObject.FindWithTag("Player");
            if (_efox == Efox.move) MinianTowerMove();//
            if (GenericSinglngton<MinianCon>.Instance.GetTarget(gameObject.transform.position, dis2, _mondata._eTeamColor) != null)
                TargetTransCheck(GenericSinglngton<MinianCon>.Instance.GetTarget(gameObject.transform.position, dis2, _mondata._eTeamColor).gameObject);
            if (Vector3.Distance(_hero.transform.position, gameObject.transform.position) < dis2 && GenericSinglngton<AllDataSingletun>.Instance._eHeroTeamColor != Mondata._eTeamColor)
                TargetTransCheck(_hero);
            else if (GenericSinglngton<MinianCon>.Instance.GetTarget(gameObject.transform.position, dis2, _mondata._eTeamColor) == null) _efox = Efox.move;// _efox ������ ���º�ȭ��
            if (_hp <= 0) { _efox = Efox.die; }
        }
    }
    private void MinianTowerMove()
    {
        if (_midLine == null) return;
        if (Mathf.Abs(Vector3.Distance(transform.position, _midLine[_mondata.LINE].getPaths()[_pathindex].position)) < 4) _pathindex++; // _paths �� �����ϸ� ����
        else
        {
            _agent.SetDestination(_midLine[_mondata.LINE].getPaths()[_pathindex].position);// ������ġ ����+�̵�
            _ani.SetInteger("legfox", (int)Efox.move);
            _agent.isStopped = false;
        }
    }
    void TargetTransCheck(GameObject targetgameObject)//�Ÿ�3 ������װ���
    {
        _agent.SetDestination(targetgameObject.transform.position);
        if (Vector3.Distance(targetgameObject.transform.position, gameObject.transform.position) < 3)
        {  
            _agent.isStopped = true;
            _ani.SetInteger("legfox", (int)Efox.attack);
            StartCoroutine(AttackCool(targetgameObject));
        }
    }
    IEnumerator AttackCool(GameObject gameObject)//���ݽ���
    {
        if (monAttack == true)
        {
            monAttack = false;
            GenericSinglngton<MainSoundCon>.Instance.MinianEffectSound(_mondata.minianAudioSource);
            yield return new WaitForSecondsRealtime(0.35f);
            if (gameObject.tag == "Minian")
            {
                gameObject.GetComponentInChildren<Orangefox>()._hp -= _attackPower;
                Debug.Log(gameObject.GetComponentInChildren<Orangefox>()._hp + "" + Mondata._eTeamColor);
            }
            if (gameObject.tag == "Player")
            { 
                GenericSinglngton<HeroUnitData>.Instance.hp -= _attackPower; 
                Debug.Log(GenericSinglngton<HeroUnitData>.Instance.hp);
            }
            yield return new WaitForSecondsRealtime(0.4f);
            monAttack = true;
        }
    }
    IEnumerator MinianDie()
    {
        _ani.SetTrigger("New Trigger");
        _agent.isStopped = true;
        yield return new WaitForSecondsRealtime(1);
        GenericSinglngton<MinianCon>.Instance.MinianDestloy(gameObject.GetComponent<Orangefox>());
    }
    public void init(Minian monData)
    {
        _midLine = GenericSinglngton<MinianCon>.Instance._GatPahts();
        _mondata = monData;
        _agent = GetComponent<NavMeshAgent>();
        _mondata.minianAudioSource = GetComponent<AudioSource>();
        gameObject.transform.position = _mondata.Transform.position;

        if (_mondata._eTeamColor == ETeamColor.Red) GetComponentInChildren<SkinnedMeshRenderer>().material.color = new Color(1, 0.1f, 0.1f);
        else GetComponentInChildren<SkinnedMeshRenderer>().material.color = new Color(1, 200 / 255f, 3 / 255f);
    }
}
