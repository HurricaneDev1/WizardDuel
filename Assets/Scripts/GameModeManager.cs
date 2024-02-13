using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class GameModeManager : MonoBehaviour
{
    [SerializeField]private PlayerManager playerManager;
    public List<PlayerInput> players = new List<PlayerInput>();

    public List<Transform> currentMaps = new List<Transform>();

    // public void StartMode(int modeNumber){
    //     currentMaps[modeNumber].SetActive(true);
    //     playerManager.SetPlayerInput(players[modeNumber]);       
    // }
}
