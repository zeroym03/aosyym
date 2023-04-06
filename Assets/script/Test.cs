using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MouseClick();
    }
    void MouseClick()
    {
        if (Input.GetMouseButtonDown(0))//선택
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);//ray에 화면에서 입력됨 마우스에 포지션을 저장
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << LayerMask.NameToLayer("Ground")))//1<<LayerMask.NameToLayer("Unit") 을 선택  // 1은 활성화 0은 비활성화
            {
                Debug.Log("hit name" + hit.collider.name);//if문에서 ray 포지션으로 물체확인후 있으면 hit에저장후 hit이름을 출력
                //UnitCon con = hit.transform.GetComponent<UnitCon>();//
                //if (con == null) return;
                //if (Input.GetKey(KeyCode.LeftShift))
                //{
                //    GenericSinglngton<RTSCon>.getInstance().ShiftClickSelectUnit(con);
                //}
                //else
                //{
                //    GenericSinglngton<RTSCon>.getInstance().ClickSelectUnit(con);
                //}
            }
            else
            {
                if (Input.GetKey(KeyCode.LeftShift) == false)
                {
                    //    DeSelectAll();
                }
            }
        }
    }
}
