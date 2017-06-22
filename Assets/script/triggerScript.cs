
using UnityEngine;
using System.Collections;

public class triggerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {
       
    }
    private void OnTriggerEnter(Collider other)
    {
        game terrain = GameObject.Find("GameObject").GetComponent<game>();
        int num = terrain.pathNum;
        int pathLength = terrain.pathlength;

        GameObject path1 = terrain.path1;
        GameObject path2 = terrain.path2;

        destroyForward();

        if (1 == num % 2)
        {
            terrain.myPath2 = Instantiate(path2, new Vector3(-25, 0, num * pathLength), Quaternion.identity);
        }
        else
        {
            terrain.myPath1 = Instantiate(path1, new Vector3(-25, 0, num * pathLength), Quaternion.identity);
        }

        //terrain.generateObstacle();
        //terrain.generatRoad();  
    }
   
    //销毁上一个路段的物品
    void destroyForward() {

        game rigidbody = GameObject.Find("GameObject").GetComponent<game>();
        
        Destroy(rigidbody.box1);
        Destroy(rigidbody.bridge1);
        Destroy(rigidbody.wood1);

        Destroy(rigidbody.Pavilion1);
        Destroy(rigidbody.Pavilion2);

        Destroy(rigidbody.shield1);

        Destroy(rigidbody.masonry1);
        int i = 0;
        foreach (GameObject road in rigidbody.roadList)
        {
            if (i < rigidbody.roadList.Count - 2) {
                Destroy(road.gameObject);
            }
            i++;
        }
        rigidbody.roadList.Clear();

        foreach (GameObject coin in rigidbody.coins)
        {
            Destroy(coin.gameObject);
        }
        rigidbody.coins.Clear();
    }
    private void OnTriggerExit(Collider other)
    {
        game terrain = GameObject.Find("GameObject").GetComponent<game>();
        int num = terrain.pathNum;
        
        if (0 == num % 2)
        {
            Destroy(terrain.myPath1.gameObject);   
        }
        else
        {
            Destroy(terrain.myPath2.gameObject); 
        }
    }
}
