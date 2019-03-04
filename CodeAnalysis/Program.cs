using Microsoft.CodeAnalysis.CSharp;
using System;
using Microsoft.CodeAnalysis;

namespace CodeAnalysis
{
  class Program
  {
    static void Main(string[] args)
    {
      var tree = CSharpSyntaxTree.ParseText(@"
using System;

Class Foo
{
  void Bar(int x)
  {
  }
}
");
      //var mscorlib = new MetadataFileReference(typeof(object).Assembly.Location);

      var options = new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary);

      //var comp = CSharpCompilation.Create("Demo").AddSyntaxTrees(tree).AddReferences(mscorlib).WithOptions(options);
      var comp = CSharpCompilation.Create("Demo").AddSyntaxTrees(tree).WithOptions(options);

      var res = comp.Emit("Demo.dll");

      Console.ReadKey();
    }
  }
}
