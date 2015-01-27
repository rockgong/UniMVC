using UnityEngine;
using System.Collections;

public class UnitMotor : MonoBehaviour {
	Transform cachedTransform;
	Unit unit;
	
	void Awake()
	{
		cachedTransform = this.transform;
	}
	
	public void SetUnit(Unit unit)
	{
		this.unit = unit;
	}
	
	public void OnUpdate(float dt)
	{
		unit.transform.position = NewPosition(dt);
		unit.transform.rotation = NewRotation(dt);
	}
	
	protected virtual Vector3 NewPosition(float dt)
	{
		return cachedTransform.position;
	}
	
	protected virtual Quaternion NewRotation(float dt)
	{
		return cachedTransform.rotation;
	}
}
