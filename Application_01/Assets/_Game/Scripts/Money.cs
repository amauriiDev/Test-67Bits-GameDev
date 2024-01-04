using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Money : MonoBehaviour
{
    //[SerializeField]
    private float time;
    //[SerializeField]
    private float cooldown;

    public static event Action OnDropEnemy;
    void Start()
    {
        cooldown = .6f;
        time = cooldown;
    }

    void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;
        
        time -= Time.fixedDeltaTime;

        if (time <= 0)
        {
            time = cooldown;
            OnDropEnemy?.Invoke();
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;
            
        time = cooldown;
    }
}
