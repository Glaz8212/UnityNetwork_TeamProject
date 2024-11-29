using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : AnimalState
{
    public IdleState(Animal animal) : base(animal) { }

    public override void Enter()
    {
        animal.PlayIdleAnimation();
        Debug.Log($"{animal.name} : Idle ����");
    }

    public override void Update()
    {
        animal.OnIdleUpdate(this);
        
        GameObject detectedPlayer = animal.DetectPlayer();
        if (detectedPlayer != null)
        {
            animal.RotateTowardsTarget(detectedPlayer.transform.position);
            animal.SetState(new AttackState(animal));
        }
    }

    public override void Exit() 
    {
        Debug.Log($"{animal.name} : Idle ���� ����");
    }
}