using System.Collections;
using System.Collections.Generic;
using UnityEngine;
enum heromove
{
    Idle,
    move,//우킬릭
    w,//좌클릭
    a,
    s,
    d,


}
public class Hero : MonoBehaviour
{

    [SerializeField] int _attack;
    [SerializeField] Animator _ani;
    [SerializeField] float  speed;
    [SerializeField] GameObject _rotate;

    // Start is called before the first frame update
    void Start()
    {
        //_ani = GetComponent<Animator>();
        Debug.Log("확인");
    }

    // Update is called once per frame
    void Update()
    {
        move();
        
    }
    public void move()
    {
     
        Vector3 v3 = Vector3.zero;
        
        if (Input.GetKey(KeyCode.W))
        {
            v3 += (Vector3.forward).normalized * Time.deltaTime * speed;
            _ani.SetInteger("hero", (int)heromove.move);
            _rotate.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
            
        }
        if (Input.GetKey(KeyCode.A))
        {
            v3 += (Vector3.left).normalized * Time.deltaTime * speed;
            _ani.SetInteger("hero", (int)heromove.move);
            _rotate.transform.localRotation = Quaternion.Euler(new Vector3(0, 270, 0));

        }
        if (Input.GetKey(KeyCode.S))
        {
            v3 += (Vector3.back).normalized * Time.deltaTime * speed;
            _ani.SetInteger("hero", (int)heromove.move);
            _rotate.transform.localRotation = Quaternion.Euler(new Vector3(0, 180, 0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            v3 += (Vector3.right).normalized * Time.deltaTime * speed;
            _ani.SetInteger("hero", (int)heromove.move);
            _rotate.transform.localRotation = Quaternion.Euler(new Vector3(0, 90, 0));
        }

        if (v3!= Vector3.zero)
        {
            transform.Translate(v3);
        }

        else
        {
            _ani.SetInteger("hero", (int)heromove.Idle);
       
        }
    }
}

