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
        _on = _mid1._Hp;
    }
    private void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {// ���� ����üũ�� �� ���ֿ� ���ݷ� �޾Ƽ� �װ��ݷ����� ü�°���
        if (_on <=0)  
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
            Debug.Log("���ݺҰ�");
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
