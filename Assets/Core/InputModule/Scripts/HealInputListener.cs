using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;
using DefaultInputActions = Core.InputModule.DefaultInputActions;

public class healInputListener : MonoBehaviour
{
    [Inject] private HealPotionService _service;

    private Core.InputModule.Generated.DefaultInputActions _input;

    private void Awake()
    {
        _input = new Core.InputModule.Generated.DefaultInputActions();
        _input.Enable();
        _input.Player.UseHealPotion.performed += _ => _service.TryUsePotion();
    }
}
