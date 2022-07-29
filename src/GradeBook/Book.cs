

namespace GradeBook
{

    public class NamedObject
    {
        public NamedObject(string name)
        {
            Name = name;
        }

        public string Name {get; set;}
    }

    public abstract class Book: NamedObject, IBook
    {
        protected Book(string name) : base(name)
        {
        }

        public abstract void AddGrade(double grade);
        public abstract Stats GetStats();
    }

    public interface IBook
    {
        void AddGrade(double grade);
        Stats GetStats();
        string Name {get;}
    }

    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
        }

        public override void AddGrade(double grade)
        {
            using(var writer = File.AppendText($"{Name}.txt"))
            {
                writer.WriteLine(grade);
            }
            
        }

        public override Stats GetStats()
        {
            var result = new Stats();

            using(var reader = File.OpenText($"{Name}.txt"))
            {
                var line = reader.ReadLine();
                while(line != null)
                {
                    result.Add(double.Parse(line));
                    line = reader.ReadLine();
                }

            }
            return result;
        }
    }

    public class InMemoryBook : Book
    {
        private List<double> grades;

        public InMemoryBook(string name) : base(name)
        {
            grades = new List<double>();
            Name = name;
        }

        public override void AddGrade(double grade)
        {
            grades.Add(grade);
        }

        public override Stats GetStats(){
            var result = new Stats();

            foreach(var grade in grades){
                result.Add(grade);
            }

            return result;
        }
    }
}