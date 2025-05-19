

using UnityEngine;

public abstract class BaseState <T> : ScriptableObject, IState {
    protected T Subject;
    public StateMachine<T> machine = new StateMachine<T>();
    public BaseState<T> CurrentSubState => machine.CurrentState;
    private float startTime;
    public float ElapsedTime => Time.time - startTime;


    public bool IsComplete { get; set; }

    public virtual void SetBlackBoard(T _subject) {
        Subject = _subject;
        SetupSubStates();
    }

    public virtual void SetupSubStates() { }

    public virtual void Initialize() {
        startTime = Time.time;
        IsComplete = false;
    }

    public virtual void Enter() { }
    public virtual void Do() { }
    public virtual void FixedDo() { }
    public virtual void Exit() { }

    public void OnUpdate() {
        Do();
        CurrentSubState?.OnUpdate();
    }
    public void OnFixedUpdate() {
        FixedDo();
        CurrentSubState?.OnFixedUpdate();
    }
    public void OnExit() {
        CurrentSubState?.OnExit();
        Exit();
    }
}
