namespace OOP.Entities;

class DungeonGuard : Enemy
{
    bool braceSkill = false;
    bool usedSkill = false;
    public DungeonGuard() : base("Dungeon Guard", 150, 25) { }

    public override void InfoEnemy()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"HP: {Hp}");
        Console.WriteLine($"Damage: {Damage}");
        Console.WriteLine("Mempunyai skill BRACE dimana dia dapat mengurangi setengah dari damage yang dia terima");
    }

    public void SpesialAbility()
    {
        Random rnd = new();
        bool activateSkill = rnd.Next(0, 9) < 4;
        if (activateSkill && !braceSkill)
        {
            braceSkill = true;
            Console.WriteLine($"{Name} mengaktifkan skill BRACE");
        }
    }

    public override void Attack()
    {
        if (Damage < 0) return;
        Console.WriteLine($"{Name} Menyerang dengan pedangnya! Memberikan {Damage} damage");
    }

    public override void TakeDamage(int damage)
    {
        if (braceSkill && !usedSkill)
        {
            damage /= 2;
            Console.WriteLine("BRACE aktif");
            base.TakeDamage(damage);
            usedSkill = true;
        }
        else
        {
            base.TakeDamage(damage);
        }
    }
}