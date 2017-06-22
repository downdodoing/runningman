using System.Collections;
using UnityEngine;

public class game : MonoBehaviour {

    public GameObject road,roadAnother;

    public GameObject path1, path2, coin,wood, Pavilion, masonry,shield;
    public GameObject myPath1, myPath2,wood1, Pavilion1,Pavilion2, masonry1, shield1;

    public ArrayList coins = new ArrayList();

    public int pathNum = 0;
    public int pathlength = 500;
    public int roadX,roadX1;
    public ArrayList roadList = new ArrayList();

    public int codeSpeed = 80;
    //障碍物
    public GameObject bridge, box,secondBox;
    public GameObject bridge1, box1, secondBox1;


    //每个金币之间的间隔
    private int coinInterval = 10;

    // Use this for initializa,tion
    void Start () {
        myPath1 = Instantiate(path1,new Vector3(-25, 0, 0),Quaternion.identity);
    }

    public void generatRoad() {
        roadX = (int)((GameObject.Find("5S_09Road").GetComponent<MeshFilter>().mesh.bounds.size.x) * 2.3);
        roadX1 = (int)((GameObject.Find("5S_01lumianjiaqiao").GetComponent<MeshFilter>().mesh.bounds.size.x) * 2.3);
        int index = 1;
            
        for (int z = -30; z <= pathlength; index++)
        {
            GameObject road1;
            if (0 == index % Random.Range(7,10))
            {
                road1 = Instantiate(roadAnother, new Vector3(0, -1f, pathNum * pathlength + z + 5), Quaternion.identity) as GameObject;
                z += roadX1;
            }
            else
            {
                road1 = Instantiate(road, new Vector3(0, -0.7f, pathNum * pathlength + z), Quaternion.identity) as GameObject;
                z += roadX;
            }
             roadList.Add(road1);
        }
    }
    //生成其他物品
    public void generateObstacle() {
        //生成拱桥
        bridge1 = Instantiate(bridge, new Vector3(-0.6451613f, 0.6877375f, pathNum* pathlength + Random.Range(200, 280)), Quaternion.identity) as GameObject;
        //生成box
        box1 = Instantiate(box, new Vector3(0.7f, 0.3f, pathNum * pathlength + Random.Range(40, 100)), Quaternion.identity) as GameObject;
        //凉亭
        Pavilion1 = Instantiate(Pavilion, new Vector3(10, 0.3f, pathNum  * pathlength + Random.Range(300, 400)), Quaternion.identity) as GameObject;
        Pavilion2 = Instantiate(Pavilion, new Vector3(-10, 0.3f, pathNum  * pathlength + Random.Range(20, 60)), Quaternion.identity) as GameObject;
        //砖石
        masonry1 = Instantiate(masonry, new Vector3(0, 1.6f, pathNum  * pathlength + Random.Range(280, 400)), Quaternion.identity) as GameObject;

        genrateCoins();
        //生成木门
        wood1 = Instantiate(wood,new Vector3(-5f, 1, pathNum * pathlength + Random.Range(70, 200)), Quaternion.identity) as GameObject;
        //护盾
        shield1 = Instantiate(shield, new Vector3(0, 2f, pathNum * pathlength + Random.Range(10, 70)), Quaternion.identity) as GameObject;
    }
    //生成金币
    private void genrateCoins() {

        generateSimilarCoin(Random.Range(70, 150),5.2f);
        generateSimilarCoin(Random.Range(240, 280),-0.3f);
        
        int randomPosition = Random.Range(300, 400);
        //用于设置拱桥型的金币
        int y = 1;
        for (int i = 0; i < 10; i++)
        {
            if (i < 5)
            {
                y += 1;
            }
            else 
            {
                y -= 1  ;
            }
            GameObject coin1 = Instantiate(coin, new Vector3(-5.2f, y, pathNum* pathlength + randomPosition + i * coinInterval), Quaternion.identity);
            coins.Add(coin1);
        }
    }
    //生成相似的金币
    private void generateSimilarCoin(int randomPosition,float x) {
        for (int i = 0; i < 5; i++)
        {
            GameObject coin1 = Instantiate(coin, new Vector3(x, 2.7f, pathNum* pathlength + randomPosition + i * coinInterval), Quaternion.identity);
            coins.Add(coin1);
        }
    }
    //停止箱子向前移动
    public void stopCode() {
        codeSpeed = 0;
    }
    // Update is called once per frame
    void Update () {
        print(Input.touchCount);
    }
}
