using OOP.Entites;

namespace OOP.Items;

class BandageRoll : Item
{
    public BandageRoll() : base("Bandage Roll", 1) { DropRate = 20; }

    public override void ShowInfo()
    {
        Console.WriteLine($"Item: {Name}");
        Console.WriteLine("Efek: Mengembalikan 25 HP saat digunakan.");
    }

    public override void UseItem(Player player)
    {
        base.UseItem(player);
        player.Heal(25);
    }
}