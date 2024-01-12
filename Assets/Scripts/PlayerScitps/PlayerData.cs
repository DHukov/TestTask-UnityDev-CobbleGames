using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerData")]
public class PlayerData : ScriptableObject
{
    public string playerName;
    public int playerHealth;
    public int playerSpeed;
    public int playerRotationSpeed;
}
