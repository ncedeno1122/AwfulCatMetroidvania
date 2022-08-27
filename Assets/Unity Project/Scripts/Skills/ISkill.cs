public interface ISkill
{
    bool IsComplete { get; }

    void ActivateSkill();
    void DeactivateSkill();
}