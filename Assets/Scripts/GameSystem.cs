using UnityEngine;
using System.Collections;

public class GameMsg
{
	public static int seqCnt = 0;
	public int seq;
	public GameMsg()
	{
		seq = seqCnt++;
	}
	
	public object arguement;
}

public class GameSystem {
	public GameSystem parentSystem = null;
	
	public void Send(GameMsg msg)
	{
		if (parentSystem != null)
			parentSystem.Receive(msg);
	}
	
	public virtual void Receive(GameMsg msg)
	{
		
	}
}
