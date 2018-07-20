using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AbilityHandler {
    private readonly Queue<Ability> abilities;

    public AbilityHandler() {
        abilities = new Queue<Ability>();
    }

    public void QueueAbilities() { //For development purposes only
        Debug.Log("Queuing up abilities...");
        abilities.Enqueue(new Ability("Ability1"));
        abilities.Enqueue(new Ability("Ability2"));
        abilities.Enqueue(new Ability("Ability3"));

        Debug.Log("Abilities queued.");
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

