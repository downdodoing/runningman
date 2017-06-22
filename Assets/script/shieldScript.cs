using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldScript : MonoBehaviour {
    private int speed = 300;
    // Use this for initialization
    public GameObject hudun;
    public GameObject createHD;

    void Start()
    {
    }   

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, speed * Time.deltaTime, 0));
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
        //float newX = GameObject.Find("HB_boy10001").transform.position.x;
       // float newY = GameObject.Find("HB_boy10001").transform.position.y;
        //float newZ = GameObject.Find("HB_boy10001").transform.position.z;
        //createHD = Instantiate(hudun, new Vector3(newX, newY, newZ), Quaternion.identity) as GameObject;
        //createHD.transform.parent = GameObject.Find("HB_boy10001").transform;
        //createHD.transform.localPosition = hudun.transform.position;
        //createHD.transform.localRotation = hudun.transform.rotation;

    }
}
