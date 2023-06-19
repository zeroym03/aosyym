using UnityEngine;

public class CameraCon : MonoBehaviour
{
    [SerializeField] Transform _transhero;

    void Update()
    {
        cameraCon();
    }
    void cameraCon()
    {
        transform.position = _transhero.position + new Vector3(0,30,-5);
    }
}
