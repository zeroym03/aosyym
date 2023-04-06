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
    Color heroColor;
    [SerializeField] public int _Damages;//싱글톤으로
    [SerializeField] float _speed;
    [SerializeField] int _hp;

    [SerializeField] Animator _ani;
    [SerializeField] Image _herohp;
    [SerializeField] GameObject _hero;
    //[SerializeField] GameObject _RPGhero;
    [SerializeField] GameObject _uiPanel;
    [SerializeField] SkinnedMeshRenderer _render;
    [SerializeField] HpDown _hpimage;
    [SerializeField] GameoverUI _gameoverUI;
    [SerializeField] BoxCollider _Sword;
    NavMeshAgent _Agent;
    float _cortimer = 0f;
    float _dietimer = 5f;
    float _attacktime = 0f;
    bool _hit = false;
    bool _move = true;
    bool _attack = false;
    int _hpdown = 20;
    int _hehp ,HP= 120;
    private void Awake()
    {
        _Agent = GetComponent<NavMeshAgent>();
    }
    void Start()
    {
        _hehp = HP = _hp;
        Debug.Log("확인");
        heroColor = _render.material.color;
    }
    void Update()
    {
        _hero.transform.position = gameObject.transform.position;
        if (_hit == false&&_move == true )Hitted();//연속피해 방지
        HittedColer();
        ReMove();
        Attack();
        if (_move == true)
        {
            if (_attack == false)
            {
           //     move();
            }
        }
        Debug.Log(_move);
        Debug.Log(_attack);
        _gameoverUI.timechange(_dietimer);
        MouseClick();
    }
    void MouseClick()
    {
        if (Input.GetMouseButtonDown(0))//선택
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << LayerMask.NameToLayer("Ground")))
            {
                Debug.Log("hit name" + hit.collider.name+ hit.point);
                _Agent.SetDestination(hit.point);
            }
        }
        if (Vector3.Distance(transform.position, _Agent.destination) >= 0.3f )// 현위치 - 목적이 계산
        {
            _ani.SetInteger("Hero", (int)heromove.move);
        }
        else
        {
            _ani.SetInteger("Hero", (int)heromove.Idle);
        }
    }
        public void move()
    {
        float vX = Input.GetAxisRaw("Horizontal");//0=>1D==     -1,1,0값이 계속들어옴
        float vZ = Input.GetAxisRaw("Vertical");//GetAxis 0=0.1=0.2=0.3===1
        Debug.Log(vX);
        _ani.SetFloat("AxisX", vX * _speed);
        _ani.SetFloat("AxisZ", vZ * _speed);
        float vY = GetComponent<Rigidbody>().velocity.y;
        Vector3 v3 = new Vector3(vX, 0, vZ);
        Vector3 vYz = v3 * 4.5f;
        vYz.y += vY;
        GetComponent<Rigidbody>().velocity = vYz;
        if (Input.GetButton("Horizontal") && vX != 0)
        {
            transform.rotation = Quaternion.LookRotation(new Vector3(vYz.x, 0, vYz.z));
        }
        if (Input.GetButton("Vertical") && vZ != 0)
        {
            transform.rotation = Quaternion.LookRotation(new Vector3(vYz.x, 0, vYz.z));
        }
    }
    public void Attack()
    {

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            _attack = true;
            _ani.SetTrigger("Attack");
            _Sword.enabled = true;
            DonMove();
        }
        if (_attack == true)
        {
            _attacktime += Time.deltaTime;
            EndAttack();
        }
    }
    void EndAttack()
    {
        if (_attacktime > 0.5f)
        {
            _attack = false;
            _Sword.enabled = false;
            Debug.Log("EndAttack");
            _attacktime = 0f;
        }
    }
    public void Hitted()
    {
         
        if (Input.GetKeyDown(KeyCode.M) /*_hp >= _hehp1*/)
        {
            _hpimage.Hpdown((float)_hp / _hehp);
            _hp -= _hpdown;
            _hit = true;
            Debug.Log("받은피해" + _hpdown + "현재체력" + _hp);
        }
        float value = ((float)_hp / _hehp);
        float min = 0;
        float max = 1;
        if (min > value) value = min;
        if (max < value) value = max;
        _herohp.transform.localScale = new Vector3(value, 1, 1);
        if (_hp <= 0)
        {
            Die();
            DonMove();
        }
    }
    public void HittedColer()
    {
        if (_hit == true)
        {
            _cortimer += Time.deltaTime;
            _render.material.color = Color.red;
            if (_cortimer > 0.5f)
            {
                _render.material.color = heroColor;
                _cortimer = 0f;
                _hit = false;
            }
        }
    }
    public void Die()
    {
        _ani.SetInteger("hero", (int)heromove.die);
        GameOver();
        _move = false;
        Debug.Log("die");
    }
    public void GameOver()
    {
        _uiPanel.SetActive(true);
    }
    public void ReMove()
    {
        if (_move == false)
        {
            _dietimer -= Time.deltaTime;
            if (_dietimer <= 0f)
            {
                Debug.Log("ReMove");
                _uiPanel.SetActive(false);
                _hp = HP;
                _move = true;
                _ani.SetInteger("hero", (int)heromove.remove);
                _dietimer = 5f;
            }
        }
    }
    public void DonMove()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}

