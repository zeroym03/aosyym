using UnityEngine;
using UnityEngine.SceneManagement;
public class Loby : MonoBehaviour
{
    public void onbuttonpres()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Loby");
    }
}
