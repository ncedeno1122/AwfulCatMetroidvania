using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Acts as a TypeObject for a PlayerController, with data and properties
/// that make it for Achik.
/// </summary>
public class AchikComponent : MonoBehaviour
{
    public Dictionary<SkillInput, ISkill> SkillDictionary { get; private set; }

    public AttiniyComponent AttiniyComponent;
    public AchikSpiritFormComponent AchikSpiritFormComponent;
    public BlessComponent BlessComponent;
    public PrayComponent PrayComponent;
    public ToggleAttiniyBasicComponent ToggleAttiniyBasicComponent;

    private void OnValidate()
    {
        if (!AttiniyComponent) AttiniyComponent = GetComponent<AttiniyComponent>();
        if (!BlessComponent) BlessComponent = GetComponent<BlessComponent>();
        if (!AchikSpiritFormComponent) AchikSpiritFormComponent = GetComponent<AchikSpiritFormComponent>();
        if (!PrayComponent) PrayComponent = GetComponent<PrayComponent>();
        if (!ToggleAttiniyBasicComponent) ToggleAttiniyBasicComponent = GetComponent<ToggleAttiniyBasicComponent>();
    }

    private void Awake()
    {
        if (!AttiniyComponent) AttiniyComponent = GetComponent<AttiniyComponent>();
        if (!BlessComponent) BlessComponent = GetComponent<BlessComponent>();
        if (!AchikSpiritFormComponent) AchikSpiritFormComponent = GetComponent<AchikSpiritFormComponent>();
        if (!PrayComponent) PrayComponent = GetComponent<PrayComponent>();
        if (!ToggleAttiniyBasicComponent) ToggleAttiniyBasicComponent = GetComponent<ToggleAttiniyBasicComponent>();
    }

    private void Start()
    {
        SkillDictionary = new()
        {
            { new SkillInput(MoveInputDirection.UP, InputActivationType.SINGLETAP, true), BlessComponent },
            { new SkillInput(MoveInputDirection.UP, InputActivationType.HOLD, true), AchikSpiritFormComponent },
            { new SkillInput(MoveInputDirection.UP, InputActivationType.HOLD, false), AchikSpiritFormComponent },
            { new SkillInput(MoveInputDirection.DOWN, InputActivationType.HOLD, true), PrayComponent },
            { new SkillInput(MoveInputDirection.NEUTRAL, InputActivationType.SINGLETAP, true), ToggleAttiniyBasicComponent }
            //{ new SkillInput(MoveInputDirection.DOWN, InputActivationType.DOUBLETAP, false), FallingStab },
            //{ new SkillInput(MoveInputDirection.HORIZONTAL, InputActivationType.DOUBLETAP, true), KnifeThrowComponent },
            //{ new SkillInput(MoveInputDirection.HORIZONTAL, InputActivationType.DOUBLETAP, false), KnifeThrowComponent },
            //{ new SkillInput(MoveInputDirection.HORIZONTAL, InputActivationType.SINGLETAP, true), EnergyBallComponent },
            //{ new SkillInput(MoveInputDirection.HORIZONTAL, InputActivationType.SINGLETAP, false), EnergyBallComponent },
        };
    }

    // + + + + | Functions | + + + + 

    public void HandleInput(SkillInput skillInput)
    {
        var dictResult = SkillDictionary.TryGetValue(skillInput, out ISkill skillComponent);
        if (dictResult && skillComponent != null)
        {
            skillComponent.ActivateSkill();
            Debug.Log($"! - Handling input for {skillComponent} | {skillComponent.GetType()}");
        }
    }
}
