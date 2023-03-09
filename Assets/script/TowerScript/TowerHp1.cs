using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHp1 : MonoBehaviour
{
    [SerializeField] int _Hp;
    [SerializeField] Hero _hero;
    [SerializeField] GameObject _mid1;
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
        if (_mid1 == false)
        {
            _Hp -= _dmg;
            Debug.Log(_Hp);
            if (_Hp <= 0)
            {
                removal();
            }
        }
        else
        {
            Debug.Log("공격불가");
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
