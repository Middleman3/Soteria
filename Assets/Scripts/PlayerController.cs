using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    AbilityQueue abilities = new AbilityQueue();

    private void Update()
    {
        CastAbility(abilities.dequeue()); //for development purposes only

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

    void queueAbilities() { //for development purposes only
        abilities.enqueue(new Ability("Ability1"));
        abilities.enqueue(new Ability("Ability2"));
        abilities.enqueue(new Ability("Ability3"));
        Debug.Log("Abilities successfully queued");
    }
    void CastAbility( Ability ability ) { //to be changed when abilities are made
        if( ability == null ) {
            return;
        }

        Debug.Log(ability.GetName() + "successfully casted.");
    }
}

public class Ability {
    private string name;

    public Ability( string _name ) {
        name = _name;
    }
    public string GetName() {
        return name;
    }
}

public class AbilityQueue {
    private Ability[] abilities = new Ability[5];

    public void enqueue( Ability ability ) {
        
            for (int i = 0; i < abilities.Length; i++)
            {
                if (abilities[i] != null)
                {
                    abilities[i] = ability;
                    break;
                }

            }
        //else
        //{
        //    Ability[] newQueue = new Ability[abilities.Length + 1];
        //    for (int i = 0; i < abilities.Length; i++)
        //    {
        //        newQueue[i] = abilities[i];
        //    }
        //    abilities = newQueue;
        //    abilities[abilities.Length - 1] = ability;
        //}

    }

    public Ability dequeue() {
        Ability[] newQueue = new Ability[abilities.Length];
        Ability ret;

        if ( !isEmpty() )
        {
            ret = abilities[0];
            for (int i = 1; i < abilities.Length; i++)
            {
                newQueue[i - 1] = abilities[i];
            }
            return ret;
        }

        return default(Ability);

    }

    public bool isEmpty() {
        if( abilities[0] == null ) {
            return true;
        }
        return false;
    }

}

