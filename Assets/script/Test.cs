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
        if (Input.GetMouseButtonDown(0))//����
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);//ray�� ȭ�鿡�� �Էµ� ���콺�� �������� ����
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << LayerMask.NameToLayer("Ground")))//1<<LayerMask.NameToLayer("Unit") �� ����  // 1�� Ȱ��ȭ 0�� ��Ȱ��ȭ
            {
                Debug.Log("hit name" + hit.collider.name);//if������ ray ���������� ��üȮ���� ������ hit�������� hit�̸��� ���
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
