using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDecayScript : MonoBehaviour
{
    float spawnTime;
    public float lifeTime;

	void Start ()
    {
        spawnTime = Time.time;
	}
	
	void Update ()
    {
        if (Time.time > spawnTime + lifeTime)
        {
            Destroy(this.gameObject);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.CompareTag("Boulder") && collision.gameObject.CompareTag("Ground"))
        {
            this.gameObject.GetComponent<DeathBoxScript>().isEnabled = false;
        }
    }
}
