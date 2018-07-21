using Microsoft.VisualStudio.TestTools.UnitTesting;
using PacMan;
using PacMan.Interfaces;

namespace PacMan.Tests
{
    [TestClass()]
    public class MapTests
    {
        static readonly string path = "C:/Users/fedyu/source/repos/pacman/PacMan.Tests/testmap.txt";

        [TestMethod()]
        public void WidhtIs30andHeightIs31()
        {
            Map map = new Map(path);

            int widht = 30;
            int height = 31;

            Assert.AreEqual(height, map.Height);
            Assert.AreEqual(widht, map.Width);
        }

        [TestMethod()]
        public void CloneElementIsTheSame()
        {
            Map map = new Map(path);

            Map clone = (Map)new Map(path).Clone();

            Assert.AreEqual(map, clone);
        }
    }
}