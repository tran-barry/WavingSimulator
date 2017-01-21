using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonController : MonoBehaviour
{
    public List<PersonInfo> Persons;
	int ID;

    // Use this for initialization
    void Start()
    {
		ID = (int)(Random.value * Persons.Count);
		GetComponent<Renderer>().material = Persons[ID].Material;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
