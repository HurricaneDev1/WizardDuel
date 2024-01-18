using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager I;
    [SerializeField]private PlayerInput playerInput;
    [SerializeField]private Material player2;
    private int numKeyboardPlayers;
    private int numPlayers;
    private List<PlayerInput> spawnedPlayers = new List<PlayerInput>();   
    void Awake(){
        I = this;
    }

    void Update(){
        PlayerJoined();
    }

    private void PlayerJoined(){
        PlayerInput player = null;
        if(Keyboard.current.anyKey.wasPressedThisFrame && numKeyboardPlayers == 0){
            SetControlsKeyboard("Keyboard", player);
        }else if(ArrowPressed() && numKeyboardPlayers == 1){
            SetControlsKeyboard("Arrows", player);
        }
        // else if(Gamepad.current.aButton.wasPressedThisFrame){
        //     player = Instantiate(playerInput, transform.position, Quaternion.identity);
        //     player.defaultControlScheme = "Controller";
        //     player.SwitchCurrentControlScheme("Controller", Gamepad.current);
        //     numPlayers ++;
        // }
    }

    public void SetControlsKeyboard(string nameOfControl, PlayerInput player){
        player = Instantiate(playerInput, transform.position, Quaternion.identity);
        player.defaultControlScheme = nameOfControl;
        player.SwitchCurrentControlScheme(nameOfControl, Keyboard.current, Mouse.current);
        numPlayers ++;
        numKeyboardPlayers ++;
        if(numKeyboardPlayers == 2){
            player.GetComponentInChildren<SpriteRenderer>().material = player2;
        }
    }

    bool ArrowPressed(){
        return Keyboard.current.leftArrowKey.wasPressedThisFrame || Keyboard.current.rightArrowKey.wasPressedThisFrame || Keyboard.current.upArrowKey.wasPressedThisFrame || Keyboard.current.downArrowKey.wasPressedThisFrame; 
    }
}
