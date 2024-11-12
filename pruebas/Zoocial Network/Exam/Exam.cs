using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using ZoocialNetwork;

public class Exam
{
    public static INetwork CreateZoocialNetwork()
    {
        // Devuelva aquí su instancia de INetwork
        return new Network();
    }

    public class Network : INetwork
    {
        List<User> Users { get; set; }

        int Groups { get; set; }
        int MinTShirts { get; set; }

        public Network()
        {
            Users = new List<User>();
            Groups = 0;
            MinTShirts = 0;
        }

        public IUser AddUser(string name, int age, string gender, string favouritePet)
        {
            var user = new User(name, age, gender, favouritePet);
            Users.Add(user);
            return user;
        }

        public void ConnectUsers(string username1, string username2)
        {
            var user1 = (User)GetUserInfo(username1);
            var user2 = (User)GetUserInfo(username2);
            AddFriend(user1, user2);
        }

        void AddFriend(User user1, User user2)
        {
            if (!user1.Friends.Contains(user2))
                user1.Friends.Add(user2);
            if (!user2.Friends.Contains(user1))
                user2.Friends.Add(user1);

            var exclusiveFriendsOfUser1 = user1.Friends.Where(x => !user2.Friends.Contains(x) && x != user2).ToList();
            var exclusiveFriendsOfUser2 = user2.Friends.Where(x => !user1.Friends.Contains(x) && x != user1).ToList();

            foreach (var friendOfUser1 in exclusiveFriendsOfUser1)
            {
                AddFriend(friendOfUser1, user2);
            }
            foreach (var friendOfUser2 in exclusiveFriendsOfUser2)
            {
                AddFriend(friendOfUser2, user1);
            }
        }

        public IUser GetUserInfo(string username)
        {
            var match = Users.Where(x => x.Name == username).FirstOrDefault();
            return match is null ? throw new ArgumentException() : match;
        }

        public IEnumerable<IUser> GetUserNetwork(string username)
        {
            var user = (User)GetUserInfo(username);
            foreach (var friend in user.Friends)
                yield return friend;

            yield return user;
        }

        public IEnumerable<IUser> GetUserNetwork(string username, Func<IUser, bool> filter)
        {
            var user = (User)GetUserInfo(username);
            foreach (var friend in user.Friends)
                if (filter(friend))
                    yield return friend;

            yield return user;
        }

        public int MinTshirts()
        {
            NumberOfGroups();
            return MinTShirts + 1;
        }

        public int NumberOfGroups()
        {
            int count = 0;
            foreach (var user in Users)
            {
                if (!user.Taken)
                {
                    var group = Users.Where(x => user.Friends.Contains(x)).ToList();
                    if (group.Count is not 0) count++;
                    this.MinTShirts = Math.Max(MinTShirts, group.Count);
                    foreach (var groupedUser in group)
                    {
                        groupedUser.Taken = true;
                    }
                }
            }
            
            foreach (var user in Users)
                user.Taken = false;

            return count;
        }

    }
    public class User : IUser
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string FavouritePet { get; set; }

        public bool Taken { get; set; }

        public List<User> Friends { get; set; }

        public User(string name, int age, string gender, string favouritePet)
        {
            (Name, Age, Gender, FavouritePet, Friends) = (name, age, gender, favouritePet, new List<User>());
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}