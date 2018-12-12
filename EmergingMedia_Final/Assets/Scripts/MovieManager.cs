using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.PostProcessing;

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

	[SerializeField]
	AudioSource openSFX;
	[SerializeField]
	AudioSource closeSFX;

	[SerializeField]
	AudioSource[] music;

	[SerializeField]
	PostProcessingBehaviour post;

	[SerializeField]
	GameObject song3;

    //Timer
    float timePassed;
    //Events
	//Round 1
    public bool firstDoorOpened = false;
	public bool firstTPOntoTrain = false;
    public bool firstDoorClosed = false;
	public bool firstTrainMove = false;
	public bool firstResetTrain = false;
	//Round 2
	public bool secondDoorOpen = false;
	public bool secondMovePeopleOn = false;
	public bool secondDoorClosed = false;
	public bool secondTrainMove = false;
	public bool secondResetTrain = false;
	//Round 3
	public bool thirdDoorOpen = false;
	public bool thirdMovePeopleOn = false;
	public bool thirdDoorClosed = false;
	public bool thirdTrainMove = false;
	public bool thirdResetTrain = false;
	//Round 4
	public bool fourthDoorOpen = false;

    void Start()
    {
        //Init timer
        timePassed = 0.0f;
        fader = fadePanel.GetComponent<Image>();
        fader.CrossFadeAlpha(0, 0, false);
		post.enabled = false;
		music[0].Play();
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
			music[1].Play();
			firstResetTrain = true;
		}

		if(timePassed > 35.0f && !secondDoorOpen)
		{
			OpenDoors();
			secondDoorOpen = true;
		}

		if(timePassed > 40.0f && !secondMovePeopleOn)
		{
			MovePeople();
			secondMovePeopleOn = true;
		}

		if(timePassed > 45.0f && !secondDoorClosed)
		{
			CloseDoors();
			secondDoorClosed = true;
		}

		if(timePassed > 50.0f && !secondTrainMove)
		{
			MoveTrain();
			secondTrainMove = true;
		}

		if(timePassed > 65.0f && !secondResetTrain)
		{
			ResetTrain();
			SpawnPeople2();
			Instantiate(song3);
			//music[2].Play();
			secondResetTrain = true;
		}

		if(timePassed > 70.0f && !thirdDoorOpen)
		{
			OpenDoors();
			thirdDoorOpen = true;
		}

		if(timePassed > 75.0f && !thirdMovePeopleOn)
		{
			MovePeople2();
			post.enabled = true;
			thirdMovePeopleOn = true;
		}

		if(timePassed > 80.0f && !thirdDoorClosed)
		{
			CloseDoors();
			thirdDoorClosed = true;
		}

		if(timePassed > 85.0f && !thirdTrainMove)
		{
			MoveTrain();
			thirdTrainMove = true;
		}

		if(timePassed > 110.0f && !thirdResetTrain)
		{
			ResetTrain();
			DespawnAllPeople();
			foreach(AudioSource asssss in music){
				asssss.Stop();
			}
			post.enabled = false;
			thirdResetTrain = true;
		}

		if(timePassed > 120.0f & !fourthDoorOpen)
		{
			OpenDoors();
			fourthDoorOpen = true;
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
		openSFX.Play();
        GetComponent<DoorHolder>().openDoors = true;
    }

    void CloseDoors()
    {
		closeSFX.Play();
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

	void MovePeople()
	{
		GetComponent<PeopleScript>().peopleOntoTrain = true;
	}

	void SpawnPeople2()
	{
		GetComponent<PeopleScript>().people2Activate = true;
	}

	void MovePeople2()
	{
		GetComponent<PeopleScript>().people2OntoTrain = true;
	}

	void DespawnAllPeople()
	{
		GetComponent<PeopleScript>().peopleDeactive = true;
	}
}
