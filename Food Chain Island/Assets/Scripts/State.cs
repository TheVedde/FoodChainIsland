using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    public string StateName;
    
    public virtual void OnMouseDown() { }
    public virtual void OnMouseDown(Card prey) { }
    public virtual void OnMouseDown(Field field) { }
    public virtual void OnMouseDown(Card prey, bool isMoveForced) {}
    public virtual void OnMouseEnter(Card card) { }
    public virtual void OnMouseExit(Card card) { }
    public virtual void OnStateExit() { }
    public virtual void OnStateEnter() { }
    public virtual void GoBack() { }
    public State()
    {
            
    }
}
