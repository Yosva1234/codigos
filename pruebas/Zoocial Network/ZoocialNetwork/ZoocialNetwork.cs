namespace ZoocialNetwork
{
    public interface IUser
    {
        string Name {get;}
        int Age {get;}
        string Gender {get;}
        string FavouritePet {get;}
    }

    public interface INetwork
    {
        IUser AddUser(string name, int age, string gender, string favouritePet);
        void ConnectUsers(string username1, string username2);

        IUser GetUserInfo(string username);
        IEnumerable<IUser> GetUserNetwork(string username);
        IEnumerable<IUser> GetUserNetwork(string username, Func<IUser,bool> filter);

        int MinTshirts();
        int NumberOfGroups();
    }
}


