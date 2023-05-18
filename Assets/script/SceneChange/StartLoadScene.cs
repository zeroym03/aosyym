using UnityEngine;
using UnityEngine.SceneManagement;

public class StartLoadScene : MonoBehaviour
{
    public void OnbtScenesChange()
    {
        SceneManager.LoadScene("Start");
    }
}
