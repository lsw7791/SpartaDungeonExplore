using System;
using UnityEngine;

public interface IDamagable
{
    void TakePhysicalDamage(int damageAmount);
}

public class PlayerCondition : MonoBehaviour, IDamagable
{
    public UICondition uiCondition;
    public int heal;
    public float healRange;
    [SerializeField]private float healTimer;
    [SerializeField]private float healInterval;
    [SerializeField] private float staminaDrainRate;


    Condition health { get { return uiCondition.health; } }
    Condition stamina { get { return uiCondition.stamina; } }

    public event Action onTakeDamage;

    private void Update()
    {
        health.Subtract(health.passiveValue * Time.deltaTime);
        stamina.Add(stamina.passiveValue * Time.deltaTime);

        healTimer += Time.deltaTime;

        if (healTimer >= healInterval)
        {
            HealIfNearCampfire();
            healTimer = 0f;
        }

        if (health.curValue <= 0.0f)
        {
            Die();
        }
    }

    public void ReduceStaminaWhileRunning()
    {
        stamina.Subtract(staminaDrainRate * Time.deltaTime);
    }

    void HealIfNearCampfire()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, healRange);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Campfire"))
            {
                EatMeats(heal);
                break; 
            }
        }
    }

    public void EatMeats(float amount)
    {
        health.Add(amount);
    }

    public void EatFruits(float amount)
    {
        stamina.Add(amount);
    }

    public void Die()
    {
        Debug.Log("플레이어가 죽었다.");
    }

    public void TakePhysicalDamage(int damageAmount)
    {
        health.Subtract(damageAmount);
        onTakeDamage?.Invoke();
    }
}