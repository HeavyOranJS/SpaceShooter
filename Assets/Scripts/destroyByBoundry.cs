using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyByBoundry : MonoBehaviour {

	void OnTriggerExit(Collider other)
	{
		Destroy(other.gameObject);
	}
}
