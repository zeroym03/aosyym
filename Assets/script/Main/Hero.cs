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
    public NavMeshAgent _Agent;
     Color heroColor;





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
        Debug.Log(_hehp);
        Debug.Log("확인");
       heroColor = _render.material.color;
    }
    void Update()
    {
        _hero.transform.position = gameObject.transform.position;
        if (GenericSinglngton<HeroData>.Instans._hit == false&& GenericSinglngton<HeroData>.Instans._move == true) { }//Hitted();//연속피해 방지
        HittedColer(); 
        ReMove();
        Attack(); 
        if (GenericSinglngton<HeroData>.Instans._move == true)
        {
            if (GenericSinglngton<HeroData>.Instans._attack == false)
            {
                MouseClick();
            }
        }
        Debug.Log(GenericSinglngton<HeroData>.Instans._move); 
        Debug.Log(GenericSinglngton<HeroData>.Instans._attack); 
        _gameoverUI.timechange(GenericSinglngton<HeroData>.Instans._dietimer); 
        
    }
    void MouseClick()//move
    {
        if (Input.GetMouseButtonDown(0))//선택
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << LayerMask.NameToLayer("Ground")))
            {
                //  Debug.Log("hit name" + hit.collider.name+ hit.point);
                _Agent.SetDestination(hit.point);
            }
        }
        if (Vector3.Distance(transform.position, _Agent.destination) >= 0.3f)// 현위치 - 목적이 계산
        {
            _ani.SetInteger("Hero", (int)heromove.move);
        }
        else
        {
            _ani.SetInteger("Hero", (int)heromove.Idle);
        }
    }

    public void Attack()//attack
    {

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            GenericSinglngton<HeroData>.Instans._attack = true;
            _ani.SetTrigger("Attack");
            _Sword.enabled = true;
            DonMove();
        }
        if (GenericSinglngton<HeroData>.Instans._attack == true)
        {
            GenericSinglngton<HeroData>.Instans._attacktime += Time.deltaTime;
            EndAttack();
        }
    }
    void EndAttack()//attack
    {
        if (GenericSinglngton<HeroData>.Instans._attacktime > 0.5f)
        {
            GenericSinglngton<HeroData>.Instans._attack = false;
            _Sword.enabled = false;
            Debug.Log("EndAttack");
            GenericSinglngton<HeroData>.Instans._attacktime = 0f;
        }
    }
    public void Hitted()//hitted
    {
         
        if (Input.GetKeyDown(KeyCode.M) /*_hp >= _hehp1*/)
        {
            _hpimage.Hpdown((float)GenericSinglngton<HeroData>.Instans._hp / _hehp);
            GenericSinglngton<HeroData>.Instans._hp -= _hpdown;
            GenericSinglngton<HeroData>.Instans._hit = true;
            Debug.Log("받은피해" + _hpdown + "현재체력" + GenericSinglngton<HeroData>.Instans._hp);
        }
        float value = ((float)GenericSinglngton<HeroData>.Instans._hp / _hehp);
        float min = 0;
        float max = 1;
        if (min > value) value = min;
        if (max < value) value = max;
        _herohp.transform.localScale = new Vector3(value, 1, 1);
        if (GenericSinglngton<HeroData>.Instans._hp <= 0)
        {
            Die();
            DonMove();
        }
    }
    public void HittedColer()//hitted
    {
        if (GenericSinglngton<HeroData>.Instans._hit == true)
        {
            GenericSinglngton<HeroData>.Instans._cortimer += Time.deltaTime;
            _render.material.color = Color.red;
            if (GenericSinglngton<HeroData>.Instans._cortimer > 0.5f)
            {
                _render.material.color = heroColor;
                GenericSinglngton<HeroData>.Instans._cortimer = 0f;
                GenericSinglngton<HeroData>.Instans._hit = false;
            }
        }
    }
    public void Die()//die 
    {
        _ani.SetInteger("hero", (int)heromove.die);
        GameOver();
        GenericSinglngton<HeroData>.Instans._move = false;
        Debug.Log("die");
    }
    public void GameOver()
    {
        _uiPanel.SetActive(true);
    }
    public void ReMove()//die
    {
        if (GenericSinglngton<HeroData>.Instans._move == false)
        {
            GenericSinglngton<HeroData>.Instans._dietimer -= Time.deltaTime;
            if (GenericSinglngton<HeroData>.Instans._dietimer <= 0f)
            {   
                Debug.Log("ReMove");
                _uiPanel.SetActive(false);
                 GenericSinglngton<HeroData>.Instans._hp = HP;
                GenericSinglngton<HeroData>.Instans._move = true;
                _ani.SetInteger("hero", (int)heromove.remove);
                GenericSinglngton<HeroData>.Instans._dietimer = 5f;
            }
        }
    }
    public void DonMove()//캐릭터
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}

