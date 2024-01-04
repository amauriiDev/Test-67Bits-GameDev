using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Type {
    Speed, 
    Stack};

[CreateAssetMenu(fileName ="PowerUp",menuName ="New PowerUp")]
public class PowerUp : ScriptableObject
{
    [SerializeField]private Type type;
    [SerializeField][Min(10)]private int baseCost;
    [SerializeField][Min(1)]private int level;
    [SerializeField][Min(10)]private int cost;

    public int Cost { get => cost;}
    public int Level { get => level;}
    public Type Type { get => type;}

    public void LevelUp(){
        level+=1;
        cost = baseCost* level;
    }
}
