using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameoverUI : MonoBehaviour
{
    [SerializeField] Text _dietimetext;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void timechange(float timer)
    {
        _dietimetext.text = $"{timer.ToString("F2")}";//$"{����� �÷� ����.ToString("F2�Ҽ��� ���ڸ�����")}";
    }
}
