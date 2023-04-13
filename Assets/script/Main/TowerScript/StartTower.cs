using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class StartTower : MonoBehaviour
{
    int _Hp;
    int _dmg = 0;
    //공격 코드 만들어야 함
    private void Start()
    {
        gameObject.SetActive(true);
        _dmg=GenericSinglngton<Hero>.Instans._Damages;
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
    void removal()
    {
        gameObject.SetActive(false);
    }
}
