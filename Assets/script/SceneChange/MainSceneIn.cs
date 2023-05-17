using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneIn: MonoBehaviour
{
    public void OnBtnMainScChange()
    {
        SceneManager.LoadScene("Main");

    }
}
