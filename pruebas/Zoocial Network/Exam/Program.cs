using ZoocialNetwork;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        // Crear Red Zoocial
        var net = Exam.CreateZoocialNetwork();

        // Agregar usuarios a la red
        var user1 = net.AddUser("Pedro", 15, "Hombre", "Perro");
        var user2 = net.AddUser("Laura", 15, "Mujer", "Gato");
        var user3 = net.AddUser("Pablo", 13, "Hombre", "León");
        var user4 = net.AddUser("Lola", 18, "Mujer", "Perro");

        // Consultar información de un usuario
        var user = net.GetUserInfo("Pedro");
        Debug.Assert(user.Name == "Pedro" && user.Age == user1.Age && user.Gender == user1.Gender && user.FavouritePet == user1.FavouritePet);

        List<IUser> newUsers = new List<IUser>();
        // Agregar 16 usuarios nuevos
        string[] pets = {"Perro", "Gato", "León", "Mono"};
        string[] genders = {"Mujer", "Hombre"};
        for(int i = 0; i < 16; i++)
        {
            var nuser = net.AddUser($"Usuario{i+1}", 14, genders[i%2], pets[i%4]);
            newUsers.Add(nuser);
        }

        // Conectando Usuarios
        for(int i = 0; i < 4; i++)
        {
            net.ConnectUsers("Pedro", newUsers[i].Name);
        }

        for(int i = 4; i < 8; i++)
        {
            net.ConnectUsers("Laura", newUsers[i].Name);
        }

        for(int i = 8; i < 12; i++)
        {
            net.ConnectUsers("Pablo", newUsers[i].Name);
        }

        for(int i = 12; i < 16; i++)
        {
            net.ConnectUsers("Lola", newUsers[i].Name);
        }

        net.ConnectUsers("Pedro", "Lola");

        // Consultar la red de un usuario
        var pedroNet = net.GetUserNetwork("Pedro");
        Debug.Assert(pedroNet.Count() == 10);

        var lauraNet = net.GetUserNetwork("Laura");
        Debug.Assert(lauraNet.Count() == 5);

        var pabloNet = net.GetUserNetwork("Pablo");
        Debug.Assert(pabloNet.Count() == 5);

        // Consultar en la red de Pedro cuántos usuarios tienen 
        // Perro como mascota favorita
        var pedroNetDog = net.GetUserNetwork("Pedro", x => x.FavouritePet == "Perro");
        Debug.Assert(pedroNetDog.Count() == 4);

        // Consultar Información de un usuario
        var nUser = net.GetUserInfo("Usuario1");
        Debug.Assert(nUser.Name == "Usuario1" && nUser.Age == 14 && nUser.Gender == newUsers[0].Gender && nUser.FavouritePet == newUsers[0].FavouritePet);
        
        // Consultar MinTshirts
        int minTshirts = net.MinTshirts();
        Debug.Assert(minTshirts == 10);

        // Consultar Número de grupos
        int nGroups = net.NumberOfGroups();
        Debug.Assert(nGroups == 3);
    }
}