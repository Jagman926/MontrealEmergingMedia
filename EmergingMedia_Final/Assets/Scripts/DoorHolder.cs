using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHolder : MonoBehaviour 
{
	[Header("Door Toggle")]
	public bool openDoors;
	public bool closeDoors;

	[SerializeField]
	private List<GameObject> doors;

	void Update ()
	{
		if(openDoors)
		{
        	OpenAllDoors();
			openDoors = false;
		}
		if(closeDoors)
		{
			CloseAllDoors();
			closeDoors = false;
		}
	}

	void OpenAllDoors()
	{
		for(int i = 0; i < doors.Count ; i++)
		{
			doors[i].GetComponent<DoorsOpen>().OpenDoors();
		}
	}

	void CloseAllDoors()
	{
		for(int i = 0; i < doors.Count ; i++)
		{
			doors[i].GetComponent<DoorsOpen>().CloseDoors();
		}
	}
}
