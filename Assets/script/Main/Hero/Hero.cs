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
  //전부 HeroData로 옮길것
   protected  NavMeshAgent _Agent;
   protected  Color _heroColor;
    protected SkinnedMeshRenderer _render;
    protected Transform _hero;
    protected Image _herohp;
    protected GameObject _uiPanel;
    protected HpDown _hpimage;
    protected BoxCollider _Sword;
   //
    int _hpdown = 5;
   protected int _maxHP= 0;
    private void Awake()
    {
       GenericSinglngton<HeroData>.Instance._HeroAni = GetComponentInChildren<Animator>();
        Debug.Log(gameObject.name);
    //    _Agent = GetComponent<NavMeshAgent>();
    }
    void Start()
    {
        Debug.Log(GenericSinglngton<HeroData>.Instance._HeroAni);

        _maxHP = GenericSinglngton<HeroData>.Instance.hp;
    }
    void Update()
    {
        if (GenericSinglngton<HeroData>.Instance.hit == false&& GenericSinglngton<HeroData>.Instance.move == true) Hitted();//연속피해 방지
        HittedColer(); 
        ReMove();
        Attack(); 
        if (GenericSinglngton<HeroData>.Instance.move == true)
        {
            if (GenericSinglngton<HeroData>.Instance.attack == false)
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
                _Agent.SetDestination(hit.point);
            }
        }
        if (Vector3.Distance(gameObject.transform.position, _Agent.destination) >= 0.3f)// 현위치 - 목적이 계산
        {
          //  _ani.SetInteger("hero", (int)heromove.move);
        }
        else
        {
         //   _ani.SetInteger("hero", (int)heromove.Idle);
        }
    }
    public void Attack()//attack
    {

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            GenericSinglngton<HeroData>.Instance.attack = true;
           // _ani.SetTrigger("Attack");
            _Sword.enabled = true;
            DonMove();
        }
        if (GenericSinglngton<HeroData>.Instance.attack == true)
        {
            GenericSinglngton<HeroData>.Instance.attacktime += Time.deltaTime;
            EndAttack();
        }
    }
    void EndAttack()//attack
    {
        if (GenericSinglngton<HeroData>.Instance.attacktime > 0.5f)
        {
            GenericSinglngton<HeroData>.Instance.attack = false;
            _Sword.enabled = false;
            GenericSinglngton<HeroData>.Instance.attacktime = 0f;
        }
    }
    public void Hitted()//hitted
    {
        if (Input.GetKeyDown(KeyCode.M) /*_hp >= _hehp1*/)
        {
            _hpimage.Hpdown((float)GenericSinglngton<HeroData>.Instance.hp / _maxHP);
            GenericSinglngton<HeroData>.Instance.hp -= _hpdown;
            GenericSinglngton<HeroData>.Instance.hit = true;
            Debug.Log("받은피해" + _hpdown + "현재체력" + GenericSinglngton<HeroData>.Instance.hp);
        }
        //float value = ((float)GenericSinglngton<HeroData>.Instance.hp / _maxHP);
        //float min = 0;
        //float max = 1;
        //if (min > value) value = min;
        //if (max < value) value = max;
        //_herohp.transform.localScale = new Vector3(value, 1, 1);
        if (GenericSinglngton<HeroData>.Instance.hp <= 0)
        {
            Die();
            DonMove();
        }
    }
    public void HittedColer()//hitted
    {
        if (GenericSinglngton<HeroData>.Instance.hit == true)
        {
            GenericSinglngton<HeroData>.Instance.cortimer += Time.deltaTime;
            _render.material.color = Color.red;
            if (GenericSinglngton<HeroData>.Instance.cortimer > 0.5f)
            {
                _render.material.color = _heroColor;
                GenericSinglngton<HeroData>.Instance.cortimer = 0f;
                GenericSinglngton<HeroData>.Instance.hit = false;
            }
        }
    }
    public void Die()//die 
    {
       // _ani.SetInteger("hero", (int)heromove.die);
        GameOver();
        GenericSinglngton<HeroData>.Instance.move = false;
    }
    public void GameOver()
    {
        GenericSinglngton<GameoverUI>.Instance.gameObject.SetActive(true);
        GenericSinglngton<GameoverUI>.Instance.timechange(GenericSinglngton<HeroData>.Instance.dietimer);

    }
    public void ReMove()//die
    {
        if (GenericSinglngton<HeroData>.Instance.move == false)
        {
            GenericSinglngton<HeroData>.Instance.dietimer -= Time.deltaTime;
            if (GenericSinglngton<HeroData>.Instance.dietimer <= 0f)
            {
                GenericSinglngton<GameoverUI>.Instance.gameObject.SetActive(false);
                GenericSinglngton<HeroData>.Instance.hp = _maxHP;
                GenericSinglngton<HeroData>.Instance.move = true;
              //  _ani.SetInteger("hero", (int)heromove.a);
                 // _ani.SetTrigger("Remove");
                GenericSinglngton<HeroData>.Instance.dietimer = 5f;
            }
        }
    }
    public void DonMove()//캐릭터
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        _Agent.destination = gameObject.transform.position;
    }
}

