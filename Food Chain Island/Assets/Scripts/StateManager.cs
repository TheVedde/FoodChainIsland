using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StateManager
{
    public static State currentState = null;
    public static void ChangeState(State state) {
        if (currentState != null) { currentState.OnStateExit(); }
        currentState = state;
        currentState.OnStateEnter();
    }
}
