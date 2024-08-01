using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private int health;

    [SerializeField] private int attack;
    [SerializeField] private int armor;
    [SerializeField] private int block;
    [SerializeField] private int averageDmg;

    [SerializeField] private Animator animator;
    [SerializeField] private Slider slider;

    public void Initiate(int attack, int armor, int block, int averageDmg, int health)
    {
        this.maxHealth = health;
        this.health = health;

        this.attack = attack;
        this.armor = armor;
        this.block = block;
        this.averageDmg = averageDmg;

        UpdateSlider();
        animator.SetTrigger("reset");
    }

    public void Attack(Character target)
    {
        int dmg = (int) (attack * (averageDmg + 100f) / 100f);
        target.TakeDamage(dmg);
        animator.SetTrigger("attack");
    }

    public void TakeDamage(int damage)
    {
        if (!RandomEvent(block))
        {
            health -= damage - armor;
            UpdateSlider();
            if (health <= 0) Die();
        }
    }

    public virtual void Die()
    {
        animator.SetTrigger("die");
    }

    private void UpdateSlider()
    {
        slider.value = (float) health / maxHealth;
    }

    private bool RandomEvent(int probability)
    {
        int rng = Random.Range(0, 100);
        return rng < probability;
    }
}
