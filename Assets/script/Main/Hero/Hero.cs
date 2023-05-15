using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
enum heromove
{
    Idle,
    move,//우킬릭
    w,//좌클릭
    die,
    remove,
    attack,
    a,
}
public class Hero : MonoBehaviour
{
    Color _heroColor;
    Transform _hero;

    //전부 HeroData로 옮길것
    protected HpDown _hpimage;
    int _hpdown = 5;//임시 피해변수
    int _maxHP = 0;
    private void Awake()
    {
        GenericSinglngton<HeroUnitData>.Instance._HeroAni = GetComponentInChildren<Animator>();
        GenericSinglngton<HeroUnitData>.Instance._HeroAgent = GetComponent<NavMeshAgent>();
        GenericSinglngton<HeroUnitData>.Instance._HeroSword = GetComponentInChildren<BoxCollider>();
        _heroColor = GetComponentInChildren<SkinnedMeshRenderer>().material.color;
        _maxHP = GenericSinglngton<HeroUnitData>.Instance.hp;

    }
    void Start()
    {
    }
    void Update()
    {
        if (GenericSinglngton<HeroUnitData>.Instance.hit == false && GenericSinglngton<HeroUnitData>.Instance.move == true) Hitted();//연속피해 방지
        HittedColer();
        ReMove();
        Attack();
        if (GenericSinglngton<HeroUnitData>.Instance.move == true)
        {
            if (GenericSinglngton<HeroUnitData>.Instance.attack == false)
            {
                MouseClick();
            }
        }
    }
    void MouseClick()//move
    {
        if (Input.GetMouseButtonDown(0))//선택
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << LayerMask.NameToLayer("Ground")))
            {
                GenericSinglngton<HeroUnitData>.Instance._HeroAgent.SetDestination(hit.point);
                Debug.Log(GenericSinglngton<HeroUnitData>.Instance._HeroAgent.destination);
            }
        }
        if (Vector3.Distance(gameObject.transform.position, GenericSinglngton<HeroUnitData>.Instance._HeroAgent.destination) >= 0.3f)// 현위치 - 목적이 계산
        {
            GenericSinglngton<HeroUnitData>.Instance._HeroAni.SetInteger("hero", (int)heromove.move);
        }
        else
        {
            GenericSinglngton<HeroUnitData>.Instance._HeroAni.SetInteger("hero", (int)heromove.Idle);
        }
    }
    public void Attack()//attack
    {

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            GenericSinglngton<HeroUnitData>.Instance.attack = true;
            GenericSinglngton<HeroUnitData>.Instance._HeroAni.SetTrigger("Attack");
            GenericSinglngton<HeroUnitData>.Instance._HeroSword.enabled = true;
            DonMove();
        }
        if (GenericSinglngton<HeroUnitData>.Instance.attack == true)
        {
            GenericSinglngton<HeroUnitData>.Instance.attacktime += Time.deltaTime;
            EndAttack();
        }
    }
    void EndAttack()//attack
    {
        if (GenericSinglngton<HeroUnitData>.Instance.attacktime > 0.5f)
        {
            GenericSinglngton<HeroUnitData>.Instance.attack = false;
            GenericSinglngton<HeroUnitData>.Instance._HeroSword.enabled = false;
            GenericSinglngton<HeroUnitData>.Instance.attacktime = 0f;
        }
    }
    public void Hitted()//hitted
    {
        if (Input.GetKeyDown(KeyCode.M) /*_hp >= _hehp1*/)
        {
            _hpimage.Hpdown((float)GenericSinglngton<HeroUnitData>.Instance.hp / _maxHP);
            GenericSinglngton<HeroUnitData>.Instance.hp -= _hpdown;
            GenericSinglngton<HeroUnitData>.Instance.hit = true;
            Debug.Log("받은피해" + _hpdown + "현재체력" + GenericSinglngton<HeroUnitData>.Instance.hp);
        }

        if (GenericSinglngton<HeroUnitData>.Instance.hp <= 0)
        {
            Die();
            DonMove();
        }
    }
    public void HittedColer()//hitted
    {
        if (GenericSinglngton<HeroUnitData>.Instance.hit == true)
        {
            GenericSinglngton<HeroUnitData>.Instance.cortimer += Time.deltaTime;
            GetComponentInChildren<SkinnedMeshRenderer>().material.color = Color.red;
            if (GenericSinglngton<HeroUnitData>.Instance.cortimer > 0.5f)
            {
                GetComponentInChildren<SkinnedMeshRenderer>().material.color = _heroColor;
                GenericSinglngton<HeroUnitData>.Instance.cortimer = 0f;
                GenericSinglngton<HeroUnitData>.Instance.hit = false;
            }
        }
    }
    public void Die()//die 
    {
        GenericSinglngton<HeroUnitData>.Instance._HeroAni.SetInteger("hero", (int)heromove.die);
        GameOver();
        GenericSinglngton<HeroUnitData>.Instance.move = false;
    }
    public void GameOver()
    {
        GenericSinglngton<GameoverUI>.Instance.gameObject.SetActive(true);
        GenericSinglngton<GameoverUI>.Instance.timechange(GenericSinglngton<HeroUnitData>.Instance.dietimer);

    }
    public void ReMove()//die
    {
        if (GenericSinglngton<HeroUnitData>.Instance.move == false)
        {
            GenericSinglngton<HeroUnitData>.Instance.dietimer -= Time.deltaTime;
            if (GenericSinglngton<HeroUnitData>.Instance.dietimer <= 0f)
            {
                GenericSinglngton<GameoverUI>.Instance.gameObject.SetActive(false);
                GenericSinglngton<HeroUnitData>.Instance.hp = _maxHP;
                GenericSinglngton<HeroUnitData>.Instance.move = true;
                GenericSinglngton<HeroUnitData>.Instance._HeroAni.SetInteger("hero", (int)heromove.a);
                GenericSinglngton<HeroUnitData>.Instance._HeroAni.SetTrigger("Remove");
                GenericSinglngton<HeroUnitData>.Instance.dietimer = 5f;
            }
        }
    }
    public void DonMove()//캐릭터
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GenericSinglngton<HeroUnitData>.Instance._HeroAgent.destination = gameObject.transform.position;
    }
}

