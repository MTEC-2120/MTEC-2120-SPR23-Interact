using StarterAssets;
using UnityEngine;

public abstract class AbilityBaseClass : MonoBehaviour
{
    public bool abilityEnabled = true;
    protected CharacterMainController mainController;
    public virtual void abilityStart() { }
    public virtual void abilityUpdate() { }
    public virtual void abilityLateUpdate() { }
}
