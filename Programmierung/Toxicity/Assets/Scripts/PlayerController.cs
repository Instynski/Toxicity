﻿using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float movespeet;
    private Rigidbody myrigi;

    private Vector3 moveInput;
    private Vector3 movevelocity;

    private Camera mainCamera;

    public GunController theGun;

	// Use this for initialization
	void Start () {
        myrigi = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        movevelocity = moveInput * movespeet;

        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if(groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);

            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }

        if (Input.GetMouseButtonDown(0))
            theGun.isFiring = true;

        if (Input.GetMouseButtonUp(0))
            theGun.isFiring = false;

	}

    void FixedUpdate()
    {
        myrigi.velocity = movevelocity;
    }
}
