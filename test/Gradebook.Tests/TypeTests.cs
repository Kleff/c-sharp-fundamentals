namespace GradeBook.Tests
{
    public delegate string WriteLogDelegate(string logMessage);
    
    public class TypeTests
    {

        [Fact]
        public void WriteLogDelegateCnPointToMethod()
        {
            WriteLogDelegate log;
            log = ReturnMessage;

            var result = log("Hello!");
            Assert.Equal("Hello!", result);
        }

        string ReturnMessage(string message)
        {
            return message;
        }

        [Fact]
        public void CSharpCanPassByRef()
        {
            var book1 = GetBook("Book 1");
            GetBookSetNameByRef(ref book1, "New Name");

            Assert.Equal("New Name", book1.Name);

        }

        [Fact]
        public void StringBehaveLikeValueTypes(){
            string name = "Scott";
            var nameUpperCase = MakeUppercase(name);

            Assert.Equal("SCOTT", nameUpperCase);
        }

        private string MakeUppercase(string parameter)
        {
            return parameter.ToUpper();
        }

        private void GetBookSetNameByRef(ref InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        } 
        
        
        [Fact]
        public void CSharpIsPassByValueByDefault()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");

            Assert.Equal("Book 1", book1.Name);
        }

        

        private void GetBookSetName(InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
            book.Name = name;
        } 

        private void SetName(InMemoryBook book, string name)
        {
            book.Name = name;
        }  

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book1, book2);
        }

        [Fact]
        public void TwoVariablesCanReferenceSameObject()
        {
            var book1 = GetBook("Book 1");
            var book2 = book1;

            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));
        }

        InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }
    }
}
    