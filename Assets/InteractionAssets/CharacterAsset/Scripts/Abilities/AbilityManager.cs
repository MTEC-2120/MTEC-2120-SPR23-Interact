using UnityEditor;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    [Header("The Abilities Will Start(), Update(), and LateUpdate() in The Following Order:")]
    public AbilityBaseClass[] characterAbilityUpdateOrder;


#if UNITY_EDITOR
    #region Functions to update The characterAbilityUpdateOrder Array
    AbilityManager()
    {
        ObjectFactory.componentWasAdded -= HandleComponentAdded;
        ObjectFactory.componentWasAdded += HandleComponentAdded;

        EditorApplication.quitting -= OnEditorQuiting;
        EditorApplication.quitting += OnEditorQuiting;
    }
    private void HandleComponentAdded(UnityEngine.Component obj)
    {
        updateCharacterAbilityArray();
    }

    private void updateCharacterAbilityArray()
    {
        removeNullAbilitySlots();
        //I understand this is Big O^2 however, it only runs on validate. What's more important is navigation of the final structure (an array) is as fast as possible.
        AbilityBaseClass[] grabbedAbilities;

        if (this == null)
        {
            return;
        }

        if (GetComponent<AbilityBaseClass>() != null)
        {
            grabbedAbilities = GetComponents<AbilityBaseClass>();
        }
        else
        {
            grabbedAbilities = new AbilityBaseClass[0];
        }



        foreach (AbilityBaseClass ability in grabbedAbilities)
        {
            bool abilityFound = false;

            foreach (AbilityBaseClass setAbility in characterAbilityUpdateOrder)
            {
                if (ability.Equals(setAbility))
                {
                    abilityFound = true;
                }
            }

            if (!abilityFound)
            {
                increaseAbilityArrayWithNewElement(ability);
            }
        }
    }

    private void removeNullAbilitySlots()
    {

        if (characterAbilityUpdateOrder.Length == 0)
        {
            return;
        }

        bool slotsNeedRemoved = true;
        while (slotsNeedRemoved)
        {
            slotsNeedRemoved = false;
            int elementToPass = 0;
            for (int i = 0; i < characterAbilityUpdateOrder.Length; i++)
            {
                if (characterAbilityUpdateOrder[i] == null)
                {
                    slotsNeedRemoved = true;
                    elementToPass = i;
                    i = characterAbilityUpdateOrder.Length;
                }
            }

            if (slotsNeedRemoved)
            {
                characterAbilityUpdateOrder = removeElementFromArray(elementToPass);
            }

        }


    }

    private AbilityBaseClass[] removeElementFromArray(int elementToSkip)
    {
        AbilityBaseClass[] shortenedArray = new AbilityBaseClass[characterAbilityUpdateOrder.Length - 1];

        int iterator = 0;
        for (int i = 0; i < characterAbilityUpdateOrder.Length; i++)
        {
            if (i != elementToSkip)
            {
                shortenedArray[iterator] = characterAbilityUpdateOrder[i];
                iterator++;
            }
        }

        return shortenedArray;
    }

    private void increaseAbilityArrayWithNewElement(AbilityBaseClass abilityToAdd)
    {
        AbilityBaseClass[] temp = new AbilityBaseClass[characterAbilityUpdateOrder.Length + 1];

        for (int i = 0; i < characterAbilityUpdateOrder.Length; i++)
        {
            temp[i] = characterAbilityUpdateOrder[i];
        }

        temp[characterAbilityUpdateOrder.Length] = abilityToAdd;


        characterAbilityUpdateOrder = temp;
    }

    private void OnEditorQuiting()
    {
        ObjectFactory.componentWasAdded -= HandleComponentAdded;
        EditorApplication.quitting -= OnEditorQuiting;
    }

    private void Reset()
    {
        updateCharacterAbilityArray();
    }

    private void OnValidate()
    {
        updateCharacterAbilityArray();
    }

    #endregion
#endif
    private void Awake()
    {
#if UNITY_EDITOR
        //This is ran to remove any null array elements
        removeNullAbilitySlots();
#endif
    }

    //Run the AbilityBaseClass functions in the order defined above
    private void Start()
    {
        for (int i = 0; i < characterAbilityUpdateOrder.Length; i++)
        {
            characterAbilityUpdateOrder[i].abilityStart();
        }
    }
    private void Update()
    {
        for (int i = 0; i < characterAbilityUpdateOrder.Length; i++)
        {
            characterAbilityUpdateOrder[i].abilityUpdate();
        }
    }

    private void LateUpdate()
    {
        for (int i = 0; i < characterAbilityUpdateOrder.Length; i++)
        {
            characterAbilityUpdateOrder[i].abilityLateUpdate();
        }
    }


    public void disableAllAbilities()
    {
        for (int i = 0; i < characterAbilityUpdateOrder.Length; i++)
        {
            characterAbilityUpdateOrder[i].abilityEnabled = false;
        }
    }

    public void enableAllAbilities()
    {
        for (int i = 0; i < characterAbilityUpdateOrder.Length; i++)
        {
            characterAbilityUpdateOrder[i].abilityEnabled = true;
        }
    }


}


