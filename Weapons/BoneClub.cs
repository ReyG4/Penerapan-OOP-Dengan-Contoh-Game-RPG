using OOP.Entites;

namespace OOP.Weapons;

class BoneClub : Weapon
{
    public BoneClub() : base("Bone Club", 40) { DropRate = 10; }

    public override void ShowInfo()
    {
        Console.WriteLine($"Weapon: {Name}, Damage: {Damage}");
        Console.WriteLine("Efek Khusus: Kehilangan 5 Sanity sebagai bayaran damage yang besar.");
    }

    public override void Attack(Player player)
    {
        base.Attack(player);
        player.LossSanity(5);
    }
}