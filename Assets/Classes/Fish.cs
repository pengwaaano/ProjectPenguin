using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour {

    public GameObject fish; //fishy
    public float spawnTime = 1f; //spawn time in seconds
    public Transform spawnPoint;
    public bool spawnOn = false;

	// Use this for initialization
	void Start () {

        InvokeRepeating("Fishy", spawnTime, spawnTime);
		
	}

    void Spawn ()
    {
        if (spawnOn)
        {
            Instantiate(fish, spawnPoint.position, spawnPoint.rotation);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
