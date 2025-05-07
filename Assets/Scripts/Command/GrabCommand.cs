
using UnityEngine;

class GrabCommand : IWeaponCommand
{
    private Weapon _weapon;
    private GameObject _hands;

    public GrabCommand(Weapon weapon, GameObject hands)
    {
        _weapon = weapon;
        _hands = hands;
    }

    public void Execute()
    {
        _weapon.AttachWeaponToParent(_hands);
    }
}
