using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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
     NavMeshAgent _Agent;
     Color heroColor;

    [SerializeField] public Animator _ani;
    [SerializeField] Image _herohp;
    [SerializeField] GameObject _hero;
    [SerializeField] GameObject _uiPanel;
    [SerializeField] SkinnedMeshRenderer _render;
    [SerializeField] HpDown _hpimage;
    [SerializeField] GameoverUI _gameoverUI;
    [SerializeField] BoxCollider _Sword;
   
    int _hpdown = 5;
    int _maxHP= 0;
    private void Awake()
    {
        _Agent = GetComponent<NavMeshAgent>();
        heroColor = _render.material.color;

    }
    void Start()
    {
      _maxHP = GenericSinglngton<HeroData>.Instans.hp;
        Debug.Log(_maxHP);
    }
    void Update()
    {

        _hero.transform.position = gameObject.transform.position;
        if (GenericSinglngton<HeroData>.Instans.hit == false&& GenericSinglngton<HeroData>.Instans.move == true) Hitted();//연속피해 방지
        HittedColer(); 
        ReMove();
        Attack(); 
        if (GenericSinglngton<HeroData>.Instans.move == true)
        {
            if (GenericSinglngton<HeroData>.Instans.attack == false)
            {
                MouseClick();
            }
        }
        _gameoverUI.timechange(GenericSinglngton<HeroData>.Instans.dietimer); 
        
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
        if (Vector3.Distance(transform.position, _Agent.destination) >= 0.3f)// 현위치 - 목적이 계산
        {
            _ani.SetInteger("hero", (int)heromove.move);
        }
        else
        {
            _ani.SetInteger("hero", (int)heromove.Idle);
        }
    }
    public void Attack()//attack
    {

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            GenericSinglngton<HeroData>.Instans.attack = true;
            _ani.SetTrigger("Attack");
            _Sword.enabled = true;
            DonMove();
        }
        if (GenericSinglngton<HeroData>.Instans.attack == true)
        {
            GenericSinglngton<HeroData>.Instans.attacktime += Time.deltaTime;
            EndAttack();
        }
    }
    void EndAttack()//attack
    {
        if (GenericSinglngton<HeroData>.Instans.attacktime > 0.5f)
        {
            GenericSinglngton<HeroData>.Instans.attack = false;
            _Sword.enabled = false;
            GenericSinglngton<HeroData>.Instans.attacktime = 0f;
        }
    }
    public void Hitted()//hitted
    {
        if (Input.GetKeyDown(KeyCode.M) /*_hp >= _hehp1*/)
        {
            _hpimage.Hpdown((float)GenericSinglngton<HeroData>.Instans.hp / _maxHP);
            GenericSinglngton<HeroData>.Instans.hp -= _hpdown;
            GenericSinglngton<HeroData>.Instans.hit = true;
            Debug.Log("받은피해" + _hpdown + "현재체력" + GenericSinglngton<HeroData>.Instans.hp);
        }
        float value = ((float)GenericSinglngton<HeroData>.Instans.hp / _maxHP);
        float min = 0;
        float max = 1;
        if (min > value) value = min;
        if (max < value) value = max;
        _herohp.transform.localScale = new Vector3(value, 1, 1);
        if (GenericSinglngton<HeroData>.Instans.hp <= 0)
        {
            Die();
            DonMove();
        }
    }
    public void HittedColer()//hitted
    {
        if (GenericSinglngton<HeroData>.Instans.hit == true)
        {
            GenericSinglngton<HeroData>.Instans.cortimer += Time.deltaTime;
            _render.material.color = Color.red;
            if (GenericSinglngton<HeroData>.Instans.cortimer > 0.5f)
            {
                _render.material.color = heroColor;
                GenericSinglngton<HeroData>.Instans.cortimer = 0f;
                GenericSinglngton<HeroData>.Instans.hit = false;
            }
        }
    }
    public void Die()//die 
    {
        _ani.SetInteger("hero", (int)heromove.die);
        GameOver();
        GenericSinglngton<HeroData>.Instans.move = false;
    }
    public void GameOver()
    {
        _uiPanel.SetActive(true);
    }
    public void ReMove()//die
    {
        if (GenericSinglngton<HeroData>.Instans.move == false)
        {
            GenericSinglngton<HeroData>.Instans.dietimer -= Time.deltaTime;
            if (GenericSinglngton<HeroData>.Instans.dietimer <= 0f)
            {   
                _uiPanel.SetActive(false);
                GenericSinglngton<HeroData>.Instans.hp = _maxHP;
                GenericSinglngton<HeroData>.Instans.move = true;
               // _ani.SetInteger("hero", (int)heromove.a);????????????
                _ani.SetTrigger("Remove");
                GenericSinglngton<HeroData>.Instans.dietimer = 5f;
            }
        }
    }
    public void DonMove()//캐릭터
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        _Agent.destination = gameObject.transform.position;
    }
}

