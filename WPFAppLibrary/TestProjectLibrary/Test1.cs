using ClassLibrary;
namespace TestProjectLibrary
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string surname = "Пришвин";
            string name = "Михаил";
            string patronymic = "Михайлович";
            Assert.AreEqual($"{"Пришвин"} {"Михаил"} {"Михайлович"}", Operations.AddAuthor(surname, name, patronymic), "Ошибка 1");    
        }
        [TestMethod]
        public void TestMethod2()
        {
            string surname = "Пришвин";
            string name = "Михаил";
            string patronymic = "Михайлович";
            Assert.AreEqual($"{"Пришвин"} {"Михаил"} {"Михайлович"}", Operations.AddAuthor(surname, "1", patronymic), "Ошибка 2");
        }
        [TestMethod]
        public void TestMethod3()
        {
            Author _author = new Author();
            string surname = "Пришвин";
            string name = "Михаил";
            string patronymic = "Михайлович";
            _author.Id = 8;
            _author.Surname = surname;
            _author.Name = name;
            _author.Patronymic = patronymic;
            Assert.AreEqual(_author, Operations.AddAuthorModel(_author), "Ошибка 3");
        }
    }

}
