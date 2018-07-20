using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    private AbilityHandler abilityHandler = new AbilityHandler();

	private void Start()
	{
        
	}

	private void Update()

    {
        abilityHandler.QueueAbilities();

        if( GetComponent<Rigidbody>().position == GetComponent<NavMeshAgent>().destination ) {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }
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

	private void FixedUpdate()
	{
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
	}


}

