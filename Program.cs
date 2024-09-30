using Factory_Method;

class Program
{
    static void Main()
    {
        var educationSystem = new EducationSystem();

        // Загрузка данных из файла
        educationSystem.LoadData("data.txt");

        // Сохранение данных в файл
        educationSystem.SaveData("data.txt");
    }
}
