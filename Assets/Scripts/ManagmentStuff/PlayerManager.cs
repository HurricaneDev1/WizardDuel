using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager I;
    [SerializeField]private PlayerInput playerInput;
    [SerializeField]private List<Material> playerMaterials = new List<Material>();
    private int numKeyboardPlayers;
    private List<PlayerInput> spawnedPlayers = new List<PlayerInput>();   
    [SerializeField]private List<Transform> spawnPoints = new List<Transform>();
    [SerializeField]private List<Transform> UISpawnPoints = new List<Transform>();
    private List<PlayerEndRound> spawnedUIs = new List<PlayerEndRound>();
    [SerializeField]private GameObject UIObject;
    void Awake(){
        I = this;
    }

    void Update(){
        PlayerJoined();
    }

    private void PlayerJoined(){
        PlayerInput player = null;
        if(Keyboard.current.anyKey.wasPressedThisFrame && numKeyboardPlayers == 0 && spawnedPlayers.Count < 4){
            SetControlsKeyboard("Keyboard", player);
        }else if(ArrowPressed() && numKeyboardPlayers == 1 && spawnedPlayers.Count  < 4){
            SetControlsKeyboard("Arrows", player);
        }else if(Gamepad.current != null && Gamepad.current.aButton.wasPressedThisFrame && spawnedPlayers.Count  < 4){
            if(spawnedPlayers.Count > 0){
                foreach(PlayerInput play in spawnedPlayers){
                    if(play.devices[0] != null && play.devices[0] == Gamepad.current){
                        return;
                    }
                }
            }
            player = Instantiate(playerInput, spawnPoints[spawnedPlayers.Count].position, Quaternion.identity);
         //   player.defaultScheme = "Controller";
            player.SwitchCurrentControlScheme("Controller", Gamepad.current);
            spawnedPlayers.Add(player);
            SetMaterial(player);
        }
    }

    public void SetControlsKeyboard(string nameOfControl, PlayerInput player){
        player = Instantiate(playerInput, spawnPoints[spawnedPlayers.Count].position, Quaternion.identity);
        player.SwitchCurrentControlScheme(nameOfControl, Keyboard.current, Mouse.current);
        spawnedPlayers.Add(player);
        numKeyboardPlayers ++;
        SetMaterial(player);
    }

    bool ArrowPressed(){
        return Keyboard.current.leftArrowKey.wasPressedThisFrame || Keyboard.current.rightArrowKey.wasPressedThisFrame || Keyboard.current.upArrowKey.wasPressedThisFrame || Keyboard.current.downArrowKey.wasPressedThisFrame; 
    }

    void SetMaterial(PlayerInput materialPlayer){
        materialPlayer.GetComponentInChildren<SpriteRenderer>().material = playerMaterials[spawnedPlayers.Count - 1];
        PlayerEndRound newUI = Instantiate(UIObject , UISpawnPoints[spawnedPlayers.Count - 1].position, Quaternion.identity).GetComponent<PlayerEndRound>();
        newUI.SpawnIn(playerMaterials[spawnedPlayers.Count - 1], materialPlayer.gameObject);
        spawnedUIs.Add(newUI);
    }

    public void AllPlayersAlive(){
        int numPlayersDead = 0;
        PlayerInput playerAlive = null;
        foreach(PlayerInput player in spawnedPlayers){
            if(player.GetComponent<PlayerHittable>().IsDead()){
                numPlayersDead ++;
            }else{
                playerAlive = player;
            }
        }
        //Reset the players
        if(numPlayersDead >= spawnedPlayers.Count - 1){
            StartCoroutine(ResetPlayers(playerAlive));
        }    
    }

    public IEnumerator ResetPlayers(PlayerInput playerAlive){
        yield return new WaitForSeconds(0.5f);
        SetPlayerUI(true);
        yield return new WaitForSeconds(0.2f);
        if(playerAlive)spawnedUIs[spawnedPlayers.IndexOf(playerAlive)].GainPoint();

        yield return new WaitForSeconds(1);
        PlayerSpawns();
        SetPlayerUI(false);
        
    }

    void PlayerSpawns(){
        List<Transform> spawnPointsAvailable = new List<Transform>();
        spawnPointsAvailable.AddRange(spawnPoints);
        foreach(PlayerInput player in spawnedPlayers){
            Transform actualSpawn = spawnPointsAvailable[Random.Range(0, spawnPointsAvailable.Count)];      
            spawnPointsAvailable.Remove(actualSpawn);
            player.GetComponent<PlayerHittable>().Reset(actualSpawn.position);
        }
    }

    void SetPlayerUI(bool on){
        foreach(PlayerEndRound end in spawnedUIs){
            end.TurnOn(on);
        }
    }
}
