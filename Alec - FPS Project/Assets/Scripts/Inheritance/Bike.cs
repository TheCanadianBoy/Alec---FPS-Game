using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bike : Vehicule
{

    public Vehicule vehicule;
    //The bike is small and has a low durability: most crashes would destroy it.
    [SerializeField] float durability = 10f;
    //The bike has a speed of 10, twice as fast as the truck
    [SerializeField] float speed = 10f;

    private void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        //Here, we specify the maneuverability of the bike. It's easier to control and maneuver than the truck, as it can make sharper turns.
        //It also has a maximum and acceleration speed higher than the truck
    }
}
