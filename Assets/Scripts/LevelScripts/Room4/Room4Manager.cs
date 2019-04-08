using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room4Manager : MonoBehaviour
{
    private GameObject player;

    private void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Start is called before the first frame update
    void Start()
    {
        player.transform.position = new Vector3(-120, -72, 0);
        player.GetComponent<PlayerState>().direction = 1;
        WorldVariables.level1Position = 4;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
