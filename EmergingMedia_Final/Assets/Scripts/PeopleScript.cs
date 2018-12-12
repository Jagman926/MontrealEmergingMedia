using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleScript : MonoBehaviour
{
	[Header("People Active")]
	public bool peopleActive;
	public bool peopleDeactive;

	[Header("People Objects")]
    public List<GameObject> people;

    void Start()
    {
        DeactivatePeople();
    }

    void Update()
    {
		if(peopleActive)
		{
			SetActivePeople();
			peopleActive = false;
		}
		if(peopleDeactive)
		{
			DeactivatePeople();
			peopleDeactive = false;
		}
    }

    void DeactivatePeople()
    {
        for (int i = 0; i < people.Count; i++)
        {
            people[i].SetActive(false);
        }
    }

    void SetActivePeople()
    {
        for (int i = 0; i < people.Count; i++)
        {
            people[i].SetActive(true);
        }
    }
}
