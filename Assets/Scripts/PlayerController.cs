using UnityEngine;
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

        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                GetComponent<NavMeshAgent>().SetDestination(hitInfo.point);
            }
        }
    }
}

