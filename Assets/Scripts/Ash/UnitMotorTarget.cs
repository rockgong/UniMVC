using UnityEngine;
using System.Collections;

public class UnitMotorTarget : UnitMotor {
	public float speed;
	public Vector3 target;
	public bool moving;

	protected override Vector3 NewPosition (float dt)
	{
		Vector3 deltaPos = target - this.transform.position;
		if (deltaPos == Vector3.zero)
		{
			moving = false;
			return transform.position;
		}
		else
			moving = true;
		deltaPos = deltaPos.normalized * speed * dt;
		Vector3 aPos = this.transform.position + deltaPos;
		Vector3 bPos = this.transform.position - deltaPos;
		Vector3 minPos = new Vector3(Mathf.Min(aPos.x, bPos.x), Mathf.Min(aPos.y, bPos.y), Mathf.Min (aPos.z, bPos.z));
		Vector3 maxPos = new Vector3(Mathf.Max(aPos.x, bPos.x), Mathf.Max(aPos.y, bPos.y), Mathf.Max (aPos.z, bPos.z));
		Vector3 ret = new Vector3(Mathf.Clamp(target.x, minPos.x, maxPos.x), Mathf.Clamp(target.y, minPos.y, maxPos.y), Mathf.Clamp (target.z, minPos.z, maxPos.z));
		return ret;
	}
	
	protected override Quaternion NewRotation (float dt)
	{
		this.transform.LookAt(target);
		return this.transform.rotation;
	}
}
