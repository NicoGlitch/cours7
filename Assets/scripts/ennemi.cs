using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class Ennemi : MonoBehaviour, damagable {
    public int lifeTotal = 1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void TakeDamage(int damage)
    {
        lifeTotal -= damage;
        if(lifeTotal <= 0)
        {
            Die();
        }
    }
    public abstract void Die();
    protected void SetLife(int inLifeTotal)
    {
        lifeTotal = inLifeTotal;
    }
}
