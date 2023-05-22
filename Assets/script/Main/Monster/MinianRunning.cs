using UnityEngine;
public class MinianRunning : GameState
{
    float _mondelay = 4.0f;
    float _moncount = 50;
    float _montime = 0;
    float _nowmonsterCount = 0;
    public override void OnEnter()
    {
        GenericSinglngton<MinianCon>.Instance.Addmonster();
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

            GenericSinglngton<MinianCon>.Instance.Addmonster();
            _montime = 0f;
            _nowmonsterCount++;
        }
    }
}
