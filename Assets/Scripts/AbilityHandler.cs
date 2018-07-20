using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AbilityHandler {
    private readonly Queue<Ability> abilities;

    public AbilityHandler() {
        abilities = new Queue<Ability>();
    }

    public void QueueAbilities() { //For development purposes only
        if (Input.GetKeyDown(KeyCode.Q))
        {
            abilities.Enqueue(new Ability("Ability1"));

        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            abilities.Enqueue(new Ability("Ability2"));

        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            abilities.Enqueue(new Ability("Ability3"));
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            abilities.Enqueue(new Ability("Ability4"));
        }
    }

    public void CastAbility() {
        if (abilities.Peek() != default(Ability))
        {
            Debug.Log(abilities.Dequeue().ToString() + " successfully casted.");
        }
    }

}

public class Ability {
    string name;

    public Ability( string _name ) {
        name = _name;
    }

	public override string ToString()
	{
        return name;
	}
}

