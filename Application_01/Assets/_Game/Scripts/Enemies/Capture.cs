using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Animations;

public class Capture : MonoBehaviour
{
    [SerializeField]GameObject parentObj;

    public static event Action<GameObject> OnEnemyIsCaptured;

    private void Captured(){
        
        OnEnemyIsCaptured?.Invoke(parentObj);
        GetComponentInParent<Enemy>().SetRigidBody(true);
    }


    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        if (other.GetComponent<EnemiesStack>().IsFull())
            return;
        
        if(TryGetComponent<BoxCollider>(out BoxCollider component)){
            Destroy(component);
        }
        Captured();
    }
}
