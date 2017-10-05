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

	private Vector2 touchOrigin = -Vector2.one;//initialize as offscreen

	AudioSource myAudio = new AudioSource();

	void Start(){
		myAudio = GetComponent<AudioSource>();
	}

	void Update(){
		if (Time.time > nextFire) 
		// if (Input.GetButton("Fire1") && Time.time > nextFire) 
        {
            nextFire = Time.time + fireRate;
			Instantiate(shot, shotSwapn.position, shotSwapn.rotation);
			myAudio.Play ();
        }
		//Instantiate(shot, shotSwapn.position, shotSwapn.rotation);
	}

    void FixedUpdate ()
    {
		var myRigidbody = GetComponent<Rigidbody>();
        float moveHorizontal = 0, moveVertical = 0;
		Vector3  movement = new Vector3();

		// if (Application.isMobilePlatform)
        // {
			// speed = 1;
            // moveHorizontal = Input.acceleration.x;
            // moveVertical = Input.acceleration.y;
			Vector3 myPosition = transform.position;//if nothing happend we still must give some values to  moveH and moveV
			
					// moveHorizontal = bar.x;
					// moveVertical = bar.y;
			// float deltaX = 0, deltaY = 0;
			if (Input.touchCount > 0){//check if there was a touch
				Touch myTouch = Input.touches[0];
				if(myTouch.phase == TouchPhase.Began){
					touchOrigin = myTouch.position;
					Debug.Log("touchOrigin = " + touchOrigin);
					// deltaX = myPosition.x - touchOrigin.x;
					// deltaY = myPosition.z - touchOrigin.y;
				}
				else if(myTouch.phase == TouchPhase.Ended && touchOrigin.x >= 0){//if we got a finished touch
					Vector2 touchEnd = myTouch.position;
					Debug.Log("touchEnd = " + touchEnd);
					float x = (touchEnd.x - touchOrigin.x) / (Screen.width / 14);//shity scaling
					float y = (touchEnd.y - touchOrigin.y) / (Screen.height / 18);

					// ZOMG
					// touch in pixels
					// camera in world WorldPoints
					// END ZOMG
					// movement = Camera.main.ScreenToWorldPoint(new Vector3(x,y, 5));
					movement = new Vector3(x, 0.0f,y);
					Debug.Log("movement = " + movement);
					// transform.localScale = Vector3.Scale(transform.localScale, new Vector3(Screen.width / 600, 1.0f, Screen.height / 900));
					touchOrigin.x = -1;		
					
					// var myRigidbody = GetComponent<Rigidbody>();
					// myRigidbody.position = new Vector3(
					// Mathf.Clamp(deltaX + touchEnd.x, boundary.xMin, boundary.xMax), 
					// 0.0f, 
					// Mathf.Clamp(deltaY + touchEnd.y, boundary.zMin, boundary.zMax));
					
					}
			}
        // }
        // else
        // {
        //     moveHorizontal = Input.GetAxis("Horizontal");
        //     moveVertical = Input.GetAxis("Vertical");
		// 	movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
        // }
		
		// var myRigidbody = GetComponent<Rigidbody>();
		// myRigidbody.velocity = movement * speed;

		myRigidbody.position = new Vector3(
			Mathf.Clamp(myRigidbody.position.x + movement.x, boundary.xMin, boundary.xMax), 
			0.0f, 
			Mathf.Clamp(myRigidbody.position.z + movement.z, boundary.zMin, boundary.zMax));
		// Debug.Log("position = " + myRigidbody.position);


		myRigidbody.rotation = Quaternion.Euler(0.0f, 0.0f ,myRigidbody.velocity.x * -tilt);
	}
}
