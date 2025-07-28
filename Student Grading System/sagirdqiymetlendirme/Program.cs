List<string> sagirdisim = new List<string>();
List<string> fenadlar = new List<string>();
Dictionary<string, Dictionary<string, int>> qiymetler = new Dictionary<string, Dictionary<string, int>>();

string sagirdata = "sagirdata.txt";
string fendata = "fendata.txt";
string qiymetdata = "qiymetdata.txt";

Console.WriteLine("Sagird Qiymetlendirme proqramina xos gelmisiniz!");

if (File.Exists(sagirdata) && File.Exists(fendata))
{
    string[] sagirdler = File.ReadAllLines(sagirdata);
    string[] fennler = File.ReadAllLines(fendata);

    int say = Math.Min(sagirdler.Length, fennler.Length);

    for (int i = 0; i < say; i++)
    {
        sagirdisim.Add(sagirdler[i]);
        fenadlar.Add(fennler[i]);
    }
}

if (File.Exists(qiymetdata))
{
    string[] qiymetXetleri = File.ReadAllLines(qiymetdata);
    foreach (string xett in qiymetXetleri)
    {
        string[] hisse = xett.Split(',');

        if (hisse.Length == 3)
        {
            string sagird = hisse[0];
            string fenn = hisse[1];
            int qiymet;

            if (int.TryParse(hisse[2], out qiymet))
            {
                if (!qiymetler.ContainsKey(sagird))
                    qiymetler[sagird] = new Dictionary<string, int>();

                qiymetler[sagird][fenn] = qiymet;
            }
        }
    }
}


double OrtaBal(string sagirdAdi)
{
    if (qiymetler.ContainsKey(sagirdAdi))
    {
        var fennler = qiymetler[sagirdAdi];

        if (fennler.Count == 0)
            return 0;

        double cem = fennler.Values.Sum();
        int say = fennler.Count;

        return cem / say;
    }

    return 0;
}
//----------------------------------------------------
void sagirdpuanla()
{
    sagirdlerebaxmaq();
    Console.Write("Istediyiniz sagirdin ID-ni girin: ");
    int sagirdidler = Convert.ToInt32(Console.ReadLine());

    fenlerebaxmaq();
    Console.Write("Istediyiniz Fenn ID-ni girin: ");
    int fenidler = Convert.ToInt32(Console.ReadLine());

    if (sagirdidler <= 0 || sagirdidler > sagirdisim.Count || fenidler <= 0 || fenidler > fenadlar.Count)
    {
        Console.WriteLine("Sehv ID-lər!");
        return;
    }

    string sagird = sagirdisim[sagirdidler - 1];
    string fenn = fenadlar[fenidler - 1];

    Console.Write("Qiymeti daxil edin(0-100)(Tam Qiymet): ");
    int qiymet = Convert.ToInt32(Console.ReadLine());
    qiymet = Math.Abs(qiymet);

    if (qiymet > 100)
    {
        Console.WriteLine("Sehv qiymet!");
        return;
    }

    if (!qiymetler.ContainsKey(sagird))
        qiymetler[sagird] = new Dictionary<string, int>();

    qiymetler[sagird][fenn] = qiymet;

    Console.WriteLine($"{sagird} ucun {fenn} fennine qiymet: {qiymet} qeyd olundu.");
    qiymetleriYaddaSaxla();
}

void qiymetlerebax()
{
    foreach (var sagird in qiymetler)
    {
        Console.WriteLine($"\n--- {sagird.Key} ---");
        foreach (var fenn in sagird.Value)
        {
            Console.WriteLine($"{fenn.Key}: {fenn.Value}");
        }
        double ortalama = OrtaBal(sagird.Key);
        Console.WriteLine($"Orta bal: {ortalama:0.00}");

    }
}

void qiymetleriYaddaSaxla()
{
    List<string> yazilacaq = new List<string>();

    foreach (var sagird in qiymetler)
    {
        foreach (var fenn in sagird.Value)
        {
            yazilacaq.Add($"{sagird.Key},{fenn.Key},{fenn.Value}");
        }
    }

    File.WriteAllLines(qiymetdata, yazilacaq);
}



//----------------------------------------------------

void fensil()
{
    fenlerebaxmaq();
    Console.Write("Silmek istediginiz fennin ID: ");
    int id = Convert.ToInt32(Console.ReadLine());

    if (id > 0 && id <= fenadlar.Count)
    {
        fenadlar.RemoveAt(id - 1);
        File.WriteAllLines(fendata,fenadlar);
    }
    else
    {
        Console.WriteLine("Sehv id girdiniz!");
        return;
    }
}

void fenlerebaxmaq()
{
    Console.WriteLine("--------------");
    Console.WriteLine("ID - Fenn");

    for (int i = 0; i < fenadlar.Count; i++)
    {
        Console.WriteLine($"{i + 1}.{fenadlar[i]}");
    }
}

void fenelaveetmek()
{
    Console.Write("Elave etmek istediginiz fennin adi: ");
    string fenadi = Console.ReadLine();

    fenadlar.Add(fenadi);
    File.WriteAllLines(fendata, fenadlar);
}

//---------------------------------------------------------------------------

void sagirdsil()
{
    sagirdlerebaxmaq();
    Console.Write("Silmek istediginiz sagirdin ID: ");
    int id = Convert.ToInt32(Console.ReadLine());

    if (id > 0 && id <= sagirdisim.Count)
    {
        sagirdisim.RemoveAt(id - 1);
        File.WriteAllLines(sagirdata,sagirdisim);
    }
    else
    {
        Console.WriteLine("Sehv id girdiniz!");
        return;
    }
}

void sagirdlerebaxmaq()
{
    Console.WriteLine("--------------");
    Console.WriteLine("ID - Ad - Soyad");

    for (int i = 0; i < sagirdisim.Count; i++)
    {
        Console.WriteLine($"{i + 1}.{sagirdisim[i]}");
    }
}

void sagirdelaveetmek()
{
    Console.Write("Elave etmek istediginiz sagirdin adi: ");
    string adi = Console.ReadLine();
    Console.Write("Elave etmek istediginiz sagirdin soyadi: ");
    string soyad = Console.ReadLine();

    string tamad = adi + " " + soyad;
    sagirdisim.Add(tamad);
    File.WriteAllLines(sagirdata, sagirdisim);
}

//----------------------------------------------------------------------

do
{
    Console.WriteLine("--------------");
    Console.WriteLine("1-Sagird Menu \n2-Fenn Menu \n3-Qiymetlendirme Menu \n4-Baglamaq");
    Console.WriteLine("--------------");
    Console.Write("ID(1-4): ");
    int id = Convert.ToInt32(Console.ReadLine());

    if (id == 1)
    {
        sagirdmenyu();
    }
    else if (id == 2)
    {
        fennmenyu();
    }
    else if (id == 3)
    {
        qiymetmenyu();
    }
    else if (id == 4)
    {
        break;
    }
    else
    {
        Console.WriteLine("Sehv ID!");
        return;
    }

} while (true);

void sagirdmenyu()
{
    Console.WriteLine("1-Sagirdler \n2-Sagird Elave Et \n3-Sagird Sil \n4-Esas menyu");
    Console.Write("ID(1-4): ");
    int sagirdid = Convert.ToInt32(Console.ReadLine());
    if (sagirdid == 1)
    {
        sagirdlerebaxmaq();
    }
    else if (sagirdid == 2)
    {
        sagirdelaveetmek();
    }
    else if (sagirdid == 3)
    {
        sagirdsil();
    }
    else if (sagirdid == 4)
    {
        return;
    }
    else
    {
        Console.WriteLine("Sehv ID!");
    }
}

void qiymetmenyu()
{
    Console.WriteLine("1-Qiymetlere Bax \n2-Qiymet Elave Et \n3-Esas menyu");
    Console.Write("ID(1-3): ");
    int qiymetid = Convert.ToInt32(Console.ReadLine());
    if (qiymetid == 1)
    {
        qiymetlerebax();
    }
    else if (qiymetid == 2)
    {
        sagirdpuanla();
    }
    else if (qiymetid == 3)
    {
        return;
    }
    else
    {
        Console.WriteLine("Sehv ID!");
    }
}

void fennmenyu()
{
    Console.WriteLine("1-Fennler \n2-Fenn Elave Et \n3-Fenn Sil \n4-Esas menyu");
    Console.Write("ID(1-4): ");
    int fenid = Convert.ToInt32(Console.ReadLine());
    if (fenid == 1)
    {
        fenlerebaxmaq();
    }
    else if (fenid == 2)
    {
        fenelaveetmek();
    }
    else if (fenid == 3)
    {
        fensil();
    }
    else if (fenid == 4)
    {
        return;
    }
    else
    {
        Console.WriteLine("Sehv ID!");
    }
}



