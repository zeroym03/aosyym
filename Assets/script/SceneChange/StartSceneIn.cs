using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneIn : MonoBehaviour
{
    public void OnbtScenesChange()
    {
        SceneManager.LoadScene("Start");
    }
}
