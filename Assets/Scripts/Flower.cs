using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    public bool honeyCharged;
    int Cooldown;
    [SerializeField] int maxCooldown = 60;
    SpriteRenderer sprite;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if(!honeyCharged)
        {
            Cooldown--;
            if(Cooldown <= 0 )
            {
                Cooldown = 0;
                honeyCharged = true;

                sprite.color = Color.white;
            }
        }
    }

    public void removeHoney()
    {
        honeyCharged = false;
        Cooldown = maxCooldown;
        sprite.color = Color.grey;
    }

}
