using UnityEngine;
public enum ETeamColor
{
    None,
    Red,
    Blue,
}
public class AllDataSingletun : MonoBehaviour
{
     ETeamColor EHeroTeamColor = ETeamColor.Blue ;//�������� �޾Ƽ� ���� �������̸� ����,�����̵� ���ϵ��� 
    public ETeamColor _eHeroTeamColor { get { return EHeroTeamColor; } set { _eHeroTeamColor = value; } }
    int HeroDmg = 70;
    public int _heroDmg { get { return HeroDmg; } }
}
