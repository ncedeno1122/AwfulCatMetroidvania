public interface IResourceSkill<T>
{
    ResourceType ResourceType { get; }
    T SkillCost { get; }

    bool HasEnoughResource(T userResourceAmount);
}