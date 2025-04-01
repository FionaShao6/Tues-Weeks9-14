using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{
    public float speed=2;
    Animator animator;
    SpriteRenderer sr;
    public bool canRun = true;
    public AudioClip footstepSounds; 
    public AudioSource audioSource;   
    
    void Start()
    {
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }
     
    // Update is called once per frame
    void Update()
    {
        float direction = Input.GetAxis("Horizontal");
        sr.flipX = direction < 0;

        animator.SetFloat("speed", Mathf.Abs(direction));


        if(Input.GetMouseButtonDown(0))
        {
            
            animator.SetTrigger("Attack");
            canRun = false;
        }

        transform.position += transform.right * direction * speed * Time.deltaTime;
    }

    public void AttackHasFinished()
    {
        Debug.Log("The attack just finished");
        canRun = true;

    }

    
      
    public void PlayFootstep()
    {
        if (footstepSounds != null) 
        {
            audioSource.PlayOneShot(footstepSounds); 
        }
    }
}

