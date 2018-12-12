using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveMetro : MonoBehaviour {

	[Header("Metro Movement")]
	public bool moveMetroIntoTunnel;
	public bool resetMetro;

	[Header("Metro Object")]
	[SerializeField]
	private GameObject metroTrain;
	
	// Update is called once per frame
	void Update () 
	{
		if(moveMetroIntoTunnel)
		{
			MoveMetroIntoTunnel();
			moveMetroIntoTunnel = false;
		}	
		if(resetMetro)
		{
			ResetMetro();
			resetMetro = false;
		}
	}

	private void MoveMetroIntoTunnel()
	{
		metroTrain.transform.DOMoveZ(transform.position.z - 200.0f, 10.0f, false);
	}

	private void ResetMetro()
	{
		metroTrain.transform.position = Vector3.zero;
	}
}
