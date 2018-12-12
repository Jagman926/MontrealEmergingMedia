using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovieManager : MonoBehaviour
{
    [Header("TP")]
    [SerializeField]
    private float TPdelay;
    [SerializeField]
    private GameObject fadePanel;
    private Image fader;
	[SerializeField]
	private GameObject player;

    //Timer
    float timePassed;
    //Events
    public bool firstDoorOpened = false;
	public bool firstTPOntoTrain = false;
    public bool firstDoorClosed = false;
	public bool firstTrainMove = false;
	public bool firstResetTrain = false;

    void Start()
    {
        //Init timer
        timePassed = 0.0f;
        fader = fadePanel.GetComponent<Image>();
        fader.CrossFadeAlpha(0, 0, false);
    }

    void Update()
    {
        //Update timer
        timePassed += Time.deltaTime;

        //Events by time increment
        if (timePassed > 5.0f && !firstDoorOpened)
        {
            OpenDoors();
            firstDoorOpened = true;
        }

		if(timePassed > 7.0f && !firstTPOntoTrain)
		{
			Teleport(player, new Vector3(26,3,-64));
			player.transform.parent = GameObject.Find("Metro").transform;
			firstTPOntoTrain = true;
		}

        if (timePassed > 13.0f && !firstDoorClosed)
        {
            CloseDoors();
            firstDoorClosed = true;
        }

		if(timePassed > 16.0f && !firstTrainMove)
		{
			MoveTrain();
			firstTrainMove = true;
		}

		if(timePassed > 30.0f && !firstResetTrain)
		{
			ResetTrain();
			SpawnPeople();
			firstResetTrain = true;
		}
    }

    void Teleport(GameObject move, Vector3 dest)
    {
        StartCoroutine(TPWithFAde(move, dest));
    }

    private IEnumerator TPWithFAde(GameObject move, Vector3 dest)
    {
        fader.CrossFadeAlpha(1, TPdelay, false);
        yield return new WaitForSeconds(TPdelay);
        move.transform.position = dest;
        fader.CrossFadeAlpha(0, TPdelay, false);
    }

    void OpenDoors()
    {
        GetComponent<DoorHolder>().openDoors = true;
    }

    void CloseDoors()
    {
        GetComponent<DoorHolder>().closeDoors = true;
    }

	void MoveTrain()
	{
		GetComponent<MoveMetro>().moveMetroIntoTunnel = true;
	}

	void ResetTrain()
	{
		GetComponent<MoveMetro>().resetMetro = true;
	}

	void SpawnPeople()
	{
		GetComponent<PeopleScript>().peopleActive = true;
	}
}
