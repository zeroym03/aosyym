using UnityEngine;
using UnityEngine.SceneManagement;
public class EndGameLoadScene : MonoBehaviour
{
    private void Start()
    {
        GameObject endSword = Resources.Load<GameObject>("Prefab/Object/EndSword");
        Instantiate(endSword).transform.position = GameObject.Find("Main Camera").transform.position - new Vector3(-0.5f, 10, -2f);
    }
    public void onbuttonpres()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("EndGame");
    }
}
