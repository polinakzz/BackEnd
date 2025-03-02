namespace Lab12._1.Model
{
    public class Student
    {
        public int Id { get; set; }  // Уникальный идентификатор студента
        public string Name { get; set; } = string.Empty;  // Имя студента
        public int Age { get; set; }  // Возраст
        public string Group { get; set; } = string.Empty;  // Группа
    }
}