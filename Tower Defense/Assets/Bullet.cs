using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour {

    private Transform target;
    public float speed = 25f;
    public void FindEnemy (Transform _target)

    {
        target = _target;
    }

	
	// Update is called once per frame
	void Update ()
    {

	if (target == null)
        { Destroy(gameObject);
            return;
         }
        Vector3 direction = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (direction.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(direction.normalized * distanceThisFrame, Space.World);

	}

    void HitTarget ()
    {
        Destroy(target.gameObject);
        Destroy(gameObject);
    }
}
