using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] float range;
    [SerializeField] float nextFire;
    [SerializeField] Camera camera;
    private float fireRate;
    private Enemy enemy;
    void Update()
    {
        //From a Unity tutorial, this statement makes sure the player cannot "spam" the fire button, but has a small cooldown before shooting again.
        if(Input.GetButtonDown("Fire1" ) && Time.time > fireRate)
        {
            fireRate = Time.time + nextFire;
            Shoot();
        }      
    }

    void Shoot()
    {
        RaycastHit hit;

        //If the player Shoots, we want to send a Raycast FROM the camera, we want the line to go FORWARD and we want to see if the target is in RANGE. 
        //"Out" means the information will be stored in the "hit" variable
        if(Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, range))
        {        
            //If the gameobject that we hit is called "Enemy", then we fetch it's "Enemy" script and activate the "isHit" function
            if(hit.transform.name == "Enemy")
            {
                enemy = hit.transform.GetComponent<Enemy>();
                enemy.isHit();
            }
        }
    }
}
