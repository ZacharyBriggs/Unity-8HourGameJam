using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnionBehaviour : MonoBehaviour
{
    public float HP;
    public GameObject pikmin;
    public GameObject spawnPos;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
	}

    public void SpawnPikmin()
    {
        Instantiate(pikmin,spawnPos.transform.position,Quaternion.identity);
    }
}
