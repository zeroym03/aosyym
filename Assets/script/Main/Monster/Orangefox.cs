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
        if (_hp <= 0) { _efox = Efox.die; }
    }
    private void Update()
    {
        if (_efox != Efox.die)
        {
            _herotransform = GameObject.FindWithTag("Player");
            if (GenericSinglngton<AllDataSingletun>.Instance._eHeroTeamColor == _mondata._eTeamColor) { _efox = Efox.move; } //_eHeroTeamColor를 매개변수로 받아서

            else MinianSearch(_herotransform.transform);//_efox = Efox
            if (_efox == Efox.move) MinianTowerMove();//GetTarget이 널이면
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
    void MinianSearch(Transform herotrans)
    {
        dis1 = Vector3.Distance(herotrans.position, transform.position); //거리체크//_hero 왜에도 적 미니언도 잡아야됨
        if (dis1 < dis2)//적 찾아서 이동시작거리
        { _efox = Efox.attack; }
        else
        {
            _efox = Efox.move;// _efox 에따라 상태변화로
        }
    }
    void MinianAttack(Transform herotrans)//영웅도 미니언컨에서 서치로?
    {
        if (dis1 < 3)//공격 시작거리
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
