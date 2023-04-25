using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    //  public void heroMove()//move
    //{
    //    if (Input.GetMouseButtonDown(0))//선택
    //    {
    //        Debug.Log("feuio");
    //        RaycastHit hit;
    //        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //        if (Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << LayerMask.NameToLayer("Ground")))
    //        {
    //              Debug.Log("hit name" + hit.collider.name+ hit.point);
    //            _Agent.SetDestination(hit.point);
    //        }
    //    }
    //    if (Vector3.Distance(transform.position, _Agent.destination) >= 0.3f)// 현위치 - 목적이 계산
    //    {
    //        _ani.SetInteger("Hero", (int)heromove.move);
    //    }
    //    else
    //    {
    //        _ani.SetInteger("Hero", (int)heromove.Idle);
    //    }
    //}
}
