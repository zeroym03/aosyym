using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Analytics;
using UnityEngine.UI;


enum heromove
{
    Idle,
    move,//우킬릭
    w,//좌클릭
    die,
    remove,
    attack,
}
public class Hero : MonoBehaviour
{
    //캐릭터가 좌표가 00으 로있도록
    HeroData herodata;
    public NavMeshAgent _Agent;





    [SerializeField] public Animator _ani;
    [SerializeField] Image _herohp;
    [SerializeField] GameObject _hero;
    //[SerializeField] GameObject _RPGhero;
    [SerializeField] GameObject _uiPanel;
    [SerializeField] SkinnedMeshRenderer _render;
    [SerializeField] HpDown _hpimage;
    [SerializeField] GameoverUI _gameoverUI;
    [SerializeField] BoxCollider _Sword;
   
   
    int _hpdown = 20;
    int _hehp ,HP= 120;
    private void Awake()
    {
        _Agent = GetComponent<NavMeshAgent>();
    }
    void Start()
    {
       HP= GenericSinglngton<HeroData>.Instans._hp;
        Debug.Log(HP);
        _hehp = HP = herodata._hp;
        Debug.Log("확인");
        herodata.heroColor = _render.material.color;
    }
    void Update()
    {
        _hero.transform.position = gameObject.transform.position;
       // if (herodata._hit == false&& herodata._move == true )//Hitted();//연속피해 방지
        HittedColer(); 
        ReMove();
        Attack(); 
        if (herodata._move == true)
        {
            if (herodata._attack == false)
            {
            }
        }
        Debug.Log(herodata._move); 
        Debug.Log(herodata._attack); 
        _gameoverUI.timechange(herodata._dietimer); 
        GenericSinglngton<HeroMove>.Instans.heroMove();
        
    }
    //void MouseClick()//move
    //{
    //    if (Input.GetMouseButtonDown(0))//선택
    //    {
    //        RaycastHit hit;
    //        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //        if (Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << LayerMask.NameToLayer("Ground")))
    //        {
    //            //  Debug.Log("hit name" + hit.collider.name+ hit.point);
    //            herodata._Agent.SetDestination(hit.point);
    //        }
    //    }
    //    if (Vector3.Distance(transform.position, herodata._Agent.destination) >= 0.3f )// 현위치 - 목적이 계산
    //    {
    //        _ani.SetInteger("Hero", (int)heromove.move);
    //    }
    //    else
    //    {
    //        _ani.SetInteger("Hero", (int)heromove.Idle);
    //    }
    //}

    public void Attack()//attack
    {

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            herodata._attack = true;
            _ani.SetTrigger("Attack");
            _Sword.enabled = true;
            DonMove();
        }
        if (herodata._attack == true)
        {
            herodata._attacktime += Time.deltaTime;
            EndAttack();
        }
    }
    void EndAttack()//attack
    {
        if (herodata._attacktime > 0.5f)
        {
            herodata._attack = false;
            _Sword.enabled = false;
            Debug.Log("EndAttack");
            herodata._attacktime = 0f;
        }
    }
    public void Hitted()//hitted
    {
         
        if (Input.GetKeyDown(KeyCode.M) /*_hp >= _hehp1*/)
        {
            _hpimage.Hpdown((float)herodata._hp / _hehp);
            herodata._hp -= _hpdown;
            herodata._hit = true;
            Debug.Log("받은피해" + _hpdown + "현재체력" + herodata._hp);
        }
        float value = ((float)herodata._hp / _hehp);
        float min = 0;
        float max = 1;
        if (min > value) value = min;
        if (max < value) value = max;
        _herohp.transform.localScale = new Vector3(value, 1, 1);
        if (herodata._hp <= 0)
        {
            Die();
            DonMove();
        }
    }
    public void HittedColer()//hitted
    {
        if (herodata._hit == true)
        {
            herodata._cortimer += Time.deltaTime;
            _render.material.color = Color.red;
            if (herodata._cortimer > 0.5f)
            {
                _render.material.color = herodata.heroColor;
                herodata._cortimer = 0f;
                herodata._hit = false;
            }
        }
    }
    public void Die()//die 
    {
        _ani.SetInteger("hero", (int)heromove.die);
        GameOver();
        herodata._move = false;
        Debug.Log("die");
    }
    public void GameOver()
    {
        _uiPanel.SetActive(true);
    }
    public void ReMove()//die
    {
        if (herodata._move == false)
        {
            herodata._dietimer -= Time.deltaTime;
            if (herodata._dietimer <= 0f)
            {
                Debug.Log("ReMove");
                _uiPanel.SetActive(false);
                 herodata._hp = HP;
                herodata._move = true;
                _ani.SetInteger("hero", (int)heromove.remove);
                herodata._dietimer = 5f;
            }
        }
    }
    public void DonMove()//캐릭터
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}

