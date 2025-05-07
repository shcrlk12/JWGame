class ThrowCommand : IWeaponCommand
{

    private Weapon _weapon;

    public ThrowCommand(Weapon weapon)
    {
        _weapon = weapon;
    }

    public void Execute()
    {
        _weapon.ThrowWeapon();
    }
}
