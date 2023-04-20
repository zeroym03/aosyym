using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TowerHpSC : MonoBehaviour
{
    [SerializeField] TowerHpSC beforetower;
   public int _Hp =200;
    int _dmg = 0;
    //공격 코드 만들어야 함
    private void Start()
    {
        gameObject.SetActive(true);
        _dmg=GenericSinglngton<HeroData>.Instans._Damages;
    }
    private void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (beforetower == null || beforetower._Hp <= 0)
        {
            _Hp -= _dmg;
            Debug.Log(_Hp);
            if (_Hp <= 0)
            {
                removal();
            }
        }
    }
    void removal()
    {
        gameObject.SetActive(false);
    }
}
