using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Farmer : MonoBehaviour
{
    int honey = 0;
    bool reachedTarget;
    Transform target;
    Transform pos;
    [SerializeField]GameObject flowerPrefab;

    private void Start()
    {
        pos = GetComponent<Transform>();
        getTarget();

    }

    private void Update()
    {
        if (honey >= 5)
        {
            honey = honey - 5;
            createFlower();
        }
        if (reachedTarget)
        {
            getTarget();
        }
    }

    private void getTarget()
    {
        System.Random rand = new System.Random();
        GameObject[] potentialTargets;
        
            potentialTargets = GameObject.FindGameObjectsWithTag("Hive");
            int randomTarget = rand.Next(potentialTargets.Length);
        Transform LockOn = potentialTargets[randomTarget].transform;
        if (LockOn == target) { return; }
            target = LockOn;
        
        //START MOVING TOWARDS TARGET
        pos.DOMove(target.position, 10);
        reachedTarget = false;
    }
    private void createFlower()
    {
        Debug.Log("New Flower");
        System.Random rand = new System.Random();
        GameObject flower = Instantiate(flowerPrefab);
        Flower flowerScript = flower.GetComponent<Flower>();
        flower.transform.position = new Vector3(rand.Next(-8,8), rand.Next(-8, 8),0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        //Checks if Collision is a Hive, then does logic appropriately.
        
        
        if (collision.gameObject.tag == "Hive")
        {
            reachedTarget = true;
            HIve hIve = collision.gameObject.GetComponent<HIve>();

            honey += hIve.honey;

        }
    }
}
