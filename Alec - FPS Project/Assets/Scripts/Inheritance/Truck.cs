using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck : Vehicule
{
    public Vehicule vehicule;
    //The truck is big and has a high durability: it would easily survive most crashes.
    [SerializeField] float durability = 100f;
    //The truck has a speed of 5, half as fast as the bike
    [SerializeField] float speed = 5f;

    private void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        //Here, we specify the maneuverability of the truck. It's harder to control and maneuver than the bike and it can't make sharp turns.
        //It isn't as fast as the bike and takes more time to break
    }
}
