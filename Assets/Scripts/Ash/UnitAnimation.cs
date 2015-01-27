using UnityEngine;
using System.Collections;

public class UnitAnimation : MonoBehaviour {
	Unit unit;
	public Animator animator;
	
	public void SetUnit(Unit unit)
	{
		this.unit = unit;
	}
	
	public void OnUpdate(float dt)
	{
		if (unit == null || this.animator == null)
			return;
		animator.SetBool("moving", this.unit.motor.moving);
	}
}
