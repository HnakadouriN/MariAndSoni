using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public int playerID = 1;
    public int speed;
    private Vector3 direction;
    private CharacterController cc;

    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        direction.Set(Input.GetAxis("Horizontal " + playerID), 0, Input.GetAxis("Vertical " + playerID));
        if (direction != Vector3.zero) transform.rotation = Quaternion.LookRotation(direction);
        cc.SimpleMove(direction * speed);
    }

    void OnGUI()
    {
        for (int i = (int)KeyCode.Joystick1Button0; i <= (int)KeyCode.Joystick2Button19; i++)
        {
            if (Input.GetKey((KeyCode)i)) GUILayout.Label(((KeyCode)i).ToString() + " is pressed.");
        }
    }
}
