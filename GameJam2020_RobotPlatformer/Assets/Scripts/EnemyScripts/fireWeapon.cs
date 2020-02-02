﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireWeapon : MonoBehaviour
{
    public GameObject bullet;
    public Transform muzzle;
    private float timeBetweenShots;
    public float firingRate;
    private bool canFire = true;
    private Sprite currentSprite;
    public Sprite otherSprite;

    // Start is called before the first frame update
    void Start()
    {
        currentSprite = GetComponent<SpriteRenderer>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeBetweenShots <= 0)
        {
            timeBetweenShots = firingRate;
            canFire = true;
            GetComponent<SpriteRenderer>().sprite = otherSprite;

        }
        else
        {
            timeBetweenShots -= Time.deltaTime;
            if(timeBetweenShots <=1)
            {
                GetComponent<SpriteRenderer>().sprite = currentSprite;

            }
        }
        if(canFire)
        {
            canFire = false;
            shootGun();
        }
    }
    private void shootGun()
    {
        Instantiate(bullet, muzzle.position, transform.rotation);

    }
}
