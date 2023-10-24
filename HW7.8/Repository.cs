using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static HW7._8.Worker;

namespace HW7._8
{
	class Repository
	{
		public Worker[] GetAllWorkers()
		{
			Console.Clear();
			{
				string[] ListWorker = File.ReadAllLines("ListWorker.txt");
				Worker[] workers = new Worker[ListWorker.Length];

				for (int i = 0; i < ListWorker.Length; i++)
				{
					string[] workerData = ListWorker[i].Split('#');
					Worker worker = new Worker();
					{
						worker.IdWorker = int.Parse(workerData[0]);
						worker.DateTimeRecord = DateTime.Parse(workerData[1]);
						worker.FullName = workerData[2];
						worker.AgeWorker = ushort.Parse(workerData[3]);
						worker.HeightWorker = byte.Parse(workerData[4]);
						worker.BirthDay = DateTime.Parse(workerData[5]);
						worker.PlaceBirth = workerData[6];
					};
					workers[i] = worker;
					Console.WriteLine($"{worker.IdWorker}| {worker.DateTimeRecord}| {worker.FullName}| {worker.AgeWorker}| {worker.HeightWorker}| {worker.BirthDay.ToShortDateString()}|" +
						$" {worker.PlaceBirth}");
				}

				return workers;
			}

		}

		public Worker GetWorkerById(int Id)
		{
			Worker[] workers = GetAllWorkers();
			Console.Clear();
			foreach (var worker in workers)
			{
				if (Id == worker.IdWorker)
				{
					Console.WriteLine($"{worker.IdWorker}| {worker.DateTimeRecord}| {worker.FullName}| {worker.AgeWorker}| {worker.HeightWorker}| {worker.BirthDay.ToShortDateString()}|" +
					$" {worker.PlaceBirth}");
					return worker;
				}

			}
			Console.WriteLine("Записей не найдено");
			return default(Worker);

			// происходит чтение из файла, возвращается Worker
			// с запрашиваемым ID
		}

		public void DeleteWorker(int id)
		{
			Worker workerToDelete = GetWorkerById(id);
			Console.Clear();
			if (workerToDelete.Equals(default(Worker)))
			{
				Console.WriteLine("Сотрудников с данным id не найдено");
			}

			else
			{
				string[] ListWorker = File.ReadAllLines("ListWorker.txt");

				string[] updateListWorker = new string[ListWorker.Length - 1];

				for (int i = 0, j = 0; i < ListWorker.Length; i++)
				{
					if (i + 1 != id)
					{
						string[] workerData = ListWorker[i].Split('#');
						workerData[0] = (j+1).ToString();
						updateListWorker[j] = string.Join("#", workerData);
						j++;
					}
				}
				ListWorker = updateListWorker;

				File.WriteAllLines("ListWorker.txt", updateListWorker);
			}
			// считывается файл, находится нужный Worker
			// происходит запись в файл всех Worker,
			// кроме удаляемого
		}

		public void AddWorker(Worker worker)
		{
			Console.Clear();
			worker.IdWorker = File.ReadAllLines("ListWorker.txt").Length + 1;
			worker.DateTimeRecord = DateTime.Now;
			Console.WriteLine();
			Console.Clear();

			using (StreamWriter WriteTxt = new StreamWriter("ListWorker.txt", true))
			{
				Console.WriteLine("Введите ФИО сотрудника");
				worker.FullName = Console.ReadLine();

				Console.WriteLine("Введите возраст");
				worker.AgeWorker = Convert.ToUInt16(Console.ReadLine());

				Console.WriteLine("Введите рост");
				worker.HeightWorker = Convert.ToByte(Console.ReadLine());

				Console.WriteLine("Введите дату рождения");
				worker.BirthDay = Convert.ToDateTime(Console.ReadLine());

				Console.WriteLine("Введите место рождения");
				worker.PlaceBirth = Console.ReadLine();

				WriteTxt.WriteLine($"{worker.IdWorker}#{worker.DateTimeRecord.ToString("g")}#{worker.FullName}#{worker.AgeWorker}#{worker.HeightWorker}#{worker.BirthDay.ToShortDateString()}#" +
					$"{worker.PlaceBirth}");
				WriteTxt.Flush();
			}
			// присваиваем worker уникальный ID,
			// дописываем нового worker в файл
		}

		public Worker[] GetWorkersBetweenTwoDates(DateTime dateFrom, DateTime dateTo)
		{
			string[] workerList = File.ReadAllLines("ListWorker.txt");
			int count = 0;
			int index = 0;

			for (int i = 0; i < workerList.Length; i++)
			{
				string[] workerData = workerList[i].Split('#');
				DateTime recordDate = DateTime.Parse(workerData[1]);
				if (recordDate>=dateFrom && recordDate<= dateTo)
				{
					count++;
				}
			}

			if (count == 0)
			{
				Console.WriteLine("\nЗаписей не найдено\n");
			}

			Worker[] workersDates = new Worker[count];
			for (int i = 0; i < workerList.Length; i++)
			{
				string[] workersDate = workerList[i].Split('#');
				int idWorker = Int32.Parse(workersDate[0]);
				DateTime dateRecord = DateTime.Parse(workersDate[1]);
				string fullName = workersDate[2];
				ushort ageWorker = UInt16.Parse(workersDate[3]);
				byte heightWorker = Byte.Parse(workersDate[4]);
				DateTime birthDay = DateTime.Parse(workersDate[5]);
				string placeBirth = workersDate[6];


				if (dateRecord>=dateFrom && dateRecord<= dateTo)
				{
					workersDates[index++] = new Worker(idWorker, dateRecord, fullName, ageWorker, heightWorker, birthDay, placeBirth);
				}
			}

			foreach (Worker worker in workersDates)
			{
				Console.WriteLine($"{worker.IdWorker} {worker.DateTimeRecord} {worker.FullName} {worker.AgeWorker} {worker.HeightWorker} {worker.BirthDay.ToShortTimeString()} {worker.PlaceBirth}");
			}
			return workersDates;

			// здесь происходит чтение из файла
			// фильтрация нужных записей
			// и возврат массива считанных экземпляров
		}
	}
}
