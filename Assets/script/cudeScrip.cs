using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cudeScrip : MonoBehaviour {

    private int speed;
    public Animation mAnimation;
    private bool isRun = true;

    private int jumpSpeed = 200;

    private CharacterController controller;
    private float margin = 0.1f;
    private float gravity = 600;
    private Vector3 moveDirection = Vector3.zero;
    //用于判断是否正在跳跃
    private bool ground = true;

    private Vector3 startPosition = Vector3.zero;
    private Vector3 endPosition = Vector3.zero;

    // Use this for initialization
    void Start() {
        
        mAnimation = this.GetComponent<Animation>();
        controller = GetComponent<CharacterController>();
        
    }
   
    // Update is called once per frame
    void Update() {
        speed = GameObject.Find("GameObject").GetComponent<game>().codeSpeed;
        setListener();
        if (mAnimation["Run"].speed == 1)
        {
            mAnimation.Play("Run");
        }

        GameObject.Find("Camera").transform.rotation = transform.rotation;
        GameObject.Find("Camera").transform.position = new Vector3(0,8,transform.position.z - 50);
    }
    //设置按键监听
    private void setListener() {
        float x = this.transform.position.x;
        float z = this.transform.position.z;

        PCOperate(x,z);
        //AndroidOperate(x,z);
    }
    //pc端
    private void PCOperate(float x,float z) {
        // h>0按的右键，反之左键
        float h = Input.GetAxis("Horizontal");
       
        //用于判断人物最多左右滑动多少距离
        //if (!((h >= 0 || h < 0) && (x <= 5.5f && x >= -5.5f) || (x <= -5.5f && h > 0) || (x >= 5.5f && h < 0)))
        //{
        //    h = 0;
        //}
        //if (h < 0)
        //{
        //    moveDirection.x = -0.35f;
        //}
        //else {
        //    moveDirection.x = 0.35f;
        //}
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A))
        {
            translateCode(h, x, z);
        }
        //向前移动
        moveDirection = new Vector3(0, 0, 1);
        moveDirection *= speed;

        // 空格键控制跳跃  
        if (Input.GetKeyDown(KeyCode.Space) && ground)
        {
            ground = false;

            mAnimation["Run"].speed = 0;
            mAnimation.Play("Jump0" + Random.Range(1, 5));

            controller.Move(Vector3.up * jumpSpeed * Time.deltaTime);
        }

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.S))
        {
            mAnimation["Run"].speed = 0;
            mAnimation.Play("Down");

            controller.height = 0.67f;
            controller.radius = 0.19f;
            controller.center = new Vector3(0, 0.1f, 0);
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            controller.height = 1.49f;
            controller.radius = 0.31f;
            controller.center = new Vector3(0, 0.75f, 0);
        }

        if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.Space))
        {
            mAnimation["Run"].speed = 1;
        }
    }
    //Android端
    private void AndroidOperate(float x, float z) {
        int direction = judgeFingerDirection();
        
        if (direction == 1 || direction == -1)
        {
            translateCode(direction, x, z);
        }
        //向前移动
        moveDirection = new Vector3(0, 0, 1);
        moveDirection *= speed;

        // 空格键控制跳跃  
        if (direction == 2 && ground)
        {
            ground = false;

            mAnimation["Run"].speed = 0;
            mAnimation.Play("Jump0" + Random.Range(1, 5));

            controller.Move(Vector3.up * jumpSpeed * Time.deltaTime);
        }

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

        if (direction == -2)
        {
            mAnimation["Run"].speed = 0;
            mAnimation.Play("Down");

            controller.height = 0.67f;
            controller.radius = 0.19f;
            controller.center = new Vector3(0, 0.1f, 0);
        }

        if (Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            controller.height = 1.49f;
            controller.radius = 0.31f;
            controller.center = new Vector3(0, 0.75f, 0);

            //让人物重新附上奔跑的动画效果
            mAnimation["Run"].speed = 1;
        }
       
    }
    /**
     * 判断手势移动的方向
     * 返回值：
     * 1 --- 表示向右移动
     * -1 --- 表示向左移动
     * 2 ---- 表示向上移动
     * -2 --- 表示向下滑动
     * */
    public int judgeFingerDirection() {
        float xMoveIstance = 0;
        float yMoveInstance = 0;

        if (Input.GetTouch(0).phase == TouchPhase.Began) {
            startPosition = Input.GetTouch(0).position;
        }

        endPosition = Input.GetTouch(0).position;
        xMoveIstance = endPosition.x - startPosition.x;
        yMoveInstance = endPosition.y - startPosition.y;

        //用户可能上滑和下滑同时进行
        if (Mathf.Abs(xMoveIstance) > Mathf.Abs(yMoveInstance))
        {
            if (xMoveIstance > 0)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
        else {
            if (yMoveInstance > 0)
            {
                return 2;
            }
            else
            {
                return -2;
            }
        }
    }
    private void translateCode(float h,float x,float z) {
        if ((h < 0 && x >= -5.5f && x < 0) || (x == 0 && h < 0))
        {
            transform.position = new Vector3(-5.1f, 0, z);
        }
        else if ((h > 0 && x < 0) || (h < 0 && x > 0))
        {
            transform.position = new Vector3(0, 0, z);
        }
        else if ((x == 0 && h > 0) || h > 0 && x > 0 && x <= 5.5f)
        {
            transform.position = new Vector3(5.3f, 0, z);
        }
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        ground = true;
    }
}
