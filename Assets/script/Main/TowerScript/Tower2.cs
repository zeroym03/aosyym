using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower2 : MonoBehaviour
{
    [SerializeField] int _Hp;
    [SerializeField] Hero _hero;
    [SerializeField] StartTower _mid1;
    int _dmg = 0;
    int _on = 0;
    
    private void Start()
    {
        gameObject.SetActive(true);
        _dmg = _hero._Damages;
        
    }
    private void Update()
    {
        if (_mid1 == false)
        {

        }
    }
    private void OnTriggerEnter(Collider other)
    {// 닿은 유닛체크후 그 유닛에 공격력 받아서 그공격력으로 체력감소
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
