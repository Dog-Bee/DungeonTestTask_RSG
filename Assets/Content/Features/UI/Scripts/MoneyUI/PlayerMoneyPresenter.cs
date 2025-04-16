using UnityEngine;

public class PlayerMoneyPresenter
{
    private readonly PlayerMoneyView _view;
    private readonly PlayerMoneyModel _model;

    public PlayerMoneyPresenter(PlayerMoneyView view, PlayerMoneyModel model)
    {
        _view = view;
        _model = model;

        _view.SetMoney(_model.MoneyAmount);
        _model.OnMoneyChanged += _view.SetMoney;
    }
}