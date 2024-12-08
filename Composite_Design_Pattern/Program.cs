// Tạo tệp tin
using System.Text.Json.Serialization;

IFileSystemComponent file1 = new File("file1.txt");
IFileSystemComponent file2 = new File("file2.txt");

// Tạo thư mục và thêm tệp vào thư mục
IFileSystemComponent directory1 = new Directory("Folder1");
//directory1.Add(file1);
//directory1.Add(file2);

// Tạo thư mục con và thêm thư mục con vào thư mục gốc
IFileSystemComponent directory2 = new Directory("Folder2");
IFileSystemComponent file3 = new File("file3.txt");
//directory2.Add(file3);
//directory1.Add(directory2);

// Hiển thị cấu trúc thư mục
directory1.Display("");

[JsonDerivedType(typeof(Directory), nameof(Directory))]

public interface IFileSystemComponent
{
    void Display(string indent);
}

public class File : IFileSystemComponent
{
    public string Name { get; set; }

    public File(string name)
    {
        Name = name;
    }

    public void Display(string indent)
    {
        Console.WriteLine($"{indent}File: {Name}");
    }
}

public class Directory : IFileSystemComponent
{
    public string Name { get; set; }
    private List<IFileSystemComponent> _children = new List<IFileSystemComponent>();

    public Directory(string name)
    {
        Name = name;
    }

    public void Add(IFileSystemComponent component)
    {
        _children.Add(component);
    }

    public void Remove(IFileSystemComponent component)
    {
        _children.Remove(component);
    }

    public void Display(string indent)
    {
        Console.WriteLine($"{indent}Directory: {Name}");
        foreach (var component in _children)
        {
            component.Display(indent + "  ");
        }
    }
}

