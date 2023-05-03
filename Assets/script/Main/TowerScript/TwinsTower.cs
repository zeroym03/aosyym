using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwinsTower : MonoBehaviour
{
    [SerializeField] TowerHpCon topTower;
    [SerializeField] TowerHpCon midTower;
    [SerializeField] TowerHpCon botTower;
     int _Hp = 200;
    public int Hp { get { return _Hp; } set { _Hp = value; } }
    int _dmg = 0;
    private void Start()
    {
        gameObject.SetActive(true);
        _dmg = GenericSinglngton<HeroData>.Instans.Damages;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (topTower.Hp <=0 || midTower.Hp <= 0|| botTower.Hp <= 0)
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
            Debug.Log("앞에포탑이 살아있습니다");
        }
    }
    void removal()
    {
        gameObject.SetActive(false);
    }
}
