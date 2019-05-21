using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : Unit
{
    public GameObject playerBase;
    public bool attacking;
    public GameObject victoryText;
    void Start()
    {
        nav = this.GetComponent<NavMeshAgent>();
        nav.speed = moveSpeed;
        targetGO = playerBase;
    }

    private void Update()
    {
        if (dying)
        {
            
            var explo = Instantiate(explosion, this.transform);
            explo.GetComponent<Rigidbody>().AddExplosionForce(99,this.transform.position*2,99);

        }
        if (HP <= 0)
        {
            Die();
        }
        if (targetGO != null)
        {
            nav.destination = targetGO.transform.position;
            target = this.transform.position;
        }
        else
            nav.destination = target;
        nav.speed = moveSpeed;
        if (attacking && timer <= 0)
        {
            var pik = targetGO.GetComponent<Unit>();
            Attack(pik);
            if (pik.HP <= 0)
            {
                targetGO = playerBase;
                attacking = false;
                moveSpeed = 1;
            }
            timer = attackSpeed;
        }
        timer -= Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pikmin") && attacking == false)
        {
            this.moveSpeed = 0;
            targetGO = other.gameObject;
            attacking = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == targetGO.gameObject)
        {
            attacking = false;
            targetGO = playerBase;
        }
    }

    private void OnDestroy()
    {
        victoryText.SetActive(true);
    }
}
