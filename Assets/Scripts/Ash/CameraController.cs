using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	public GameObject targetObject;
	public Vector3 offset;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (targetObject != null)
		{
			this.transform.position = targetObject.transform.position + offset;
			this.transform.LookAt(targetObject.transform.position);
		}
	}
	
	public void SetTargetObject(GameObject obj)
	{
		targetObject = obj;
	}
}
