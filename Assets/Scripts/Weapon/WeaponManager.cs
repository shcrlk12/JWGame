using UnityEngine;

class WeaponManager : MonoBehaviour
{
    private PlayerInput _playerInput;
    private Weapon _weapon;
    void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerInput.E)
        {
            IWeaponCommand weaponCommand;
            if (_weapon != null)
            {
                weaponCommand = new ThrowCommand(_weapon);
            }
            else
            {
                weaponCommand = new GrabCommand(_weapon, gameObject);
            }
            weaponCommand.Execute();

        }
    }
}
