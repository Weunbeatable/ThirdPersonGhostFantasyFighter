using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamage : MonoBehaviour
{
    [SerializeField] private Collider myCollider;
    private void OnTriggerEnter(Collider other)
    {
        if (other == myCollider) { return; }

        if (other.TryGetComponent<Health>(out Health health))// checking if other component has health component do damage
        {
            health.DealDamage(10);
        }
    }
}
