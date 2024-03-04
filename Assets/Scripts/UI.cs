using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    TextMeshProUGUI Counter;


    private void Awake()
    {
        Counter = GetComponentInChildren<TextMeshProUGUI>();
    }
    void Update()
    {
        int bees = 0;
        int flowers = 0;
        GameObject[] gameObjects = GameObject.FindObjectsOfType<GameObject>();

        foreach (GameObject gameObject in gameObjects)
        {
            if (gameObject.tag == "Flower") { flowers++; }
            if (gameObject.tag == "Bee") { bees++; }
        }
        Counter.text = $"Flowers: {flowers}\nBees: {bees}";
    }
}
