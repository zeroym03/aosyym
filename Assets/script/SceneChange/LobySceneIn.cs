using UnityEngine;
using UnityEngine.SceneManagement;
public class LobySceneIn : MonoBehaviour
{
    public void onbuttonpres()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Loby");
    }
}
