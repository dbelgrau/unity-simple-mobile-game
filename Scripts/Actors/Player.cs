using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public override void Die()
    {
        base.Die();
        GameplayManager.Instance.PlayerDead();
    }
}
