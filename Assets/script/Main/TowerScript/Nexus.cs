using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nexus : MonoBehaviour
{
    [SerializeField] TwinsTower twinsTower1;
    [SerializeField] TwinsTower twinsTower2;
    [SerializeField] GameObject endCanvas;
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
        if (twinsTower2.Hp <= 0 && twinsTower1.Hp <= 0) 
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
        Time.timeScale = 1f;
        endCanvas.SetActive(true);
    }
}
