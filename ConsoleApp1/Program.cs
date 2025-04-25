using System;

public class Buku
{
    public int ID { get; set; }
    public string Judul { get; set; }
    public string Penulis { get; set; }
    public int Tahunterbit { get; set; }
    public string Status { get; set; } = "Dipinjam";

    public virtual void DisplayInfo()
    {
        Console.WriteLine($"ID: {ID}, Judul: {Judul}, Penulis: {Penulis}, Tahun: {Tahunterbit}, Status: {Status}");
    }
}

public class Bukanbukubiasa : Buku
{
    public string Kategori { get; set; }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Kategori: {Kategori}");
    }
}

public class Perpustakaan
{
    public string Nama { get; set; }
    public string Alamat { get; set; }
    public List<Buku> KoleksiBuku { get; set; } = new List<Buku>();

    public void MenambahkanBuku(Buku buku)
    {
        KoleksiBuku.Add(buku);
        Console.WriteLine("Menambahkan Bukuku.");
    }

    public void TampilkanSemua()
    {
        foreach (var buku in KoleksiBuku)
        {
            buku.DisplayInfo();
            Console.WriteLine();
        }
    }

    public void MencariBukuku(string kataKunci)
    {
        var hasil = KoleksiBuku.Where(b => b.Judul.Contains(kataKunci, StringComparison.OrdinalIgnoreCase) || b.ID.ToString() == kataKunci);
        if (hasil.Any())
        {
        foreach(var buku in hasil)
                buku.DisplayInfo();
        }
        else
        {
            Console.WriteLine("Bukuku tidak ditemukan.");
        }
    }

    public void Bukuku(int id)
    {
        var buku = KoleksiBuku.FirstOrDefault(b => b.ID == id);
        if (buku != null)
        {
            Console.Write("Judul bukuku: "); buku.Judul = Console.ReadLine();
            Console.Write("Penulis bukuku: "); buku.Penulis = Console.ReadLine();
            Console.Write("Tahun terbit bukuku: "); buku.Tahunterbit = int.Parse(Console.ReadLine());
            Console.Write("Status bukuku (Tersedia/Dipinjam): "); buku.Status = Console.ReadLine();
            Console.WriteLine("Bukuku berhasil dipinjam.");
        }
        else
        {
            Console.WriteLine("Bukuku tidak ditemukan.");
        }
    }

    public void Menghapusbukuku(int id)
    {
        var buku = KoleksiBuku.FirstOrDefault(b => b.ID == id);
        if (buku != null)
        {
            KoleksiBuku.Remove(buku);
            Console.WriteLine("Bukuku dihapus.");
        }
        else
        {
            Console.WriteLine("Bukuku hiilang.");
        }
    }
}