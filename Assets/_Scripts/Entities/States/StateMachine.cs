using System.Collections.Generic;

public class StateMachine<T> {
    public BaseState<T> CurrentState;
    public void Set(BaseState<T> newState, bool forceReset = false) {
        if (CurrentState != newState || forceReset) {
            CurrentState?.OnExit();
            CurrentState = newState;
            CurrentState.Initialize();
            CurrentState.Enter();
        }
    }

    public List<string> GetActiveStateBranch(List<string> list = null) {
        if (list == null) {
            list = new List<string>();
        }

        if (CurrentState == null) {
            return list;
        }
        else {
            list.Add(CurrentState.ToString());
            return CurrentState.machine.GetActiveStateBranch(list);
        }
    }
}