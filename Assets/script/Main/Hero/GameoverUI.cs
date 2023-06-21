using UnityEngine;
using UnityEngine.UI;

public class GameoverUI : MonoBehaviour
{
    [SerializeField] Text _dietimetext;
    public void timechange(float timer)
    {
        _dietimetext.text = "남은부활시간"+$"{timer.ToString("F2")}";//$"{출력할 플롯 더블.ToString("F2소수점 몇자리생성")}";
    }
}
