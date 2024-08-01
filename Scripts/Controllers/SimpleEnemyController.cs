using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemyController : MonoBehaviour
{
    private float timer;
    [SerializeField] private float attackTimeof = 1f;

    private void FixedUpdate()
    {
        if (!GameplayManager.Instance.isPlaying) return;

        if (timer > 0f) timer -= Time.fixedDeltaTime;

        if (timer <= 0f)
        {
            GameplayManager.Instance.enemy.Attack(GameplayManager.Instance.player);
            timer = attackTimeof;
        }
    }
}
