using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdObstacleDamage : ObstacleDamage
{
    public override void OnCollisionEnter(Collision collision)
    {
        base.damageAmount = 10f; // Set the damage amount for this specific obstacle
        base.OnCollisionEnter(collision);
    }
}
