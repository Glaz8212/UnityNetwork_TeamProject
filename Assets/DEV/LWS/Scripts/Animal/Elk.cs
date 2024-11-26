using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elk : Animal
{
    private Vector3[] patrolPoints = { new Vector3(0, 0, 0), new Vector3(5, 0, 5), new Vector3(10, 0, 0) };
    private int currentPointIndex = 0;

    public override void OnIdleUpdate(IdleState state)
    {
        Vector3 target = patrolPoints[currentPointIndex];
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            currentPointIndex = (currentPointIndex + 1) % patrolPoints.Length;
        }

        PlayAnimation("Move");
    }

    public override GameObject DetectPlayer()
    {
        return null;
    }
}