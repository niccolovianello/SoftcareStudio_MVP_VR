using Game;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GameManager : MonoBehaviour
{

    private Shooter _gun;
    private void Start()
    {
        _gun = FindObjectOfType<ActionBasedController>().GetComponentInChildren<Shooter>();
        DisableGun();
    }

    private void DisableGun()
    {
        _gun.gameObject.SetActive(false);
    }

    public void EnableGun()
    {
        _gun.gameObject.SetActive(true);
    }
}
