using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    public override void Die()
    {
        base.Die();
        GameplayManager.Instance.DefeatEnemy();
    }
}
