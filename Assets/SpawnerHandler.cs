using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnerHandler : MonoBehaviour
{
    [Header("Spawning")]
    public GameObject prefab;
    public Transform spawnPoint;
    public GameObject spawnParticleEffect;
    public AudioClip spawnSound;

    [Header("Teleporting")]
    public Transform xrOrigin;
    public Transform startingPoint;
    public Transform teleportLocation;

    private XRInputActions inputActions;

    private bool isAtTeleportLocation = false;

    private void Awake()
    {
        inputActions = new XRInputActions();
    }

    private void OnEnable()
    {
        
        inputActions.Gameplay.SpawnObject.Enable();
        inputActions.Gameplay.SpawnObject.performed += Spawn;

        
        inputActions.Gameplay.TeleportToggle.Enable();
        inputActions.Gameplay.TeleportToggle.performed += ToggleTeleport;
    }

    private void OnDisable()
    {
        
        inputActions.Gameplay.SpawnObject.performed -= Spawn;
        inputActions.Gameplay.SpawnObject.Disable();

        
        inputActions.Gameplay.TeleportToggle.performed -= ToggleTeleport;
        inputActions.Gameplay.TeleportToggle.Disable();
    }

    private void Spawn(InputAction.CallbackContext context)
    {
        
        Instantiate(
            prefab,
            spawnPoint.position,
            spawnPoint.rotation
        );

        
        if (spawnParticleEffect != null)
        {
            Instantiate(
                spawnParticleEffect,
                spawnPoint.position,
                spawnPoint.rotation
            );
        }

        
        if (spawnSound != null)
        {
            AudioSource.PlayClipAtPoint(
                spawnSound,
                spawnPoint.position
            );
        }
    }

    private void ToggleTeleport(InputAction.CallbackContext context)
    {
        if (isAtTeleportLocation)
        {
            TeleportTo(startingPoint);
        }
        else
        {
            TeleportTo(teleportLocation);
        }

        isAtTeleportLocation = !isAtTeleportLocation;
    }

    private void TeleportTo(Transform location)
    {
        xrOrigin.transform.SetPositionAndRotation(
            location.position,
            location.rotation
        );
    }
}




