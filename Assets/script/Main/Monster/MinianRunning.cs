using UnityEngine;
enum ELine
{
    _midline,
    _topline,
    _botline,
    _redmidline,
    _redtopline,
    _redbotline,
}
public class MinianRunning : GameState
{
    float _mondelay = 4.0f;
    float _moncount = 50;
    float _montime = 0;
    float _nowmonsterCount = 0;
    int _midline = 0;
    int _topline = 1;
    int _botline = 2;
    int _redmidline = 3;
    int _redtopline = 4;
    int _redbotline = 5;
    public override void OnEnter()
    {
        MinianSummon();
    }
    public override void MainLoop()
    {
        MakeMonsterLoop();
    }
    void MakeMonsterLoop()
    {
        _montime += Time.deltaTime;
        if (_montime >= _mondelay && _nowmonsterCount < _moncount)
        {
            MinianSummon();
            _montime = 0f;
            _nowmonsterCount++;
        }
    }
    void MinianSummon()
    {
        GenericSinglngton<MinianCon>.Instance.Addmonster(_midline, ETeamColor.Red);
        GenericSinglngton<MinianCon>.Instance.Addmonster(_topline, ETeamColor.Red);
        GenericSinglngton<MinianCon>.Instance.Addmonster(_botline, ETeamColor.Red);
        GenericSinglngton<MinianCon>.Instance.Addmonster(_redmidline, ETeamColor.Blue);
        GenericSinglngton<MinianCon>.Instance.Addmonster(_redtopline, ETeamColor.Blue);
        GenericSinglngton<MinianCon>.Instance.Addmonster(_redbotline, ETeamColor.Blue);
    }
}
