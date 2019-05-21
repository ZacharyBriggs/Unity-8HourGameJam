using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour
{
    public float HP;
    public float Damage;
    public float attackSpeed;
    public float moveSpeed;
    protected float speed;
    public Vector3 target;
    public GameObject targetGO;
    public GameObject explosion;
    protected NavMeshAgent nav;
    [SerializeField]
    protected float timer;
    protected bool dying;
	// Use this for initialization
	void Start ()
    {
        nav = this.GetComponent<NavMeshAgent>();
        nav.speed = moveSpeed;
        speed = moveSpeed;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(dying)
        {
            Instantiate(explosion, this.transform);
        }
        Move();
        nav.speed = moveSpeed;
        if (HP <= 0)
        {
            Die();
        }
        timer -= Time.deltaTime;
    }

    protected void Move()
    {
        if(HP <= 0)
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
    }
    public void Attack(Unit target)
    {
            target.TakeDamage(Damage);
            timer = attackSpeed;
    }
    public void TakeDamage(float amount)
    {
        HP -= amount;
    }
    public void Die()
    {
        dying = true;
        Destroy(this.gameObject,2);
    }
    public void SetTarget(Vector3 pos)
    {
        target = pos;
    }
}
