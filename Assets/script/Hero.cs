using System.Collections;
using System.Collections.Generic;
using UnityEngine;
enum heromove
{
    Idle,
    move,//��ų��
    w,//��Ŭ��
    a,

}
public class Hero : MonoBehaviour
{
    
    [SerializeField] int _attack;
    Animator _ani;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Ȯ��");
    }

    // Update is called once per frame
    void Update()
    {
        move();
        
    }
    public void move()
    {
        if (Input.GetKey("a"))
        {
            _ani.SetInteger("hero", (int)heromove.Idle);
        }
        if (Input.GetKey("w"))
        {
            _ani.SetInteger("hero", (int)heromove.w);
        }
        //else
        {
        //    _ani.SetInteger("hero", (int)heromove.Idle);
       
        }
    }
}

