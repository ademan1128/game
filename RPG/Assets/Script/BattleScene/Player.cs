using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public int health = 100;
    public int attackPower = 10;

    [SerializeField] private BattleSceneManager battlescenemanager;
    void Start()
    {
        health = 100;
    }

    void Update()
    {
        if(battlescenemanager.state == BattleState.PlayerTurn)
        {
            if (Keyboard.current.aKey.wasPressedThisFrame)
            {
                Debug.Log("Player attacks!");
            }
        }
    }
}
