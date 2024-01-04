using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class EnemiesStack : MonoBehaviour
{
    [Header("ATRIBUTO INSPECTOR")]
    [SerializeField]private Transform pivot;
    [SerializeField]private Stack<GameObject> stackedEnemies;

    public static event Action OnUnstackEnemy;


    void OnEnable() {
        Capture.OnEnemyIsCaptured+= StackUp;
        Money.OnDropEnemy+=Unstack;
    }

    void Start()
    {
        stackedEnemies = new Stack<GameObject>();
    }

    public bool IsFull(){
        return !(stackedEnemies.Count < GameManager.instance.UserData.MaxStack);
    }
    public bool IsEmpty(){
        return stackedEnemies.Count <= 0;
    }

    public void StackUp(GameObject enemy){
        
        if (IsFull()){
            return;
        }
        enemy.transform.position = new Vector3(0, stackedEnemies.Count * .5f, 0) + pivot.position;
        enemy.transform.SetParent(pivot);
        stackedEnemies.Push(enemy);
    }

    public void Unstack(){
        if (IsEmpty())
        return;

        OnUnstackEnemy?.Invoke();

        GameObject objEnemy = stackedEnemies.Pop();
        Enemy enemy = objEnemy.GetComponent<Enemy>();
        enemy.SetRigidBody(false);
        objEnemy.transform.position += Vector3.right * 1.35f;  // um pequeno deslocamento pra frente
        objEnemy.transform.SetParent(null);

        GameManager.instance.addMoney(enemy.Money);
        GameManager.instance.AddXp(enemy.Xp); 
    }

    void OnDisable() {
    Capture.OnEnemyIsCaptured-= StackUp;
    Money.OnDropEnemy-= Unstack;    
    }
}
