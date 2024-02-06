using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillar : MonoBehaviour, IDamageAble
{
    [SerializeField] float maxHealth;
    private float health;
    Vector2 startPos;
    EnemyHealthBar healthBar;
    void Start()
    {
        health = maxHealth;
        startPos = transform.position;
        healthBar = GetComponentInChildren<EnemyHealthBar>();
        healthBar.OnInit(transform);
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
   

    public void TakeDamage(float damage)
    {
        if (health > 0)
        {
            health -= damage;
            healthBar.UpdateHealthBar(health, maxHealth);
        }
    }

    public void TakeDamage(float damage, float knockBackForce, Vector2 knockBackAngle)
    {
        if (health > 0)
        {
            health -= damage;
            healthBar.UpdateHealthBar(health, maxHealth);

        }
    }
}
