﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : CharaController
{

    public float WalkSpeed;
    public float ChangeForwardTime;
    EnemyController()
    {
        HP = 3;
        Attack = 1;
        WalkSpeed = 0.01f;
        ChangeForwardTime = 3.0f;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("RandomWalk");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * WalkSpeed;
        if ( HP == 0)
        {
            Destroy(this.gameObject);
        }
            
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "enemy")
            damageHP(1);
    }

    IEnumerator RandomWalk()
    {
        while (true)
        {
            transform.forward = new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(-1.0f, 1.0f)).normalized;
            yield return new WaitForSeconds(ChangeForwardTime);
        }
    }
}
