using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFish : MonoBehaviour {

    public GameObject fish; //fishy
    public float spawnTime = 1f; //spawn time in seconds
    public Transform spawnPoint;
    public bool isSpawning = false;
    public bool shouldSpawn = true; //Should always be set to True after user has one working penguin

    public GameObject parentObject;

    // Use this for initialization
    void Start () {

    }

    IEnumerator Spawn (float seconds)
    {
        yield return new WaitForSeconds(seconds);

        GameObject Fishy = Instantiate(fish, spawnPoint.transform.position, spawnPoint.transform.rotation);

        Fishy.transform.parent = parentObject.transform;

        isSpawning = false;
    }
    
    // Update is called once per frame
    void Update () {

        if(!isSpawning && shouldSpawn == true)
        {
            isSpawning = true;
            StartCoroutine(Spawn(2.0f));
        }
    }
}
