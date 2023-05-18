using UnityEngine;

public class MidLine : MonoBehaviour
{
    [SerializeField] Transform[] _MidPaths;
    public Transform[] getPaths() { return _MidPaths; }
}
