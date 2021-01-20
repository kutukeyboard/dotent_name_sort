using Microsoft.VisualStudio.TestTools.UnitTesting;
using name_sort;
using System.IO;

namespace name_sort
{
  [TestClass]
  public class UnitTest1
  {
    [TestMethod]
    public void getPathTest()
    {
      string getPathExpected = Path.Combine(Directory.GetCurrentDirectory(), "unsorted-names-list.txt");
      Assert.AreEqual(getPathExpected, Program.getPath("unsorted-names-list.txt"));
    }

    [TestMethod]
    public void loadFileTest()
    {
      string path = Path.Combine(Directory.GetCurrentDirectory(), "unsorted-names-list.txt");
      Assert.IsNotNull(Program.loadFile(path));
    }
  }
}
