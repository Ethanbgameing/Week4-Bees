using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HIve : MonoBehaviour
{
    public int honey = 20;
    [SerializeField]GameObject beePrefab;
    public void produceBee()
    {
     GameObject bee = Instantiate(beePrefab);
     Bee beeScript = bee.GetComponent<Bee>();
     beeScript.setHomeHive(this.gameObject);
        
    }

    private void Update()
    {
        if (honey >= 10)
        {
            honey = honey - 10;
            produceBee();
        }
    }

    public void addHoney() { honey++; }
}
