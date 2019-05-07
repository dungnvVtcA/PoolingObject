﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newObjectPoolerScript : MonoBehaviour
{
    public static newObjectPoolerScript current;

    public GameObject pooledObject;

    public int pooledAmount = 20;

    public bool willGrow = true;

    public List<GameObject> pooledObjects;

    private void Awake()
    {
        current = this;
    }


    void Start()
    {
        pooledObjects = new List<GameObject>();
        for(int i =0; i < pooledAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(pooledObject);
            pooledObject.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public GameObject getPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if(!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        if(willGrow)
        {
            GameObject obj = (GameObject)Instantiate(pooledObject);
            pooledObjects.Add(obj);
            return obj;
        }
        return null;
    }
}
