namespace ConsoleApp
{
    internal class Program
    {

        private static readonly MainLogic helper = new MainLogic();

        static void Main(string[] args)
        {
            Console.WriteLine("1. Выборка всех данных из таблицы Employee, стоящей в схеме базы данных на стороные «один»");
            Console.WriteLine("ID || Имя || Фамилия");
            foreach (var item in helper.getEmployee())
            {
                Console.WriteLine($"{item.id} || {item.name} || {item.surname}");
            }
            Console.WriteLine("------------------------------------------------------");

            Console.WriteLine("2. Выборку данных из таблицы Employee, стоящей в схеме базы данных нас стороне отношения «один», отфильтрованные по наличию буквы «h» в name");
            Console.WriteLine("ID || Имя || Фамилия");
            foreach (var item in helper.getEmployeeFiltered())
            {
                Console.WriteLine($"{item.id} || {item.name} || {item.surname}");
            }
            Console.WriteLine("------------------------------------------------------");

            Console.WriteLine("3. Выборка данных из таблицы Rent, сгрупированых по номеру арендованной комнаты и вывод количество раз аренды комнаты");
            Console.WriteLine("Номер комнаты || Количество");
            foreach (var item in helper.getRentGroupByRoom())
            {
                Console.WriteLine($"{item.name} || {item.count}");
            }
            Console.WriteLine("------------------------------------------------------");

            Console.WriteLine("4. Выборка данных из таблицы Rent, с выводом данных о компании");
            Console.WriteLine("ID || Номер комнаты || Имя организации || Email организации || Дата въезда || Дата выезда");
            foreach (var item in helper.getRentWithOrg())
            {
                Console.WriteLine($"{item.id} || {item.room.numOfRoom} || {item.organization.name} || {item.organization.email} || {item.entryDate.ToShortDateString()} || {item.exitDate.ToShortDateString()}");
            }
            Console.WriteLine("------------------------------------------------------");

            Console.WriteLine("5. Выборка данных из таблицы Rent, с выводом данных о компании содержащая букву h в email");
            Console.WriteLine("ID || Номер комнаты || Имя организации || Email организации || Дата въезда || Дата выезда");
            foreach (var item in helper.getRentWithOrgFiltered())
            {
                Console.WriteLine($"{item.id} || {item.room.numOfRoom} || {item.organization.name} || {item.organization.email} || {item.entryDate.ToShortDateString()} || {item.exitDate.ToShortDateString()}");
            }
            Console.WriteLine("------------------------------------------------------");

            Console.WriteLine("6. Добавление сотрудника в таблицу Employee");
            var emp = helper.addEmployee("Valeria", "Bortnovskaya");
            Console.WriteLine("Сотрудник успешно добавлен!");
            Console.WriteLine($"ID: {emp.Result.id}");
            Console.WriteLine($"Имя: {emp.Result.name}");
            Console.WriteLine($"Фамилия: {emp.Result.surname}");
            Console.WriteLine("------------------------------------------------------");

            Console.WriteLine("7. Добавление записи в таблицу Rent");
            var rent = helper.addRent();
            Console.WriteLine("Запись успешно добавлена!");
            Console.WriteLine($"ID: {rent.Result.id}");
            Console.WriteLine($"RoomID: {rent.Result.roomID}");
            Console.WriteLine($"OrganizationID: {rent.Result.organizationID}");
            Console.WriteLine($"Дата въезда: {rent.Result.entryDate.ToShortDateString()}");
            Console.WriteLine($"Дата выезда: {rent.Result.exitDate.ToShortDateString()}");
            Console.WriteLine("------------------------------------------------------");

            Console.WriteLine($"8. Удаление сотрудника из таблицы Employee с id = {emp.Result.id}");
            var delemp = helper.deleteEmployee(emp.Result.id);
            Console.WriteLine("Сотрудник успешно удалён!");
            Console.WriteLine($"ID: {delemp.Result.id}");
            Console.WriteLine($"Имя: {delemp.Result.name}");
            Console.WriteLine($"Фамилия: {delemp.Result.surname}");
            Console.WriteLine("------------------------------------------------------");

            Console.WriteLine($"9. Удаление записи из таблицы Rent с id = {rent.Result.id}");
            var delrent = helper.deleteRent(rent.Result.id);
            Console.WriteLine("Запись успешно удалена!");
            Console.WriteLine($"ID: {rent.Result.id}");
            Console.WriteLine($"RoomID: {rent.Result.roomID}");
            Console.WriteLine($"OrganizationID: {rent.Result.organizationID}");
            Console.WriteLine($"Дата въезда: {rent.Result.entryDate.ToShortDateString()}");
            Console.WriteLine($"Дата выезда: {rent.Result.exitDate.ToShortDateString()}");
            Console.WriteLine("------------------------------------------------------");

            Console.WriteLine($"10. Изменение всех email из таблицы Organization, где присутствует буква h на H");
            Console.WriteLine("ID || Название || Email");
            foreach (var item in helper.updateAll().Result)
            {
                Console.WriteLine($"{item.id} || {item.name} || {item.email}");
            }
            Console.WriteLine("------------------------------------------------------");
        }
    }
}