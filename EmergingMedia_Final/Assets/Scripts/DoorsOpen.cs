using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoorsOpen : MonoBehaviour 
{
	[SerializeField]
	private bool rightDoor;

	public void OpenDoors()
	{
		if(rightDoor)
			transform.DOMoveZ(transform.position.z - 1.5f, 2f, false);
		else
			transform.DOMoveZ(transform.position.z + 1.5f, 2f, false);
	}

	public void CloseDoors()
	{
		if(rightDoor)
			transform.DOMoveZ(transform.position.z + 1.5f, 2f, false);
		else
			transform.DOMoveZ(transform.position.z - 1.5f, 2f, false);
	}
}
