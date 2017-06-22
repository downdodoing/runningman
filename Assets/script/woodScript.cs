using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class woodScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        //print("wood");
        //GameObject.Find("HB_boy10001").GetComponent<cudeScrip>().mAnimation.Play("Down");
        Time.timeScale = 0;
    }
    
}
