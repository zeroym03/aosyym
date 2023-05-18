using UnityEngine;
using UnityEngine.SceneManagement;
public class EndGameLoadScene : MonoBehaviour
{
    public void onbuttonpres()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("EndGame");
    }
}
