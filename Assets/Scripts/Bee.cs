using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : MonoBehaviour
{
    

    public bool hasHoney = false;
    public bool reachedTarget = true;
    [SerializeField]private Transform target;
    private GameObject homeHive;
    Transform pos;

    private void Start()
    {
        pos = GetComponent<Transform>();
        moveTowardTarget();
    }

    public void setHomeHive(GameObject target)
    {
        homeHive = target;
    }
    private void Update()
    {
    }


    private void moveTowardTarget()
    {
      reachedTarget = false;
      System.Random rand = new System.Random();
      GameObject[] potentialTargets;
      if(!hasHoney) 
        {
            potentialTargets = GameObject.FindGameObjectsWithTag("Flower");
            int randomTarget = rand.Next(potentialTargets.Length);
            target = potentialTargets[randomTarget].transform;
        }
      else
        {
            target = homeHive.transform;
        }
        //START MOVING TOWARDS TARGET
        pos.DOMove(target.position, 5);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //CHECKS IF COLLISION WAS INTENDED TARGET
        if (collision.gameObject.transform.position != target.position) return;

        if (collision.gameObject.tag == "Hive")
        {
            reachedTarget = true;
            HIve hIve = collision.gameObject.GetComponent<HIve>();

            hasHoney = false;
            hIve.addHoney();
            moveTowardTarget();
        }
        else if(collision.gameObject.tag == "Flower")
        {

            reachedTarget = true;
            if (hasHoney)
            {
                return;
            }
            Flower flower = collision.gameObject.GetComponent<Flower>();

            if (flower.honeyCharged)
            {
                hasHoney = true;
                flower.removeHoney();
            }
            moveTowardTarget();
        }
    }
}
