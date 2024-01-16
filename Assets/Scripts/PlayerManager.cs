using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager I;
    public List<PlayerInput> playerInputs = new List<PlayerInput>();
    private int numPlayers;
    private List<PlayerInput> spawnedPlayers = new List<PlayerInput>();   
    void Awake(){
        I = this;
    }

    void Update(){
        PlayerJoined();
    }

    private void PlayerJoined(){
        if(Keyboard.current.spaceKey.wasPressedThisFrame){
            PlayerInput player = null;
            switch(numPlayers){
                case 0:
                    player = Instantiate(playerInputs[0], transform.position, Quaternion.identity);
                    player.defaultControlScheme = "Keyboard";
                    player.SwitchCurrentControlScheme("Keyboard", Keyboard.current, Mouse.current);
                    numPlayers ++;
                    break;
                case 1:
                    player = Instantiate(playerInputs[0], transform.position, Quaternion.identity);
                    player.defaultControlScheme = "Arrows";
                    player.SwitchCurrentControlScheme("Arrows", Keyboard.current, Mouse.current);
                    numPlayers ++;
                    break;
            }
        }
    }
}
