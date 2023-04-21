using StarterAssets;
using UnityEngine;

[AbilityUsage(CharacterMainController.GameplayTypeFlags.All)]
public class ABILITY_Dash : AbilityBaseClass
{
    public float dashRange = 50.0f;
    public float dashCooldown = 1f;

    private float _dashTimeoutDelta = 0;
    private bool cooling;


    StarterAssetsInputs _inputs;

    public override void abilityStart()
    {
        _inputs = GetComponentInParent<StarterAssetsInputs>();
        mainController = GetComponentInParent<CharacterMainController>();
    }

    public override void abilityUpdate()
    {

        if (!enabled || !abilityEnabled)
        {
            return;
        }

        if (_dashTimeoutDelta > 0.0f)
        {
            _dashTimeoutDelta -= Time.deltaTime;
        }
        else if (_dashTimeoutDelta < 0.0f && cooling)
        {
            cooling = false;
            _inputs.dash = false;
        }

        if (cooling)
        {
            return;
        }

        if (_inputs.dash)
        {
            CharacterMainController.Instance.addImpulseForceToCharacter(transform.forward, dashRange);
            _dashTimeoutDelta = dashCooldown;
            cooling = true;

        }


    }

}
