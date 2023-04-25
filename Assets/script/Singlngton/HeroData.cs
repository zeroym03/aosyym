using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HeroData :Hero
{
    public int _Damages = 5;
    public float _speed = 20;
    public int _hp =20;
   public float _cortimer = 0f;
    public float _dietimer = 5f;
    public float _attacktime = 0f;
    public bool _hit = false;
    public bool _move = true;
    public bool _attack = false;
    public string _name = "yym";// 정보를 각각으로 나눠서 파일로저장 

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
