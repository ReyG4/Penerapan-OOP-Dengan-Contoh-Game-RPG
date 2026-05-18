using OOP.Interface;

namespace OOP.Entites;

class Enemy(string name, int hp, int damage) : ICanAttack, ICanDamageable
{
    private int _hp = hp;
    private int _damage = damage;
    public string Name { get; set; } = name;
    public int Hp => _hp;
    public int Damage => _damage;

    public virtual void InfoEnemy()
    {
        Console.WriteLine($"Enemy: {Name}");
        Console.WriteLine($"HP: {Hp}");
        Console.WriteLine($"Damage: {_damage}");
        Console.WriteLine("Kemampuan Spesial: Tidak ada");
    }

    public virtual void Attack(int damage)
    {
        if (damage < 0) return;
        Console.WriteLine($"{Name} menyerang dengan damage {damage}");
    }

    public virtual void TakeDamage(int damage)
    {
        if (damage < 0) return;
        _hp -= damage;
        Console.WriteLine($"{Name} terkena {damage} damage, sisa HP {_hp}");
    }

    public void Heal(int heal)
    {
        if (heal < 0) return;
        _hp += heal;
        if (_hp > 100) _hp = 100;
        Console.WriteLine($"{Name} memulihkan HP sebesar {heal}");
    }
}