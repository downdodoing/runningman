    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class masonryScript : MonoBehaviour {

    private int speed = 300;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, speed * Time.deltaTime));
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
    }

}
