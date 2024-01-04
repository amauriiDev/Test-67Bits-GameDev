using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpArea : MonoBehaviour
{
    [SerializeField]private PowerUp powerUp;
    void OnTriggerEnter(Collider other)
    {
        GameManager.instance.SetPowerUp(powerUp);
    }
}
