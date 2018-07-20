﻿using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    private AbilityHandler abilityHandler = new AbilityHandler();

	private void Start()
	{
        abilityHandler.QueueAbilities();
	}

	private void Update()

    {
        if( Input.GetKeyDown( KeyCode.A ) ) {
            abilityHandler.CastAbility();
        }



        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                GetComponent<NavMeshAgent>().destination = hit.point;
            }
        }

    }


}

