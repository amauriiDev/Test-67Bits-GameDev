using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]private Transform target; // Transform do jogador
    [SerializeField]private float smoothSpeed = 0.125f; // Velocidade de movimento da câmera
    [SerializeField]private Vector3 offset; // Distância inicial da câmera em relação ao jogador

    void Start()
    {
        offset = transform.position;
    }
    void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset; // Calcula a posição desejada da câmera
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); // Suaviza o movimento da câmera
        transform.position = smoothedPosition; // Atualiza a posição da câmera
    }
}

