﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Captain.Command;

public class PirateController : MonoBehaviour
{
    [SerializeField]
    public IPirateCommand activeCommand;
    
    [SerializeField]
    public GameObject productPrefab;

    // Start is called before the first frame update
    void Start()
    {
        this.activeCommand = ScriptableObject.CreateInstance<SlowWorkerPirateCommand>();
    }

    // Update is called once per frame
    void Update()
    {
        var working = this.activeCommand.Execute(this.gameObject, this.productPrefab);

        this.gameObject.GetComponent<Animator>().SetBool("Exhausted", !working);
    }

    //Has received motivation. A likely source is from on of the Captain's morale inducements.
    public void Motivate()
    {
        int actionNumber = Random.Range(1, 4);
        if (actionNumber == 1)
        {
            //Debug.Log("1");
            this.activeCommand = Object.Instantiate(ScriptableObject.CreateInstance<SlowWorkerPirateCommand>());
        }
        else if (actionNumber == 2)
        {
            //Debug.Log("2");
            this.activeCommand = Object.Instantiate(ScriptableObject.CreateInstance<NormalWorkerPirateCommand>());
        }
        else if (actionNumber == 3)
        {
            //Debug.Log("3");
            this.activeCommand = Object.Instantiate(ScriptableObject.CreateInstance<FastWorkerPirateCommand>());
        }
    }
}
