
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
