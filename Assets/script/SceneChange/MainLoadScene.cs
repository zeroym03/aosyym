using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainLoadScene: MonoBehaviour
{
    [SerializeField] GameObject _panal;
    [SerializeField] Toggle _toggle;
    [SerializeField] Slider _slider;
    public void OnBtnMainScChange()//bt
    { 
        GenericSinglngton<MinianCon>.Instance.SetClearPath();
        SceneManager.LoadScene("Maintest");
    }
    public void OnButtenSetting()//bt
    {
        if (_panal.activeSelf == false)   {_panal.SetActive(true);}
        else{_panal.SetActive(false);  }
    }
    public void OnSoundToggle()
    {

    }  
    public void OnSoundSlider()
    {

    }
}
