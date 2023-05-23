using UnityEngine;
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
        GenericSinglngton<MinianCon>.Instance.Addmonster(_midline);
        GenericSinglngton<MinianCon>.Instance.Addmonster(_topline);
        GenericSinglngton<MinianCon>.Instance.Addmonster(_botline);
        //GenericSinglngton<MinianCon>.Instance.Addmonster(_redmidline);
        //GenericSinglngton<MinianCon>.Instance.Addmonster(_redtopline);
        //GenericSinglngton<MinianCon>.Instance.Addmonster(_redbotline);

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

            GenericSinglngton<MinianCon>.Instance.Addmonster(_midline);
            GenericSinglngton<MinianCon>.Instance.Addmonster(_topline);
            GenericSinglngton<MinianCon>.Instance.Addmonster(_botline);
            _montime = 0f;
            _nowmonsterCount++;
        }
    }
}
