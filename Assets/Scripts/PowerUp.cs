using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public enum Type
    {
        Coin,
        ExtraLife,
        MagicMushroom,
        Starpower
    }
    public Type type;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Collect(collision.gameObject);
        }
    }
    private void Collect(GameObject player)
    {
        switch (type)
        {
            case Type.Coin:
                GameManager.instance.AddCoin();
                break;
            case Type.ExtraLife:
                GameManager.instance.AddLife();
                break;
            case Type.MagicMushroom:
                player.GetComponent<Player>().Grow();
                break;
            case Type.Starpower:
                player.GetComponent<Player>().StarPower();
                break;
        }
        Destroy(gameObject);   
    }
}
