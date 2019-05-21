using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePikminBehaviour : PikminBehaviour
{	
	// Update is called once per frame
	void Update ()
    {
        if (dying)
            Instantiate(explosion, this.transform);
        Move();
        nav.speed = moveSpeed;
        if (HP <= 0)
        {
            Die();
        }
        timer -= Time.deltaTime;
        if (attacking && timer <= 0)
        {
            GetComponent<Animator>().SetTrigger("AttackTrigger");
            Attack(eb);
            if(eb.HP <= 0)
            {
                targetGO = null;
                attacking = false;
            }
        }
	}
}
