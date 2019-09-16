using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class playerControl : MonoBehaviour {

    Rigidbody rbd;
    Camera cam;
    public int speedFactor = 40;
    public float fireDelay = 0.1f;
    public float delayBeforNextFire = 0;
    public GameObject bulletPrefab;

	// Use this for initialization
	void Start () {
        rbd = GetComponent<Rigidbody>();
        cam = FindObjectOfType<Camera>();
    }
	
	// Update is called once per frame
	void Update () {
        float inputAxisX = Input.GetAxis("Horizontal");
        float inputAxisY = Input.GetAxis("Vertical");

        Vector3 mouvement = new Vector3(inputAxisX, 0, inputAxisY);
        rbd.MovePosition(rbd.position + mouvement * speedFactor * Time.deltaTime);
        OrientatePlayer();
        processFire();
    }
    private void processFire()
    {
        delayBeforNextFire -= Time.deltaTime;
        if(Input.GetAxis("Fire1") != 0)
        {
            if(delayBeforNextFire <= 0)
            {
                ShootBullet();
                delayBeforNextFire = fireDelay;
            }
        }
    }

    private void ShootBullet()
    {
        GameObject bulletObject = Instantiate(bulletPrefab, transform.position + (transform.forward * 2), transform.rotation);
    }

    private Vector3 findPositionOfMouse()
    {
        Vector3 result = new Vector3();
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit, 1000))
        {
            result.x = hit.point.x;
            result.y = hit.point.y;
            result.z = hit.point.z;
        }
        return result;
    }
    private void OrientatePlayer()
    {
        Vector3 result = findPositionOfMouse();
        result.y = rbd.position.y;
        Vector3 relativePos = result - transform.position;
        Quaternion quanterUnionRotation = Quaternion.LookRotation(relativePos, Vector3.up);
        rbd.MoveRotation(quanterUnionRotation);
    }
}
