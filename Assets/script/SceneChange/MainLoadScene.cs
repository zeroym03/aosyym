using UnityEngine;
using UnityEngine.SceneManagement;

public class MainLoadScene: MonoBehaviour
{
    public void OnBtnMainScChange()
    { 
        GenericSinglngton<MinianCon>.Instance.SetClearPath();
        SceneManager.LoadScene("Maintest");
    }
}
