using UnityEngine;

public class PlayerHealthPresenter
{
    private readonly PlayerHealthBarView _view;
    private readonly PlayerHealthModel _model;

    public PlayerHealthPresenter(PlayerHealthBarView view, PlayerHealthModel model)
    {
        _view = view;
        _model = model;
        
        _model.OnHealthChanged += _view.SetHealth;
        _view.SetHealth(_model.CurrentHealth, _model.MaxHealth);
    }
}
