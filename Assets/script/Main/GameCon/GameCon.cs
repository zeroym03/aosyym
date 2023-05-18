using UnityEngine;
public class GameCon : MonoBehaviour
{
    GameState _state;
    private void Start()
    {
        ChangeGameState(new MinianRunning());
    }
    void Update()
    {
        if (_state != null) _state.MainLoop();
    }
    public void ChangeGameState(GameState state)
    {
        _state = state;
        if (_state != null) _state.OnEnter();
    }
}
public class GameState
{
    public virtual void OnEnter(){}
    public virtual void MainLoop(){}
}

