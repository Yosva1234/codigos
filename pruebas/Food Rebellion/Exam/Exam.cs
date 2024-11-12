using FoodRebellion;


public class Exam
{
    public static IRankings CreateRankings(INode root)
    {
        // Retorne su instancia de IRankings aquí
        return new Ranking(new Node("kak",2));
    }

    public class Ranking : IRankings
    {
        public INode Root { get; set; }

        public Ranking(INode root)
        {
            Root = root;
        }

        public INode Find(Func<INode, bool> query)
        {
            var result = Find(query, Root);
            return result is null ? throw new ArgumentException() : result;
        }

        INode Find(Func<INode, bool> query, INode actualNode)
        {
            if (actualNode is null) return null!;

            if (query(actualNode)) return actualNode;

            var result = Find(query, actualNode.Left);
            if (result is null) result = Find(query, actualNode.Right);

            return result;
        }

        public IEnumerable<INode> GetByLevel(int level)
        {
            List<INode> result = new List<INode>();
            if (level < 1) throw new ArgumentException();
            GetByLevel(Root, 1, level, result);
            if (result.All(x => x is null)) throw new Exception();
            return result.Where(x => x is not null);
        }

        void GetByLevel(INode actualNode, int actualLevel, int level, List<INode> result)
        {
            if (actualLevel == level)
            {
                result.Add(actualNode.Left);
                result.Add(actualNode.Right);
            }

            else
            {
                GetByLevel(actualNode.Left, actualLevel + 1, level, result);
                GetByLevel(actualNode.Right, actualLevel + 1, level, result);
            }
            // return null;
        }

        public void Insert(INode node)
        {
            var result = Find(x => x.Left is not null && x.Right is null || x.Right is not null && x.Left is null);
            node.Parent = result;
            if (result.Left is null) result.Left = node;
            else if (result.Right is null) result.Right = node;
            ReOrder(node, node.Parent);
        }

        void ReOrder(INode insertedNode, INode actualNode)
        {
            if (actualNode is null)
            {
                Root = insertedNode;
                return;
            }

            if (insertedNode.Tastiness > actualNode.Tastiness)
            {
                // swap parents
                insertedNode.Parent = actualNode.Parent;
                actualNode.Parent = insertedNode;

                // parent node left/right child becomes the inserted now
                if (insertedNode.Parent is not null && insertedNode.Parent.Left is not null && insertedNode.Parent.Left == actualNode)
                    insertedNode.Parent.Left = insertedNode;

                else if (insertedNode.Parent is not null && insertedNode.Parent.Right is not null && insertedNode.Parent.Right == actualNode)
                    insertedNode.Parent.Right = insertedNode;

                var insertedLC = insertedNode.Left;
                var insertedRC = insertedNode.Right;


                // swapping children
                if (actualNode.Left != insertedNode)
                {
                    insertedNode.Left = actualNode.Left;
                    insertedNode.Left.Parent = insertedNode;
                    insertedNode.Right = actualNode;
                }

                else if (actualNode.Right != insertedNode)
                {
                    insertedNode.Right = actualNode.Right;
                    insertedNode.Right.Parent = insertedNode;
                    insertedNode.Left = actualNode;
                }

                actualNode.Left = insertedLC;
                actualNode.Right = insertedRC;

                if (actualNode.Left is not null)
                    actualNode.Left.Parent = actualNode;
                if (actualNode.Right is not null)
                    actualNode.Right.Parent = actualNode;

                ReOrder(insertedNode, insertedNode.Parent);
                // insertedNode.Left = actualNode.Left;
                // insertedNode.Right = actualNode.Right;

            }
        }

        public void Remove(string name)
        {
            // Getting to-remove node
            var result = Find(x => x.Name == name, Root);

            // If to-remove node is the Root node we change the Root node to the Root's tasty one
            if (result == Root) Root = result.Tasty;

            // if it is a leaf node we disconnect the result node and finish
            if (result.Left is null && result.Right is null && result.Parent is not null && result.Parent.Left == result)
            {
                result.Parent.Left = null!;
                return;
            }

            if (result.Left is null && result.Right is null && result.Parent is not null && result.Parent.Right == result)
            {
                result.Parent.Right = null!;
                return;
            }

            // Removed node parent becomes tasty node parent
            result.Tasty.Parent = result.Parent;

            if (result.Tasty.Parent is not null)
            {
                if (result.Tasty.Parent.Left == result) result.Tasty.Parent.Left = result.Tasty;
                else if (result.Tasty.Parent.Right == result) result.Tasty.Parent.Right = result.Tasty;
            }

            var toBalanceNode = result.Bland;
            Balance(result.Bland, result.Tasty);
        }

        void Balance(INode toBalanceNode, INode actualNode)
        {

            toBalanceNode.Parent = actualNode;

            // we reached a leaf node
            if (actualNode.Left is null && actualNode.Right is null)
            {
                actualNode.Left = toBalanceNode;
                return;
            }

            // else we need to keep balancing
            var bland = actualNode.Bland;
            var tasty = actualNode.Tasty;

            if (actualNode.Left is not null && actualNode.Left == actualNode.Bland)
            {
                actualNode.Left = toBalanceNode;
                Balance(bland, tasty);
            }

            else if (actualNode.Right is not null && actualNode.Right == actualNode.Bland)
            {
                actualNode.Right = toBalanceNode;
                Balance(bland, tasty);
            }
        }
    }

    public class Node : INode
    {
        public string Name { get; set; }

        public int Tastiness { get; set; }

        public INode? Parent { get; set; }
        public INode? Left { get; set; }
        public INode? Right { get; set; }

        public INode Tasty { get; set; }

        public INode Bland { get; set; }

        public Node(string name, int tastiness)
        {
            (Name, Tastiness) = (name, tastiness);
        }
    }
}