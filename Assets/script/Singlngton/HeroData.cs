using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HeroData :Hero
{
    public Color heroColor;
    public int _Damages = 5;
    public float _speed;
    public int _hp;
   public float _cortimer = 0f;
    public float _dietimer = 5f;
    public float _attacktime = 0f;
    public bool _hit = false;
    public bool _move = true;
    public bool _attack = false;
    public string _name = "yym";// ������ �������� ������ ���Ϸ����� 

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}