using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerInteractiveState : PlayerAbilityState
{
    private Switch interactiveObject;

    public PlayerInteractiveState(Player player, PlayerStateMachine stateMachine, PlayerControlData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
        
    }

    public override void Enter()
    {
        base.Enter();

        if(interactiveObject != null)
        {
            interactiveObject.LookTarget(() =>
            {
                isAbilityDone = true;
            });
        }

        player.InputHandler.UseInteractiveInput();

        Movement.SetVelocityX(0);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        Movement.SetVelocityX(0);
    }

    public void SetInteractiveObject(Switch interactiveObject)
    {
        this.interactiveObject = interactiveObject;
    }

    public void Finish()
    {
        isAbilityDone = true;
    }
}
