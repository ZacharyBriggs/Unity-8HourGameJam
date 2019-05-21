using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PikminBehaviour : Unit
{
    public bool attacking;
    public EnemyBehaviour eb;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Enemy"))
        {
            this.moveSpeed = 0;
            eb = other.transform.GetComponent<EnemyBehaviour>();
            attacking = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == eb.gameObject)
        {
            this.moveSpeed = speed;
            attacking = false;
            eb = null;
            targetGO = null;
        }
    }
}
