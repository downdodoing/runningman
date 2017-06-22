using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

	Timer timer;

	// Use this for initialization
	void Start () {
	
		timer = new Timer (10);
		timer.tickEvent += DeleteIt;
		timer.StartTimer ();
	}

	//设置时间到了之后执行该方法
	private void DeleteIt(){
		Destroy (this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Rotate(new Vector3(0,6,0));
		timer.UpdateTimer (Time.deltaTime);
	}


	void OnDestroy(){
		timer.tickEvent -= DeleteIt;
	}
}
