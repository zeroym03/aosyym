using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UIElements;

enum heromove
{
    Idle,
    move,//우킬릭
    w,//좌클릭
    die,



}
public class Hero : MonoBehaviour
{
    Color heroColor;
    [SerializeField] int _attack;
    [SerializeField] float speed;
    [SerializeField] int _hp;
    [SerializeField] Animator _ani;
    [SerializeField] GameObject _rotate;
    [SerializeField] GameObject _hero;
    [SerializeField] GameObject _uiPanel;
    [SerializeField] SkinnedMeshRenderer _render;
    float _timer = 0f;
    bool _hit = false;
   // bool _isGameOver = false;
    bool _move = true;
  
    void Start()
    {
        Debug.Log("확인");
        heroColor = _render.material.color;
    }
    void Update()
    {
        if (_move == true)
        {
            move();
        }
        Hitted();
        HittedColer();
    }
    public void move()
    {
        Vector3 v3 = Vector3.zero;   
        if (Input.GetKey(KeyCode.W))
        {
            v3 += (Vector3.forward).normalized * Time.deltaTime * speed;
            _ani.SetInteger("hero", (int)heromove.move);
            _rotate.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
        if (Input.GetKey(KeyCode.A))
        {
            v3 += (Vector3.left).normalized * Time.deltaTime * speed;
            _ani.SetInteger("hero", (int)heromove.move);
            _rotate.transform.localRotation = Quaternion.Euler(new Vector3(0, 270, 0));
        }
        if (Input.GetKey(KeyCode.S))
        {
            v3 += (Vector3.back).normalized * Time.deltaTime * speed;
            _ani.SetInteger("hero", (int)heromove.move);
            _rotate.transform.localRotation = Quaternion.Euler(new Vector3(0, 180, 0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            v3 += (Vector3.right).normalized * Time.deltaTime * speed;
            _ani.SetInteger("hero", (int)heromove.move);
            _rotate.transform.localRotation = Quaternion.Euler(new Vector3(0, 90, 0));
        }
        if (v3!= Vector3.zero)
        {
            transform.Translate(v3);
        }
        else
        {
            _ani.SetInteger("hero", (int)heromove.Idle);
        }
    }
    public void Hitted()
    {
        if (Input.GetKeyDown(KeyCode.M))//공격받았을때
        {
            _hp -= 20;
            _hit = true;
        }
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
            _timer += Time.deltaTime;
            _render.material.color = Color.red;
            if (_timer > 0.5f)
            {
                _render.material.color = heroColor;
                _timer = 0f;
                _hit = false;
            }
        }
    }
    public void Die()
    {
        _ani.SetInteger("hero", (int)heromove.die);
        GameOver();
    }
    public void GameOver()
    {
        _uiPanel.SetActive(true);
    }
}

