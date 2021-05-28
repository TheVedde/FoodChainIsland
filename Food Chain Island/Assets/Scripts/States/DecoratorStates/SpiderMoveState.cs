using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderMoveState : SelectToMoveState
{
    public SpiderMoveState(int moves, bool imf) : base( moves, imf)
    {
        moves = Moves;
        imf = isMoveForced;
    }
    
    public override void OnMouseDown(Card prey)
    {
        StateManager.ChangeState(new MoveState(Moves, prey, isMoveForced));
    }
    
    public override void OnStateExit()
    {
        GUIManager.inst.RemoveAbilityText();
    }
}
