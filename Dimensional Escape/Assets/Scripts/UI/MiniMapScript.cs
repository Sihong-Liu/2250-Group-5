using UnityEngine;

public class MiniMapScript : MonoBehaviour
{
    public GameObject Player;

    private void Update()
    {
        transform.position = new Vector3(Player.transform.position.x, 40, Player.transform.position.z);
    }
}
