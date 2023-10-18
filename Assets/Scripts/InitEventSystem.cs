using UnityEngine;
using UnityEngine.EventSystems;

public class InitEventSystem : MonoBehaviour
{
    [SerializeField] private EventSystem eventSystem;
        
    private void Awake() => eventSystem.UpdateModules();
}