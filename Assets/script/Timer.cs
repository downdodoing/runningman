using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

	bool _isTicking;//是否在计时中

	float _currentTime;//当前时间

	float _endTime;//结束时间

	public delegate void EventHander();

	public event EventHander tickEvent;

	public Timer(float second){
		_currentTime = 0;
		_endTime = second;
	}
		
	//开始计时
	public void StartTimer(){
		_isTicking = true;
	}

	//更新计时
	public void UpdateTimer(float deltaTime){
		if(_isTicking){
			_currentTime += deltaTime;

			if (_currentTime > _endTime) {
				_isTicking = false;
				tickEvent ();
			}
		}
	}

	//停止计时
	public void StopTimer(){
		_isTicking = false;
	}

	//继续计时
	public void ContinueTimer(){
		_isTicking = true;
	}

	//重新计时
	public void ReStartTimer(){
		_isTicking = true;
		_currentTime = 0;
	}

	//重置计时器
	public void ResetEndTimer(float second){
		_endTime = second;
	}
}
