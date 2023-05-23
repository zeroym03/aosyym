using UnityEngine;

public class LinePaths : MonoBehaviour
{
    [SerializeField] Transform[] _LinePaths;
    public Transform[] getPaths() { return _LinePaths; }
}
