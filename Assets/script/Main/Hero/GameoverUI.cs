using UnityEngine;
using UnityEngine.UI;

public class GameoverUI : MonoBehaviour
{
    [SerializeField] Text _dietimetext;
    public void timechange(float timer)
    {
        _dietimetext.text = $"{timer.ToString("F2")}";//$"{����� �÷� ����.ToString("F2�Ҽ��� ���ڸ�����")}";
    }
}
