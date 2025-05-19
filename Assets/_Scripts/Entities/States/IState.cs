using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IState {
    bool IsComplete { get; set; }
    public void Enter();
    public void Do();
    public void OnUpdate();
    public void FixedDo();
    public void OnFixedUpdate();
    public void Exit();
    public void OnExit();
}
