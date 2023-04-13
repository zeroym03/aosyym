using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nexus : MonoBehaviour
{
    [SerializeField] int _Hp;
    [SerializeField] Hero _hero;
    [SerializeField] GameObject _Endparent;
    int _dmg= 0;
    private void Start()
    {
      //  gameObject.SetActive(true);
        _dmg = _hero._Damages;
    }
    private void OnTriggerEnter(Collider other)
    {
        _Hp -= _dmg;
        Debug.Log(_Hp);
        if (_Hp <= 0)
        {
            EndGame();
            removal();
        }
    }
    void removal()
    {
        gameObject.SetActive(false);
    }
    void EndGame()
    {
        _Endparent.SetActive(true);
        Time.timeScale = 0f;
    }
}
