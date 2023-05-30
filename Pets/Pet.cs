using System;

namespace SuperAutoPets;

public abstract class Pet : ICloneable
{
    public int Tier { get; protected set; }
    public int Level { get; protected set; } = 1;
    public int XP { get; protected set; } = 1;

    public int HP { get; protected set; }
    public int DMG { get; protected set; }

    public bool IsDead { get => HP < 1; }

    public void Merge(Pet m)
    {
        int hp = this.HP > m.HP ? this.HP : m.HP;
        int atk = this.DMG > m.DMG ? this.DMG : m.DMG;

        this.HP = hp + 1;
        this.DMG = atk + 1;
        levelUp(m.XP);
    }

    private void levelUp(int xp = 1)
    {
        if (this.Level == 3)
            return;

        this.XP += xp;

        if (this.XP >= 3 && this.Level == 1)
        {
            this.XP -= 3;
            this.Level++;
        }

        if (this.XP >= 4 && this.Level == 2)
        {
            this.XP = 4;
            this.Level++;
        }
    }

    public virtual void OnAttack(FightArgs args)
    {
        var switched = args.Switch();
        args.EnemyMachine.OnHurt(switched);
        this.OnHurt(args);
    }

    public virtual void OnHurt(FightArgs args)
    {
        this.HP -= args.EnemyMachine.DMG;
    }

    public virtual void OnSell(SellArgs args) { }

    public Pet Clone()
    {
        return (Pet)this.MemberwiseClone();
    }

    object ICloneable.Clone()
    {
        return Clone();
    }
}

public interface PetStrategy
{
    IAttackEffect AttackEffect { get; }
    ISellEffect SellEffect { get; }
    IHurtEffect HurtEffect { get; }

    IShop ShopStartEffect { get; }
    IShop ShopEndEffect { get; }
}