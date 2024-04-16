using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth;

    public bool isDead { get; private set; }

    public Action<float> OnHealthUpdated;
    public Action OnDeath;

    private float health;

    void Start()
    {
        health = maxHealth;
        OnHealthUpdated(maxHealth);
    }

    public void DeductHealth(float value)
    {
        if (isDead) return;
        health -= value;
        if (health <= 0)
        {
            isDead = true;
            OnDeath();
            health = 0;
        }
        OnHealthUpdated(health);
    }
}