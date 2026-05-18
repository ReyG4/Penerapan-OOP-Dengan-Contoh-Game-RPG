using OOP.Entites;
using OOP.Interface;

namespace OOP.Items;

class Item(string name, int useLeft) : IUseable
{
    public string Name { get; set; } = name;
    public int UseLeft { get; set; } = useLeft;
    public int Quantity { get; set; } = 1;
    public int DropRate { get; set; } = 0;

    public virtual void ShowInfo()
    {
        Console.WriteLine($"Item: {Name}");
        Console.WriteLine("Efek: Tidak ada");
    }

    public virtual void UseItem(Player player)
    {
        Console.WriteLine($"Kamu menggunakan {Name}.");
        Quantity--;
        UseLeft--;
        Console.WriteLine($"{Name} tersisa: {Quantity} dengan penggunaan tersisa: {UseLeft}");
        Finished();
        Lose(player);
    }

    public virtual void Finished()
    {
        if (UseLeft <= 0)
        {
            Console.WriteLine($"Kamu sudah kehabisan penggunaan {Name}.");
        }
    }

    public virtual void Lose(Player player)
    {
        if (Quantity <= 0)
        {
            Console.WriteLine($"{Name} sudah habis dari inventory mu.");
            player.Inventory.Remove(this);
        }
    }


}