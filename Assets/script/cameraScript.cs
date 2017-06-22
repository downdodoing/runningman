
using UnityEngine;

public class cameraScript : MonoBehaviour {
    public Vector3 offset;
    private Transform playerBip;
    public float smoothing = 1;

    // Use this for initialization
    void Start()
    {
        playerBip = GameObject.Find("GameObject").transform.Find("HB_boy10001");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //transform.position = playerBip.position + offset;
        Vector3 targetPos = playerBip.position;
        transform.position = Vector3.Lerp(transform.position, targetPos, smoothing * Time.deltaTime);
    }
}
