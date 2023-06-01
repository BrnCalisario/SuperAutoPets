namespace SuperAutoPets;

public interface IAttackEffect : IEffect
{
    void Apply(FightArgs args);
}

public class EmptyAttackEffect : IAttackEffect
{
    public string EffectLog => string.Empty;

    public void Apply(FightArgs args) { }
}