using OOP.Entites;

namespace OOP.Weapons;

class Torch : Weapon
{
    public Torch() : base("Torch", 10)
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
        Console.WriteLine($"Kamu menggunakan {Name}, Mengurangi sanity sebesar 10 point.");
        UseLeft--;
        if (UseLeft <= 0)
        {
            Quantity--;
        }
        Console.WriteLine($"Penggunaan {Name} tersisa: {UseLeft}");
        Finished();
        Lose(player);
    }

    public void TorchEffect(Player player)
    {
        player.effectTorch = true;
    }

}