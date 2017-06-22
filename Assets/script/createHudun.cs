using UnityEngine;
using System.Collections;

public class createHudun : MonoBehaviour {

	public GameObject hudun;

	public GameObject createHD;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider o){
		Destroy (this.gameObject);
		float newX = GameObject.Find ("person").transform.position.x;
		float newY = GameObject.Find ("person").transform.position.y;
		float newZ = GameObject.Find ("person").transform.position.z;
		print (GameObject.Find ("person").transform.position.x);
		print (GameObject.Find ("person").transform.position.y);
		print (GameObject.Find ("person").transform.position.z);
		createHD = Instantiate (hudun, new Vector3 (newX, newY, newZ), Quaternion.identity) as GameObject;
		createHD.transform.parent = GameObject.Find ("person").transform;
		createHD.transform.localPosition = hudun.transform.position;
		createHD.transform.localRotation = hudun.transform.rotation;
	}

}
