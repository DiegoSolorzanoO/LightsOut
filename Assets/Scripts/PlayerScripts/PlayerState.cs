using System.Collections;
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
    public GameObject lantern;

    protected Rigidbody2D rb;

    private Animator animator;
    private Pause gameManager;

    private void Awake() {
        speed = 10;
        moving = false;
        canMove = true;
        interacting = false;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Pause>();
    }

    private void Start() {
        GetComponent<PlayerLight>().StartFlicker();
    }

    void Update()
    {
        if (gameManager.IsPaused()) {
            return;
        }
        if (WorldVariables.dialogueActive && !ducking && !interacting) {
            ChangeAnim(12, 32);
            canMove = false;
            return;
        } else if(!interacting){
            canMove = true;
        }
        if(interacting) {
            ChangeAnim(12, 32);
            return;
        }
        if (running) {
            speed = 15;
            ChangeAnim(11, 31);
        } else if(ducking){
            speed = 6;
            if (!moving) {
                ChangeAnim(42, 22);
            } else {
                ChangeAnim(41, 21);
            }
        } else if (moving && !interacting){
            speed = 10;
            ChangeAnim(11, 31);
        } else if(!moving && !interacting) {
            ChangeAnim(12,32);
        }
    }

    public bool Interact() {
        if (!ducking && canMove) {
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

    public void ChangeAnim(int izq, int der) {
        if (direction == 0) {
            animator.SetInteger("AnimState", izq);
            if (ducking) {
                lantern.transform.position = new Vector3(transform.position.x + 3f, transform.position.y + 9.5f, transform.position.z - 0.5f);
            } else {
                lantern.transform.position = new Vector3(transform.position.x - 12f, transform.position.y + 37f, transform.position.z - 0.5f);
            }
            
        } else {
            animator.SetInteger("AnimState", der);
            if (ducking) {
                lantern.transform.position = new Vector3(transform.position.x - 3f, transform.position.y + 9.5f, transform.position.z - 0.5f);
            } else {
                lantern.transform.position = new Vector3(transform.position.x + 12f, transform.position.y + 37f, transform.position.z - 0.5f);
            }
            
        }
    }
}
