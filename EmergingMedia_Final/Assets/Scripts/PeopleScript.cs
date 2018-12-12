using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleScript : MonoBehaviour
{
    [Header("People Active")]
    public bool peopleActive;
    public bool peopleDeactive;
    public bool peopleOntoTrain;
	public bool people2Activate;
	public bool people2OntoTrain;

    [Header("People Objects")]
    public List<GameObject> people;
    public List<GameObject> people2;
    [SerializeField]
    private GameObject peopleSwarm;
    [SerializeField]
    private GameObject peopleSwarm2;

    void Start()
    {
        DeactivatePeople();
    }

    void Update()
    {
        if (peopleActive)
        {
            SetActivePeople();
            peopleActive = false;
        }
        if (peopleDeactive)
        {
            DeactivatePeople();
            peopleDeactive = false;
        }
        if (peopleOntoTrain)
        {
            PeopleOntoTrain();
            peopleOntoTrain = false;
        }
		if(people2Activate)
		{
			SetActivePeople2();
			people2Activate = false;
		}
		if(people2OntoTrain)
		{
			People2OntoTrain();
			people2OntoTrain = false;
		}
    }

    void DeactivatePeople()
    {
        for (int i = 0; i < people.Count; i++)
        {
            people[i].SetActive(false);
            people2[i].SetActive(false);
        }
    }

    void SetActivePeople()
    {
        for (int i = 0; i < people.Count; i++)
        {
            people[i].SetActive(true);
        }
    }

    void SetActivePeople2()
    {
        for (int i = 0; i < people.Count; i++)
        {
            people2[i].SetActive(true);
        }
    }

    void PeopleOntoTrain()
    {
        peopleSwarm.transform.position = new Vector3(10, 0, 0);
        peopleSwarm.transform.parent = GameObject.Find("Metro").transform;
    }

	void People2OntoTrain()
	{
		peopleSwarm2.transform.position = new Vector3(10, 0, 0);
        peopleSwarm2.transform.parent = GameObject.Find("Metro").transform;
	}
}
