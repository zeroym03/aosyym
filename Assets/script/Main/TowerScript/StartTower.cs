using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class StartTower : MonoBehaviour
{
    [SerializeField] public int _Hp;
    [SerializeField] Hero _hero;
    int _dmg = 0;
    private void Start()
    {
        gameObject.SetActive(true);
        _dmg = _hero._Damages;
    }
    private void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        _Hp -= _dmg;
        Debug.Log(_Hp);
        if (_Hp <= 0)
        {
            removal();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        _Hp -= _dmg;
        Debug.Log(_Hp);
        if (_Hp <= 0)
        {
            removal();
        }
    }
    void removal()
    {
        gameObject.SetActive(false);
    }
}
