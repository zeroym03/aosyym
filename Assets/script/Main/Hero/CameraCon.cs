using UnityEngine;

public class CameraCon : MonoBehaviour
{
    Transform _transhero;

    void Update()
    {
        cameraCon();
    }
    void cameraCon()
    {
        _transhero = GameObject.FindWithTag("Player").transform;
        transform.position = _transhero.position + new Vector3(0,30,-5);
    }
}
