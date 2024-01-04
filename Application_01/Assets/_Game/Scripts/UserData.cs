using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName ="UserData", menuName ="Criar Dados")]
public class UserData: ScriptableObject
{

    public static event Action OnLevelUp;
    //Player Atributos
    [SerializeField][Min(6)]private float speed = 6.0f;
    [SerializeField][Min(4)]private int maxStack = 10;

    // UI Atributos
    [SerializeField][Min(0)]private int money = 0;
    [SerializeField][Min(1)]private int level = 1;
    [SerializeField][Min(0)]private int xp = 0;
    [SerializeField][Min(10)]private int maxXp = 10;

    public float Speed { get => speed; set => speed = value; }
    public int MaxStack { get => maxStack; set => maxStack = value; }

    public int Money { get => money; set => money = value; }
    public int Level { get => level; set => level = value; }
    public int Xp { get => xp; set => xp = value; }
    public int MaxXp { get => maxXp; set => maxXp = value; }

    public void UpdateMoney(int value){
        Money+= value;
    }
    public void IncreaseSpeed(){
        Speed += 6*0.05f;      // adicioanr 5% de velocidade de movimento base
    }
    public void IncreaseMaxStack(){
        MaxStack+=1;
    }

    public void LevelUp(){
        level+=1;
        maxXp = Level* 10;
        OnLevelUp?.Invoke();
    }
    public bool AddXp(int value){
        if(value <= 0)
            return false;

        float dif = (xp + value) - maxXp;
        if (dif > 0)// subir de nível
        {
            LevelUp();
            xp = (int)dif;
            return true;
        }
        xp+= value;
        return false;
    }

    public void NewGame(){
        Speed = 6.0f;
        MaxStack = 4;

        Money = 0;
        Level = 1;
        Xp = 0;
        MaxXp = 10;
    }
}
