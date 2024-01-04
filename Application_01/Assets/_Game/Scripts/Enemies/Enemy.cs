using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour,IDamageable
{
    [SerializeField]const int initialXp = 4;
    [SerializeField]const int initialMoney = 10;
    [SerializeField]private LayerMask lmPlayer;
    [SerializeField]private Animator animator;

    [SerializeField]private GameObject interactableObj;

    [SerializeField]private bool isDead;
    [SerializeField]private int xp;
    [SerializeField]private int money;

    public int Xp { get => xp;}
    public int Money { get => money;}

    private void Start()
    {
        animator = GetComponentInParent<Animator>();
        isDead = false;
        xp = initialXp;
        money = initialMoney;
    }


    private void FixedUpdate()
    {
        if (!isDead){
            return;
        }
    }

    void IDamageable.TakeHit(Transform enemy, float force, Transform point){
        animator.enabled = false;
        enemy.GetComponent<Rigidbody>().AddForce(point.transform.forward * force, ForceMode.Impulse);
        StartCoroutine(CapturedTime());
    }

    IEnumerator CapturedTime(){
        // esperar 2 sec para que o inimigo possa ser capturado
        yield return new WaitForSeconds(2);

        interactableObj.transform.position += Vector3.up * 15;
        BoxCollider InteractiveCollider = interactableObj.AddComponent<BoxCollider>();
        InteractiveCollider.isTrigger = true;

        isDead = true;
        animator.SetBool("isDead",isDead);
    }
    public void SetRigidBody(bool flag){

        animator.enabled = flag;
        Rigidbody[] rigids = GetComponentsInChildren<Rigidbody>();
        foreach (var body in rigids)
        {
            body.isKinematic = flag;
        }
    }
}
        

