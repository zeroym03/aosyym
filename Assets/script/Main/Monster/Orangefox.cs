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
    private void OnTriggerEnter(Collider other)//현재 플레이어에 무기콜리더 트리거로 피해를 입히도록 되어있어 트리거로 피해를 입도록함
    {
        if (GenericSinglngton<AllDataSingletun>.Instance._eHeroTeamColor != _mondata._eTeamColor)
        {
            Debug.Log("OnTriggerEnter");

            if (other.gameObject.layer == 9)//레이어가 9면 아레실행
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
            else if (GenericSinglngton<MinianCon>.Instance.GetTarget(gameObject.transform.position, dis2, _mondata._eTeamColor) == null) _efox = Efox.move;// _efox 에따라 상태변화로
            if (_hp <= 0) { _efox = Efox.die; }
        }
    }
    private void MinianTowerMove()
    {
        if (_midLine == null) return;
        if (Mathf.Abs(Vector3.Distance(transform.position, _midLine[_mondata.LINE].getPaths()[_pathindex].position)) < 4) _pathindex++; // _paths 에 도착하면 실행
        else
        {
            _agent.SetDestination(_midLine[_mondata.LINE].getPaths()[_pathindex].position);// 도착위치 저장+이동
            _ani.SetInteger("legfox", (int)Efox.move);
            _agent.isStopped = false;
        }
    }
    void TargetTransCheck(GameObject targetgameObject)//거리3 대상한테공격
    {
        _agent.SetDestination(targetgameObject.transform.position);
        if (Vector3.Distance(targetgameObject.transform.position, gameObject.transform.position) < 3)
        {  
            _agent.isStopped = true;
            _ani.SetInteger("legfox", (int)Efox.attack);
            StartCoroutine(AttackCool(targetgameObject));
        }
    }
    IEnumerator AttackCool(GameObject gameObject)//공격실행
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
