using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobySceneschange : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void OnbtScenesChange()
    {
        SceneManager.LoadScene("Start");
        Debug.Log("¹öÆ°");
    }
}
