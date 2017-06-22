using System.Collections;
using UnityEngine;

public class terrainScript : MonoBehaviour {

    public GameObject[] treeArray;
    private GameObject tree_l,tree_r;
    private ArrayList treelist = new ArrayList();

    public GameObject[] stoneArray;
    private GameObject stone_l, stone_r;
    private ArrayList stoneList = new ArrayList();

    // Use this for initialization
    void Start() {
        game terrain = GameObject.Find("GameObject").GetComponent<game>();
        int pathNum = terrain.pathNum;
        int pathLength = terrain.pathlength;
 
        for (int z = 5; z < 500; z += Random.Range(20, 40))
        {
            tree_l = Instantiate(treeArray[Random.Range(0, 3)], new Vector3(13, 0, pathLength * pathNum + z), Quaternion.identity) as GameObject;
            tree_r = Instantiate(treeArray[Random.Range(0, 3)], new Vector3(-13, 0, pathLength * pathNum+ z), Quaternion.identity) as GameObject;

            treelist.Add(tree_l);
            treelist.Add(tree_r);
            
        }
        //生成石头
        for (int z = 5; z < 500; z += Random.Range(10, 30))
        {
            stone_l = Instantiate(stoneArray[Random.Range(0, 5)], new Vector3(15, -1, pathLength * pathNum + z), Quaternion.identity) as GameObject;
            stone_r = Instantiate(stoneArray[Random.Range(0, 5)], new Vector3(-15, -1, pathLength * pathNum + z), Quaternion.identity) as GameObject;
            
            stoneList.Add(stone_r);
            stoneList.Add(stone_l);
        }
      
        terrain.generatRoad();
        terrain.generateObstacle();
        terrain.pathNum++;
    }
    // Update is called once per frame
    void Update () {
		
	}

    private void OnDestroy()
    {
        game rigidbody = GameObject.Find("GameObject").GetComponent<game>();


        foreach (GameObject tree in treelist)
        {
            Destroy(tree.gameObject);
        }

        foreach (GameObject stone in stoneList)
        {
            Destroy(stone.gameObject);

        }

        stoneList.Clear();
        treelist.Clear();
    }
}
