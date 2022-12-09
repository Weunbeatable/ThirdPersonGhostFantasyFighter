using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    bool isAlive;

    private int health;
    void Start()
    {
        isAlive = true;
        health = maxHealth;
    }

    public void DealDamage(int damageDealt)
    {
        //if (!isAlive) { return; }
        if(health <= 0) { return; }
        
        {
            health -= damageDealt;

            health = Mathf.Max(health - damageDealt, 0); // making sure our health doesn't go negative, if it does set it to 0 otherwise whatever your damage value wass
        }
    }
}
