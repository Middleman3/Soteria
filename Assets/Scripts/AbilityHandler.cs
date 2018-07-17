using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AbilityHandler {
    private Queue<Ability> abilities;

    public AbilityHandler() {
        abilities = new Queue<Ability>();
    }

    public void QueueAbilities() { //For development purposes only
        Debug.Log("Queuing up abilities...");
        abilities.enqueue(new Ability("Ability1"));
        abilities.enqueue(new Ability("Ability2"));
        abilities.enqueue(new Ability("Ability3"));

        Debug.Log("Abilities queued.");
    }

    public void CastAbility() {
        Debug.Log(abilities.dequeue().ToString() + " successfully casted.");
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

