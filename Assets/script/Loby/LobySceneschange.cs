using UnityEngine;
using UnityEngine.SceneManagement;

public class LobySceneschange : MonoBehaviour
{
    public void OnbtScenesChange()
    {
        SceneManager.LoadScene("Start");
    }
}
