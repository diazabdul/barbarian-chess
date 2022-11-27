using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerMovement : MonoBehaviour
{
    PhotonView view;
    public float speed = 10f;
    private CharacterController player;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();
        view = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (view.IsMine)
        {
            Vector3 Move = Vector3.zero;
            Move.x = Input.GetAxis("Horizontal") * speed;
            Move.y = Input.GetAxis("Vertical") * speed;
            player.Move(Move * Time.deltaTime);
        }
    }
}
