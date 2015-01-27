using UnityEngine;
using System.Collections;

public class DummySystem : GameSystem {
	public override void Receive(GameMsg msg)
	{
		Debug.Log(string.Format("msg : {0} : {1}", msg.seq.ToString(), msg.arguement.ToString()));
	}
}
