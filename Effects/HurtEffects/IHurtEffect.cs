namespace SuperAutoPets;

public interface IHurtEffect : IEffect
{
    void Apply(FightArgs args);
}

public class EmptyHurtEffect : IHurtEffect
{
    public string EffectLog => string.Empty;

    public void Apply(FightArgs args) { }
}