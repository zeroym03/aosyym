using UnityEngine;
public enum ETeamColor
{
    None,
    Red,
    Blue,
}
public class AllDataSingletun : MonoBehaviour
{
     ETeamColor EHeroTeamColor = ETeamColor.Blue ;//이정보를 받아서 같은 팀색깔이면 공격,공격이동 못하도록 
    public ETeamColor _eHeroTeamColor { get { return EHeroTeamColor; } set { _eHeroTeamColor = value; } }
    int HeroDmg = 70;
    public int _heroDmg { get { return HeroDmg; } }
}
