
using MongoDB.Driver;
using StudentManagementAPI.Database;
using StudentManagementAPI.Models;

namespace StudentManagementAPI.Services
{
    public class StudentService : IStudentService
    {
        private readonly IMongoCollection<Student> _students;
        public StudentService(IMongoDbClient mongoDbClient)
        {
            
            _students = mongoDbClient.GetCollection<Student>();
        }
        public Student Create(Student student)
        {
            student.Id = Guid.NewGuid().ToString();
            _students.InsertOne(student);
            return student;
        }

        public List<Student> Get()
        {
            return _students.Find(student => true).ToList();
        }

        public Student Get(string id)
        {
            return _students.Find(student => student.Id == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _students.DeleteOne(student => student.Id == id);
        }

        public void Update(Student student)
        {
            var std = Get(student.Id);
            if (std == null) throw new Exception($"Student with id {student.Id} not found");
            _students.ReplaceOne(std => std.Id == student.Id, student);
        }

    }
}
