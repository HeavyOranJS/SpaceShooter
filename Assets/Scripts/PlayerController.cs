using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {
	public float speed = 0.0f;
	public float tilt = 0.0f;

	public Boundary boundary;

	public GameObject shot;
	public Transform shotSwapn;
	public float fireRate;
	private float nextFire;
	void Update(){
		if (Time.time > nextFire) 
		// if (Input.GetButton("Fire1") && Time.time > nextFire) 
        {
            nextFire = Time.time + fireRate;
			Instantiate(shot, shotSwapn.position, shotSwapn.rotation);
        }
		//Instantiate(shot, shotSwapn.position, shotSwapn.rotation);
	}

    void FixedUpdate ()
    {
        float moveHorizontal, moveVertical;

		if (Application.isMobilePlatform)
        {
            moveHorizontal = Input.acceleration.x;
            moveVertical = Input.acceleration.y;
        }
        else
        {
            moveHorizontal = Input.GetAxis("Horizontal");
            moveVertical = Input.GetAxis("Vertical");
        }

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		var myRigidbody = GetComponent<Rigidbody>();
		myRigidbody.velocity = movement * speed;

		myRigidbody.position = new Vector3(
			Mathf.Clamp(myRigidbody.position.x, boundary.xMin, boundary.xMax), 
			0.0f, 
			Mathf.Clamp(myRigidbody.position.z, boundary.zMin, boundary.zMax));

		myRigidbody.rotation = Quaternion.Euler(0.0f, 0.0f ,myRigidbody.velocity.x * -tilt);
	}
}
