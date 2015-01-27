using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {
	public int unitID;
	public UnitMotorTarget motor;
	public UnitAnimation anim;
	
	void Awake()
	{
		motor = GetComponent<UnitMotorTarget>();
		if (motor != null)
			motor.SetUnit(this);
			
		anim = GetComponent<UnitAnimation>();
		if (anim != null)
			anim.SetUnit(this);
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (motor != null)
			motor.OnUpdate(Time.deltaTime);
		if (anim != null)
			anim.OnUpdate(Time.deltaTime);
	}
	
	void OnGUI()
	{
		Camera main = Camera.main;
		Vector3 screenPoint = main.ViewportToScreenPoint(transform.position);
		GUILayout.Label(screenPoint.ToString());
		Rect rect = new Rect(screenPoint.x, screenPoint.y, 100, 20);
		GUI.Label(rect, unitID.ToString());
	}
	
	public void SetTarget(Vector3 target)
	{
		if (motor != null)
		{
			motor.target = target;
		}
	}
	
	public void SetSpeed(float speed)
	{
		if (motor != null)
		{
			motor.speed = speed;
		}
	}
}
