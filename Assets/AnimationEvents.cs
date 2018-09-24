using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
	public bool animationInProgress = false;
	public bool navBarOpen = false;

	public void setAnimationInProgressTrue()
	{
		animationInProgress = true;
	}
	
	public void setAnimationInProgressFalse()
	{
		animationInProgress = false;
	}
	
	public void setNavBarOpen()
	{
		navBarOpen = true;
	}
	
	public void setNavBarClosed()
	{
		navBarOpen = false;
	}
}
