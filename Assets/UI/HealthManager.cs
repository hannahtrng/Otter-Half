using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] List<Animator> animators;
    int health;

    private void Awake()
    {
        foreach(var animator in animators){
            animator.SetBool("Full", true);
        }
        health = animators.Count;
    }

    public void OnDamage()
    {
        health--;
        if (health == 0)
        {
            //kill player code
        }
        else if(health > 0 && health < animators.Count)
        {
            // we want to make the 
            // (health + 1)'th heart empty
            Animator animator = animators[health];
            animator.SetBool("Full", false);
        }



        /*
            OnDamage, if no hearts are empty, change heart1 to emptyheart1
            OnDamage, if one heart is empty, change heart2 to emptyheart2
            OnDamage, if two hearts are empty, change heart3 to emptyheart3
            if three hearts are empty, kill player

        */
    }
}
