using UnityEngine;

public abstract class SyperWarrior
{
    [field: SerializeField] public string Name { get; private set; } = "Not used";
    [field: SerializeField] public int Health { get; private set; } = 0;
    [field: SerializeField] public int Damage { get; private set; } = 0;

    public void Activate()
    {

    }
}
