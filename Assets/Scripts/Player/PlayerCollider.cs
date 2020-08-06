using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{

    private PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<PlayerController>();
    }

    private void OnCollisionStay2D(Collision2D other) {
        if (other.gameObject.tag == "Ground")
        {
            player.grounded = true;
        }

    }

    private void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.tag == "Ground")
        {
            player.grounded = false;
        }
    }

}
