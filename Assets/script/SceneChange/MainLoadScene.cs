using UnityEngine;
using UnityEngine.SceneManagement;

public class MainLoadScene: MonoBehaviour
{
    public void OnBtnMainScChange()
    {
        SceneManager.LoadScene("Main");

    }
}
