using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour {
    Rigidbody rbd;
    public int lifeSpan = 3;
    public int bulletSpeed = 1;
    public int bullentDamage=1;
    private float timeleftTolive;

	// Use this for initialization
	void Start () {
        rbd = GetComponent<Rigidbody>();
        timeleftTolive = lifeSpan;
	}
	
	// Update is called once per frame
	void Update () {
        rbd.MovePosition(rbd.position + transform.forward * bulletSpeed * Time.deltaTime);
        AppyLifeSpan();

    }
    private void AppyLifeSpan()
    {
        timeleftTolive -= Time.deltaTime;
        if(timeleftTolive < 0)
        {
            Die();
        }
    }
    private void Die()
    {
        Destroy(gameObject);
    }
    public void onTriggerEnter(Collider otherObject)
    {
        damagable damagable = otherObject.GetComponentInParent<damagable>();
        if(damagable != null)
        {
            damagable.TakeDamage(bullentDamage);
        }
        Die();
    }
}
