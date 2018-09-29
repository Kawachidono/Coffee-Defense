using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

    public Transform target;
    public float range = 15f;

    public string enemyTag = "Enemy";

    public Transform gun;
    public GameObject bulletPref;
    public Transform bulletSpawn;

    public float turnSpeed = 10f;

    public float fireRate = 1f;
    private float fireCountdown = 0f;

	// Use this for initialization
	void Start ()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);	
	}

    void UpdateTarget ()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        float closestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < closestDistance)
            {
                closestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && closestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (target == null)
            return;

        //
        Vector3 direction = target.position - transform.position;
        Quaternion look = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp(gun.rotation, look, Time.deltaTime * turnSpeed).eulerAngles;
        gun.rotation = Quaternion.Euler(0f, rotation.y, 0f);
		
        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
	}

    void Shoot ()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPref, bulletSpawn.position, bulletSpawn.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
            bullet.FindEnemy(target);

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
