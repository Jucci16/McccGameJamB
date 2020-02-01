using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropHazard : MonoBehaviour
{
    public float timeBetweenDrops;
    public float dropRate;
    private bool canDrop;
    public GameObject hazard;
    public Transform spout;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBetweenDrops <= 0)
        {
            timeBetweenDrops = dropRate;
            canDrop = true;
        }
        else
        {
            timeBetweenDrops -= Time.deltaTime;
        }

        if (canDrop)
        {
            canDrop = false;
            drophazard();
        }
    
    }
    private void drophazard()
    {
        Instantiate(hazard, spout.position, transform.rotation);
    }
}
