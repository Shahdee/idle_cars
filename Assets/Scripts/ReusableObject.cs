using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReusableObject : MonoBehaviour, IUpdatable, IFixUpdatable
{
    public virtual void ClearForBuffer(){}

    public virtual void UpdatePhysics(float delta){}

    public virtual void UpdateMe(float delta){}
}
