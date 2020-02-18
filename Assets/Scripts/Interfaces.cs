using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Params;

public interface IInitable{
    void Init();
}

public interface IUpdatable{
    void UpdateMe(float deltaTime);
}

// physics 
public interface IFixUpdatable{
    void UpdatePhysics(float deltaTime);
}
