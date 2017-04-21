using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {

    private Transform lookAT;
    private Vector3 startOffset;

	void Start ()
    {
        lookAT = GameObject.FindGameObjectWithTag("Player").transform;
        startOffset = transform.position - lookAT.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = lookAT.position + startOffset;
	}
}
