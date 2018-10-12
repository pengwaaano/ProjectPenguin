using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFish : MonoBehaviour {


	// Use this for initialization
	void Start () {

        Destroy(this.gameObject, 5.0f);
		
	}
	
	// Update is called once per frame
	void Update () {


        transform.position = new Vector3(this.transform.position.x + 1.0f, this.transform.position.y);
		
	}
}
