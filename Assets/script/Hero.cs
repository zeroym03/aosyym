using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
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
    //n,m
    Color heroColor;
    [SerializeField] public int _Damages;
    [SerializeField] float _speed;
    [SerializeField] int _hp;
    [SerializeField] Animator _ani;
    [SerializeField] Image _herohp;
    [SerializeField] GameObject _rotate;
    [SerializeField] GameObject _hero;
    [SerializeField] GameObject _uiPanel;
    [SerializeField] SkinnedMeshRenderer _render;
    [SerializeField] HpDown _hpimage;
    [SerializeField] GameoverUI _gameoverUI;
    float _cortimer = 0f;
    float _dietimer = 5f;
    bool _hit = false;
    bool _move = true;
    bool _attack = false;
    int _hpdown = 20;
    int _hehp1 = 120;
    void Start()
    {
        int _hehp = _hp;
        Debug.Log("확인");
        heroColor = _render.material.color;
    }
    void Update()
    {
      
        //if (_hit == false)
        //    Hitted();//연속피해 방지
        HittedColer();
        ReMove();
        Attack();
        if (_move == true)
        {
            if (_attack == false)
            {
                move();
            }
        }
        _gameoverUI.timechange(_dietimer);
    }
    public void move()
    {
        Vector3 v3 = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            v3 += (Vector3.forward).normalized * Time.deltaTime * _speed;
            _ani.SetInteger("hero", (int)heromove.move);
            _rotate.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
        if (Input.GetKey(KeyCode.A))
        {
            v3 += (Vector3.left).normalized * Time.deltaTime * _speed;
            _ani.SetInteger("hero", (int)heromove.move);
            _rotate.transform.localRotation = Quaternion.Euler(new Vector3(0, 270, 0));
        }
        if (Input.GetKey(KeyCode.S))
        {
            v3 += (Vector3.back).normalized * Time.deltaTime * _speed;
            _ani.SetInteger("hero", (int)heromove.move);
            _rotate.transform.localRotation = Quaternion.Euler(new Vector3(0, 180, 0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            v3 += (Vector3.right).normalized * Time.deltaTime * _speed;
            _ani.SetInteger("hero", (int)heromove.move);
            _rotate.transform.localRotation = Quaternion.Euler(new Vector3(0, 90, 0));
        }

        if (v3 != Vector3.zero)
        {
            transform.Translate(v3);
        }
        else
        {
            _ani.SetInteger("hero", (int)heromove.Idle);
        }
    }
    public void Attack()
    {

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            _attack = true;
            _ani.SetInteger("hero", (int)heromove.attack);

         
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            _attack = false;
        }

    }
    public void Hitted()
    {
        int _hehp = _hp;
        if (_hp >= _hehp1)
        {
            _hpimage.Hpdown((float)_hp / _hehp1);
        }
        float value = ((float)_hp / _hehp1);
        float min = 0;
        float max = 1;
        if (min > value) value = min;
        if (max < value) value = max;
        _herohp.transform.localScale = new Vector3(value, 1, 1);
        if (_hp < 0)return;//공격받았을때
        
            _hp -= _hpdown;
            _hit = true;
            Debug.Log("받은피해" + _hpdown + "현재체력" + _hp);
        if (_hp <= 0)
        {
            Die();
            _move = false;
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
                _hp = _hehp1;
                _move = true;
                _ani.SetInteger("hero", (int)heromove.remove);
                _dietimer = 5f;
            }
        }
    }
   
}

