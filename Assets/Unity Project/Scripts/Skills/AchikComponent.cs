using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Describes the input for a Skill to be activated!
/// </summary>
public struct SkillInput
{
    public MoveInputDirection direction;
    public InputActivationType activationType;
    public bool isGrounded;

    public SkillInput(MoveInputDirection direction, InputActivationType activationType, bool isGrounded)
    {
        this.direction = direction;
        this.activationType = activationType;
        this.isGrounded = isGrounded;
    }

    public override bool Equals(object obj)
    {
        if (obj == null || obj.GetType() != this.GetType()) return false;
        SkillInput objInput = (SkillInput) obj;
        return this.direction == objInput.direction &&
               this.activationType == objInput.activationType &&
               this.isGrounded == objInput.isGrounded;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}

public class AchikComponent : MonoBehaviour
{
    public Dictionary<SkillInput, ISkill> SkillDictionary { get; private set; }

    public AttiniyComponent AttiniyComponent;
    public BlessComponent BlessComponent;
    public AchikSpiritFormComponent AchikSpiritFormComponent;

    private void OnValidate()
    {
        if (!AttiniyComponent) AttiniyComponent = GetComponent<AttiniyComponent>();
        if (!BlessComponent) BlessComponent = GetComponent<BlessComponent>();
        if (!AchikSpiritFormComponent) AchikSpiritFormComponent = GetComponent<AchikSpiritFormComponent>();
    }

    private void Awake()
    {
        if (!AttiniyComponent) AttiniyComponent = GetComponent<AttiniyComponent>();
        if (!BlessComponent) BlessComponent = GetComponent<BlessComponent>();
        if (!AchikSpiritFormComponent) AchikSpiritFormComponent = GetComponent<AchikSpiritFormComponent>();
    }

    private void Start()
    {
        SkillDictionary = new()
        {
            { new SkillInput(MoveInputDirection.UP, InputActivationType.SINGLETAP, true), BlessComponent },
            { new SkillInput(MoveInputDirection.UP, InputActivationType.DOUBLETAP, true), AchikSpiritFormComponent },
            { new SkillInput(MoveInputDirection.UP, InputActivationType.DOUBLETAP, false), AchikSpiritFormComponent },
            //{ new SkillInput(MoveInputDirection.DOWN, InputActivationType.SINGLETAP, true), PrayerComponent },
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
