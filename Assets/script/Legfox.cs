using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
enum fox
{
    move,
    attack,
    die,
}
public class Legfox : MonoBehaviour
{
    [SerializeField] Transform _hero;
    [SerializeField] GameObject _rotate;
    [SerializeField] float _speed;
    [SerializeField] float _hp;
    [SerializeField] int _attack;
    [SerializeField]  Animator _ani;
    Vector3 v3 = Vector3.zero;
    void Start()
    {
        
    }
    void Update()
    {
        // move();
        attack();
    }
   public void move()
    {
        v3 += (Vector3.forward).normalized * Time.deltaTime * _speed;
        _ani.SetInteger("legfox", (int)fox.move);
        _rotate.transform.localRotation = Quaternion.Euler(new Vector3(90, 0, 0));
        transform.Translate((_hero.position - _rotate.transform.position).normalized * Time.deltaTime * _speed);
    }
    public void attack()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            _ani.SetInteger("legfox", (int)fox.attack);
        }
    }
}
