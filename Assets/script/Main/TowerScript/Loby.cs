using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loby : MonoBehaviour
{
    private void Update()
    {

    }
    public void onbuttonpres()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Loby");
    }
}
