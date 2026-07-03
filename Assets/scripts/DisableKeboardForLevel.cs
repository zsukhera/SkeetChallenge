using UnityEngine;
using UnityEngine.InputSystem;

public class DisableKeyboardForLevel : MonoBehaviour
{
    private PlayerInput playerInput;
    //this will be applied on the menu
    //for the real game, this shall be disabled 
    //because we need the input
    //add this 
    /*
             using UnityEngine;
        using UnityEngine.InputSystem;

        public class EnablePlayerInput : MonoBehaviour
        {
            void Start()
            {
                PlayerInput playerInput = FindObjectOfType<PlayerInput>();

                if (playerInput != null)
                    playerInput.enabled = true;
            }
        }
     */
    void Start()
    {
        playerInput = FindObjectOfType<PlayerInput>();

        if (playerInput != null)
            playerInput.enabled = false;
    }
}