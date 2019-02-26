﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public bool moving;
    public int speed;
    public bool running;
    public bool ducking;
    public bool canMove;
    public bool interacting;
    public int direction;

    protected Rigidbody2D rb;

    private Animator animator;

    private void Awake() {
        speed = 10;
        moving = false;
        canMove = true;
        interacting = false;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    public int GetSpeed() {
        return speed;
    }

    public void SetSpeed(int nspeed) {
        speed = nspeed;
    }

    public bool Moving() {
        return moving;
    }

    public void Moving(bool nvalue) {
        moving = nvalue;
    }

    public bool Running() {
        return running;
    }

    public void Running(bool nvalue) {
        running = nvalue;
    }

    public bool Ducking() {
        return ducking;
    }

    public void Ducking(bool nvalue) {
        ducking = nvalue;
    }

    public bool CanMove() {
        return canMove;
    }

    public void CanMove(bool nvalue) {
        canMove = nvalue;
    }

    public bool Interacting() {
        return interacting;
    }

    public void Interacting(bool nvalue) {
        interacting = nvalue;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (running) {
            speed = 20;
        } else if(ducking){
            speed = 6;
            if (!moving) {
                if(direction == 0) {
                    animator.SetInteger("AnimState", 42);
                } else {
                    animator.SetInteger("AnimState", 22);
                }
            } else {
                if (direction == 0) {
                    animator.SetInteger("AnimState", 41);
                } else {
                    animator.SetInteger("AnimState", 21);
                }
            }
        } else if (moving && !interacting){
            speed = 10;
            if (direction == 0) {
                animator.SetInteger("AnimState", 11);
            } else {
                animator.SetInteger("AnimState", 31);
            }
        } else if(!moving && !interacting) {
            if (direction == 0) {
                animator.SetInteger("AnimState", 12);
            } else {
                animator.SetInteger("AnimState", 32);
            }
        }
        Debug.Log(direction);
    }

    public bool Interact() {
        if (!moving && !ducking) {
            canMove = false;
            interacting = true;
            StartCoroutine(Searching());
            return true;
        }
        return false;
    }

    IEnumerator Searching() {
        yield return new WaitForSeconds(3);
        canMove = true;
        interacting = false;
    }
}
