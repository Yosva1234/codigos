
using filesystem;
namespace MatCom.Exam;
public class Exam
{
    public static IFileSystem CreateFileSystem()
    {
        // Devuelva aquí su instancia de IFileSystem
        return new FileSystem();
    }

    // Borre esta excepción y ponga su nombre como string, e.j.
    // Nombre => "Fulano Pérez Pérez";
    public static string Nombre => "Alejandro Echevarria Brunet";

    // Borre esta excepción y ponga su grupo como string, e.j.
    // Grupo => "C2XX";
    public static string Grupo => "C112";

    public class FileSystem : IFileSystem
    {
        public Folder Root { get; }
        public FileSystem(Folder? root = null)
        {
            Root = root is null ? new Folder("root") : root;
        }
        public void Copy(string origin, string destination)
        {
            string originRoot = GetOriginRoot(origin);
            var originFolder = (Folder)GetFolder(originRoot);
            var address = origin.Split('/', StringSplitOptions.RemoveEmptyEntries);
            var destinationFolder = (Folder)GetFolder(destination);
            File? file = null!;
            Folder? folder = null!;

            if (IsFile(originFolder, address.Last(), ref file))
            {
                var match = destinationFolder.Files.Where(x => x.Name == file.Name).FirstOrDefault();
                var clone = file.Clone();
                clone.Parent = destinationFolder;
                if (match is null) destinationFolder.Files.Add(clone);
                else match.Size = clone.Size;
            }
            else if (IsFolder(originFolder, address.Last(), ref folder))
            {
                var match = destinationFolder.Folders.Where(x => x.Name == folder.Name).FirstOrDefault();
                var clone = folder.Clone();
                clone.Parent = destinationFolder;
                if (match is null) destinationFolder.Folders.Add(clone);
                else Merge(clone, match);
            }

            else throw new ArgumentException($"Specified file or folder {address.Last()} does not exists.");
        }

        string GetOriginRoot(string origin)
        {
            for (int i = origin.Length - 1; i >= 0; i--)
                if (origin[i] == '/') break;
                else origin = origin.Remove(origin.Length - 1);

            return origin;
        }

        bool IsFolder(Folder originFolder, string name, ref Folder folder)
        {
            foreach (var item in originFolder.GetFolders())
                if (item.Name == name)
                {
                    folder = (Folder)item;
                    return true;
                }
            return false;
        }

        bool IsFile(Folder originFolder, string name, ref File file)
        {
            foreach (var item in originFolder.GetFiles())
                if (item.Name == name)
                {
                    file = (File)item;
                    return true;
                }

            return false;
        }

        void Merge(Folder f1, Folder f2)
        {
            // Merging two folders means merge its files 
            foreach (var file in f1.Files)
            {
                var result = f2.Files.Where(x => x.Name == file.Name).FirstOrDefault();
                if (result is null) f2.Files.Add(file);
                else result.Size = file.Size;
            }

            // and its folders
            foreach (var folder in f1.Folders)
            {
                var result = f2.Folders.Where(x => x.Name == folder.Name).FirstOrDefault();
                if (result is null) f2.Folders.Add(folder);
                // if we have two subfolders with the exact same name we merge them
                else Merge(folder, result);
            }
        }

        public void Delete(string path)
        {
            var originRoot = GetOriginRoot(path);
            var originFolder = (Folder)GetFolder(originRoot);
            var address = path.Split('/', StringSplitOptions.RemoveEmptyEntries);
            File file = null!;
            Folder folder = null!;
            if (IsFile(originFolder, address.Last(), ref file))
            {
                file.Parent!.Files.Remove(file);
                file.Parent = null!;
            }
            else if (IsFolder(originFolder, address.Last(), ref folder))
            {
                folder.Folders.Clear();
                folder.Files.Clear();
                folder.Parent!.Folders.Remove(folder);
                folder.Parent = null!;
            }
        }

        public IEnumerable<IFile> Find(FileFilter filter)
        {
            List<File> result = new List<File>();
            Find(Root, result, filter);
            return result;
        }

        void Find(Folder actualFolder, List<File> result, FileFilter filter)
        {
            foreach (var file in actualFolder.Files)
                if (filter(file))
                    result.Add(file);

            foreach (var folder in actualFolder.Folders)
                Find(folder, result, filter);
        }

        public IFile GetFile(string path)
        {
            var address = path.Split('/', StringSplitOptions.RemoveEmptyEntries);
            if (address.Length == 0) throw new ArgumentException("Invalid path.");
            return GetFile(Root, 0, address);
        }

        File GetFile(Folder actualFolder, int index, string[] address)
        {
            if (index == address.Length - 1)
                foreach (var file in actualFolder.Files)
                    if (file.Name == address[index])
                        return file;

            foreach (var folder in actualFolder.Folders)
            {
                if (folder.Name == address[index])
                    return GetFile(folder, index + 1, address);
            }

            throw new ArgumentException();
        }

        public IFolder GetFolder(string path)
        {
            var address = path.Split('/', StringSplitOptions.RemoveEmptyEntries);
            if (address.Length == 0) return Root;
            return GetFolder(Root, 0, address);
        }

        Folder GetFolder(Folder actualFolder, int index, string[] address)
        {
            if (index == address.Length)
                return actualFolder;

            foreach (var folder in actualFolder.Folders)
            {
                if (folder.Name == address[index])
                    return GetFolder(folder, index + 1, address);
            }


            throw new ArgumentException($"Specified folder \"{address.Last()}\" folder does not exists.");
        }

        public IFileSystem GetRoot(string path)
        {
            var folder = (Folder)GetFolder(path);
            return new FileSystem(folder);
        }

        public void Move(string origin, string destination)
        {
            Copy(origin, destination);
            Delete(origin);
        }
    }

    public class Folder : IFolder
    {
        public string Name { get; }

        public Folder? Parent { get; set; }

        public List<File> Files { get; }

        public List<Folder> Folders { get; }

        public Folder(string name)
        {
            this.Name = name;
            Files = new List<File>();
            Folders = new();
        }

        public IFile CreateFile(string name, int size)
        {
            var file = new File(name, size);
            file.Parent = this;
            Files.Add(file);
            return file;
        }

        public IFolder CreateFolder(string name)
        {
            var folder = new Folder(name);
            folder.Parent = this;
            Folders.Add(folder);
            return folder;
        }

        public IEnumerable<IFile> GetFiles()
        {
            return Files.OrderBy(x => x.Name);
        }

        public IEnumerable<IFolder> GetFolders()
        {
            return Folders.OrderBy(x => x.Name);
        }

        public int TotalSize()
        {
            int result = 0;
            foreach (var file in Files)
                result += file.Size;

            foreach (var folder in Folders)
                result += folder.TotalSize();

            return result;
        }

        public Folder Clone()
        {
            var folder = new Folder(this.Name);

            foreach (var file in Files)
                folder.Files.Add(file.Clone());

            foreach (var _folder in Folders)
                folder.Folders.Add(_folder.Clone());

            return folder;
        }
    }

    public class File : IFile
    {
        public int Size { get; set; }

        public string Name { get; }

        public Folder? Parent { get; set; }

        public File(string name, int size)
        {
            (Name, Size) = (name, size);
        }

        public File Clone()
        {
            return new File(Name, Size);
        }
    }
}