using System.Collections;
using System.Collections.Generic;
using UnityEngine;
enum heromove
{
    Idle,
    move,//우킬릭
    w,//좌클릭

}
public class Hero : MonoBehaviour
{
    Animator _ani;
    [SerializeField] int _attack;
  

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("확인");
    }

    // Update is called once per frame
    void Update()
    {
        move();
        
    }
    public void move()
    {
        if (true)
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

