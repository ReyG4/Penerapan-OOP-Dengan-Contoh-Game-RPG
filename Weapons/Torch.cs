using OOP.Entities;

namespace OOP.Weapons;

class Torch : Weapon
{
    public Torch() : base("Torch", 25)
    {
        UseLeft = 3;
        DropRate = 25;
    }
    public override void ShowInfo()
    {
        Console.WriteLine($"Weapon: {Name}, Damage: {Damage}, Penggunaan: {UseLeft}, Jumlah: {Quantity}");
        Console.WriteLine("Efek Khusus: Bisa digunakan untuk mengurangi sanity sebesar 10 point dan akan langsung hancur setelah 3 kali digunakan.");
    }

    public override void UseItem(Player player)
    {
        var existingItem = player.Inventory.FirstOrDefault(
            i => i.Name.Equals(
                Name,
                StringComparison.OrdinalIgnoreCase)
            );
        Console.WriteLine($"Kamu menggunakan {Name}, Mengurangi pengurangan sanity sebesar 10 point.");
        existingItem!.UseLeft--;
        if (existingItem.UseLeft <= 0)
        {
            existingItem.Quantity--;
            if (existingItem.Quantity >= 0)
            {
                existingItem.UseLeft = 3;
            }
        }
        TorchEffect(player);
        Console.WriteLine($"Penggunaan {Name} tersisa: {UseLeft}");
        Finished(player);
        Lose(player);
    }

    public void TorchEffect(Player player)
    {
        player.EffectTorch = true;
    }

}