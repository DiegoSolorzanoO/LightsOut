using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLogicScript : MonoBehaviour
{
    public GameObject player;
    public bool canFollow;

    // Start is called before the first frame update
    void Start()
    {
        canFollow = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(canFollow) {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 72, -10);
        }
    }

    private void OnTriggerStay2D(Collider2D collision) {

    }
}
